using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUser : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;
    private KeyCode TakeCode = KeyCode.F;

    private void Update()
    {
        if (_inventory.HasSpace)
            return;

        if (Input.GetKeyDown(TakeCode))
        {
            Item item = _inventory.Get();
            item.Use(gameObject);
            Destroy(item.gameObject);
        }
    }
}
