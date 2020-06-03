using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3DS
{
    public class Dictionary
    {
        List<string>[] arr;
        public string this[string key]
        {
            get 
            {

                return null;
            }
            set
            {
                //exists and dont exist;
            }
        }
        private long Hash(long hash)
        {
            return hash %
        }
        private long PreHash(string str)
        {
            long hash = 5381;            
            foreach(var c in str)
                hash = ((hash << 5) + hash) + c; /* hash * 33 + c */
            return hash;
        }
        
    }
    
}
