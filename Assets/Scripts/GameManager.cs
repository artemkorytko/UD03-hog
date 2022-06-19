using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Level[] _allLevels;
    
    [SerializeField] private GameObject _mainPanel;
    [SerializeField] private UIGamePanel _gamePanel;
    [SerializeField] private GameObject _winPanel;

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
        _mainPanel.SetActive(true);
        _gamePanel.gameObject.SetActive(false);
        _winPanel.SetActive(false);
    }

    private void CreateLevel()
    {
       _currentLevel = InstantiateLevel(_currentLevelIndex);
       _currentLevel.Initialize();
    }

    private Level InstantiateLevel(int index)
    {
        if (_currentLevel)
        {
            Destroy(_currentLevel.gameObject);
        }

        if (index >= _allLevels.Length)
        {
            index %= _allLevels.Length;
        }

        return Instantiate(_allLevels[index]);
    }

    private void LoadData()
    {
        _currentLevelIndex = PlayerPrefs.GetInt("level_index", 0);
    }

    private void SaveData()
    {
        PlayerPrefs.SetInt("level_index",_currentLevelIndex);
    }

    public void StartGame()
    {
        _mainPanel.SetActive(false);
        _winPanel.SetActive(false);
        
        _gamePanel.Initialize(_currentLevel);
        _gamePanel.gameObject.SetActive(true);

        _currentLevel.OnCompleted += StopGame;
    }
    
    private void StopGame()
    {
        _currentLevel.OnCompleted -= StopGame;
        _mainPanel.SetActive(false);
        _gamePanel.gameObject.SetActive(false);
        _winPanel.SetActive(true);

        _currentLevelIndex++;
        SaveData();
    }
    
    public void StartNewGame()
    {
        CreateLevel();
        StartGame();
    }
}
