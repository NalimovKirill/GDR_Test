using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControlls : MonoBehaviour
{
    [SerializeField] private GameObject _playerPref;
    [SerializeField] private GameObject _coinSpawner;
    private int _countOfCoins;

    [SerializeField] private Button _playButton;
    [SerializeField] private Button _restartButton;

    [SerializeField] private Image _background;

    [SerializeField] private Text _coinScore;

    [SerializeField] private GameObject _winScreen;
    [SerializeField] private GameObject _loseScreen;
    private int _playerCoins = 0;

    public bool GameIsPaused = true;
    void Start()
    {
        Events.OnCoinCollected += AddPlayerScore;
        Events.OnPlayerWin += PlayerWin;
        Events.OnPlayerLose += PlayerLose;

        _winScreen.SetActive(false);
        _loseScreen.SetActive(false);

        _restartButton.gameObject.SetActive(false);
    }

    void Update()
    {
        if (GameIsPaused)
        {
            Time.timeScale = 0;
        }

        _countOfCoins = _coinSpawner.gameObject.transform.childCount;
        if (_countOfCoins <= 0)
        {
            Events.SendPlayerWin();
        }
    }

    private void AddPlayerScore()
    {
        _playerCoins++;
        _coinScore.text = "Монет :" + _playerCoins;
    }

    private void PlayerWin()
    {
        _winScreen.SetActive(true);
        _restartButton.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    private void PlayerLose()
    {
        Events.OnCoinCollected -= AddPlayerScore;
        Events.OnPlayerWin -= PlayerWin;
        Events.OnPlayerLose -= PlayerLose;

        _loseScreen.SetActive(true);
        _restartButton.gameObject.SetActive(true);

        Time.timeScale = 0;
    }

    public void OnPlayButtonClick()
    {
        Instantiate(_playerPref);

        GameIsPaused = false;

        Time.timeScale = 1;


        _playButton.gameObject.SetActive(false);
        _background.gameObject.SetActive(false);
    }
    public void onRestartButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

       // _coinScore = GameObject.Find("CoinScore").GetComponent<Text>();
        Time.timeScale = 1;
    }


}
