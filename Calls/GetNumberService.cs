using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calls.HttpClient;
using Calls.HttpClient.SerializationService;

namespace Calls
{
    public class GetNumberService
    {
        public string GetNumber()
        {
            var url = "https://cdn.emnify.net/api/v1/voice/twilio/DEVICE_MSISDN";
            var client = HttpClientFactory.CreateHttpClient();
            var str = client.SendPostRequestLight(url);
            var index = str.IndexOf("49");
            var res =  "+" + str.Substring(index, 13);
            if (res.Last() == '<')
                res = res.Remove(13, 1);
            return res;
        }
    }
}
