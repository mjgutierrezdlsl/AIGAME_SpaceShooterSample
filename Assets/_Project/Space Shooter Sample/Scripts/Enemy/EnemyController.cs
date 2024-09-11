using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rigidbody;
    [SerializeField] Bullet _bullet;
    [SerializeField] float _attackInterval;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Transform _spawnPoint;
    private Vector3 _directionToPlayer;
    private float _elapsedTime;

    private void Update()
    {
        _directionToPlayer = (_playerTransform.position - transform.position).normalized;
        transform.up = _directionToPlayer;

        ShootAtPlayer();
    }

    private void ShootAtPlayer()
    {

        if (_elapsedTime < _attackInterval)
        {
            _elapsedTime += Time.deltaTime;
        }
        else
        {
            var bullet = Instantiate(_bullet);

            var homingBullet = (HomingBullet)bullet;
            if (homingBullet != null)
            {
                homingBullet.Init(_playerTransform);
            }

            bullet.transform.position = _spawnPoint.position;
            bullet.transform.up = transform.up;
            // Move the bullet
            bullet.Body.AddForce(transform.up * bullet.MovementSpeed, ForceMode2D.Impulse);
            _elapsedTime = 0;
        }
    }
}
