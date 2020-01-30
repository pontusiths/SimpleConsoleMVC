using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleConsoleMVC
{
    internal class Controller
    {
        private Context model;
        private View view;
        private InfoMessageView welcomeView;
        private NavigationMenuView mainMenuView;
        private LoginView loginView;

        public Controller(View view, Context model)
        {
            this.view = view;
            this.model = model;

        }

        internal void Run()
        {
            GoToWelcomeScreen();
        }

        public void GoToWelcomeScreen()
        {
            if (welcomeView == null) welcomeView = new InfoMessageView
            {
                Message = "Welcome to this app",
                Callback = GoToMainMenu
            };
            welcomeView.Display();
        }

        private void GoToMainMenu()
        {
            if (mainMenuView == null) mainMenuView = new NavigationMenuView
            {
                Message = "MainMenu",
                MenuItems = new List<NavigationMenuItemView>
                {
                    new NavigationMenuItemView
                    {
                        Title = "Login",
                        GoTo = GoToLoginScreen
                    },
                    new NavigationMenuItemView
                    {
                        Title = "Exit Program",
                        GoTo = ()=>Environment.Exit(0)
                    }
                }
            };
            mainMenuView.Display();
        }

        private void GoToLoginScreen()
        {
            loginView = new LoginView{ ValidateLogin = ValidateLogin, LoginSuccessCallback = GoToProfile};
            loginView.Display();
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

        private void GoToProfile()
        {
            //init profile
            //profileView.Display()
        }
    }
}