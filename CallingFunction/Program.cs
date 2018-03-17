using Amazon.Lambda;
using Amazon;
using System;
using Amazon.Lambda.Model;
using System.IO;
namespace CallingFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            AmazonLambdaClient client = new AmazonLambdaClient("Your Client ID", "Your Client Secert", RegionEndpoint.USWest2);
            InvokeRequest request = new InvokeRequest() { FunctionName="Udemy",Payload="\"test\""};
            InvokeResponse response = client.Invoke(request);
            if (response != null && response.StatusCode == 200)
            {
                var sr = new StreamReader(response.Payload);
                string result = sr.ReadToEnd();
                Console.WriteLine($"Results: {result}");
            }
            Console.ReadLine();
        }
    }
}
