using UnityEngine;

public class ForceMovementController : MovementController
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _rotationSpeed;

    protected override Vector2 HandleInputDirection()
    {
        return new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    protected override void Move(Vector2 direction, float deltaTime)
    {
        var thrust = transform.up * direction.y;
        _rigidbody.AddForce(deltaTime * Speed * thrust);
        _rigidbody.MoveRotation(_rigidbody.rotation - direction.x * _rotationSpeed * deltaTime);

        // Limit the speed of our ship
        if (_rigidbody.velocity.magnitude > _maxSpeed)
        {
            _rigidbody.velocity = _rigidbody.velocity.normalized * _maxSpeed;
        }

    }
    protected override void Update()
    {
        // base.Update();
        Direction = HandleInputDirection().normalized;
    }
    private void FixedUpdate()
    {
        Move(Direction, Time.fixedDeltaTime);
    }
}