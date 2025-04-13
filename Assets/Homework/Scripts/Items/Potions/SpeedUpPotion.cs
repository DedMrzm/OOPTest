using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class SpeedUpPotion : Item
{
    [SerializeField] private float _speedUpPower = 2;

    public override bool CanUse(GameObject owner)
        => owner.GetComponent<Speed>() != null;

    public override void Use(GameObject owner)
    {
        if (CanUse(owner))
        {
            Speed speed = owner.GetComponent<Speed>();
            speed.Value += _speedUpPower;

            Debug.Log("SPEEDUP");
            Debug.Log($"{owner.name} Speed: {speed.Value}");

            base.Use(owner);
        }
    }
}
