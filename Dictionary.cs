﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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

        public void ParseTxt(string fname)
        {
            Console.WriteLine("Parsing...");
            var lst=File.ReadAllLines("dict_processed.txt");
            StringBuilder sb = new StringBuilder();
            arr = new LinkedList<KeyValuePair<string, string>>[lst.Length];
            foreach (var line in lst)
            {              
                int i = 0;
                if (!String.IsNullOrEmpty(line))                    
                for (;line[i]!=';'; i++)
                    sb.Append(line[i]);
                this[sb.ToString()] = line.Substring(i + 1);
                sb.Clear();
            }
            Console.WriteLine("Done parsing");
        }
        public string this[string key]
        {
            get
            {
                var k = key.ToUpper();
                var i = StrHash(k, arr.Length);

                return arr[i].FirstOrDefault(x => x.Key == k).Value;
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
            var h = StrHash(key, Arr.Length);
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
        private long StrHash(string s,int length)
        {
            int hash = 0;
            for (int i = 0; i < s.Length; i++)
                hash = (31 * hash + s[i]) % length;
            return hash;
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
