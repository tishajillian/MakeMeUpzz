using Project_PSD_LAB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_PSD_LAB.Repository
{
    public class UserRepository
    {
        private static Database1Entities1 db = new Database1Entities1();
        public static User getUserByUsername(String username)
        {
            return (from x in db.Users
                    where x.Username.Equals(username)
                    select x).FirstOrDefault();
        }
        public static User getLastUser()
        {
            return db.Users.ToList().LastOrDefault();
        }
        public static void createUser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }
        public static List<User> getAllUser()
        {
            return (from x in db.Users select x).ToList();
        }
        public static void updateProfile(User user, String username, String email, String gender, DateTime DOB)
        {
            user.Username = username;
            user.UserEmail = email;
            user.UserGender = gender;
            user.UserDOB = DOB;
            db.SaveChanges();
        }
        public static void updatePassword(User user, String password)
        {
            user.UserPassword = password;
            db.SaveChanges();
        }
    }
}