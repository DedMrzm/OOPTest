using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpPotion : Potion
{
    [SerializeField] private float _speedUpPower = 2;

    private Character _character;
    public override void Use()
    {
        _character = GetComponent<Character>();

        _character.Speed += _speedUpPower;

        base.Use();
    }
}
