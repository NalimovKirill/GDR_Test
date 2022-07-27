using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;

    [SerializeField] private int _countOfEnemy;
    void Start()
    {
        for (int i = 0; i < _countOfEnemy; i++)
        {
            SpawnEnemy();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.childCount < _countOfEnemy)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        
        int spawnPointX = Random.Range(-8, 8);
        int spawnPointY = Random.Range(-4, 4);
        Vector2 spawnPosition = new Vector2(spawnPointX, spawnPointY);
        var enemy = Instantiate(_enemy, spawnPosition, Quaternion.identity);

        enemy.transform.parent = gameObject.transform;

    }
    
    
}
