IdentityServer 4 - Sample #01
=============================

This is a sample project on how to use [Identity Server 4](http://docs.identityserver.io) with an ASP.NET MVC client.

This sample follows the [Quick Start](http://docs.identityserver.io/en/release/quickstarts/0_overview.html) in the
Identity Server docs, but simplifies the setup to include just the Identity Server implementation and an MVC
client that requests only an identity token from Identity Server. The identity token is then processed by
the MVC client and stored as the identity of the logged on user.


Custom Scopes
-------------

The custom scopes configured in this sample use the *-scope* suffix in the name just to be more clear about what is a scope
name and what is a claim type. Each scope name that matches an identity resource configured with the name
is mapped to one or more claim types.

In this sample we use two custom scope names with custom claim types mapped to them.

- **role-scope** - This scope is mapped to just one claim type
  - *role* - One or more roles that the authenticated user has.
- **manager-scope** - This scope is mapped to multiple claim types
  - *managerid* - Represents the employee id of the manager to the authenticated user.
  - *managername* - The name of the authenticated user's manager.
  - *manageremail* - The e-mail of the authenticated user's manager.

Please note that these scope names and claim types could be anything that makes sense to your application.


MVC Client
----------

The MVC client represents a web application that needs to authenticate its users, and request a few custom
claims to be included in the token issued by Identity Server.

The client application requests the claims by requesting for scopes that the desired claim types are mapped to,
as explained above. These scopes are requested in the Client application's *Startup.cs* file. The custom scopes that
client requests are *role-scope* and *manager-scope*, which then produces the desired claim types and the
issued identity token.


Identity Server
---------------

In order for the MVC client to be able to authenticate users with Identity Server, it must be configured so
that Identity Server can recognize it.

The main configuration information is created in the *Config.cs* file in the *IdentityServer4.Sample01* project.
The main thing to notice in that file is the configuration of the client application, where the *role-scope*
and *manager-scope* are added as allowed scopes for the client application.

Additionally, these custom scopes are mapped to claim types using *IdentityResource* object instances that
are also defined in *Config.cs*.