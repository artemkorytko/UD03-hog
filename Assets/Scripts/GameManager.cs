using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Level[] allLevels;// ссылка на массив уровня  

    [SerializeField] private GameObject mainPanel;// ссылка гейм обджекту на маинПанел
    [SerializeField] private UIGamePanel gamePanel;// ссылка юайпанелу на геймПанел
    [SerializeField] private GameObject winPanel;// ссылка гейм обджекту на винПанел

    private int _currentLevelIndex;// локальная переменная 
    private Level _currentLevel;//ссылка на текущий экземпляр уровня

    private void Awake()// метод который запускается первее метода Старт
    {
        LoadData();//загружаем дату
        CreateLevel();//создаем уровень
        Initialize();//инициализируем
    }

    private void Initialize()//метод инициализации
    {
        mainPanel.SetActive(true);// включчение компонента
        gamePanel.gameObject.SetActive(false);// выключчение компонента
        winPanel.SetActive(false);// включчение компонента
    }

    private void CreateLevel()//метод создания обьекта на сцене
    {
        _currentLevel = InstantiateLevel(_currentLevelIndex);// писваиваем функционал создания обьектов
        _currentLevel.name = Random.Range(0, 100).ToString();//просто рандомное имя уровня, чтоб видеть в редакторе разницу
        _currentLevel.Initialize();//инициализируем новый уровень
    }

    private Level InstantiateLevel(int index)// метод проверки на создание уровня 
    {
        if (_currentLevel)// если текущий ур существует
        {
            Destroy(_currentLevel.gameObject);// уничтожаем игровой обьект текущего уровня
        }

        if (index >= allLevels.Length)//если индекс больше или равен длине всех наших уровней 
        {
            index %= allLevels.Length;// мы его
        }

        return Instantiate(allLevels[index]);// возвращаем созданный эл.
    }

    private void LoadData()// метод 
    {
        _currentLevelIndex = PlayerPrefs.GetInt("level_index", 0);// переменная (присваиваем из системы сохран.) получить индекс уровня 0, он же 1ый уровень,0 это дефолтное значение, если не было присвоено что либо другое
    }

    private void SaveData()// метод сохранения даты
    {
        PlayerPrefs.SetInt("level_index", _currentLevelIndex);//сохраняем номер последнего уровня что играли
    }

    public void StartGame()//медод описывающий когда происходит старт игры
    {
        mainPanel.SetActive(false);//выкл стартовое меню
        winPanel.SetActive(false);// выкл вин панел
        
        gamePanel.Initialize(_currentLevel);// расказываем о нашем уровне на котором он запускается
        gamePanel.gameObject.SetActive(true);//включаем геймпанел

        _currentLevel.OnCompleted += StopGame;// подписываемся на событие остановки игры
    }
    
    private void StopGame()//мотод описывающий когда ставим игру на стоп
    {
        _currentLevel.OnCompleted -= StopGame;// отписались 
        mainPanel.SetActive(false);// выкл маинпанел
        gamePanel.gameObject.SetActive(false);// выкл геймпанел
        winPanel.SetActive(true);// вкл винпанел

        _currentLevelIndex++;// прибавляем 1 в наш уровень
        SaveData();// сохр дату
    }
    
    public void StartNewGame()// метод старта игры
    {
        CreateLevel();// создать уровень
        StartGame();// начать игру
    }
}
