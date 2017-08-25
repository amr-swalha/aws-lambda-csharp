using Newtonsoft.Json;
using System.Collections.Generic;

namespace AWSLambdaService
{
    public class RootObject
    {
        public string val1 { get; set; }
        public string val2 { get; set; }
        [JsonIgnore]
        public string twoValues => val1 + val2;
        public List<Student> StudentData { get; set; }
    }
}