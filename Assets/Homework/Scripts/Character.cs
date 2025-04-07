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

    [SerializeField] private float _speed;
    [SerializeField] private int _health;
    
    private void Awake()
    { 
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw(HorizontalAxis), 0, Input.GetAxisRaw(VerticalAxis));

        if (input.magnitude <= StopZone)
            return;

        Vector3 normalizedInput = input.normalized;

        HandleMoveTo(normalizedInput);
    }

    private void HandleMoveTo(Vector3 direction)
    {
        _characterController.Move(direction * _speed * Time.deltaTime);
    }
}
