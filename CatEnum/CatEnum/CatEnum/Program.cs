using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CatEnum
{
    /// <summary>
    /// Purpose: Create a program that allows an user to select one product, 
    ///  then show the other products in the same category
    /// </summary>
    class Program
    {
        static void Main(String[] args)
        {
            Controller c = new Controller();            
            c.Run();
        }
    }
}
