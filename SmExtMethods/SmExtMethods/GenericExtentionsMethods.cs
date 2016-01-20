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


        /// <summary>
        /// it will create a Deep Clone of Given Object 
        /// </summary>
        /// <typeparam name="T">Type of Ojbect</typeparam>
        /// <param name="a"></param>
        /// <returns></returns>
        public static T DeepClone<T>(this T clone)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                //create a binary formatter
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, clone);
                //set the position at start
                stream.Position = 0;
                //Desearilze Object and Cast into T
                return (T)formatter.Deserialize(stream);
            }
        }


        /// <summary>
        /// it will sort the list by its orbitrary property name given as String
        /// so a user can sort a list at runtime by giving property name as string
        /// </summary>
        /// <typeparam name="T">Generic type of List</typeparam>
        /// <param name="list">list to Sort</param>
        /// <param name="isAscending">Direction</param>
        /// <param name="propertyName">Property Name</param>
        public static void SortListBy<T>(this List<T> list, string propertyName ,bool isAscending=true) where T : IComparable
        {
            var propertyInfo = typeof(T).GetProperty(propertyName);
            Comparison<T> ascending = (t1, t2) => ((IComparable)propertyInfo.GetValue(t1, null)).CompareTo(propertyInfo.GetValue(t2, null));
            Comparison<T> descending = (t1, t2) => ((IComparable)propertyInfo.GetValue(t2, null)).CompareTo(propertyInfo.GetValue(t1, null));
            list.Sort(isAscending ? ascending : descending);
        }



        /// <summary>
        /// It will First Split Str on with seprator and generate a list<string>
        /// after this will try to convert List<string> into List<T>
        /// if Convertion fails then return the default value for that item
        /// </summary>
        /// <typeparam name="T">Type</typeparam>kl
        /// <param name="Str">String</param>
        /// <param name="Seprator">Seprator to split the String</param>
        /// <param name="defaultValue">set Default Value if conversion fails</param>
        /// <returns>return the List<T> holds converted values or default values</returns>
        public static List<T> ToList<T>(this string Str, char Seprator, T defaultValue) where T : IConvertible
        {

            List<string> lstStr = Str.Split(new char[] { Seprator }, StringSplitOptions.RemoveEmptyEntries).ToList();
            List<T> lst = new List<T>();

            lstStr.ForEach(s => lst.Add(s.To<T>(defaultValue)));
            return lst;
        }

        /// <summary>
        /// You have to Pas List it will check if an object contains or not
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool In<T>(this T source, params T[] list)
        {
            return list.Contains(source);
        }
       
      
    }
}
