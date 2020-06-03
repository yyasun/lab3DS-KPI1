using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;

namespace Lab3DS
{
    public class Dictionary
    {
        LinkedList<KeyValuePair<string, string>>[] arr;
        long count=0;
        long popSlotsCount=0;
        const int A = 5;
        const int startAmount = 8;
        public Dictionary()
        {
            arr = new LinkedList<KeyValuePair<string, string>>[startAmount];
        }
        public string this[string key]
        {
            get
            {
                var i = Hash(PreHash(key), arr.Length);

                return arr[i].FirstOrDefault(x => x.Key == key).Value;
            }
            set
            {
                count++;
                if (count > popSlotsCount * A)
                {
                    Rehash(arr.Length * 2);
                }
                Add(key, value, arr);
            }
        }
        public void Remove(string key)
        {
            count--;
            for (int i = 0; i < arr.Length; i++)
            {
                KeyValuePair<string, string> a= new KeyValuePair<string, string>();
                try
                {
                    a = arr[i].First(x => x.Key == key);                  
                }
                catch
                {
                }
                arr[i].Remove(a);
                break;
            }
            if (count < (popSlotsCount * A) / 4)
            {
                Rehash(arr.Length / 4);
            }

        }
        private void Add(string key, string value, LinkedList<KeyValuePair<string, string>>[] Arr)
        {
            var h = Hash(PreHash(key), Arr.Length);
            if (Arr[h] == null)
            {
                popSlotsCount++;
                Arr[h] = new LinkedList<KeyValuePair<string, string>>();
            }
            Arr[h].AddFirst(new KeyValuePair<string, string>(key, value));
        }
        private void Rehash(int newLen)
        {
            var tmpArr = new LinkedList<KeyValuePair<string, string>>[newLen];

            foreach (var lst in arr)
            {
                if(lst!=null)
                foreach (var kp in lst)
                {
                    Add(kp.Key, kp.Value, tmpArr);
                }
            }
            arr = tmpArr;
            Console.WriteLine("test");
        }
        private long Hash(long hash, int length)
        {
            return hash % length;
        }
        private long PreHash(string str)
        {
            long hash = 5381;
            foreach (var c in str)
                hash = ((hash << 5) + hash) + c; /* hash * 33 + c */
            return hash;
        }

    }

}
