using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _speed = 20;
    [SerializeField] private float _destroyTime = 2f;

    [SerializeField] public Vector3 _direction;

    public bool _isMoving = false;

    private void Update()
    {
        ProcessMove();
    }

    public void StartMovingBy(Vector3 direction)
    {
        _direction = direction;
        transform.rotation = Quaternion.LookRotation(direction);

        _isMoving = true;
    }

    private void ProcessMove()
    {
        if (_isMoving)
        {
            transform.Translate(_direction * _speed * Time.deltaTime, Space.World);
            Destroy(gameObject, _destroyTime);
        }
    }
}
