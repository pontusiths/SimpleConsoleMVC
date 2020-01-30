using System;

namespace SimpleConsoleMVC
{
    internal class View
    {
        public Action NextMenu;
        public Func<string, bool> ValidInput;
        public Func<string, string, bool> ValidateLogin;
        public Action GoToMenu;
        public View()
        {
        }

        internal void DisplayMainMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the app.\n" +
                "Press any key to continue;"
                );
            Console.ReadKey(true);
            NextMenu();
        }

        internal void DisplayLoginScreen()
        {
            Console.Clear();
            Console.WriteLine("Type in your Username:");
            var username = Console.ReadLine();
            if (ValidInput(username) == false)
            {
                Console.WriteLine("Invalid Username, press any key to continue;");
                Console.ReadKey(true);
                DisplayLoginScreen();
                return;
            }

            Console.WriteLine("Type in your Password:");
            var password = Console.ReadLine();
            if (ValidateLogin(username, password) == false)
            {
                Console.WriteLine("Invalid Username or Password, press any key to continue;");
                Console.ReadKey(true);
                DisplayLoginScreen();
                return;
            }

            GoToMenu();
        }
    }
}