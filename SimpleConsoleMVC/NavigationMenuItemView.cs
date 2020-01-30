using System;

namespace SimpleConsoleMVC
{
    public class NavigationMenuItemView
    {
        public string Title { get; set; }
        public Action GoTo { get; set; }
    }
}