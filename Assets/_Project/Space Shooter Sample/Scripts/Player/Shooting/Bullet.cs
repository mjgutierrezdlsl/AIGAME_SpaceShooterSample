using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] int damageAmount = 1;
    [SerializeField] private float _movementSpeed = 100f;
    public float MovementSpeed => _movementSpeed;
    [SerializeField] private Rigidbody2D _rigidbody;
    public Rigidbody2D Body => _rigidbody;
    [SerializeField] float lifetime = 3f;
    [SerializeField] ParticleSystem _bulletShards;
    private void Start()
    {
        // StartCoroutine(DestroyBullet());
    }
    private IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        print("Hit" + other.collider.name);
        if (other.rigidbody.CompareTag("Meteor"))
        {
            var meteor = other.rigidbody.GetComponent<Meteor>();
            meteor.TakeDamage(damageAmount);

            var shards = Instantiate(_bulletShards);
            shards.transform.position = transform.position;

            Destroy(gameObject);
        }
        if (other.rigidbody.CompareTag("Player"))
        {
            // TakeDamage
            Destroy(gameObject);
        }
    }
}
