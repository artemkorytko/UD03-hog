using System;//подключение библиотеки
using System.Collections.Generic;//подключение библиотеки для использования событий,словаря
using UnityEngine;//подключение библиотеки

public class Level : MonoBehaviour//создание публичного класса уровня игры, наследуемого базового класса monobehaviour
{
   private GameItem[] _gameItems;//создание приватного массива игровых объектов
   private int _itemsCount;//создание приватного целочисленного значения количества объектов

   public event Action OnCompleted;//инициализация публичного события выполнения уровня
   public event Action<string> OnItemListChanged;//инициализация публичного события события строкового типа листа изменения 

      public void Initialize()//публичный метод инициализации дочерних игровых объектов в уровне
   {
      _gameItems = GetComponentsInChildren<GameItem>();//присвоение игровых объектов к дочерним компонентам массива

      for (int i = 0; i < _gameItems.Length; i++)//выполнение цикла для заполнения игровых объектов в уровне
      {
         _gameItems[i].OnFind += OnFindItem;//подписка на событие масива игровых объектов для поиска игровых объектов
      }

      _itemsCount = _gameItems.Length;//количество игровых объектов присваиваем к длине массива игровых объектов
   }

   private void OnFindItem(string name)//приватный метод найденных игровых объектов для отображения найденного объекта
   {
      _itemsCount--;//отнимаем количество объектов на -1
      
      if (_itemsCount > 0)//выполнение условия,если количество объектов больше 0,то
      {
         OnItemListChanged.Invoke(name);//вызов события изменения листа изменения объектов в игре,вызов метода с отображение имени
      }
      else//иначе
      {
         OnCompleted.Invoke();//вызов события выполненного уровня, вызов метода 
      }
   }

   public Dictionary<string, GameItemData> GetItemDictionary()//создание публичного словаря игровых объектов на уровне
   {
      Dictionary<string, GameItemData> itemsData = new Dictionary<string, GameItemData>();//инициализация словаря
      
      for (int i = 0; i < _gameItems.Length; i++)//выполнение цикла для перебора массива игровых объектов на уровне
      {
         string key = _gameItems[i].Name;//присвоение ключа к массиву мен игровых объектов
         if (itemsData.ContainsKey(key))//выолнение условия,если игровой объект содержит определенный ключ,то
         {
            itemsData[key].IncreaseAmount();//увеличиваем количество ключей на +1, используя метод увеличения числа
         }
         else//иначе
         {
            itemsData.Add(key,new GameItemData(_gameItems[i].Sprite));//добавление игровому объекту ключа и картинки
         }
      }
      
      return itemsData;//возвращает данные о игровом объекте
   }
}
