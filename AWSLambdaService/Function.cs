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
        public async Task<int> FunctionHandler(string input, ILambdaContext context)
        {
            var task1 = opAsync1();
            var task2 = opAsync2();
            var task3 = opAsync3();
            Task.WaitAll(new Task[] { task1, task2, task3 });
            return await Task.FromResult(1);
        }
        public async Task<int> opAsync1()
        {
            await Task.Delay(500);
            return 1;
        }
        public async Task<int> opAsync2()
        {
            await Task.Delay(1000);
            return 1;
        }
        public async Task<int> opAsync3()
        {
            await Task.Delay(500);
            return 1;
        }
    }
}
