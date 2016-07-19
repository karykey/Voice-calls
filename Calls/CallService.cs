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
        private const string AccountSid = "Your_AccountSid";
        private const string AuthToken = "Your_AuthToken";
        private const string TwilioEndPoint = "http://demo.twilio.com/docs/voice.xml";

        public void Call()
        {
            var toNumber = new GetNumberService().GetNumber();
            var twilio = new TwilioRestClient(AccountSid, AuthToken);
            var options = new CallOptions();
            options.Url = TwilioEndPoint;
            options.To = toNumber;//"+4915753";
            options.From = "Your_Verified_Caller_ID";
            var call = twilio.InitiateOutboundCall(options);

            Thread.Sleep(20000);
            GetLog(twilio, call.Sid);
  
        }

        static void GetLog(TwilioRestClient client, string sid)
        {
            var call = client.GetCall(sid);

            //your log file path!!!
            using (var writer = new StreamWriter(@"C:\Users\Kapo\Desktop\Calls_Log.txt"))
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
