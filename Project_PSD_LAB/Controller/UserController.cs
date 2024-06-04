using Project_PSD_LAB.Handler;
using Project_PSD_LAB.Model;
using Project_PSD_LAB.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services.Description;

namespace Project_PSD_LAB.Controller
{
    public class UserController
    {
        public static bool isUserLoggedIn()
        {
            if (HttpContext.Current.Session != null && !HttpContext.Current.Session.IsNewSession)
            {
                if (HttpContext.Current.Session["userRole"] != null)
                {
                    return true;
                }
            }
            HttpCookie authCookie = HttpContext.Current.Request.Cookies["user_cookie"];
            if (authCookie != null)
            {
                string cookieValue = authCookie.Value;
                User user = getUserByUsername(cookieValue);
                if (user != null)
                {
                    return true;
                }
            }

            return false;
        }
        //public static bool isUserLoggedIn()
        //{
        //    if (HttpContext.Current.Session != null)
        //    {
        //        HttpCookie userCookie = HttpContext.Current.Request.Cookies["user_cookie"];
        //        if (userCookie != null)
        //        {
        //            User user = UserHandler.getUserByUsername(userCookie.Value.ToString());
        //            if (user != null)
        //            {
        //                return true;
        //            }
        //        }
        //    }
        //    return false;
        //}
        //public static bool isUserLoggedIn()
        //{
        //    if (HttpContext.Current.Session != null &&
        //        HttpContext.Current.Request.Cookies["user_cookie"] != null)
        //    {
        //        return true;
        //    }
        //    return false;
        //}
        public static bool isUserAdmin()
        {
            if(HttpContext.Current.Session != null && HttpContext.Current.Session["userRole"] != null)
            {
                if(HttpContext.Current.Session["userRole"].ToString().Equals("Admin"))
                {
                    return true;
                }
            }
            HttpCookie userCookie = HttpContext.Current.Request.Cookies["user_cookie"];
            if (userCookie != null)
            {
                User user = UserHandler.getUserByUsername(userCookie.Value.ToString());
                if (user.UserRole.Equals("Admin"))
                {
                    return true;
                }
            }
            return false;
        }
        public static User getUserBySessionCookie()
        {
            if (HttpContext.Current.Session != null && HttpContext.Current.Session["user"] != null)
            {
                User user = (User) HttpContext.Current.Session["user"];
                return user;
            }
            HttpCookie userCookie = HttpContext.Current.Request.Cookies["user_cookie"];
            if (userCookie != null)
            {
                User user = UserHandler.getUserByUsername(userCookie.Value.ToString());
                return user;
            }
            return null;
        }
        public static Response<User> doLogin(string username, string password)
        {
            Response<User> responseHandler = UserHandler.checkLogin(username, password);

            if (username.Equals(""))
            {
                return new Response<User>
                {
                    Message = "Username must be filled!",
                    IsSuccess = false,
                    payload = null
                };
            }

            if (password.Equals(""))
            {
                return new Response<User>
                {
                    Message = "Password must be filled!",
                    IsSuccess = false,
                    payload = null
                };
            }

            if (!responseHandler.IsSuccess)
            {
                return responseHandler;
            }

            return responseHandler;
        }
        public static User getUserByUsername (String username)
        {
            return UserHandler.getUserByUsername(username);
        }
        public static String checkUserRole (String username)
        {
            User user = UserHandler.getUserByUsername(username);
            return user.UserRole;
        }
        public static Response<User> checkUsername(String username)
        {
            User user = UserHandler.getUserByUsername(username);

            if (username.Equals(""))
            {
                return new Response<User>
                {
                    Message = "Username must be filled!",
                    IsSuccess = false,
                    payload = null
                };
            }

            if (username.Length < 5 || username.Length > 15)
            {
                return new Response<User>
                {
                    Message = "Length of Username must be between 5 and 15.",
                    IsSuccess = false,
                    payload = null
                };
            }

            if (!Regex.IsMatch(username, @"^[a-zA-Z]+$"))
            {
                return new Response<User>
                {
                    Message = "Username must be written in alphabet only.",
                    IsSuccess = false,
                    payload = null
                };
            }

            if (user != null)
            {
                return new Response<User>
                {
                    Message = "Username already exists.",
                    IsSuccess = false,
                    payload = null
                };
            }

            return new Response<User>
            {
                Message = "Success",
                IsSuccess = true,
                payload = null
            };
        }
        public static Response<User> checkUpdateUsername(User user, String newUsername)
        {

            if (newUsername.Equals(""))
            {
                return new Response<User>
                {
                    Message = "Username must be filled!",
                    IsSuccess = false,
                    payload = null
                };
            }

            if (newUsername.Length < 5 || newUsername.Length > 15)
            {
                return new Response<User>
                {
                    Message = "Length of Username must be between 5 and 15.",
                    IsSuccess = false,
                    payload = null
                };
            }

            if (!Regex.IsMatch(newUsername, @"^[a-zA-Z]+$"))
            {
                return new Response<User>
                {
                    Message = "Username must be written in alphabet only.",
                    IsSuccess = false,
                    payload = null
                };
            }

            User check = UserHandler.getUserByUsername(newUsername);
            if (check != null)
            {
                if(!user.Username.Equals(newUsername))
                {
                    return new Response<User>
                    {
                        Message = "Username already exists.",
                        IsSuccess = false,
                        payload = null
                    };
                }
            }

            return new Response<User>
            {
                Message = "Success",
                IsSuccess = true,
                payload = null
            };
        }
        public static Response<User> checkEmail(String email)
        {
            if (email.Equals(""))
            {
                return new Response<User>
                {
                    Message = "Email must be filled!",
                    IsSuccess = false,
                    payload = null
                };
            }

            if (!Regex.IsMatch(email, @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.com$"))
            {
                return new Response<User>
                {
                    Message = "Email must ends with '.com'",
                    IsSuccess = false,
                    payload = null
                };
            }

            return new Response<User>
            {
                Message = "Success",
                IsSuccess = true,
                payload = null
            };
        }
        public static Response<User> checkGender(String gender)
        {
            if (gender.Equals(""))
            {
                return new Response<User>
                {
                    Message = "Gender must be chosen!",
                    IsSuccess = false,
                    payload = null
                };
            }

            return new Response<User>
            {
                Message = "Success",
                IsSuccess = true,
                payload = null
            };
        }
        public static Response<User> checkPassword(String password, String confPassword)
        {
            if (password.Equals(""))
            {
                return new Response<User>
                {
                    Message = "Password must be filled!",
                    IsSuccess = false,
                    payload = null
                };
            }

            if (!Regex.IsMatch(password, @"^[a-zA-Z0-9]+$"))
            {
                return new Response<User>
                {
                    Message = "Password must be in alphanumeric format only!",
                    IsSuccess = false,
                    payload = null
                };
            }

            if (!password.Equals(confPassword))
            {
                return new Response<User>
                {
                    Message = "Password does not match!",
                    IsSuccess = false,
                    payload = null
                };
            }

            if (confPassword.Equals(""))
            {
                return new Response<User>
                {
                    Message = "Please confirm the password!",
                    IsSuccess = false,
                    payload = null
                };
            }

            if (!confPassword.Equals(password))
            {
                return new Response<User>
                {
                    Message = "Password does not match!",
                    IsSuccess = false,
                    payload = null
                };
            }

            return new Response<User>
            {
                Message = "Success",
                IsSuccess = true,
                payload = null
            };
        }
        public static Response<User> checkDOB(DateTime DOB)
        {
            if(DOB == DateTime.MinValue)
            {
                return new Response<User>
                {
                    Message = "Date Of Birth must be filled!",
                    IsSuccess = false,
                    payload = null
                };
            }

            return new Response<User>
            {
                Message = "Success",
                IsSuccess = true,
                payload = null
            };
        }
        public static Response<User> checkRegister(String username, String email,
            String gender, String password, String confPassword, DateTime DOB)
        {
            Response<User> responseUsername = checkUsername(username);
            if (!responseUsername.IsSuccess)
            {
                return responseUsername;
            }

            Response<User> responseEmail = checkEmail(email);
            if (!responseEmail.IsSuccess)
            {
                return responseEmail;
            }

            Response<User> responseGender = checkGender(gender);
            if (!responseGender.IsSuccess)
            {
                return responseGender;
            }

            Response<User> responsePassword = checkPassword(password, confPassword);
            if (!responsePassword.IsSuccess)
            {
                return responsePassword;
            }

            Response<User> responseDOB = checkDOB(DOB);
            if (!responseDOB.IsSuccess)
            {
                return responseDOB;
            }

            return new Response<User>
            {
                Message = "Success",
                IsSuccess = true,
                payload = null
            };
        }
        public static Response<User> doRegister(String username, String email,
            String gender, String password, DateTime DOB)
        {
            Response<User> response = UserHandler.doRegister(username, email, gender, password, DOB);
            return response;
        }
        public static List<User> getAllUser()
        {
            return UserHandler.getAllUser();
        }
        public static Response<User> checkUpdateProfile(User user, String username, String email, String gender, DateTime DOB)
        {
            Response<User> responseUsername = checkUpdateUsername(user, username);
            if (!responseUsername.IsSuccess)
            {
                return responseUsername;
            }

            Response<User> responseEmail = checkEmail(email);
            if (!responseEmail.IsSuccess)
            {
                return responseEmail;
            }

            Response<User> responseGender = checkGender(gender);
            if (!responseGender.IsSuccess)
            {
                return responseGender;
            }

            Response<User> responseDOB = checkDOB(DOB);
            if (!responseDOB.IsSuccess)
            {
                return responseDOB;
            }

            return new Response<User>
            {
                Message = "Success",
                IsSuccess = true,
                payload = null
            };
        }
        public static Response<User> updateProfile(User user, String username, String email, String gender, DateTime DOB)
        {
            Response<User> response= UserHandler.updateProfile(user, username, email, gender, DOB);
            return response;
        }
        public static Response<User> checkUpdatePassword(User user, String oldPassword, String newPassword)
        {
            if (oldPassword.Equals(""))
            {
                return new Response<User>
                {
                    Message = "Old Password must be filled!",
                    IsSuccess = false,
                    payload = null
                };
            }

            if (!oldPassword.Equals(user.UserPassword))
            {
                return new Response<User>
                {
                    Message = "Old Password is incorrect!",
                    IsSuccess = false,
                    payload = null
                };
            }

            if (newPassword.Equals(""))
            {
                return new Response<User>
                {
                    Message = "New Password must be filled!",
                    IsSuccess = false,
                    payload = null
                };
            }

            if (!Regex.IsMatch(newPassword, @"^[a-zA-Z0-9]+$"))
            {
                return new Response<User>
                {
                    Message = "Password must be in alphanumeric format only!",
                    IsSuccess = false,
                    payload = null
                };
            }

            return new Response<User>
            {
                Message = "Success",
                IsSuccess = true,
                payload = null
            };
        }
        public static Response<User> updatePassword(User user, String newPassword)
        {
            Response<User> response = UserHandler.updatePassword(user, newPassword);
            return response;
        }
    }

}
