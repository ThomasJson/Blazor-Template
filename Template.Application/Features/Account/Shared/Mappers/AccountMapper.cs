using Template.Domain.Entities;
using Template.Application.Features.Account.Shared.Dto;

namespace Template.Application.Features.Account.Shared.Mappers
{
    public static class AccountMapper
    {
        public static AccountDto ToAccountDto(AccountEntity accountEntity)
        {
            var accountDto = new AccountDto()
            {
                Id = accountEntity.Id,
                Email = accountEntity.Email,
                Password = accountEntity.Password,
                UserId = accountEntity.UserId
            };

            return accountDto;
        }
    }
}