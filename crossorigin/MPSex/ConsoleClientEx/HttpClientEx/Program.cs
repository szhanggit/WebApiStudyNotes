using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientEx
{
    class Program
    {
        static void Main(string[] args)
        {
            Dispatcher dp = new Dispatcher();
            //dp.Send();
            dp.SendAsyc();
            Console.WriteLine($"{DateTime.Now.ToLongTimeString()}: Receive Request");
            Console.ReadKey();
        }
    }
}
