using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityServer4.Sample01
{
    public static class Config
    {

        public static IEnumerable<ApiResource> ApiResources()
        {

            yield break;
        }

        public static IEnumerable<Client> Clients()
        {
            return new List<Client>()
            {

            };
        }

        public static IEnumerable<TestUser> TestUsers()
        {
            return new List<TestUser>()
            {
                new TestUser()
                {
                    SubjectId = "1",
                    Username = "user1@inter.net",
                    Password = "pwd",
                    Claims =
                    {
                        new Claim(JwtClaimTypes.Role, "role1"),
                        new Claim(JwtClaimTypes.Role, "role2"),
                        new Claim(JwtClaimTypes.Email, "user1@inter.net")
                    }
                }
            };
        }
    }
}
