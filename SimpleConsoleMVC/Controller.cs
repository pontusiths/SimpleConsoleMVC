using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleConsoleMVC
{
    internal class Controller
    {
        private Context model;
        private InfoMessageView welcomeView;
        private NavigationMenuView mainMenuView;
        private LoginView loginView;

        public Controller(Context model)
        {
            this.model = model;

        }

        internal void Run()
        {
            
            GoToWelcomeScreen();
        }

        private void GoToCalendarForm()
        {
            CalendarEvent calendarEvent = new CalendarEvent();
            var formView = new FormView();
            formView.formItems = new List<FormItem>
            {
                new FormItem
                {
                    Message = "Enter event name",
                    SetReference = (s) => calendarEvent.Name = s,
                },
                new FormEnumItem
                {
                    EnumType = typeof(WeekDay),
                    Message = "Select weekday",
                    SetReference = (s) => calendarEvent.Day = (WeekDay)int.Parse(s)
                },
                new FormItem
                {
                    Message = "Enter duration of event in minutes",
                    SetReference = (s) => calendarEvent.Minutes = int.Parse(s),
                }
            };
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