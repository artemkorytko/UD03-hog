using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Level[] allLevels;// создаЄм массив левелов

    [SerializeField] private GameObject mainPanel;// создаЄм объект панели старта
    [SerializeField] private UIGamePanel gamePanel;//создаЄм объект панели игры
    [SerializeField] private GameObject winPanel;//создаЄм объект панели финиша левела
    int _currentLevelIndex;//не понимаю строку
    private Level _currentLevel;//не понимаю строку

    private void Awake()//метод вызываемый перед стартом
    {
        LoadData();//загружаем данные
        CreateLevel();//создаЄм левел
        Initialize();//инициализируем левел
    }

    private void LoadData()// создаЄм экземпл€р загрузки данных
    {
        _currentLevelIndex = PlayerPrefs.GetInt(key:"Level_index", defaultValue: 0);//загружаем наши сохранЄные данные в зависимости от нашего левела
    }

    private void SaveData()// создаЄм экземпл€р сохранени€ данных
    {
        PlayerPrefs.SetInt("level_index", _currentLevelIndex);//сохран€ем данные нашего левела
    }

    private void CreateLevel()//не совсем понимаю что мы в этом методе делаем
    {
        _currentLevel = InstantiateLevel(_currentLevelIndex);
        _currentLevel.name = Random.Range(0, 100).ToString();
        _currentLevel.Initialize();
    }

    private Level InstantiateLevel(int index)//тоже не совсем понимаю, если мы прошли предыдущий левел,то он убираетс€,если мы прошли не все левелы,то запускаетс€ новый
    {
        if (_currentLevel)
        {
            Destroy(_currentLevel.gameObject);
        }
        if(index >= allLevels.Length)
        {
            index %= allLevels.Length;
        }
        return Instantiate(allLevels[index]);
    }

    private void Initialize()//запускаем инициализацию
    {
        mainPanel.SetActive(true);//активируем панель старта, другие панели не задействуютс€
        gamePanel.gameObject.SetActive(false);
        winPanel.SetActive(false);
    }

    public void StartGame()//старт игры
    {
        mainPanel.SetActive(false);//запускаетс€ панель игры,другие панели не задействуютс€
        gamePanel.gameObject.SetActive(true);
        winPanel.SetActive(false);

        gamePanel.Initialize(_currentLevel);//инициализируем какой левел мы запускаем
        _currentLevel.OnCompleted += StopGame;//если прошли левел,то игра окончена
    }

    private void StopGame()//конец игры
    {
        _currentLevel.OnCompleted -= StopGame;//не понимаю эту строчку
        mainPanel.SetActive(false);//активируетс€ только панель винпанела,остальные панели не задействованы
        gamePanel.gameObject.SetActive(false);
        winPanel.SetActive(true);

        _currentLevelIndex++;//переходим на следующий уровень
        SaveData();//сохран€ем данные
    }
   public void StartNewGame()//старт новой игры
    {
        CreateLevel();//создание левела
        StartGame();//старт новой игры
        StartGame();//старт новой игры
    }
   

}
