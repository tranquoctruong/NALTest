using System.Linq;

namespace AuthenticationBusiness.UserBusiness
{
    public class ApplicationBusiness : IApplicationBusiness
    {
        public User UserLogin(string userName, string password)
        {
            using (NALDBEntities dbContext = new NALDBEntities())
            {
                var userInfo = dbContext.Users.FirstOrDefault(u => u.UserName == userName && u.UserPassword == password);

                return userInfo;
            }
        }

        public bool ValidateExistUser(string userName)
        {
            using (NALDBEntities dbContext = new NALDBEntities())
            {
                return dbContext.Users.Any(u => u.UserName.ToLower() == userName.ToLower());
            }
        }

        public User UserSignUp(string userName, string password, int userType)
        {
            try
            {
                using (NALDBEntities dbContext = new NALDBEntities())
                {
                    var newUser = dbContext.Users.Add(new User() { UserName = userName, UserPassword = password, UserType = userType });
                    dbContext.SaveChanges();
                    return newUser;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
