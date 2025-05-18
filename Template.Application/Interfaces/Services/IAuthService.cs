using Template.Application.Features.Account.InputRequests;
using Template.Application.Features.Account.Shared.Dto;
using Template.Domain.Entities;

namespace Template.Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task<AccountEntity> GetAuthenticatedAccount(LoginInputRequest loginInputRequest);
    }

}