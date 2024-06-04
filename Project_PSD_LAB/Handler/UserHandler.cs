using Project_PSD_LAB.Factory;
using Project_PSD_LAB.Model;
using Project_PSD_LAB.Modules;
using Project_PSD_LAB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_PSD_LAB.Handler
{
    public class UserHandler
    {
        public static Response<User> checkLogin (String username, String password)
        {
            User user = UserRepository.getUserByUsername(username);

            if (user == null)
            {
                return new Response<User>
                {
                    Message = "User not found",
                    IsSuccess = false,
                    payload = null
                };
            }

            if (password != user.UserPassword)
            {
                return new Response<User>
                {
                    Message = "Wrong password entered",
                    IsSuccess = false,
                    payload = null
                };
            }

            return new Response<User>
            {
                Message = "Success",
                IsSuccess = true,
                payload = user
            };
        }
        public static User getUserByUsername(String username)
        {
            return UserRepository.getUserByUsername(username);
        }
        public static int generateId()
        {
            User user = UserRepository.getLastUser();
            if(user == null)
            {
                return 1;
            }
            int lastId = user.UserID;
            lastId++;
            return lastId;
        }
        public static Response<User> doRegister(String username, String email,
            String gender, String password,  DateTime DOB)
        {
            User user = UserFactory.CreateUser(generateId(), username, email, 
                DOB, gender, "Customer", password);
            UserRepository.createUser(user);
            return new Response<User>
            {
                Message = "Success",
                IsSuccess = true,
                payload = user
            };
        }
        public static List<User> getAllUser()
        {
            return UserRepository.getAllUser();
        }
        public static Response<User> updateProfile(User user, String username,
            String email, String gender, DateTime DOB)
        {
            UserRepository.updateProfile(user, username, email, gender, DOB);
            return new Response<User>
            {
                Message = "Success",
                IsSuccess = true,
                payload = user
            };
        }
        public static Response<User> updatePassword(User user, String password)
        {
            UserRepository.updatePassword(user, password);
            return new Response<User>
            {
                Message = "Success",
                IsSuccess = true,
                payload = user
            };
        }
    }
}