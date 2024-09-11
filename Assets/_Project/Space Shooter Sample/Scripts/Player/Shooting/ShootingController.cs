using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoint;
    [SerializeField] Bullet bulletPrefab;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootBullet();
        }
    }
    private void ShootBullet()
    {
        for (int i = 0; i < spawnPoint.Length; i++)
        {
            // Instantiate the bullet
            var bullet = Instantiate(bulletPrefab);
            bullet.transform.position = spawnPoint[i].position;
            bullet.transform.up = transform.up;
            // Move the bullet
            bullet.Body.AddForce(transform.up * bullet.MovementSpeed, ForceMode2D.Impulse);
        }
    }
}
