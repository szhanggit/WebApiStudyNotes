// See https://aka.ms/new-console-template for more information
using HttpClientConsole;

Console.WriteLine("Hello, World!");


CommonService _commonService = new CommonService();
await _commonService.ProcessRequest();