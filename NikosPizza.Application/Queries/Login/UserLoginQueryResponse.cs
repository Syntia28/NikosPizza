using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NikosPizza.Application.Queries.Login
{
    public class UserLoginQueryResponse
    {
        public UserLoginQueryResponse() { }
        public bool IsSuccess { get; set; }
        public string Mensaje { get; set; }
    }
}