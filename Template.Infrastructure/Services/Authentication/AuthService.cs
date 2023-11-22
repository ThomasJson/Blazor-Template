using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Template.Application.Features.Account.Shared.Dto;
using Template.Application.Interfaces.Services;
using Template.Domain.Entities;
using Template.Persistence.Contexts;

namespace Template.Infrastructure.Services.Authentication
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<AuthService> _logger;

        public AuthService(ApplicationDbContext context, ILogger<AuthService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<AccountEntity> GetAuthentication(AccountDto accountDto)
        {
            try
            {
                var accountEntity = await _context.Accounts.FirstOrDefaultAsync(x => x.Email == accountDto.Email);
                return accountEntity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Une erreur s'est produite lors de la récupération du compte.");
                throw;
            }
        }

        public Task<Dictionary<string, string>> GetSessionDatas(AccountDto accountDto)
        {
            try
            {
                Dictionary<string, string> sessionDatas = new Dictionary<string, string>();

                var userAssociated = _context.Users.FirstOrDefault(x => x.Id == accountDto.UserId);
                if (userAssociated != null)
                {
                    sessionDatas.Add("UserName", userAssociated.FirstName);
                    var roleLink = _context.AccountRoleLinks.FirstOrDefault(x => x.AccountId == accountDto.Id);

                    var roleAssociated = _context.Roles.FirstOrDefault(x => x.Id == roleLink.RoleId);
                    if (roleAssociated != null)
                    {
                        sessionDatas.Add("Role", roleAssociated.Name);
                    }
                }

                return Task.FromResult(sessionDatas);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Une erreur s'est produite lors de la récupération des données de session.");
                throw;
            }
        }
    }
}