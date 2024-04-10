using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerEntity : BaseEntity
{
    [SerializeField] private float _speed = 5;
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Transform _shootPoint;


    private Rigidbody2D _rigidbody;
    private PlayerInputActions _playerInput;
    private Vector2 _inputVector;
    private Weapon _currentWeapon;

    private float _minLimitX = -3.45f;
    private float _maxLimitX = 3.45f;
    private float _maxLimitY = 6.4f;
    private float _minLimitY = -6.4f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerInput = new PlayerInputActions();
        _playerInput.Player.Enable();
        ChangeWeapon(_weapons[0]);
    }

    private void Update()
    {
        _inputVector = _playerInput.Player.Move.ReadValue<Vector2>();
        _currentWeapon.Shoot(_shootPoint);
    }

    private void FixedUpdate()
    {
        Move();
    }

    protected override void Death()
    {
        throw new System.NotImplementedException();
    }

    protected override void Move()
    {
        Vector2 moveVelocity = _inputVector * _speed * Time.fixedDeltaTime;
        _rigidbody.velocity = moveVelocity;

        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, _minLimitX, _maxLimitX);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, _minLimitY, _maxLimitY);
        transform.position = clampedPosition;
    }

    private void ChangeWeapon(Weapon weapon)
    {
        _currentWeapon = weapon;
    }

}
