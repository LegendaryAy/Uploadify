using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Uploadify.Services
{
    public class EmailService
    {
        public static IRestResponse SendSimpleMessage(string email)
        {
            RestClient client = new RestClient();
            client.BaseUrl = new Uri("https://api.mailgun.net/v3");
            client.Authenticator =
                new HttpBasicAuthenticator("api",
                                            "YOUR_API_KEY");
            RestRequest request = new RestRequest();
            request.AddParameter("domain", "samples.mailgun.org", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", "Excited User <mailgun@samples.mailgun.org>");
            request.AddParameter("to", $"{email}");
            request.AddParameter("subject", "Hello");
            request.AddParameter("text", "Testing some Mailgun awesomness!");
            request.AddFile("attachment", "uyeufhuehehfufe");
            request.Method = Method.POST;
            return client.Execute(request);
        }
    }
}
