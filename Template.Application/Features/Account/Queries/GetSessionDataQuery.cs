using MediatR;
using Template.Application.Features.Account.Shared.Dto;
using Template.Application.Interfaces.Services;

namespace Template.Application.Features.Account.Queries
{
    public record GetSessionDataQuery(AccountDto AccountDto) : IRequest<Dictionary<string, string>>;

    internal class GetSessionDataHandler : IRequestHandler<GetSessionDataQuery, Dictionary<string, string>>
    {
        private readonly IAuthService _authService;

        public GetSessionDataHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<Dictionary<string, string>> Handle(GetSessionDataQuery query, CancellationToken cancellationToken)
        {
            Dictionary<string, string> sessionDatas;

            sessionDatas = await _authService.GetSessionDatas(query.AccountDto);

            if (sessionDatas != null)
            {
                return sessionDatas;
            }

            else { return null; }
        }
    }
}