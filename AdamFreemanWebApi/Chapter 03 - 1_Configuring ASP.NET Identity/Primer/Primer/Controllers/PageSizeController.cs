using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Diagnostics;
using System.Threading.Tasks;
using Primer.Infrastructure;
using System.Threading;

namespace Primer.Controllers
{
    public class PageSizeController : ApiController, ICustomController
    {
        private static string TargetUrl = "http://apress.com";

        /*
         http://localhost:38000/api/pagesize
             */
        //public long GetPageSize()
        //{
        //    WebClient wc = new WebClient();
        //    Stopwatch sw = Stopwatch.StartNew();
        //    byte[] apressData = wc.DownloadData(TargetUrl);
        //    Debug.WriteLine("Elapsed ms: {0}", sw.ElapsedMilliseconds);
        //    return apressData.LongLength;
        //}

        public async Task<long> GetPageSize(CancellationToken cToken)
        {
            WebClient wc = new WebClient();
            Stopwatch sw = Stopwatch.StartNew();
            List<long> results = new List<long>();
            for (int i = 0; i < 10; i++)
            {
                if (!cToken.IsCancellationRequested)
                {
                    try
                    {
                        Debug.WriteLine("Making Request: {0}", i);
                        byte[] apressData = await wc.DownloadDataTaskAsync(TargetUrl);
                        results.Add(apressData.LongLength);
                    }
                    catch (Exception ex)
                    {

                        throw;
                    }
                }
                else
                {
                    Debug.WriteLine("Cancelled");
                    return 0;
                }
            }
            Debug.WriteLine("Elapsed ms: {0}", sw.ElapsedMilliseconds);
            return (long)results.Average();
        }

        public Task PostUrl(string newUrl, CancellationToken cToken)
        {
            TargetUrl = newUrl;
            return Task.FromResult<object>(null);
        }
    }
}
