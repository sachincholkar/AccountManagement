using AccountManagement.Domain.Entity;
using AccountManagement.Domain.Repository;
using MediatR;

namespace AccountManagement.Application.Accounts.Commands.UpdateAccount
{
    public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand, int>
    {
        private readonly IAccountRepository _accountRepository;
        public UpdateAccountCommandHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task<int> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {
            Account account = new Account() { Id = request.Id, AccountNumber = request.AccountNumber, FirstName = request.FullName.Split(" ")[0], LastName = request.FullName.Split(" ")[1], AccountType = request.AccountType, Balance = request.Balance };
            return await _accountRepository.UpdateAccountAsync(request.Id, account );
        }
    }
}
