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
                UserFirstName = accountEntity.User.FirstName,
                RoleName = accountEntity.RolesLink.FirstOrDefault()?.Role.Name
            };

            return accountDto;
        }
    }
}