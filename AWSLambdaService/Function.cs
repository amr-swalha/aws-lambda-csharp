using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace AWSLambdaService
{
    public class Function
    {
        
        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public string FunctionHandler(string input, ILambdaContext context)
        {
            string cxt = $"ML: {context.MemoryLimitInMB}, FN: {context.FunctionName}, ARN: {context.InvokedFunctionArn}, RequestID: {context.AwsRequestId}, LogSN: {context.LogStreamName}, LogSNG: {context.LogGroupName}, RemainingTime: {context.RemainingTime}";
            
            return cxt;
        }
        
    }
}
