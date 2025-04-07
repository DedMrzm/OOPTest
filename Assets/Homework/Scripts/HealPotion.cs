using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPotion : Potion
{
    [SerializeField] private int _healingPower;

    private Character character;
    public override void Use()
    {
        if (character = GetComponentInParent<Character>())
        {
            character.Health += _healingPower;
        }
        base.Use();
    }
}
