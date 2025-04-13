using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.GridLayoutGroup;

public class ShootPotion : Item
{
    [SerializeField] private Projectile _projectilePrefab;

    public override bool CanUse(GameObject owner)
        => owner.GetComponent<ShootPoint>() != null;

    public override void Use(GameObject owner)
    {
        if(CanUse(owner))
        {
            ShootPoint shootPoint = owner.GetComponent<ShootPoint>();
            MovingHandler movingHandler = owner.GetComponent<MovingHandler>();

            shootPoint.SetShootDirection(movingHandler.LastDirection);

            Projectile projectile = Instantiate(_projectilePrefab, shootPoint.transform.position, Quaternion.identity);

            Debug.Log("Shoot");

            projectile.StartMovingBy(shootPoint.ShootDirection);
            base.Use(owner);
        }
    }

}
