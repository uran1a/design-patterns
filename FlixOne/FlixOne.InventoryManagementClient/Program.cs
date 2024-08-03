using System.Reflection;

namespace FlixOne.InventoryManagementClient
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Greeting();
            GetCommand("?").RunCommand(out bool shouldQuit);
        }

        private static void Greeting()
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version.ToString();

            Console.WriteLine("*********************************************************************************************");
            Console.WriteLine("*                                                                                           *");
            Console.WriteLine("*               Welcome to FlixOne Inventory Management System                              *");
            Console.WriteLine($"*                                                                                v{version}   *");
            Console.WriteLine("*********************************************************************************************");
            Console.WriteLine("");
        }


    }
}
