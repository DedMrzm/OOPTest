using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;

    private void OnTriggerEnter(Collider other)
    {
        if(_inventory.HasSpace == false)
            return;

        Item item = other.GetComponent<Item>();

        if(item != null)
        {
            _inventory.Take(item);
        }
    }
}
