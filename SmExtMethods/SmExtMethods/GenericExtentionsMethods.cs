using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SmExtentionsMethods
{
    public static partial class ExtentionsMethods
    {
         /// <summary>
        /// For Loop Just like foreach.
        /// First argument of Action is Object of T
        /// whlie 2nd argument is Index of Object in the List.
        /// Index starts from zero
        /// </summary>
        /// <typeparam name="T">Type of Generic List</typeparam>
        /// <param name="lst">List &amp; which needs to iterate</param>
        /// <param name="action">Takes two argument ,One is object of T and 2nd is Int Index of Object in the List</param>
        /// <exception cref="System.ArgumentNullException"> </exception>
        
        public static void For<T>(this List<T> lst, Action<T, int> action) 
        {
            for (int i = 0; i < lst.Count; i++)
            {
                action(lst[i], i);
                
            }
        }



        public static T DeepClone<T>(this T a)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, a);
                stream.Position = 0;
                return (T)formatter.Deserialize(stream);
            }
        }

        


       
      
    }
}
