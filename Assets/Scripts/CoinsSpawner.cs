using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _coin;

    [SerializeField] private int _countOfCoins;

    private GameControlls _gameControlls;

    private void Awake()
    {
        _gameControlls = FindObjectOfType<GameControlls>();
    }
    void Start()
    {
        for (int i = 0; i < _countOfCoins; i++)
        {
            SpawnCoins();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_gameControlls.GameIsPaused == true)
        {
            if (gameObject.transform.childCount < _countOfCoins)
            {
                SpawnCoins();
            }
        }
    }

    private void SpawnCoins()
    {
        int spawnPointX = Random.Range(-8, 8);
        int spawnPointY = Random.Range(-4, 4);
        Vector2 spawnPosition = new Vector2(spawnPointX, spawnPointY);
        var coin = Instantiate(_coin, spawnPosition, Quaternion.identity);

        coin.transform.parent = gameObject.transform;

    }
}
