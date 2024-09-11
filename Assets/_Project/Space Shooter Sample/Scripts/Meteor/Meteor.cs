using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    [SerializeField] SpriteRenderer _spriteRenderer;
    [SerializeField] float _health = 5f;

    public void Init(Sprite sprite)
    {
        _spriteRenderer.sprite = sprite;
    }

    public void TakeDamage(float damageAmount)
    {
        _health -= damageAmount;

        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
