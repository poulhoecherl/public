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
        }

        /// <summary>
        /// Execution wrapper
        /// </summary>
        public void Run()
        {
            // Display the Start Menu
            view.DisplayMainMenu(model);

            // Capture user input
            String input = Console.ReadLine();
            while (input.ToLower() != "q")
            {
                if (input.Length > 0) // sanity: must type something ...
                {
                    if (input.Substring(0, 1).Any(char.IsDigit)) // sanity: make sure the input is numeric
                    {
                        String category = GetCategoryForId(Int32.Parse(input.Substring(0, 1)));
                        view.DisplaySearch(category, SearchForCategoryItems(category));
                        view.DisplayMainMenu(model);
                    }
                    else if (input.ToLower() == "c") // list Categories
                    {
                        view.DisplayCategories(model.Loaded_CategoriesAsString);
                    }
                    else if (input.ToLower() == "m") // display Menu
                    {
                        view.DisplayMainMenu(model);
                    }
                    else // Error
                        Console.WriteLine("Enter a valid Numeric value, or 'q' to Quit.");

                    input = Console.ReadLine();
                }

            }

            view.DisplayQuit();
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
                throw new Exception(String.Format("No Category for ID {0}", Id));

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
