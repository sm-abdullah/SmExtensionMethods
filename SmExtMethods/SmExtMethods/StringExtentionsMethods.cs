using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using SmExtentionsMethods;
namespace SmExtentionsMethods
{
    public static partial class ExtentionsMethods
    {

        #region String Methods
        #region String Basic Type Converstion
        /// <summary>
        ///  it will Convert a string into int?
        ///  if Fails then return null
        /// </summary>
        /// <param name="IntStr">Int Convertable String</param>
        /// <returns>Int ? </returns>
        /// <example > int i = "23".toInt() ?? 0 </example>
        public static int? toInt(this string IntStr)
        {
            int? i = null;
            try
            {
                i = int.Parse(IntStr);
            }
            catch (Exception ex)
            {

                i = null;
            }


            return i;


        }

        /// <summary>
        ///  it will Convert a string into decimal?
        ///  if Fails then return null
        /// </summary>
        /// <param name="decimalStr">decimal Convertable String</param>
        /// <returns>decimal ? </returns>
        /// <example > decimal d = "23.2".toDecimal() ?? 0 </example>
        public static decimal? toDecimal(this string decimalStr)
        {
            decimal? i = null;
            try
            {
                i = decimal.Parse(decimalStr);
            }
            catch (Exception ex)
            {

                i = null;
            }

            return i;


        }

        /// <summary>
        ///  it will Convert a string into double?
        ///  if Fails then return null
        /// </summary>
        /// <param name="dobuleStr">Double Convertable String</param>
        /// <returns>double ? </returns>
        /// <example > double d = "23.2".toDouble() ?? 0.0; </example>
        public static double? toDouble(this string dobuleStr)
        {

            double? d = null;
            try
            {
                d = double.Parse(dobuleStr);
            }
            catch (Exception ex)
            {

                d = null;
            }
            return d;

        }

        /// <summary>
        ///  it will Convert a string into float?
        ///  if Fails then return null
        /// </summary>
        /// <param name="floatStr">float Convertable String</param>
        /// <returns> float? </returns>
        /// <example > float f = "23.2".toFloat() ?? 0.0; </example>
        public static float? toFloat(this string floatStr)
        {

            float? f = null;
            try
            {
                f = float.Parse(floatStr);
            }
            catch (Exception ex)
            {

                f = null;
            }
            return f;

        }

        /// <summary>
        ///  it will Convert a string into long?
        ///  if Fails then return null
        /// </summary>
        /// <param name="longStr">toLong Convertable String</param>
        /// <returns> long? </returns>
        /// <example > long l = "23".toLong() ?? 0; </example>
        public static long? toLong(this string longStr)
        {
            long? i = null;
            try
            {
                i = long.Parse(longStr);
            }
            catch (Exception ex)
            {

                i = null;
            }

            return i;

        }

        /// <summary>
        ///  it will Convert a string into short?
        ///  if Fails then return null
        /// </summary>
        /// <param name="shortStr">short Convertable String</param>
        /// <returns> short? </returns>
        /// <example > short s = "23".toShort() ?? 0; </example>
        public static short? toShort(this string shortStr)
        {
            short? i = null;
            try
            {
                i = short.Parse(shortStr);
            }
            catch (Exception ex)
            {
                i = null;
            }
            return i;


        }

        #endregion
        #region DateTime
        /// 
        /// it will Return null if unable to parse it
        /// 
        /// 
        /// 
        public static DateTime? toDateTime(this string str)
        {
            DateTime? i = null;
            try
            {
                i = DateTime.Parse(str);
            }
            catch (Exception ex)
            {

                i = null;
            }

            return i;
        }


        /// 
        /// It will Conver the String into the Given Format. Note : it will Return DateTime.MinValue Back if Unable to Convert due to Exceptions
        /// 
        /// 
        /// Date Pattern MM-dd-yyyy / dd-MM-yyyy
        /// It will return DateTime in a give Format
        public static string toDateFormat(this string str, string ShortDatePattern = "MMM-dd-yyyy")
        {
            DateTime date = DateTime.MinValue;
            if (DateTime.TryParse(str, out date))
            {

                return date.ToString(ShortDatePattern);

            }
            else
            {
                return null;
            }



        }
        #endregion




        public static string RegexReplace(this string input, string pattern, string replacement)
        {
            return Regex.Replace(input, pattern, replacement);
        }
        public static MatchCollection RegexMatches(this string input, string pattern, RegexOptions regexOptions = RegexOptions.IgnoreCase)
        {
            return Regex.Matches(input, pattern, regexOptions);
        }
        public static Match RegexMatch(this string input, string pattern, RegexOptions regexOptions = RegexOptions.IgnoreCase)
        {
            return Regex.Match(input, pattern, regexOptions);
        }
        public static string HtmlDataDecode(this string data)
        {
            return System.Net.WebUtility.HtmlDecode(data);
        }
        public static string HtmlDataEncode(this string data)
        {
            return System.Net.WebUtility.HtmlEncode(data);
        }

        public static string HtmlURLEncode(this string URL)
        {
            return System.Uri.EscapeUriString(URL);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sRelUrl">it is the Relative URL</param>
        /// <param name="sAbsUrl">It must be a Absolute URL i.e http://www.goog.com</param>
        /// <exception cref="System.UriFormatException">Absolute URL must be Valid URL</exception>
        /// <returns>It will Convert a Relative URL to the Absolute URL</returns>
        public static string MakeAbsUrlFrom(this string sRelUrl, string sAbsUrl)
        {

            Uri RelUrl = new Uri(sRelUrl, UriKind.RelativeOrAbsolute);
            if (RelUrl.IsAbsoluteUri)
            {
                return RelUrl.AbsoluteUri;
            }
            if (!Regex.IsMatch(sAbsUrl, "(?<protocol>http|https)://(?<domain>[\\w\\.]+)(?<path>/.*)?"))
            {
                sAbsUrl = "http://" + sAbsUrl;
            }

            Uri AbsUrl = new Uri(sAbsUrl);
            if (AbsUrl.IsAbsoluteUri)
            {
                sRelUrl = new Uri(AbsUrl, sRelUrl).AbsoluteUri;
            }



            return sRelUrl;
        }


        #region BoolReturnd Functions
        // Function to test for Positive Integers. 
        public static bool IsNaturalNumber(this String strNumber)
        {
            Regex objNotNaturalPattern = new Regex("[^0-9]");
            Regex objNaturalPattern = new Regex("0*[1-9][0-9]*");
            return !objNotNaturalPattern.IsMatch(strNumber) &&
            objNaturalPattern.IsMatch(strNumber);
        }
        // Function to test for Positive Integers with zero inclusive 
        public static bool IsWholeNumber(this String strNumber)
        {
            Regex objNotWholePattern = new Regex("[^0-9]");
            return !objNotWholePattern.IsMatch(strNumber);
        }
        // Function to Test for Integers both Positive & Negative 
        public static bool IsInteger(this String strNumber)
        {
            Regex objNotIntPattern = new Regex("[^0-9-]");
            Regex objIntPattern = new Regex("^-[0-9]+$|^[0-9]+$");
            return !objNotIntPattern.IsMatch(strNumber) && objIntPattern.IsMatch(strNumber);
        }
        // Function to Test for Positive Number both Integer & Real 
        public static bool IsPositiveNumber(this String strNumber)
        {
            Regex objNotPositivePattern = new Regex("[^0-9.]");
            Regex objPositivePattern = new Regex("^[.][0-9]+$|[0-9]*[.]*[0-9]+$");
            Regex objTwoDotPattern = new Regex("[0-9]*[.][0-9]*[.][0-9]*");
            return !objNotPositivePattern.IsMatch(strNumber) &&
            objPositivePattern.IsMatch(strNumber) &&
            !objTwoDotPattern.IsMatch(strNumber);
        }
        // Function to test whether the string is valid number or not
        public static bool IsNumber(this String strNumber)
        {
            Regex objNotNumberPattern = new Regex("[^0-9.-]");
            Regex objTwoDotPattern = new Regex("[0-9]*[.][0-9]*[.][0-9]*");
            Regex objTwoMinusPattern = new Regex("[0-9]*[-][0-9]*[-][0-9]*");
            String strValidRealPattern = "^([-]|[.]|[-.]|[0-9])[0-9]*[.]*[0-9]+$";
            String strValidIntegerPattern = "^([-]|[0-9])[0-9]*$";
            Regex objNumberPattern = new Regex("(" + strValidRealPattern + ")|(" + strValidIntegerPattern + ")");
            return !objNotNumberPattern.IsMatch(strNumber) &&
            !objTwoDotPattern.IsMatch(strNumber) &&
            !objTwoMinusPattern.IsMatch(strNumber) &&
            objNumberPattern.IsMatch(strNumber);
        }
        // Function To test for Alphabets. 
        public static bool IsAlpha(this String strToCheck)
        {
            Regex objAlphaPattern = new Regex("[^a-zA-Z]");
            return !objAlphaPattern.IsMatch(strToCheck);
        }
        // Function to Check for AlphaNumeric.
        public static bool IsAlphaNumeric(this String strToCheck)
        {
            Regex objAlphaNumericPattern = new Regex("[^a-zA-Z0-9]");
            return !objAlphaNumericPattern.IsMatch(strToCheck);
        }

        public static bool IsValidEmail(this string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
        #region String IO
        /// 
        /// It will Load a Text File From the Given path, return Empty String in case of Exceptions 
        /// 
        /// Loaded Text File
        /// Path of File to Load
        /// False in case of Exceptions
        public static bool LoadFromTextFile(this string textFile, string filePath)
        {
            try
            {
                StreamReader streamReader = new StreamReader(filePath);
                textFile = streamReader.ReadToEnd();
                streamReader.Close();
                return true;
            }
            catch (Exception ex)
            {
                textFile = "";
                return false;
            }
        }
        /// 
        /// Save this String As Text File
        /// 
        /// 
        /// 
        /// 
        /// 
        public static bool SaveAsTextFile(this string Text, string FileName, string FilePath, bool append = false)
        {
            bool IsFileSaved = false;
            try
            {
                System.IO.FileInfo file = new System.IO.FileInfo(FilePath);
                if (!Directory.Exists(FilePath))
                {
                    DirectoryInfo di = Directory.CreateDirectory(FilePath);
                }
                string path = System.IO.Path.Combine(FilePath, FileName);
                System.IO.StreamWriter Writer =
                   new System.IO.StreamWriter(path, append);
                Writer.Write(Text);
                Writer.Close();
                IsFileSaved = true;

            }
            catch
            {
                IsFileSaved = false;
            }
            return IsFileSaved;
        }



        #endregion
        #endregion




        /// 
        /// if An Exceptions Occurs or unable to parse then Null String will be returned
        /// 
        /// 
        /// 
        /// 
        public static string toDateFormat(this DateTime date, string ShortDatePattern = "MMM-dd-yyyy")
        {


            try
            {
                return date.ToString(ShortDatePattern);
            }
            catch (Exception ex)
            {
                return null;
            }




        }

        /// <summary>
        /// It will convert a string into T
        /// If Fails then Return Default Value
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="Str">String which will be converted into T</param>
        /// <param name="defaultValue">if Fails then return this</param>
        /// <returns>Return T</returns>
        public static T To<T>(this string Str, T defaultValue) where T : IConvertible
        {
            try
            {
                return (T)Convert.ChangeType(Str, typeof(T));
            }
            catch (Exception ex)
            {
                return defaultValue;
            }
        }

        #region Lists

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

        #endregion

        /// <summary>
        /// Remove the Consective muliple occurence of chars
        /// 
        /// </summary>
        /// <param name="Str"></param>
        /// <param name="Occure">the character which consectiviely occure's and required Once</param>
        /// <example>"1    2   3  4  5" can be turn into "1 2 3 4 5"
        ///            var out = "1    2   3  4  5".RemoveMultipleOccurence(' ');
        /// </example>

        public static string RemoveMultipleOccurence(this string Str, char Occure)
        {
            Regex regex = new Regex(string.Format(@"[{0}]", Occure) + "{2,}", RegexOptions.None);
            return regex.Replace(Str, Occure.ToString());
        }
        public static string RemoveMultipleOccurence(this string Str, string Occure)
        {
            Regex regex = new Regex(string.Format(@"[{0}]", Occure) + "{2,}", RegexOptions.None);
            return regex.Replace(Str, Occure.ToString());
        }

        /// <summary>
        /// Generates tree of items from item list
        /// </summary>
        /// 
        /// <typeparam name="T">Type of item in collection</typeparam>
        /// <typeparam name="K">Type of parent_id</typeparam>
        /// 
        /// <param name="collection">Collection of items</param>
        /// <param name="id_selector">Function extracting item's id</param>
        /// <param name="parent_id_selector">Function extracting item's parent_id</param>
        /// <param name="root_id">Root element id</param>
        /// 
        /// <returns>Tree of items</returns>
        public static IEnumerable<TreeItem<T>> GenerateTree<T, K>(
            this IEnumerable<T> collection,
            Func<T, K> id_selector,
            Func<T, K> parent_id_selector,
            K root_id = default(K))
        {
            foreach (var c in collection.Where(c => parent_id_selector(c).Equals(root_id)))
            {
                yield return new TreeItem<T>
                {
                    Item = c,
                    Children = collection.GenerateTree(id_selector, parent_id_selector, id_selector(c))
                };
            }
        }

    



    }

}
