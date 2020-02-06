using System.Collections.Generic;

namespace SimpleConsoleMVC
{
    internal class Context
    {
        public Context()
        {
        }

        public List<User> Users { get; internal set; }
    }
}