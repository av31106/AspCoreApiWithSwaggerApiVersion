using API2022WithSwegger.Models;
using API2022WithSwegger.Models.Comman;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API2022WithSwegger.Controllers.Comman
{
    [Area("Comman")]
    public class UserController : CustomApiBase
    {
        private static List<User> Users = new List<User>()
        {
            new User { Id = 1,Name="Anil Kumar",LoginId="Anil31106",Address="Jagat Puri", DepartmentIds=new List<int> {1,2}},
            new User { Id = 2,Name="Raj Kumar",LoginId="Raj311",Address="Ram Puri", DepartmentIds=new List<int> {11,22}},
            new User { Id = 3,Name="kamal Kumar Singh",LoginId="kamal106",Address="Shahjaha puri", DepartmentIds=new List<int> {14}},
            new User { Id = 3,Name="kamal Bora",LoginId="Bora106",Address="Ram puri", DepartmentIds=new List<int> {11}}
        };

        public UserController() { }

        /// <summary>
        /// Get user details based id.
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns>User details</returns>
        [HttpGet]
        [ActionName("GetUserById")]
        public ResultReponse GetUserById(int id)
        {
            ResultReponse resultReponse;
            User? user;
            if (Users != null)
            {
                user = Users.FirstOrDefault(col => col.Id == id);
                if (user != null)
                {
                    resultReponse = ResponseSend(true, user);
                }
                else
                {
                    resultReponse = ResponseSend(false, null, $"User with id {id} does not exists.");
                }
            }
            else
            {
                resultReponse = ResponseSend(false, null, $"User with id {id} does not exists.");
            }
            return resultReponse;
        }

        /// <summary>
        /// Get user details based login id.
        /// </summary>
        /// <param name="loginId">User login id</param>
        /// <returns>User details</returns>
        [HttpGet]
        [ActionName("GetUserByLoginId")]
        public ResultReponse GetUserByLoginId(string loginId)
        {
            ResultReponse resultReponse;
            User? user;
            if (Users != null)
            {
                user = Users.FirstOrDefault(col => col.LoginId == loginId);
                if (user != null)
                {
                    resultReponse = ResponseSend(true, user);
                }
                else
                {
                    resultReponse = ResponseSend(false, null, $"User with login id {loginId} does not exists.");
                }
            }
            else
            {
                resultReponse = ResponseSend(false, null, $"User with login id {loginId} does not exists.");
            }
            return resultReponse;
        }

        /// <summary>
        /// Get all users details.
        /// </summary>
        /// <returns>Users details</returns>
        [HttpGet]
        [ActionName("GetAllUsers")]
        public ResultReponse GetAllUsers()
        {
            return ResponseSend(true, Users);
        }

        /// <summary>
        /// Add user details.
        /// </summary>
        /// <param name="user">User Details</param>
        /// <returns>User details</returns>
        [HttpPost]
        [ActionName("AddUser")]
        public ResultReponse AddUser(User user)
        {
            Users.Add(user);
            return ResponseSend(true, user);
        }

        /// <summary>
        /// Update any user details based on id.
        /// </summary>
        /// <param name="user">User Details</param>
        /// <returns>User Details</returns>
        [HttpPost]
        [ActionName("UpdateUser")]
        public ResultReponse UpdateUser(User user)
        {
            ResultReponse? resultReponse;
            if (Users != null)
            {
                User? dbUser = Users.FirstOrDefault(col => col.Id == user.Id);
                if (dbUser != null)
                {
                    dbUser.Name = user.Name;
                    dbUser.LoginId = user.LoginId;
                    dbUser.Address = user.Address;
                    dbUser.DepartmentIds = user.DepartmentIds;
                    resultReponse = ResponseSend(true, user);
                }
                else
                {
                    resultReponse = ResponseSend(false, null, $"User with id {user.Id} does not exists.");
                }
            }
            else
            {
                resultReponse = ResponseSend(false, null, $"User with id {user.Id} does not exists.");
            }
            return resultReponse;
        }

        /// <summary>
        /// Delete user based on id.
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns>User Details</returns>
        [HttpPost]
        [ActionName("DeleteUser")]
        public ResultReponse DeleteUser(int id)
        {
            ResultReponse? resultReponse;
            User? user;
            if (Users != null)
            {
                user = Users.FirstOrDefault(col => col.Id == id);
                if (user != null)
                {
                    Users.Remove(user);
                    resultReponse = ResponseSend(true, user);
                }
                else
                {
                    resultReponse = ResponseSend(false, null, $"User with id {id} does not exists.");
                }
            }
            else
            {
                resultReponse = ResponseSend(false, null, $"User with id {id} does not exists.");
            }
            return resultReponse;
        }
    }
}
