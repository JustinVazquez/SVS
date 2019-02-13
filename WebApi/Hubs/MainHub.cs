using Core.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Hubs
{
    public class MainHub : Hub
    {

        public bool Test()
        {
            return true;
        }

        public User Login(string name,string password)
        {
            User test = new User();
            test.ID = 1;
            test.Name = "Test";
            test.Email = "Test.Test@Test.de";
           
            return test;
        }
    }
}
