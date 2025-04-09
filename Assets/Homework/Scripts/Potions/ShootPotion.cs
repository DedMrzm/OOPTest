using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPotion : Potion
{
    [SerializeField] private GameObject _projectilePrefab;

    private bool _isUse;

    private Character _character;

    public override void Use()
    {
        _character = GetComponentInParent<Character>();
        if(_character != null && _isUse == false)
        {
            _isUse = true;
          
            GameObject projectile = Instantiate(_projectilePrefab, _character.transform.position, Quaternion.identity);

            Debug.Log("Shoot");

            projectile.GetComponent<Projectile>().StartMovingBy(_character.ViewingDirection);
            base.Use();
        }
    }

}
