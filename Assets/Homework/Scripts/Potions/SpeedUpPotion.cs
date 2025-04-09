using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class SpeedUpPotion : Potion
{
    [SerializeField] private float _speedUpPower = 2;

    private Character _character;
    public override void Use()
    {
        _character = GetComponentInParent<Character>();
        if (_character != null)
        {
            _character.Speed += _speedUpPower;
            Debug.Log("SPEEDUP");
            Debug.Log($"Character Speed: {_character.Speed}");
        }
        base.Use();
    }
}
