﻿using IdentityModel;
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
                new Client()
                {
                    ClientId = "mvc",
                    ClientName = "MVC Client",
                    AllowedGrantTypes = GrantTypes.Implicit,

                    // where to redirect to after login
                    RedirectUris = { "http://localhost:5002/signin-oidc" },

                    // where to redirect to after logout
                    PostLogoutRedirectUris = { "http://localhost:5002/signout-callback-oidc" },

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        JwtClaimTypes.Role,
                        "myclaim"
                    },

                    RequireConsent = false,

                    AlwaysIncludeUserClaimsInIdToken = true
                }
            };
        }

        public static IEnumerable<IdentityResource> IdentityResources()
        {
            return new List<IdentityResource>()
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResource(JwtClaimTypes.Role, new string[]{ JwtClaimTypes.Role })
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
                        new Claim(JwtClaimTypes.Email, "user1@inter.net"),
                        new Claim("myclaim", "my claim value")
                    }
                }
            };
        }
    }
}
