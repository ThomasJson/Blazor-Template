using Microsoft.EntityFrameworkCore;
using Template.Application.Features.Account.Shared.Dto;
using Template.Domain.Entities;
using Template.Persistence.Contexts;

namespace Template.Persistence.Repositories
{
    public class AccountRepository : IDisposable
    {
        private readonly ApplicationDbContext _context;

        public AccountRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AccountEntity> GetAccountByEmailAdress(AccountDto accountDto)
        {
            return await _context.Accounts.FirstOrDefaultAsync(x => x.Email == accountDto.Email);
        }
        
        public void Dispose()
        {
            _context.Dispose();
        }

    }
}