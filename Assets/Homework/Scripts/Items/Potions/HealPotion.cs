using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.GridLayoutGroup;

public class HealPotion : Item
{
    [SerializeField] private int _healingPower;

    public override bool CanUse(GameObject owner)
    => owner.GetComponent<Health>() != null;

    public override void Use(GameObject owner)
    {
        Health ownerHealth = owner.GetComponent<Health>();

        if (ownerHealth != null)
        {
            ownerHealth.Value += _healingPower;
            Debug.Log("HEAL");
            Debug.Log($"Character HP = {ownerHealth.Value} ");
        }
        base.Use(owner);
    }
}
