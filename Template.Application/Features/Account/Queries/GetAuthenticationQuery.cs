using MediatR;
using Template.Application.Features.Account.Shared.Dto;
using Template.Application.Features.Account.Shared.Mappers;
using Template.Application.Interfaces.Services;

namespace Template.Application.Features.Account.Queries
{
    public record class GetAuthenticationQuery(AccountDto AccountDto) : IRequest<AccountDto>;

    internal class GetAuthenticationQueryHandler : IRequestHandler<GetAuthenticationQuery, AccountDto>
    {
        private readonly IAuthService _authService;

        public GetAuthenticationQueryHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<AccountDto> Handle(GetAuthenticationQuery query, CancellationToken cancellationToken)
        {
            var accountEntity = await _authService.GetAuthenticatedAccount(query.AccountDto);

            if (accountEntity != null)
            {
                var accountDto = AccountMapper.ToAccountDto(accountEntity);
                return accountDto;
            }
            else
            {
                return null;
            }

        }
    }
}