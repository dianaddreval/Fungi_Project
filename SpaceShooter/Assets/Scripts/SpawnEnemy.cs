using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnEnemy : MonoBehaviour
{
  [SerializeField] private GameObject[] _enemyPrefab;
  private Transform _spawnPosition;
  [SerializeField] private Boundary _boundary;
  [SerializeField] private float _spawnInterval;
  private float _spawnTimer;
  
    void Update()
    {
        if (Time.time >= _spawnTimer)
        {
            _spawnTimer = Time.time + _spawnInterval;
            Instantiate(_enemyPrefab[Random.Range(0, _enemyPrefab.Length)], SpawnPosition(), Quaternion.identity);
        }
    }

    Vector3 SpawnPosition()
    {
        Vector3 position = new Vector3
        (
            Mathf.Clamp((float)Random.Range(-6, 6), _boundary.xMin, _boundary.xMax), 23.0f, 0.0f
        );
        return position;
    }
}
