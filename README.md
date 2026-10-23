# 2D Computer Platformer Game

[![C#](https://img.shields.io/badge/Language-C%23-239120.svg)](https://learn.microsoft.com/en-us/dotnet/csharp/)
[![Unity](https://img.shields.io/badge/Engine-Unity%206%20(6000.0.37f1)-000000.svg?logo=unity)](https://unity.com/)
[![URP](https://img.shields.io/badge/Render%20Pipeline-URP%202D-blue.svg)](https://unity.com/srp/universal-render-pipeline)
[![Input System](https://img.shields.io/badge/Input-Unity%20Input%20System-informational.svg)](https://docs.unity3d.com/Packages/com.unity.inputsystem@1.11/manual/index.html)
[![Platform](https://img.shields.io/badge/Platform-Windows%20(x64)-lightgrey.svg)](https://www.microsoft.com/windows)
[![IDE](https://img.shields.io/badge/IDE-Visual%20Studio%202022-purple.svg)](https://visualstudio.microsoft.com/)
[![Thesis](https://img.shields.io/badge/Bachelor%20Thesis-FRI%20UNIZA%20(2025)-orange.svg)](https://fri.uniza.sk)
[![Release](https://img.shields.io/badge/Release-v1.0.0-brightgreen.svg)](https://github.com/lubomirbojda/BC_2D/releases/tag/v1.0.0)

A 2D pixel-art action platformer built in **Unity 6 (`6000.0.37f1`)** and **C#**. Players choose between two distinct hero classes (**Warrior** for melee combat or **Wizard** for ranged spellcasting), traverse three multi-stage levels built with 2D Tilemaps, collect persistent coins to unlock character abilities, and battle a variety of passive, active, and multi-phase boss enemies.

This project was developed as a **Bachelor Thesis (`Bakalárska práca` – *2D počítačová platformová hra*)** at the Faculty of Management Science and Informatics, University of Žilina (**FRI UNIZA**, Department of Software Technologies, 2025).

---

## Table of Contents

- [Overview](#overview)
- [Key Features](#key-features)
- [Playable Characters & Combat Styles](#playable-characters--combat-styles)
- [Enemy AI Hierarchy & Boss Phases](#enemy-ai-hierarchy--boss-phases)
- [Architecture & Project Structure](#architecture--project-structure)
- [Download & How to Play (Release v1.0.0)](#download--how-to-play-release-v100)
- [Opening & Running from Source (Unity Editor)](#opening--running-from-source-unity-editor)
- [Controls & Gameplay](#controls--gameplay)
- [Documentation](#documentation)
- [Screenshots](#screenshots)

---

## Overview

The game guides the player from an interactive main menu—where they can customize their character class, purchase/equip upgrades, and configure audio settings—into three handcrafted 2D platforming levels (`Level1`, `Level2`, `Level3`). Each level culminates in an arena encounter where defeating the boss unlocks the exit doors (`Doors`) to complete the stage and bank collected coins.

```plaintext
Main Menu (Character / Ability / Level Select)  ──►  2D Platforming & Coin Collection  ──►  Boss Arena Fight  ──(Boss Defeated)──►  Exit Doors Open (Victory & Save Coins)
```

If the player takes contact or projectile damage from an enemy, 1 heart is deducted from the health bar (`HealtBar`) and a `1.5s` invincibility blinking coroutine (`InvincibilityCoroutine`) is triggered. Losing all hearts opens the defeat screen (`Defeat`), allowing instant level restart or return to the main menu.

---

## Key Features

- **Two Playable Character Classes:** Switch between melee (`Warrior`) and ranged (`Wizard`) playstyles in the Main Menu, dynamically instantiated at level start via `SpawnPlayer`.
- **Object-Oriented Enemy AI & Multi-Phase Bosses:** Clean inheritance hierarchy (`Enemy` &rarr; `PassiveEnemy` / `ActiveEnemy` &rarr; `BossEnemy`) combined with custom `StateMachineBehaviour` scripts (`BaseBossBehaviour`) driving multi-phase boss state machines inside Unity's `Animator`.
- **Persistent Coin Economy & Upgrades (`PlayerPrefs`):** Every coin placed in a level has a unique `_coinID`. Coins picked up during a run (`CoinManager`) are permanently saved upon level completion so they cannot be farmed repeatedly, and can be spent in the **Abilities** menu to unlock character upgrades (such as bonus maximum health).
- **Modern Unity Input System:** Event-driven player controls (`PlayerInputs.inputactions` & `PauseInput.inputactions`) decoupling physical keybindings from movement (`OnMove`), ground-checked jumping (`OnJump`), attacking (`OnAttack`), and pausing (`PauseGame`).
- **Custom 2D Physics Layer Collision Matrix:** Dedicated physics layers (`Ground`, `Player`, `Enemy`, `Attack`, `EnemyMovePoint`, `AttackEndPoint`, `EnemyHitbox`, `PlayerHitbox`) ensuring deterministic hitbox/hurtbox detection and patrol boundaries.
- **Smooth Damped Camera & Boss Arena Locking:** `CameraMovement` follows the player using `Vector3.SmoothDamp` within clamped level bounds and smoothly locks onto the boss arena when the player crosses the `CameraMaxZoneLock` trigger.

---

## Playable Characters & Combat Styles

Before starting a level, players can select their preferred hero in the **Character Selection** menu:

| Character | Combat Style | Base Damage | Attack Speed | Mechanics & Implementation |
| :--- | :--- | :---: | :---: | :--- |
| **Warrior** (`WarriorPrefab`) | **Melee** (`WarriorAttack`) | **2** | Fast | Activates a close-range `BoxCollider2D` child hitbox (`_attackHitbox`) synchronized with the sword slash animation frames (`Attack()` / `EndAttack()`). High damage, higher risk due to close-quarters proximity. |
| **Wizard** (`WizardPrefab`) | **Ranged** (`WizardAttack`) | **1** | Slower | Instantiates a magic projectile (`WizardBall`) at `_attackPosition` traveling horizontally in the player's facing direction (`_ballSpeed = 3f`). Destroys itself on impact with an `Enemy` or `AttackEndPoint` collider. Safer distance, lower damage per hit. |

---

## Enemy AI Hierarchy & Boss Phases

All enemies inherit from the base `Enemy` class, which manages health points (`Health`), damage intake (`TakeDamage()`), hit/death audio cues (`HitAudioClip`, `DeathAudioClip`), and `Attack` trigger collisions.

| Category | Classes | Behavior & AI Mechanics |
| :--- | :--- | :--- |
| **Passive Enemies** | `PassiveEnemy`, `PassiveMoveLR`, `PassiveMoveLRAttack` | Patrol horizontally between `EnemyMovePoint` triggers (`MoveLeftRight`). They do not react to player proximity; `PassiveMoveLRAttack` performs a timed melee attack animation at each patrol turnaround point. |
| **Active Enemies** | `ActiveEnemy`, `ShootingEnemy`, `StraightShootingEnemy`, `AimedShootingEnemy`, `Bird` | Equipped with an `ActiveZone` perimeter trigger. When the player enters the zone, enemies actively react—firing straight projectiles (`StraightShot`), calculating normalized trajectory vectors toward the player's position (`AimedShot`), or performing aerial bombing runs (`Bird`). |
| **Boss Enemies** | `BossEnemy`, `BaseBossBehaviour`, `BossLevel1OpenDoors`, `WalkBehaviourB2`, `FlyBehaviourB3` | **Level 1 Boss:** Aimed ranged guardian linked to `BossLevel1OpenDoors`.<br>**Level 2 Boss:** Chases and melee-attacks the player in Phase 1; transitions to ranged projectile attacks (`Shoot`) when health drops below `50%`.<br>**Level 3 Boss:** 3-phase encounter—melee pursuit in Phase 1 (`Phase1B3`), aerial waypoint flight (`_movePoint1` $\leftrightarrow$ `_movePoint2`) with ranged barrages in Phase 2 (`Phase2B3`), and doubled flight speed (`_moveSpeed * 2`) in Phase 3. Defeating a boss automatically triggers `_doors.OpenDoors()`. |

---

## Architecture & Project Structure

| Script / Class | Folder (`Assets/Scripts/...`) | Role in Application |
| :--- | :--- | :--- |
| **`MainMenu` & `SelectionCharacter`** | `Menu` | Controls main menu overlays (Level Select, Character Select, Abilities, Options, Controls, Reset) and initializes default `PlayerPrefs`. |
| **`Ability` & `AbiilitiesSelection`** | `Menu` | Handles purchasing upgrades with collected coins and toggling active player abilities (e.g., `+1` max health in `PlayerGetHit`). |
| **`SpawnPlayer`** | `Player` | Reads `SelectedCharacter` from `PlayerPrefs` on level `Awake()` and spawns either the Warrior (`PlayerDamage = 2`) or Wizard (`PlayerDamage = 1`). |
| **`PlayerMovement` & `PlayerJumpScript`** | `Player/Movement` | Processes `UnityEngine.InputSystem` callbacks (`OnMove`, `OnAttack`, `OnJump`), updates `Rigidbody2D.linearVelocity`, flips character sprites, and checks ground triggers (`Ground`). |
| **`PlayerAttack`, `WarriorAttack`, `WizardAttack`, `WizardBall`** | `Player/Attacks` | Polymorphic combat system handling melee hitbox activation and ranged projectile instantiation. |
| **`PlayerGetHit`, `HealtBar`, `Heart`** | `Player` / `Player/HealtBar` | Manages player health, `1.5s` post-hit invincibility blinking coroutine, and real-time heart UI rendering. |
| **`CoinManager` & `CoinScript`** | `Player/Coin` | Tracks coins collected during the current run and persists each coin's unique `_coinID` to `PlayerPrefs` upon victory. |
| **`CameraMovement` & `CameraMaxZoneLock`** | `Player/Camera` | Smoothly follows the player within level boundaries and locks camera position during boss fights. |
| **`Pause` & `Doors`** | `Player/Windows` / `Player` | Manages `Time.timeScale`, input blocking (`Pause.GameIsPaused`), level exit door animations, and Victory/Defeat UI windows. |
| **`AudioPlay`, `MusicPlay`, `VolumeSettings`** | `Sounds` | Centralized static audio clip playback (`PlayAudioClip`) and persistent master volume slider (`AudioListener.volume`). |

---

## Download & How to Play (Release v1.0.0)

You do **not** need Unity installed to play the game. A standalone pre-built Windows executable is available directly in the repository's GitHub Releases.

### Steps to Run the Standalone Build

1. Navigate to the **[Releases](https://github.com/lubomirbojda/2D-Platformer-Game/releases)** page of this repository and download the **`v1.0.0`** ZIP archive.
2. **Extract the entire ZIP archive** into a folder on your computer.
3. Make sure the extracted directory keeps all required Unity runtime files together:
   ```plaintext
   Build/
   ├── 2D PLATFORMER.exe
   ├── UnityPlayer.dll
   ├── UnityCrashHandler64.exe
   ├── 2D PLATFORMER_Data/
   ├── D3D12/
   └── MonoBleedingEdge/
   ```
4. Double-click **`2D PLATFORMER.exe`** to launch the game!

> [!IMPORTANT]
> Do not move `2D PLATFORMER.exe` out of the extracted folder on its own—Unity requires the `2D PLATFORMER_Data` and `MonoBleedingEdge` folders and `UnityPlayer.dll` to remain in the same directory as the executable.

---

## Opening & Running from Source (Unity Editor)

### Prerequisites

- **Operating System:** Windows 10 / 11 (64-bit)
- **Game Engine:** [Unity Hub](https://unity.com/download) with **Unity 6 (`6000.0.37f1`)** installed
- **IDE:** [Visual Studio 2022](https://visualstudio.microsoft.com/) with the *Game development with Unity* workload

### Steps

1. **Clone the repository:**
   ```bash
   git clone https://github.com/lubomirbojda/2D-Platformer-Game
   cd 2D-Platformer-Game
   ```

2. **Add the project to Unity Hub:**
   - Open **Unity Hub** &rarr; click **Add** &rarr; **Add project from disk** and select the cloned `BC_2D` folder.
   - Open the project using editor version **`6000.0.37f1`**.

3. **Open the Main Menu Scene & Play:**
   - In the **Project** window, navigate to `Assets/Scenes/MainMenu/` and double-click **`MainMenu.unity`**.
   - Press the **Play** button (`▶`) at the top of the Unity Editor.

---

## Controls & Gameplay

### In-Game Controls

| Action | Primary Key / Input | Alternative Key | Input System Action |
| :--- | :---: | :---: | :--- |
| **Move Left** | `A` | `Left Arrow` (`←`) | `Player/Move` |
| **Move Right** | `D` | `Right Arrow` (`→`) | `Player/Move` |
| **Jump** | `Spacebar` | — | `Player/Jump` |
| **Attack** (Melee / Ranged) | `Left Mouse Button` (`LMB`) | — | `Player/Attack` |
| **Pause / Resume Game** | `Escape` (`Esc`) | — | `Pause/New action` |

### Main Menu & Progression
- **Play (`Level Select`):** Choose from **Level 1**, **Level 2**, or **Level 3**.
- **Character Selection:** Switch between **Warrior** (melee, 2 DMG) and **Wizard** (ranged, 1 DMG).
- **Abilities:** Spend coins earned from completed levels to buy and toggle character upgrades (e.g., extra health heart).
- **Options & Controls:** Adjust master game volume (`VolumeSettings`) or view keybindings.
- **Reset:** Clears all saved progress (`PlayerPrefs.DeleteAll()`) including collected coins and unlocked abilities, restoring initial defaults.

---

## Documentation

This project is accompanied by a complete Bachelor Thesis detailing the comparison of 2D game engines (Godot, Unity, Unreal Engine), game mechanics & level design, UML diagrams (Use Case, State Machine, Class Inheritance), C# implementation details, and performance testing:

- **Bachelor Thesis:** *2D počítačová platformová hra* (*2D computer platformer game*)
- **Author:** Ľubomír Bojda
- **Supervisor:** Ing. Miroslav Gábor, PhD.
- **Institution:** University of Žilina, Faculty of Management Science and Informatics (FRI UNIZA), 2025

*[You can find whole Bachelor Thesis in format PDF here](https://opac.crzp.sk/?fn=detailBiblioForm&sid=D39A92077CB2E2E72941E1898013)*

---

## Screenshots

<!-- Sem môžeš pridať screenshoty z hry (stačí ich pretiahnuť do README editora na GitHube) -->
<p align="center">
  <img width="1919" height="1079" alt="image" src="https://github.com/user-attachments/assets/d749898b-97f1-418d-aacb-8efb02a1a9ae" />
  <img width="1919" height="1079" alt="image" src="https://github.com/user-attachments/assets/f95d4cad-035e-4961-92c6-8778ea7ee1c6" />
  <img width="1919" height="1079" alt="image" src="https://github.com/user-attachments/assets/456b54f0-71f3-4ff5-8ef8-6370743294c4" />
  <img width="1919" height="1079" alt="image" src="https://github.com/user-attachments/assets/e63bb553-84ff-468b-aa6f-24e466a22def" />

</p>
