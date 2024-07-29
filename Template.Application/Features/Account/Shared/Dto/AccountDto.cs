using System;
using Template.Domain.Entities;

namespace Template.Application.Features.Account.Shared.Dto
{
    public class AccountDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserFirstName { get; set; }
        public string RoleName { get; set; }
    }

}