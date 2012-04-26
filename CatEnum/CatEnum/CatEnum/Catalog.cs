using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace CatEnum
{
    /// <summary>
    /// The "Model"
    /// </summary>
    public class Catalog
    {
        private String CatalogPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase.Replace("file:///", "")), "Catalog.txt");

        internal String[] ActiveCatalog = null;

        internal List<Item> LoadedCatalog = new List<Item>();

        internal List<String> LoadedHeaders = new List<String>();

        /// <summary>
        /// Ctor
        /// </summary>
        internal Catalog()
        {
            ActiveCatalog = File.ReadAllText(CatalogPath).Split('\n'); // <= cache it here: its a small file....
            loadCatalog(ActiveCatalog);
        }//END

        /// <summary>
        /// Loaded categories
        /// </summary>
        /// <returns></returns>
        internal List<String> Loaded_Categories
        {
            get{
                List<String> sb = new List<String>();
                    foreach (Item item in LoadedCatalog)
                    {
                        if(!sb.Contains(item.Category))
                            sb.Add(item.Category);
                    }
                    return sb;
                }
        }//END

        /// <summary>
        /// Return a delimited list of the Categories
        /// </summary>
        internal String Loaded_CategoriesAsString
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                if (Loaded_Categories != null)
                {
                    foreach (string cat in Loaded_Categories)
                    {
                        sb.AppendLine(cat.ToString().Trim() + '\t');
                    }
                }
                return sb.ToString();
            }
        }// END

        /// <summary>
        /// Load the Catalog List with Items
        /// </summary>
        /// <param name="theCatalog"></param>
        private void loadCatalog(String[] theCatalog)
        {
            var lines = (from line in theCatalog
                         select line).ToList();

            foreach (var line in lines)
            {
                if( (line.Length > 0) && (line.Substring(0, 1).Any(char.IsDigit) ) )
                {
                    String[] fields = line.Split('\t');
                    if (fields != null)
                        LoadedCatalog.Add(new Item(fields[0], fields[1], fields[2].TrimEnd('\r') ) );
                }
                else if(line.Contains("\tCategory"))
                {
                    String[] fields = line.Split('\t');
                    if (fields != null)
                    {
                        foreach (String field in fields)
                        {
                            LoadedHeaders.Add( field.TrimEnd('\r') ) ;
                        }
                    }
                        
                }
            }
        }//END

       
        /// <summary>
        /// Override for a simple Catalog dump
        /// </summary>
        /// <returns></returns>
        public override String ToString()
        {
            if (ActiveCatalog == null)
                return String.Empty;

            StringBuilder sb = new StringBuilder();
            foreach (String line in ActiveCatalog)
            {
                if((line.Length > 0) && (line.Substring(0, 1).Any(char.IsDigit) ))
                    sb.AppendLine(line);
            }
            return sb.ToString();
        }//END
    }
}
