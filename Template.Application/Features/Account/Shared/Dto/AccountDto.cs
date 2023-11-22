using System;

namespace Template.Application.Features.Account.Shared.Dto
{
    public class AccountDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime LastConnection { get; set; }
        public int UserId { get; set; }
    }
}