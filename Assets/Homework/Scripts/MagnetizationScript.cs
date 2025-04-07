using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetizationScript : MonoBehaviour
{
    [SerializeField] private float _magnetizationForce;

    private bool _isMagnitized = false;
    private bool _isPotion;

    private Transform _transformWhichNeedMagnitize;

    private float TakeDistance = 1f;

    private void Awake()
    {
        _isPotion = GetComponent<Potion>();
    }

    private void Update()
    {
        if (_isMagnitized && _isPotion)
            Magnetize();
        else
            Demagnitize();
    }


    private void OnTriggerEnter(Collider other)
    {
        Character character = other.GetComponent<Character>();
        Backpack backpack = other.GetComponent<Backpack>();

        if (character != null && backpack.Potion == null)
        {
            _isMagnitized = true;
            _transformWhichNeedMagnitize = character.transform;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Character character = other.GetComponent<Character>();
        Backpack backpack = other.GetComponent<Backpack>();

        if(character != null && GetDirectionTo(character.transform.position).magnitude <= TakeDistance)
        {
            character.TakePotion(this.GetComponent<Potion>());
            Debug.Log("Take");
        }

        if(backpack.Potion != null)
        {
            _isMagnitized = false;
        }
        else
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
        }
    }

    private void Demagnitize()
    {
        _transformWhichNeedMagnitize = null;
    }

    private Vector3 GetDirectionTo(Vector3 to)
        => to - transform.position;
}
