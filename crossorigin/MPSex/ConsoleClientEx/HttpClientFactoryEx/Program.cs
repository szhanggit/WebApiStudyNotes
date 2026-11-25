using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientFactoryEx
{
    class Program
    {
        static void Main(string[] args)
        {
            Dispatcher dp = new Dispatcher();
            dp.Send();
            Console.WriteLine($"{DateTime.Now.ToLongTimeString()}: Receive Request");
            Console.ReadKey();
        }
    }
}
