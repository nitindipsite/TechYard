﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JunkYard
{
    class StoreData<T> : IEnumerable<T>
    {
        private LinkedList<T> list = new LinkedList<T>();

        public void Add(T item)
        {
            list.AddLast(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in list)
            {
                yield return item;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            foreach (T item in list)
            {
                yield return item;
            }
        }

        //public static void Main(string[] args)
        //{
        //    var datalist = new StoreData<int>();
        //    datalist.Add(1);
        //    datalist.Add(1);
        //    datalist.Add(1);
        //    datalist.Add(1);
        //    datalist.Add(1);

        //    foreach (var item in datalist)
        //    {

        //    }
        //}
    }


}
