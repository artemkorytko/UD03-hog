using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Level[] allLevels;

    [SerializeField] private GameObject mainPanel;
    [SerializeField] private UiGamePanel gamePanel;
    [SerializeField] private GameObject winPanel;

    private int _currentLevelIndex;
    private Level _currentLevel;

    private void Awake()
    {
        LoadData();
        CreateLevel();
        Initialize();
    }

    private void Initialize()
    {
        _currentLevel.Initialize();
        
        mainPanel.SetActive(true);
        gamePanel.gameObject.SetActive(false);
        winPanel.SetActive(false);
    }

    private void CreateLevel()
    {
        _currentLevel = InstantiateLevel(_currentLevelIndex);
    }

    private Level InstantiateLevel(int index)
    {
        if (_currentLevel)
        {
            Destroy(_currentLevel.gameObject);
        }

        if (index >= allLevels.Length)
        {
            index %= allLevels.Length;
        }

        return Instantiate(allLevels[index]);
    }

    private void LoadData()
    {
        _currentLevelIndex = PlayerPrefs.GetInt("level_index", 0);
    }

    private void SaveData()
    {
        PlayerPrefs.SetInt("level_index", _currentLevelIndex);
    }

    public void StartGame()
    {
        mainPanel.SetActive(false);
        winPanel.SetActive(false);
        
        gamePanel.Initialize(_currentLevel);
        gamePanel.gameObject.SetActive(true);

        _currentLevel.OnCompleted += StopGame;
    }
    
    private void StopGame()
    {
        _currentLevel.OnCompleted -= StopGame;
        mainPanel.SetActive(false);
        gamePanel.gameObject.SetActive(false);
        winPanel.SetActive(true);

        _currentLevelIndex++;
        SaveData();
    }
    
    public void StartNewGame()
    {
        CreateLevel();
        _currentLevel.Initialize();
        StartGame();
    }
}