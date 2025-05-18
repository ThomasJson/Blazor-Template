using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Application.Features.Account.InputRequests
{
    public class LoginInputRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
