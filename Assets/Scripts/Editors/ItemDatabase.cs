using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Editors
{
    [CreateAssetMenu(menuName = "Database/Items", fileName = "Items")]
    public class ItemDatabase : ScriptableObject
    {
        [SerializeField, HideInInspector] private List<Item> itemsList;
        [SerializeField] private Item currentItem;
        public int Count => itemsList.Count;
        private int currentIndex = 0;

        public Item this[int index]
        {
            get
            {
                if (itemsList != null && index >= 0 && index < itemsList.Count)
                {
                    return itemsList[index];
                }
                return null;
            }
            set
            {
                if (itemsList == null)
                {
                    itemsList = new List<Item>();
                }
                if (index >= 0 && index < itemsList.Count && value != null)
                {
                    itemsList[index] = value;
                }
                else
                {
                    Debug.LogError("Выход за границы массива, либо переданное значение = null");
                }
            }
        }

        public Item GetNext()
        {
            currentIndex++;
            if (currentIndex >= itemsList.Count)
            {
                currentIndex = 0;
            }
            currentItem = this[currentIndex];
            return currentItem;
        }

        public Item GetPrev()
        {
            if (currentIndex > 0)
            {
                currentIndex--;
            }
            currentItem = this[currentIndex];
            return currentItem;
        }

        public Item GetRandom()
        {
            int random = Random.Range(0, itemsList.Count);
            return itemsList[random];
        }

        public void ClearDataBase()
        {
            itemsList.Clear();
            itemsList.Add(new Item());
            currentIndex = 0;
        }
        public void RemoveCurrentItem()
        {
            if (currentIndex > 0)
            {
                currentItem = itemsList[--currentIndex];
            }
            else
            {
                itemsList.Clear();
                currentItem = null;
            }
        }

        public void AddItem()
        {
            if (itemsList == null)
            {
                itemsList = new List<Item>();
            }
            currentItem = new Item();
            itemsList.Add(currentItem);
            currentIndex = itemsList.Count - 1;
        }


    }
    [Serializable]
    public class Item
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public int MinRadius { get; private set; } = 1;
        [field: SerializeField] public int MaxRadius { get; private set; }

    }

}
