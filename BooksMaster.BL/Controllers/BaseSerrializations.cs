﻿using BooksMaster.BL.User;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace BooksMaster.BL.Controllers
{
    public class BaseSerrializations
    {
        public List<T> Load<T>() where T : class
        {
            var formatter = new BinaryFormatter();
            var fileName = typeof(T).Name;

            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && formatter.Deserialize(fs) is List<T> items)
                {
                    return items;
                }
                else
                {
                    return new List<T>();
                }
            }
        }
        
        public Pages Load() 
        {
            var formatter = new BinaryFormatter();
            var fileName = "allPages.dat";

            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && formatter.Deserialize(fs) is Pages items)
                {
                    return items;
                }
                else
                {
                    return new Pages();
                }
            }
        }

        public void Save<T>(List<T> item) where T : class
        {
            var formatter = new BinaryFormatter();
            var fileName = typeof(T).Name;

            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, item);
            }
        }
        
        public void Save<T>(Pages item) where T : class
        {
            var formatter = new BinaryFormatter();
            var fileName = "allPages.dat";

            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, item);
            }
        }
    }
}