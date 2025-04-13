using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Speed))]
[RequireComponent(typeof(CharacterController))]
public class MovingHandler : MonoBehaviour
{
    private string HorizontalAxis = "Horizontal";
    private string VerticalAxis = "Vertical";

    private float StopZone = 0.05f;

    private float _xInput;
    private float _zInput;

    private CharacterController _characterController;

    private Speed _speed;

    public Vector3 LastDirection { get; private set; }

    private void Awake()
    {
        _speed = GetComponent<Speed>();
        _characterController = GetComponent<CharacterController>();
    }

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

        LastDirection = normalizedInput;

        HandleMoveTo(normalizedInput);
    }

    private void HandleMoveTo(Vector3 direction)
    {
        _characterController.Move(direction * _speed.Value * Time.deltaTime);
    }
}
