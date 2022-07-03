using _0_Framework.Infrastructure;
using Account.Application.Contract.Account;
using AccountManagement.Domain.AccountAgg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Infrastucture.EFCore.Repository
{
    public class AccountRepository : RepositoryBase<long, AccountManagement.Domain.AccountAgg.Account>, IAccountRepository
    {

        private readonly AccountContext _context;

        public AccountRepository(AccountContext context) : base(context)
        {
            _context = context;
        }

        public EditAccount GetDetails(long id)
        {
            return _context.accounts.Select(x=>new EditAccount
            {
                Id= x.Id,
                FullName=x.FullName,
                UserName=x.UserName,
                RollId=x.RollId,
                Mobile=x.Mobile,
                ProfilePhoto=x.ProfilePhoto,

            }).AsNoTracking().FirstOrDefault(a => a.Id == id);
        }

        public List<AccountViewModel> Search(AccountSearchModel searchModel)
        {
            var query = _context.accounts.Select(x => new AccountViewModel 
            { 
            Id=x.Id,
            FullName=x.FullName,
            UserName=x.UserName,
            ProfilePhoto=x.ProfilePhoto,
            Mobile=x.Mobile,
            
          
            }).AsNoTracking();

            if(!string.IsNullOrWhiteSpace(searchModel.FullName))
               query=query.Where(x =>x.FullName.Contains(searchModel.FullName) );

            if (!string.IsNullOrWhiteSpace(searchModel.UserName))
                query = query.Where(x => x.UserName.Contains(searchModel.UserName));

            if (!string.IsNullOrWhiteSpace(searchModel.Mobile))
                query = query.Where(x => x.FullName.Contains(searchModel.Mobile));

            if (searchModel.RollId > 0)
                query = query.Where(x => x.RollId == searchModel.RollId);

            return query.ToList();

        }
    }
}
