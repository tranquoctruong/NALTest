using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace AuthenticationWeb.Common
{
    public static class DataCommon
    {
        public static string InvalidLogin = "Invalid Username or Password";
        public static string InvalidSignup = "Invalid User infomation, please check again!";
        public static string ExistUser = "User name is exists!";
    }

    public enum UserType
    {
        [Description("Admin")]
        Admin = 0,
        [Description("User")]
        User = 1,
        [Description("Partner")]
        Parner = 2
    }
}