using System;

namespace SimpleConsoleMVC
{
    public class FormItem
    {
        public string Message { get; set; }
        public Action<string> SetReference { get; set; }
    }
}