using UnityEngine;//подключение библиоткu 
using Random = UnityEngine.Random;//подключение библиотеки для использования рандомных значений

public class GameManager : MonoBehaviour//создание публичного класса, который будет контролировать создание, загрузку уровня,отображения панелей в игре, наследуемого базового класса Monobehavior
{
   [SerializeField] private Level[] allLevels;//создание приватного массива уровней,который будет виден в инспекторе unity

   [SerializeField] private GameObject mainPanel;//создание приватной панели старта,которая будет видна в инспекторе unity
   [SerializeField] private UIGamePanel gamePanel;//создание приватной UIпанели игры,которая будет видна в инспекторе unity
   [SerializeField] private GameObject winPanel;//создание приватной панели выйгрыша,которая будет видна в инспекторе unity

   private int _currentLevelIndex;//создание приватного целочисленного индекса текущего уровня
   private Level _currentLevel;// создание приватного имени публичного класса Level
   private void Awake()//создание метода, который будет загружать, создавать уровень, переключаться между игровыми панелями,перед методом Start
   {
      LoadData();//вызов метода индекса уровня
      CreateLevel();//вызова метода создания уровня
      Initialize();// вызов метода переключения панели
      
   }

   private void Initialize()//метод, который загружает стартовое меню игры
   {
      mainPanel.SetActive(true);//включает стартовое меню игры
      gamePanel.gameObject.SetActive(false);//отключает игровую панель
      winPanel.SetActive(false);//отключает панель выйгрыша уровня
   }

   private void CreateLevel()//метод создания уровня
   {
     _currentLevel =  InstantiateLevel(_currentLevelIndex);//присвоение класса Level текущий индекс уровня
     _currentLevel.name = Random.Range(0, 100).ToString();//присвоение текущему имени уровня рандомное значение от 0 до 100, с преобразование в строковый тип 
     _currentLevel.Initialize();//инициализация метода загрузки панели текущего уровня
   }

   private Level InstantiateLevel(int index)//создание индекса уровней
   {
      if (_currentLevel)//создание условия для создания уровня
      {
         Destroy(_currentLevel.gameObject);//удаление gameogject текущего уровня
      }

      if (index >= allLevels.Length)//если индекс >= длины массива всех уровней
      {
         index %= allLevels.Length;//берем остаток от деления индекса на длину массива всех уровней
      }

      return Instantiate(allLevels[index]);//возвращаем созданное згачения индекса уровня
   }
   private void LoadData()//метод,который загружает индекс уровня
   {
      _currentLevelIndex = PlayerPrefs.GetInt("level_index", 0);//присваиваем индекс уровня,который получает сохраненную информацию для его загрузки начиная с 0
   }

   private void SaveData()//метод,который сохраняет индекс уровня
   {
      PlayerPrefs.SetInt("level_index",_currentLevelIndex);//сохраняет информацию текущего индекса уровня
   }

   public void StartGame()//метод инициализации стартовой панели
   {
      winPanel.SetActive(false);//отключает панель выйгрыша
      mainPanel.SetActive(false);//отключает панель меню
      
      gamePanel.Initialize(_currentLevel);//инициализация текущего уровня
      gamePanel.gameObject.SetActive(true);//включает игровую сцену

      _currentLevel.OnCompleted += StopGame;//подписка к событию текущего уровня,при выполнении которого, сработает метод конец игры(выйгрыша)

   }
   
   private void StopGame()//метод, который завершает уровень
   {
      _currentLevel.OnCompleted -= StopGame;
      
      mainPanel.SetActive(false);//отключает стартовую панель меню
      gamePanel.gameObject.SetActive(false);//отключает игровое меню
      winPanel.SetActive(true);//включает меню выйгрыша уровня

      _currentLevelIndex++;//прибавляет индекс уровня на +1 для перехода к следующему уровню
      SaveData();//сохраняет информацию о уровне
   }
   
   public void StartNewGame()//метод для создания новой игры
   {
     CreateLevel();//инициализация метода создания уровня
     StartGame();//инициализация метода отображения игрового уровня
   }
}
