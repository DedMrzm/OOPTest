using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPoint : MonoBehaviour
{
    private Vector3 _shootDirection;

    public Vector3 ShootDirection => _shootDirection;

    public void SetShootDirection(Vector3 direction)
        => _shootDirection = direction;
}
