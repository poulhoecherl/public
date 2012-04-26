CatEnum README
Author: Poul Hoecherl (poulhoecherl@gmail.com)
Purpose: Create a program that allows an user to select one product, then show the other products in the same category

Design Notes:
1. This project uses a *super simplified* MVC pattern, the class/file names are self-describing
  The intention is simply to separate concerns adn make it easy to review the code.

2. In the spirit of KISS, there is no sub-classing or templating of the Views, dynamic data binding or even much user input validation
   Obviously bad input is filtered, to keep the focus on the im-plementation of the core functionality, but theres a lot to break here!

3. In the interest of time (and stability) , parsing is just done using static String methods, Generics and Linq.
   In a production environment I may normally (at least) evaluate using a trusted third-party or FOSS library if extensive parsing is required. (Theres a ton of good ones out there)
   
