using System.Collections.Generic;
using Amazon.Lambda.Core;
using Amazon.DynamoDBv2.Model;
using Amazon.DynamoDBv2;
// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace LambdaDynamoDB
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
            AmazonDynamoDBConfig config = new AmazonDynamoDBConfig();
            config.RegionEndpoint = Amazon.RegionEndpoint.USWest2;
            AmazonDynamoDBClient client = new AmazonDynamoDBClient("AKIAI4CVVUA4GFICZWYQ", "ywxncLIn8ptj0IXHHjTIWRiZV0vQLqpHgoRO4f5G", config);
            PutItemRequest request = new PutItemRequest();
            Dictionary<string, AttributeValue> data = new Dictionary<string, AttributeValue>();
            data.Add("OrderId", new AttributeValue {N ="5" });
            data.Add("CreatedAt", new AttributeValue { S = "12-9-2017" });
            data.Add("User", new AttributeValue { S = "new value" });
            request.TableName = "Orders";
            request.Item = data;
            var result =  client.PutItemAsync(request).Result;
            GetItemRequest getItemRequest = new GetItemRequest();
            getItemRequest.TableName = "Orders";
            Dictionary<string, AttributeValue> dataGet = new Dictionary<string, AttributeValue>();
            dataGet.Add("OrderId", new AttributeValue { N = "5" });
            dataGet.Add("CreatedAt", new AttributeValue { S = "12-9-2017" });
            getItemRequest.Key = dataGet;
            var resultGet = client.GetItemAsync(getItemRequest).Result;
            var output = new AttributeValue();
            resultGet.Item.TryGetValue("User", out output);
            DeleteItemRequest deleteItemRequest = new DeleteItemRequest();
            deleteItemRequest.TableName = "Orders";
            deleteItemRequest.Key = dataGet;
            return output.S.ToString();
        }
    }
}
