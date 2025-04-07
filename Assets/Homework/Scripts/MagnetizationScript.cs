using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetizationScript : MonoBehaviour
{
    [SerializeField] private float _magnetizationForce;

    private bool _isMagnitized = false;

    private Transform _transformWhichNeedMagnitize;

    private void Update()
    {
        if (_isMagnitized)
            Magnetize();
        else
            Demagnitize();
    }


    private void OnTriggerEnter(Collider other)
    {
        Character character = other.GetComponent<Character>();
        //BackpackScript backpack = other.GetComponent<BackpackScript>();

        if (character != null /*&&/* backpack.Potion == null*/)
        {
            _isMagnitized = true;
            _transformWhichNeedMagnitize = character.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Character character = other.GetComponent<Character>();

        if (character != null)
        {
            _transformWhichNeedMagnitize = null;
            _isMagnitized = false;
        }
    }

    private void Magnetize()
    {
        if(_transformWhichNeedMagnitize != null)
        {
            Vector3 direction = GetDirectionTo(_transformWhichNeedMagnitize.position);
            Vector3 normalizedDirection = direction.normalized;
            gameObject.transform.Translate(normalizedDirection * _magnetizationForce * Time.deltaTime, Space.World);
            Debug.Log("Magnitize");
        }
        
    }

    private void Demagnitize()
    {
        if(gameObject.transform.parent != null)
        {
            gameObject.transform.SetParent(null);
        }
    }

    private Vector3 GetDirectionTo(Vector3 to)
        => to - transform.position;
}
