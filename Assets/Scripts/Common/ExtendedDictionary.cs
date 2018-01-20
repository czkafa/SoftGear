using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Common
{
    public class ExtendedDictonary<Tkey, Tvalue> : Dictionary<Tkey, Tvalue>
    {
        public Dictionary<Tkey, Tvalue> Items = new Dictionary<Tkey, Tvalue>();
        public ExtendedDictonary() : base() { }
        ExtendedDictonary(int capacity) : base(capacity) { }

        public new Tvalue this[Tkey key]
        {
            get
            {
                return (Tvalue)base[key];
            }
            set
            {
                if (!base[key].Equals(value))
                {
                    base[key] = value;
                    OnUserInfoUpdated();
                }
            }
        }
        public delegate void OnDictionaryElementChangeHandler();
        public event OnDictionaryElementChangeHandler DictionaryUpdate;

        protected void OnUserInfoUpdated()
        {
            OnDictionaryElementChangeHandler handler = DictionaryUpdate;
            if (handler != null)
            {
                handler();
            }
        }
    }
}
