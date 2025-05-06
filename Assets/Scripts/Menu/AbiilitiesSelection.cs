using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;

public class AbiilitiesSelection : MonoBehaviour
{
    [SerializeField] private List<Ability> _abilities;

    public void SelectActiveAbility(Ability ability)
    {
        foreach (var abil in _abilities)
        {
            abil.DeactivateAbility();
        }
        ability.SetAbilityActive();
    }

    public static bool IsAbilityActiveByIndex(int index)
    {
        if (PlayerPrefs.GetInt("Ability" + index) == 1)
            return true;

        return false;
    }

}
