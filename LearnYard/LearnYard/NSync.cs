using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace IEnumerable
{
    class NSync
    {
        public async Task<int> AccessTheWebAsync()
        {
            HttpClient client = new HttpClient();

            Task<string> getWebStringTask = client.GetStringAsync("http://msdn.microsoft.com");
          
            DoIndependentWork();

            string urlContents = await getWebStringTask;
              
            return urlContents.Length;
        }

        private void DoIndependentWork()
        {
            Console.WriteLine("Working....");
        }

    }
}
