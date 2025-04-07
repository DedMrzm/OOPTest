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

    

    private Backpack _backpack;

    public int Health { get => _health; set => _health = value; }
    public float Speed { get => _speed; set => _speed = value; }

    private void Awake()
    { 
        _characterController = GetComponent<CharacterController>();
        _backpack = GetComponent<Backpack>();
    }

    // Update is called once per frame
    private void Update()
    {
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

        HandleMoveTo(normalizedInput);
    }

    private void HandleMoveTo(Vector3 direction)
    {
        _characterController.Move(direction * _speed * Time.deltaTime);
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
