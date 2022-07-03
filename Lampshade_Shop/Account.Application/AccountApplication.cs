using _0_Framework.Application;
using Account.Application.Contract.Account;
using AccountManagement.Domain.AccountAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Application
{
    public class AccountApplication : IAccountApplication
    {

        private readonly IAccountRepository _accountRepository;
        private readonly IPasswordHasher _passwordHasher;
        public AccountApplication(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public OperationResult ChangePassword(ChangePassword password)
        {
            var operation=new OperationResult();

            var user = _accountRepository.Get(password.Id);

            if (user == null)
                return operation.Failed(DefultMessage.NotFoundMessage);

            if (password.Password != password.RePassword)
                return operation.Failed(DefultMessage.NotMatchPassword);

            var Password = _passwordHasher.Hash(password.Password);
            user.ChangePassword(Password);
            _accountRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Create(CreateAccount command)
        {
            var operation = new OperationResult();

            if(_accountRepository.Exists(x=>x.UserName==command.UserName))
                return operation.Failed(DefultMessage.DuplicatedMessage);

            var Password = _passwordHasher.Hash(command.Password);
            var user = new AccountManagement.Domain.AccountAgg.Account(command.FullName, command.UserName, Password,
                command.Mobile, command.RollId, command.ProfilePhoto);

            _accountRepository.Create(user);
            _accountRepository.SaveChanges();
            return operation.Succedded();

        }

        public OperationResult Edit(EditAccount command)
        {
            var operation = new OperationResult();

            var user = _accountRepository.Get(command.Id);

            if (user == null)
                return operation.Failed(DefultMessage.NotFoundMessage);

            user.Edit(command.FullName, command.UserName, command.Mobile, command.RollId, command.ProfilePhoto);
            _accountRepository.SaveChanges();
            return operation.Succedded();
        }

        public EditAccount GetDetails(long id)
        {
            return _accountRepository.GetDetails(id);
        }

        public List<AccountViewModel> Search(AccountSearchModel searchModel)
        {
            return _accountRepository.Search(searchModel);
        }
    }
}
