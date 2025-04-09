using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPotion : Potion
{
    [SerializeField] private int _healingPower;

    private Character _character;
    public override void Use()
    {
        _character = GetComponentInParent<Character>();
        if (_character != null)
        {
            _character.Health += _healingPower;
            Debug.Log("HEAL");
            Debug.Log($"Character HP = {_character.Health} ");
        }
        base.Use();
    }
}
