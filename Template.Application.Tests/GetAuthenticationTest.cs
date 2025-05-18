using Moq;
using Template.Application.Features.Account.InputRequests;
using Template.Application.Features.Account.Queries;
using Template.Application.Features.Account.Shared.Dto;
using Template.Application.Interfaces.Services;

namespace Template.Application.Tests
{
    public class GetAuthenticationTest
    {
        [Fact]
        public async Task Handle_WithValidLoginInputRequest_Should_Return_AccountDto()
        {
            // Arrange
            var loginInputRequest = new LoginInputRequest { Email = "test@outlook.fr", Password = "Password123" };

            var accountRoleLinkEntities = new List<Domain.Entities.AccountRoleLinkEntity>
            {
                new Domain.Entities.AccountRoleLinkEntity
                {
                    AccountId = 1,
                    RoleId = 2,
                    Role = new Domain.Entities.RoleEntity
                    {
                        Id = 2,
                        Name = "User"
                    }
                }
            };

            var accountEntity = new Domain.Entities.AccountEntity
            {
                Id = 1,
                Email = "test@outlook.fr",
                Password = "Password123",
                User = new Domain.Entities.UserEntity
                {
                    FirstName = "John",
                    LastName = "Doe"
                },
                RolesLink = accountRoleLinkEntities
            };

            var expectedAccount = new AccountDto
            {
                Id = 1,
                Email = "test@outlook.fr",
                UserFirstName = "John",
                RoleName = "User"
            };

            var mockAuthService = new Mock<IAuthService>();
            mockAuthService
                .Setup(s => s.GetAuthenticatedAccount(It.IsAny<LoginInputRequest>()))
                .ReturnsAsync(accountEntity);

            var query = new GetAuthenticationQuery(loginInputRequest);
            var handler = new GetAuthenticationQueryHandler(mockAuthService.Object);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedAccount.Email, result.Email);
            Assert.Equal(expectedAccount.UserFirstName, result.UserFirstName);
            Assert.Equal(expectedAccount.RoleName, result.RoleName);
        }
    }
}