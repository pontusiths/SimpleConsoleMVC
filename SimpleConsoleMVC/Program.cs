using System;

namespace SimpleConsoleMVC
{
    class Program
    {
        static void Main(string[] args)
        {
            var model = new Context();
            //model.ConfigDatabase(blablabla);
            //model.Connect();
            var controller = new Controller(model);
            controller.Run();
        }
    }
}
