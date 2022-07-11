using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationBusiness.UserBusiness
{
    public interface IApplicationBusiness
    {
        bool ValidateExistUser(string userName);
        User UserSignUp(string userName, string password, int userType);
        User UserLogin(string userName, string password);
    }
}
