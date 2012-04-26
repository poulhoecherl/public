using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using System.Threading;

namespace CatEnum
{
    /// <summary>
    /// The simplified "Controller" 
    /// </summary>
    class Controller
    {
       
        String[] catalogData = null;
        Catalog model = null;
        View view = null;

        /// <summary>
        /// Ctor
        /// </summary>
        public Controller()
        {
            model = new Catalog();
            catalogData = model.ActiveCatalog;
            view = new View();
        }//END

        /// <summary>
        /// Execution wrapper
        /// </summary>
        public void Run()
        {
            // Display the Start Menu
            view.DisplayMainMenu(model);

            // Capture user input
            int index = -1;
            String input = Console.ReadLine();
            while (input.ToLower() != "q")
            {
                if(Int32.TryParse(input.Trim(), out index) )
                {
                    
                    if ( checkInputRange(index) )
                    {
                        String category = GetCategoryForId(index);
                        view.DisplaySearch(category, SearchForCategoryItems(category)); // display search results
                        view.DisplayMainMenu(model); // dump the menu again for convenince
                    }
                    else
                        view.PrintToConsole("Enter a Numeric value between 1 and 7.", ConsoleColor.Red);
                }
                else if (input.ToLower() == "c") // list Categories
                {
                    view.DisplayCategories(model.Loaded_CategoriesAsString);
                }
                else if (input.ToLower() == "m") // display Menu
                {
                    view.DisplayMainMenu(model);
                }
                
                input = Console.ReadLine();
              }
            view.DisplayQuit();// Quit banner
        }//END

        /// <summary>
        /// Check the value is valid
        /// </summary>
        /// <param name="Start"></param>
        /// <param name="End"></param>
        /// <param name="TestVal"></param>
        /// <returns></returns>
        private bool checkInputRange(int TestVal)
        {
            // check value in range...
            bool ValueInRange = Enumerable.Range(1, 7).Contains(TestVal);
            // return value...
            return ValueInRange;
        }//END
      
        /// <summary>
        /// Get the Category for the ID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        private String GetCategoryForId(int Id)
        {
            var lines = (from line in catalogData
                         where line.StartsWith(Id.ToString())
                         select line).ToList();

            //"1\tRunning Shoe\tRunning\r"
            if (lines == null)
                view.PrintToConsole(String.Format("No Category for ID {0}", Id), ConsoleColor.Red);

            String[] tokens = lines[0].Split('\t');
            return tokens[tokens.Length - 1].TrimEnd('\n');
        }// END

        /// <summary>
        /// Search the Catalog for an item by Category
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        private String SearchForCategoryItems(String category)
        {
            
            var lines = (from line in catalogData
                         where line.Contains( category)
                         select line).ToList();


            return  Utils.Flatten(lines);

        }// END

        
    }
}
