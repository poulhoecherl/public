using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;

namespace CatEnum
{
    /// <summary>
    /// The "View"
    /// Notes: Rather than implement an Observer pattern here, I choose a simpler conventional View pattern
    ///  as this View just needs to know how to present a very few specifc View cases
    /// </summary>
    class View
    {
        /// <summary>
        /// Dump the Menu to the Console
        /// </summary>
        /// <param name="thisCatalog"></param>
        internal void DisplayMainMenu(Catalog thisCatalog)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***********************************");
            sb.AppendLine("Please select an Item by number");
            sb.AppendLine(" > Enter m to display Main Menu");
            sb.AppendLine(" > Enter c to display Categories"); 
            sb.AppendLine(" > Enter q to Quit");
            sb.AppendLine("***********************************");
            printC(sb.ToString(), ConsoleColor.White);
            sb.Clear();
            

            var lines = (from line in thisCatalog.ActiveCatalog
                         where (line.Length > 0) && (line.Substring(0, 1).Any(char.IsDigit))
                         select line).ToList();

            sb.AppendLine("-----------------------------------");
            sb.AppendLine(String.Format("{0} {1}   {2}", thisCatalog.LoadedHeaders[0], thisCatalog.LoadedHeaders[1], thisCatalog.LoadedHeaders[2])); //"Id      Product Name    Category"
            sb.AppendLine("-----------------------------------");
            sb.Append(thisCatalog.ToString()); 
            sb.Append("-----------------------------------");

            printC(sb.ToString(),ConsoleColor.Yellow);
        }//END

        /// <summary>
        /// Dump the Search results to the Console
        /// </summary>
        /// <param name="Category"></param>
        /// <param name="Results"></param>
        internal void DisplaySearch(String Category, String Results)
        {
            printC(String.Format(" > Products for Category: {0}", Category), ConsoleColor.White);
            printC("-----------------------------------", ConsoleColor.Green);
            printC(Results.Replace(Category,String.Empty), ConsoleColor.Green);
            printC("-----------------------------------", ConsoleColor.Green);
        }//END

        /// <summary>
        /// Dump the Search Categories to the Console
        /// </summary>
        /// <param name="categories"></param>
        internal void DisplayCategories(String categories)
        {
            printC(String.Format(" > Categories: "), ConsoleColor.White);
            printC("-----------------------------------", ConsoleColor.Green);
            printC(categories, ConsoleColor.Green);
            printC("-----------------------------------", ConsoleColor.Green);
        }//END

        /// <summary>
        /// Dump the Quit banner
        /// </summary>
        internal void DisplayQuit()
        {
            printC("  *** Thanks for playing! ***", ConsoleColor.Red);

            Thread.Sleep(1000);
        }//END

        /// <summary>
        /// Accessor for the Console
        /// </summary>
        /// <param name="thisMsg"></param>
        /// <param name="thisColor"></param>
        internal void PrintToConsole(string thisMsg, ConsoleColor thisColor)
        {
            printC(thisMsg, thisColor);
        }
        /// <summary>
        /// Console Write handler
        /// </summary>
        /// <param name="p"></param>
        private void printC(String thisMsg, ConsoleColor thisColor)
        {
            Console.ForegroundColor = thisColor;
            Console.WriteLine(thisMsg.TrimEnd('\n'));
            Console.ResetColor();
        }//END



        
    }
}
