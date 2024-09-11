using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovementController : MonoBehaviour
{
    [field: SerializeField] protected float Speed { get; set; }
    public Vector2 Direction { get; protected set; }
    private Vector2 _faceDirection;
    protected abstract Vector2 HandleInputDirection();
    protected abstract void Move(Vector2 direction, float deltaTime);
    protected virtual void Update()
    {
        Direction = HandleInputDirection().normalized;

        _faceDirection = Direction == Vector2.zero ? _faceDirection : Direction;
        transform.up = _faceDirection;
    }
}
