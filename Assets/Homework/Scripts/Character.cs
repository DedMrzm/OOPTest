using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private string HorizontalAxis = "Horizontal";
    private string VerticalAxis = "Vertical";

    private float StopZone = 0.05f;

    private float _xInput;
    private float _zInput;

    private CharacterController _characterController;

    public float Speed;
    public int Health;

    public Vector3 ViewingDirection { get; private set; }

    private Backpack _backpack;

    private void Awake()
    { 
        _characterController = GetComponent<CharacterController>();
        _backpack = GetComponent<Backpack>();
    }

    // Update is called once per frame
    private void Update()
    {
        //Debug.Log("Viewing Direction: " + ViewingDirection);
        HandleInput();
    }

    private void HandleInput()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw(HorizontalAxis), 0, Input.GetAxisRaw(VerticalAxis));

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (_backpack.Potion != null)
                _backpack.Potion.Use();
            else
                Debug.Log("В рюкзаке нет предметов");
        }
        if (input.magnitude <= StopZone)
            return;

        Vector3 normalizedInput = input.normalized;

        ViewingDirection = normalizedInput;

        HandleMoveTo(normalizedInput);
    }

    private void HandleMoveTo(Vector3 direction)
    {
        _characterController.Move(direction * Speed * Time.deltaTime);
    }

    public void TakePotion(Potion potion)
    {
        if (_backpack != null && _backpack.Potion == null)
        {
            _backpack.Potion = potion;
            potion.gameObject.transform.SetParent(transform, true);
            potion.transform.localPosition = Vector3.zero;

            potion.HideMyMesh();
        }
    }

}
