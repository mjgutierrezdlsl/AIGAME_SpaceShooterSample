using System.Collections.Generic;
using UnityEngine;

public class MeteorManager : MonoBehaviour
{
    [SerializeField] Sprite[] _meteorSprites;
    [SerializeField] int _spawnCount = 5;
    [SerializeField] float _spawnRadius = 5f;
    [SerializeField] Meteor _meteorPrefab;
    [SerializeField] Transform _meteorParent;
    private List<Meteor> _meteors = new();

    private void Start()
    {
        SpawnMeteors();
    }

    public void SpawnMeteors()
    {
        for (int i = 0; i < _spawnCount; i++)
        {
            var meteor = Instantiate(_meteorPrefab, _meteorParent);
            meteor.transform.SetPositionAndRotation
            (
                Random.insideUnitCircle * _spawnRadius,
                Quaternion.Euler(new(0, 0, Random.Range(0f, 360f)))
            );
            meteor.Init(_meteorSprites[Random.Range(0, _meteorSprites.Length)]);
            _meteors.Add(meteor);
        }
    }
}
