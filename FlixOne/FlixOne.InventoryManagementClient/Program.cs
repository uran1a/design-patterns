using System.Reflection;

namespace FlixOne.InventoryManagementClient
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Greeting();
            //GetCommand("?").RunCommand(out bool shouldQuit);
        }

        private static void Greeting()
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version.ToString();

            Console.WriteLine("*********************************************************************************************");
            Console.WriteLine("*                                                                                           *");
            Console.WriteLine("*               Добро пожаловать в FlixOne Систему Управления Инвентаризаций                *");
            Console.WriteLine($"*                                                                                v{version}   *");
            Console.WriteLine("*********************************************************************************************");
            Console.WriteLine("");
        }


    }
}
