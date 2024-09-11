using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class HomingBullet : Bullet
{
    private Transform _playerTransform;
    private Vector2 _directionToPlayer;
    public void Init(Transform playerTransform)
    {
        _playerTransform = playerTransform;
    }
    private void Update()
    {
        _directionToPlayer = _playerTransform.position - transform.position;
        _directionToPlayer.Normalize();
        transform.up = _directionToPlayer;
    }
    private void FixedUpdate()
    {
        // Body.MovePosition(Vector2.MoveTowards(transform.position, _playerTransform.position, Time.fixedDeltaTime * MovementSpeed));
        Body.velocity = _directionToPlayer * MovementSpeed;
    }
}
