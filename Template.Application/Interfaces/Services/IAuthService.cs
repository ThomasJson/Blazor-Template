using Template.Application.Features.Account.Shared.Dto;
using Template.Domain.Entities;

namespace Template.Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task<AccountEntity> GetAuthentication(AccountDto accountDto);
        Task<Dictionary<string, string>> GetSessionDatas(AccountDto accountDto);
    }
}