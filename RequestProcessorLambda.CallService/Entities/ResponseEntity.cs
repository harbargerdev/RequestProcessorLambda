using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace RequestProcessorLambda.CallService.Entities
{
    [Serializable]
    public class ResponseEntity
    {
        [DataMember]
        public UserEntity User { get; set; }
        [DataMember]
        public string ActivityKey { get; set; }
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public string SubType { get; set; }

        public ResponseEntity(string email, string key)
        {
            User = new UserEntity(email);
            ActivityKey = key;
            Type = "Invoice";
            SubType = "CreditMemo";
        }
    }
}
