using _0_Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Domain.AccountAgg
{
    public class Account : EntityBase
    {
        public string FullName { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string Mobile { get; private set; }
        public long RollId { get; private set; }
        public string ProfilePhoto { get; private set; }

        public Account(string fullName, string userName, string password, string mobile, long rollId,
            string profilePhoto)
        {
            FullName = fullName;
            UserName = userName;
            Password = password;
            Mobile = mobile;
            RollId = rollId;
            ProfilePhoto = profilePhoto;
        }

        public void Edit(string fullName, string userName, string mobile, long rollId,
            string profilePhoto)
        {
            FullName = fullName;
            UserName = userName;        
            Mobile = mobile;
            RollId = rollId;

            if(!string.IsNullOrWhiteSpace(ProfilePhoto))
            ProfilePhoto = profilePhoto;
        }

        public void ChangePassword(string password)
        {
            Password = password;
        }
    }

}
