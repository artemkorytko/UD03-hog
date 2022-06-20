using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//подключенные библиотеки
public class GameManager : MonoBehaviour //объявляем класс GameManager, наследуем от MonoBehaviour. Скрипт решаем на пустой объект GameManager, отвечающий за логику
{
   [SerializeField] private Level[] allLevels; //объявляем приватный массив типа Level с именем allLevels
   
   [SerializeField] private GameObject mainPanel; //объявляем приватную переменную типа GameObject с именем mainPanel
   [SerializeField] private UIGamePanel gamePanel; //объявляем приватную переменную типа UIGamePanel с именем gamePanel
   [SerializeField] private GameObject winPanel; //объявляем приватную переменную типа GameObject с именем winPanel
   //serialize field - значит будет выделено поле, можно инициилизировать из конструктора (передать ссылку)

   private int _currentLevelIndex; //объявляем приватную переменную типа int с именем _currentLevelIndex
   private Level _currentLevel; //объявляем приватную переменную типа Level с именем _currentLevel
   private void Awake() //метод из класса MonoBehaviour, срабатывает 1 раз при инициилизации объекта на сцене, раньше чем Start
   {
      LoadData(); //запускаем наш метод LoadData для загрузки последнего уровня, на котором мы остановились
      CreateLevel(); //запускаем наш метод CreateLevel для создания уровня
      Initialize(); //запускаем наш метод Initialize для инициилизации (включим экран с кнопкой для старта игры, остальные экраны отключим)
   }

   private void Initialize() //объявляем наш метод Initialize. Приватный, ничего не возвращает.
   {
      _currentLevel.Initialize(); //инициилизируем текущий уровень. Вызываем метод из скрипта Level.cs
      
      mainPanel.SetActive(true); //задаем значение для параметра SetActive у игрового объекта true (включаем UI стартового экрана)
      winPanel.SetActive(false); //задаем значение для параметра SetActive у игрового объекта false (отключаем UI экрана победы)
      gamePanel.gameObject.SetActive(false); //задаем значение для параметра SetActive false у свойства gameObject нашего игрового UI (отключаем UI уровня)
   }
   

   private Level InstantiateLevel(int index) //объявляем наш метод для инициилизации уровня. Приватный, возвращает элемент массива Level с индексом index. На вход принимает int переменную index
   {
      if (_currentLevel) //если текущий левел существует (true)
      {
         Destroy(_currentLevel.gameObject); //то уничтожает текущий левел (чтобы создать новый)
      }

      if (index >= allLevels.Length) //если индекс (номер уровня, который хотим заинициилизировать) превышает длинну массива (выходит за рамки добавленых в массив уровней)
      {
         index %= allLevels.Length; //то производим целочисленное деление индекса на длинну массива и остаток целых единиц присваиваем в индекс, чтобы зациклить уровни по кругу
      }

      return Instantiate(allLevels[index]); //создаем уровень и возращаем его
   }

   private void CreateLevel() //объявляем наш метод для создания уровня. Приватный, ничего не возвращает
   {
     _currentLevel = InstantiateLevel(_currentLevelIndex); //присваиваем в переменную текущий уровень, полученный из метода для инициилизации уровня по входящему индексу
   }

   private void LoadData() //объявляем наш метод для загрузки (определения индекса уровня, который хотим заинициилизировать)
   {
      _currentLevelIndex = PlayerPrefs.GetInt("level_index", 0); //получаем индекс текущего уровня, который хотим инициилизировать. Метод GetInt класса PlayerPrefs позволит получить индекс int, который соответствует определенному ключу (level_index) 
   }
   
   private void SaveData() //объявляем наш метод для сохранения уровня. Приватный, ничего не возвращает.
   {
      PlayerPrefs.SetInt("level_index", _currentLevelIndex); //метод SetInt класса PlayerPrefs получит индекс текущего уровня и запишет его с ключем level_index, чтобы потом можно было получить по ключу его обратно в методе LoadData
   }

   public void StartGame() //объявляем наш метод для старта игры (уровня)
   {
      mainPanel.SetActive(false); //задаем значение для параметра SetActive у игрового объекта false (отключаем UI стартового экрана)
      winPanel.SetActive(false); //задаем значение для параметра SetActive у игрового объекта false (отключаем UI экрана победы)
      
      gamePanel.Initialize(_currentLevel); //инициилизируем, вызывая метод из скрипта UIGamePanel.cs
      gamePanel.gameObject.SetActive(true); //включаем UI на уровне

      _currentLevel.OnComplete += StopGame; //подписываем метод для остановки игры на ивент, отвечающий за прохождение уровня
   }
   
   private void StopGame() //объявляем наш метод для остановки игры. Приватный, ничего не возвращает
   {
      _currentLevel.OnComplete -= StopGame; //отписываемся от ивенты, отвечающего за проходения уровня
      mainPanel.SetActive(false); //выключаем UI панели старта
      winPanel.SetActive(true); //включаем UI панели победы после завершения уровня
      gamePanel.gameObject.SetActive(false); //отключаем наш UI уровня

      _currentLevelIndex++; //увеличиваем индек текущего уровня на 1
      SaveData(); //сохраняем уровень для последующей загрузки
   }
   
   public void StartNewGame() //объявляем наш метод для старта новой игры. Публичный, ничего не возвращает
   {
      CreateLevel(); //запускаем метод для создания уровня
      _currentLevel.Initialize(); //инициилизируем уровень, вызываем метод из скрипта Level.cs
      StartGame(); //запускаем метод для старта игры
   }
}
