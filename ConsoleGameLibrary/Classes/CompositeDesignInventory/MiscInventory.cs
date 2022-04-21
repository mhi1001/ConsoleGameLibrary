using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleGameLibrary.CompositeDesignInventory;

namespace ConsoleGameLibrary.Classes.CompositeDesignInventory
{
    public class MiscInventory : IMiscInventory, IEnumerable<IMiscInventory>
    {
        private List<IMiscInventory> _items = new List<IMiscInventory>();

        public string Name { get; set; }

        public void AddItem(IMiscInventory item)
        {
            _items.Add(item);
        }
        public IMiscInventory GetItem(IMiscInventory item)
        {
            return _items.Find(i => i.Name == item.Name);
        }
        public void RemoveItem(IMiscInventory item)
        {
            _items.Remove(item);
        }


        public IEnumerator<IMiscInventory> GetEnumerator()
        {
            foreach (IMiscInventory item in _items)
            {
                yield return item;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
