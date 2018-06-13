using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace RequestProcessorLambda.CallService.Entities
{
    [Serializable]
    public class UserEntity
    {
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string EmployeeId { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }

        public UserEntity(string email)
        {
            Email = email;
            UserName = email.Split("@")[0];
            string[] firstLastName = UserName.Split(".");
            FirstName = firstLastName[0];
            LastName = firstLastName[1];
            EmployeeId = "999999";
        }
    }
}
