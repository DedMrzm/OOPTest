using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetizationScript : MonoBehaviour
{
    [SerializeField] private float _magnetizationForce;

    private bool _isMagnitized = false;

    private Transform _transformWhichNeedMagnitize;

    //ѕеределать вместо триггера на подсчЄт рассто€ни€ и при меньше чего-то прит€гиватьс€

    private void Update()
    {
        if (_isMagnitized)
            Magnetize();
        else
            Demagnitize();
    }


    private void OnTriggerStay(Collider other)
    {
        ItemCollector itemCollector = other.GetComponent<ItemCollector>();
        Inventory inventory = other.GetComponent<Inventory>();

        if(inventory.HasSpace == false && itemCollector != null)
        {
            _isMagnitized = false;
        }
        else
        {
            _isMagnitized = true;
            _transformWhichNeedMagnitize = inventory.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _isMagnitized = false;
    }

    private void Magnetize()
    {
        if(_transformWhichNeedMagnitize != null)
        {
            Vector3 direction = GetDirectionTo(_transformWhichNeedMagnitize.position);
            Vector3 normalizedDirection = direction.normalized;
            transform.parent.transform.Translate(normalizedDirection * _magnetizationForce * Time.deltaTime, Space.World);
        }
    }

    private void Demagnitize()
    {
        _transformWhichNeedMagnitize = null;
    }

    private Vector3 GetDirectionTo(Vector3 to)
        => to - transform.position;
}
