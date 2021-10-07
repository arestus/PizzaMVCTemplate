using PizzaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PizzaMVC.Services
{
    public class UserService
    {
        public async Task<UserDTO> Register(UserDTO userDto)
        {
            UserDTO userDTO = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8934/api/");
                var postTask = await client.PostAsJsonAsync<UserDTO>("User", userDto);
                if (postTask.IsSuccessStatusCode)
                {
                    var data = await postTask.Content.ReadFromJsonAsync<UserDTO>();
                    userDTO = data;
                }
            }
            return userDTO;
        }

        public async Task<UserDTO> Login(UserDTO userDto)
        {
            UserDTO userDTO = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8934/api/");
                var postTask = await client.PostAsJsonAsync<UserDTO>("User/Login", userDto);
                if (postTask.IsSuccessStatusCode)
                {
                    var data = await postTask.Content.ReadFromJsonAsync<UserDTO>();
                    userDTO = data;
                }
            }
            return userDTO;
        }
    }
}
