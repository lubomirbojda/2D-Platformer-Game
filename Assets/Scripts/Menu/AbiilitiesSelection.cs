using System.Collections.Generic;
using UnityEngine;

public class AbiilitiesSelection : MonoBehaviour
{
    [SerializeField] private List<Ability> _abilities;

    //Set sent ability as active one and disable other ones
    public void SelectActiveAbility(Ability ability)
    {
        foreach (var abil in _abilities)
        {
            abil.DeactivateAbility();
        }
        ability.SetAbilityActive();
    }

    //Return if ability is active by ability index
    public static bool IsAbilityActiveByIndex(int index)
    {
        if (PlayerPrefs.GetInt("Ability" + index) == 1)
            return true;

        return false;
    }

}
