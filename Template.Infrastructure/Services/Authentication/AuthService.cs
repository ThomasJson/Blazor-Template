using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;
using Template.Application.Features.Account.Shared.Dto;
using Template.Application.Interfaces.Services;
using Template.Domain.Entities;
using Template.Persistence.Contexts;
using Template.Persistence.Repositories;

namespace Template.Infrastructure.Services.Authentication
{
    public class AuthService : IAuthService
    {
        private readonly AccountRepository _accountRepository;
        private readonly ILogger<AuthService> _logger;

        public AuthService(AccountRepository accountRepository, ILogger<AuthService> logger)
        {
            _accountRepository = accountRepository;
            _logger = logger;
        }

        public async Task<AccountEntity> GetAuthenticatedAccount(AccountDto accountDto)
        {
            try
            {
                var accountEntity = await _accountRepository.GetAccountByEmailAdress(accountDto);
                
                if (accountEntity == null || accountEntity.Password != accountDto.Password)
                {
                    return null;
                }

                return accountEntity;
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, "Error while retrieving account.");
                throw;
            }
        }

    }
}