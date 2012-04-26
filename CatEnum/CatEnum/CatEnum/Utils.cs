using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CatEnum
{
    class Utils
    {

        /// <summary>
        /// Flattens a List<String> into \n\r-delimited String or display purposes
        /// </summary>
        /// <param name="ListToFlatten"></param>
        /// <returns></returns>
        public static String Flatten(List<String> ListToFlatten)
        {
            if (ListToFlatten == null)
                return String.Empty;

            StringBuilder sb = new StringBuilder();
            foreach (String line in ListToFlatten)
            {
                sb.AppendLine(line);
            }
            return sb.ToString();
        }
    }
}
