using System;

namespace SimpleConsoleMVC
{
    class Program
    {
        static void Main(string[] args)
        {
            var model = new Context();
            var view = new View();
            var controller = new Controller(view, model);
            controller.Run();
        }
    }
}
