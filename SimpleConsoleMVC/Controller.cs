using System;
using System.Linq;

namespace SimpleConsoleMVC
{
    internal class Controller
    {
        private Context model;
        private View view;
        private object user;

        public Controller(View view, Context model)
        {
            this.view = view;
            this.model = model;

        }

        internal void Run()
        {
            GoToMainMenu();
        }

        public void GoToMainMenu()
        {
            view.NextMenu = GoToLoginScreen;
            view.DisplayMainMenu();
        }

        private void GoToLoginScreen()
        {
            view.ValidateLogin = ValidateLogin;
            view.ValidInput = (s) => true; //sätt en validate metod här om det behövs.
            view.GoToMenu = GoToMenu;
            view.DisplayLoginScreen();

        }

        private void GoToMenu()
        {
            //view.ChoiceA = GoToUserList;
            //view.ChoiceB = GoToProfile;
            //view.ChoiceC = GoTo...;
            //view.DisplayLoggedInMenu()

        }

        private bool ValidateLogin(string username, string password)
        {
            User user;
            try
            {
                user = model.Users.Single(u => u.username == username);
            }
            catch(Exception ex)
            {
                return false;
            }
            return (user.password == password);
        }
    }
}