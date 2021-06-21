using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }

    /// <summary>
    /// GameState
    /// 0: gameplay
    /// 1: pause
    /// 2: cutscene
    /// </summary>
    private int _gameState = 0;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;

        DontDestroyOnLoad(gameObject);
    }

    public void PlayGame()
    {
        _gameState = 0;
    }

    public void PauseGame()
    {
        _gameState = 1;
    }

    public void CusScene()
    {
        _gameState = 2;
    }

    public bool IsGamePlay()
    {
        return _gameState == 0;
    }
}
