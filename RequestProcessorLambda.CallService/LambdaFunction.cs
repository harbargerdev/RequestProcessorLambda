using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Amazon.Lambda.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RequestProcessorLambda.CallService.Entities;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace RequestProcessorLambda.CallService
{
    public class LambdaFunction
    {        
        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public JObject FunctionHandler(string input, ILambdaContext context)
        {
            if(input != null && input.Equals(string.Empty))
            { 
                Dictionary<string, string> requestDictionary = new Dictionary<string, string>();
                string[] keys = input.Split("&");

                foreach(string value in keys)
                {
                    string[] keyValue = value.Split("=");
                    requestDictionary.Add(keyValue[0], keyValue[1]);
                }
            }

            ResponseEntity response = BuildMockResult();
            return JObject.FromObject(response);
        }

        private UserEntity GetUser(string key)
        {
            UserEntity user = new UserEntity("first.last@email.com");
            return user;
        }

        private ResponseEntity BuildMockResult()
        {
            string email = "first.last@email.com";
            string key = "123456";

            ResponseEntity response = new ResponseEntity(email, key);
            //return JsonConvert.SerializeObject(response);
            return response;
        }
    }
}
