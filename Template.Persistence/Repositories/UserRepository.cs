using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Application.Features.Account.Shared.Dto;
using Template.Domain.Entities;
using Template.Persistence.Contexts;

namespace Template.Persistence.Repositories
{
    public class UserRepository : IDisposable
    {

        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserEntity> GetUserById(AccountEntity accountEntity)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == accountEntity.UserId);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
