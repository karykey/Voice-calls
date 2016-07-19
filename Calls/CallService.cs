using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Twilio;

namespace Calls
{
    
    public class CallService
    {
        private const string AccountSid = "AC31ffd45a4cb420fa211a4cbd791c84e9";
        private const string AuthToken = "618e1a2fc6551b45b20ed9f83d80405b";
        private const string TwilioEndPoint = "http://demo.twilio.com/docs/voice.xml";

        public void Call()
        {
            var toNumber = new GetNumberService().GetNumber();
            var twilio = new TwilioRestClient(AccountSid, AuthToken);
            var options = new CallOptions();
            options.Url = TwilioEndPoint;
            options.To = toNumber;//"+4915753272611";
            options.From = "+4917648763655";
            var call = twilio.InitiateOutboundCall(options);

            Thread.Sleep(20000);
            GetLog(twilio, call.Sid);
  
        }

        static void GetLog(TwilioRestClient client, string sid)
        {
            var call = client.GetCall(sid);

            //your log file path!!!
            using (var writer = new StreamWriter(@"C:\Users\Dmitry\Desktop\Calls_Log.txt"))
            {
                writer.WriteLine("Call Sid: {0}", call.Sid);
                writer.WriteLine("Time of call: {0}", DateTime.Now);
                writer.WriteLine("From: {0}", call.From);
                writer.WriteLine("To: {0}", call.To);
                writer.WriteLine("Call status: {0}", call.Status);
            }
        }
    }
}
