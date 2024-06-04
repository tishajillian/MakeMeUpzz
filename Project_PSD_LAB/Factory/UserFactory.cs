using Project_PSD_LAB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_PSD_LAB.Factory
{
    public class UserFactory
    {
        public static User CreateUser(int userID, String username, String userEmail, DateTime userDOB, String userGender, String userRole, String userPassword)
        {
            User user = new User()
            {
                UserID = userID,
                Username = username,
                UserEmail = userEmail,
                UserDOB = userDOB,
                UserGender = userGender,
                UserRole = userRole,
                UserPassword = userPassword,
            };

            return user;
        }
    }
}