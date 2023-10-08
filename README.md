# Secured Blazorserver Web -> Protected Minimal API (using Auth0)
Demo app that shows how to sign in users and call a protected API from a Blazor Server app using Auth0 authorization server. It also demonstrates how to use Refresh Tokens.

## Choosing the Right SDK. [Reference](https://auth0.com/blog/choose-the-right-dotnet-sdk-for-auth0/)
### Package for AuthN
Enable users to log in using Auth0 universal login page, SSO, Passwordless, social login etc.
<img width="450" alt="image" src="https://github.com/affableashish/blazor-api-auth0/assets/30603497/a4d56475-84a9-4656-9444-f3deaf1fd6b2">

### Package for AuthN
To control access.                                                                             
<img width="450" alt="image" src="https://github.com/affableashish/blazor-api-auth0/assets/30603497/66892eae-4b64-4b4d-b01a-034cb38cf8eb">

### Package for managing users and other Auth0 tenant features               
<img width="450" alt="image" src="https://github.com/affableashish/blazor-api-auth0/assets/30603497/49af67f3-a783-4054-83ee-d494a4be33f3">

## Install Auth0 templates (I won't be using this. Just here for information. [Reference](https://github.com/auth0/auth0-dotnet-templates).)
This will make it easier to create projects with Auth0 stuffs scaffolded in.

### To uninstall packages. [Reference](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-new-uninstall).
<img width="450" alt="image" src="https://github.com/affableashish/blazor-api-auth0/assets/30603497/ce51c891-53ba-4d0c-8745-bf4d5a46e282">

## SignIn/ SignOut users to your web app
Signup at Auth0 and create a new app (regular server app) for my Blazor Server app.
The Web app looks like this:                                                                    
<img width="750" alt="image" src="https://github.com/affableashish/blazor-api-auth0/assets/30603497/0afd00a0-e166-4f46-9f25-d0178b0efcdc">                                                               
I'll add Web API later.

### Configure Auth0
**Get your application keys**                                                               
**Domain:** `dev-12345zb7dr55dwyy.us.auth0.com`                                                               
**Client Id:** `12345r3m4ZneVjyrhKrcS9eMtfw12345`                                                               
**Client Secret:** `123458uEEConRXbQphi7rAq8gA1WOX5SXodUdBi8qSB1hjfhVlJ2lfZEl8p12345`                               

**Configure Callback Urls**                                                               
This is the url of my application where Auth0 will redirect to after the user has authenticated in order for the SDK to complete the authentication process.

**Configure Logout Urls**                                                               
This is the url of my application where Auth0 can return to after the user has been logged out of the authorization server. This is specified in the returnTo query parameter. The logout url for my app should be added to "Allowed Logout URLs" field in my Application settings.                                                                    
<img width="550" alt="image" src="https://github.com/affableashish/blazor-api-auth0/assets/30603497/64389f2a-185e-4a40-aba6-81775b1e210c">                                                               
Allowed Logout url says which url to send the user to after the logout.

### Integrate Auth0. [Reference](https://auth0.com/blog/what-is-blazor-tutorial-on-building-webapp-with-authentication/).
Universal Login is the best way to setup authentication. [Reference](https://auth0.com/docs/authenticate/login/auth0-universal-login).

**Install dependencies**                                                               
`Install-Package Auth0.AspNetCore.Authentication`                                                                    
<img width="450" alt="image" src="https://github.com/affableashish/blazor-api-auth0/assets/30603497/63679850-4925-408f-a043-b4000ed0e2ab">

**Setup Program.cs**                                                               
Services:                                                                                                            
<img width="450" alt="image" src="https://github.com/affableashish/blazor-api-auth0/assets/30603497/b9d427be-8531-43bd-8b69-d786b540a763">

Middleware:                                                                    
<img width="261" alt="image" src="https://github.com/affableashish/blazor-api-auth0/assets/30603497/f4b80af9-be20-4540-8bb3-508de11ca2c9">

### Add Login Razor Page to Pages folder                                                               
<img width="350" alt="image" src="https://github.com/affableashish/blazor-api-auth0/assets/30603497/3085f01d-6df4-4a4b-92d0-f5540bd2dc55">

**Add this code:**                                                                    
<img width="550" alt="image" src="https://github.com/affableashish/blazor-api-auth0/assets/30603497/182a7398-28cc-407f-be0b-baa7bbf57151">

### Add Logout Razor Page
<img width="550" alt="image" src="https://github.com/affableashish/blazor-api-auth0/assets/30603497/431c6786-25e8-4909-bcb3-a8e1d547f882">

### Modify App.Razor file
<img width="850" alt="image" src="https://github.com/affableashish/blazor-api-auth0/assets/30603497/44e0d54c-8140-40a8-95dc-7514207467ec">                                                               
For more details check out the code. I'm just listing out the steps to be successful.

### Add LoginDisplay.razor to Shared
<img width="450" alt="image" src="https://github.com/affableashish/blazor-api-auth0/assets/30603497/fefdafe0-9b6c-4715-bbbd-c2fadd05cc65">

### Show user info on the Index.razor page
<img width="750" alt="image" src="https://github.com/affableashish/blazor-api-auth0/assets/30603497/c11b15a2-bbb8-4150-8394-31286c7a4dbc">

### Take it for the test ride
Launch the app and hit login.                                                               
<img width="750" alt="image" src="https://github.com/affableashish/blazor-api-auth0/assets/30603497/52908069-a7a9-4de0-84db-82986041fe92">                                                               
Signup using your email address.                                                               
I used my email address: affableashk@outlook.com.

### Give Consent 
<img width="350" alt="image" src="https://github.com/affableashish/blazor-api-auth0/assets/30603497/491b2dbe-e944-4e23-b1c9-ed1e8d34c872">                                                               

Remember I signed up for Auth0 with a different email account (cs one).                                              
It's saying that my app wants to access my account that's under dev-4n8b… tenant/ domain.

### Goto Index Page
<img width="750" alt="image" src="https://github.com/affableashish/blazor-api-auth0/assets/30603497/b75d3e00-e5c5-47d9-97b0-81785e2c0c22">

## Authorization for Web APIs. [Reference](https://auth0.com/blog/aspnet-web-api-authorization/).
Register Web API with Auth0                                                               
<img width="850" alt="image" src="https://github.com/affableashish/blazor-api-auth0/assets/30603497/df21cf56-bdef-4ccc-9d2a-eb010a466f6b">

### Create API
<img width="550" alt="image" src="https://github.com/affableashish/blazor-api-auth0/assets/30603497/00a5f320-9bf2-4034-ae33-f419d99151e4">                                                               

Note:                                                               
**Auth0 domain:** 
`https://dev-12345zb7dr55dwyy.us.auth0.com/`                                                   
**API Identifier:** 
`https://api.weatherforecast.com`                                                         
Launch the app and hit login.

### Configure the Web API
Put the API info in appsettings.json                                                               
<img width="350" alt="image" src="https://github.com/affableashish/blazor-api-auth0/assets/30603497/d1fd143a-2fe0-4564-b64b-5327cbc8241b">

### Install package: 
`Microsoft.AspNetCore.Authentication.JwtBearer`                                                               
In order to interact with Auth0 authorization services, my app needs to be able to handle tokens in JWT format.
The package helps with that.                                                               
<img width="850" alt="image" src="https://github.com/affableashish/blazor-api-auth0/assets/30603497/09c792da-6192-419d-976b-5973cd4dc6da">

### Modify Program.cs
Check out Program.cs especially the lines between:                                                               
<img width="180" alt="image" src="https://github.com/affableashish/blazor-api-auth0/assets/30603497/0eab0472-e246-4f43-bbee-d6e55367b0b1">

### Get token from Auth0
Go to Test tab -> Copy Token                                                               
<img width="800" alt="image" src="https://github.com/affableashish/blazor-api-auth0/assets/30603497/08e21b57-a720-4275-8a8f-9d317da43671">

### Take it for the test ride
Open Swagger UI -> Click Authorize Button -> Paste Token -> Press Authorize                                         
Call "/weather" and you should see success! 🎉

## Call Protected APIs. [Reference](https://auth0.com/blog/call-protected-api-in-aspnet-core/).
1. The user authenticates with Auth0.                                                               
2. After authentication, the user explores the blazor app.                                                           
3. When the user wants to check the forecast, the blazor app makes a request to the forecast API.

Grab Client secret and put it in Client app                                                               
From here:                                                               
<img width="850" alt="image" src="https://github.com/affableashish/blazor-api-auth0/assets/30603497/ac8094c7-0c92-4c0c-a571-29d8acbfe2e9">

### Configure Program.cs

### Use Access token using TokenHandler by overriding SendAsync

### Take it for a test ride. It'll work like a champ. 🍾

## Add Role Based Authorization to Protected API. [Reference](https://auth0.com/blog/role-based-authorization-for-aspnet-webapi/).
A role is a collection of permissions. Basically you build a predefined set of permissions, give it a name, such as Employee, HR Assistant, HR Manager etc. and assign that role to a user.

If you need to add or remove a permissions from all the users who have a speicific role, you just need to add or remove that permissions from the role they are assigned.

So far our Protected API already requires an access token but it doesn't perform any check on the permission granted to the users.

### Define Permissions for our API
Define permissions needed for our application.
I'll add "read:weather" permission. This permission allows a user to read the weather endpoint.

Notice that Web App doesn't have permissions tab but API does:
<img width="550" alt="image" src="https://github.com/affableashish/blazor-api-auth0/assets/30603497/608d0e82-d2dd-4ff8-bd1f-b9037603a53f">
<img width="550" alt="image" src="https://github.com/affableashish/blazor-api-auth0/assets/30603497/eea1c93e-d5f0-4e19-96e7-e50db873208f">

This is how it looks like after I added the Permission:                                                              
<img width="850" alt="image" src="https://github.com/affableashish/blazor-api-auth0/assets/30603497/e1fbd6c5-1dca-49d8-84e3-1f3c2737de69">                                                               
This informs Auth0 that this Web API supports these permissions.

### Enable RBAC
Settings tab                                                                
-> Enable RBAC                                                               
-> Add Permissions in the Access Token                                                               
<img width="650" alt="image" src="https://github.com/affableashish/blazor-api-auth0/assets/30603497/803a33af-0cf2-4985-9f77-06bc0abaafec">                                                               
Save

### Create Roles
Your goal is to create roles so that only specific users can perform specific actions.
For eg: In a newspaper company an Editor role should have permissions to read (read:article), create (create:article) and update (update:article) articles.

Go to Dashboard -> User Management -> Roles -> Create Role
<img width="850" alt="image" src="https://github.com/affableashish/blazor-api-auth0/assets/30603497/cd52e475-95ef-4974-b57d-d18be1f2f882">                                                               
Create

Go to Permissions tab of this Role and "Add Permissions"                                                             
<img width="350" alt="image" src="https://github.com/affableashish/blazor-api-auth0/assets/30603497/63ee595a-7bc1-4e8e-9350-028f16a7f7e7">

Select the Weather forecast API                                                               
<img width="450" alt="image" src="https://github.com/affableashish/blazor-api-auth0/assets/30603497/759dce20-7f3d-4220-a535-d538faef32c7">                                                               
Add Permissions

**Final Look:**                                                               
<img width="650" alt="image" src="https://github.com/affableashish/blazor-api-auth0/assets/30603497/5f2c0e75-de24-468a-b5ee-6fa0e167765f">

### Create a new user with "weather-reader" role
<img width="850" alt="image" src="https://github.com/affableashish/blazor-api-auth0/assets/30603497/b5630edd-b70f-472d-bcbd-bd3648a39e8b">                                                               
Create
<img width="850" alt="image" src="https://github.com/affableashish/blazor-api-auth0/assets/30603497/d19e051a-536d-4e44-9ed5-5d9d8db35fc9">                                                               
Password: Password1!

### Go to Roles tab and assign this guy "weather-reader" role.
<img width="450" alt="image" src="https://github.com/affableashish/blazor-api-auth0/assets/30603497/43a073ef-8c99-4a9d-ad2b-9e122d05989f"> 

Assign

### Add Authorization Policy in the API
You'll be getting permissions in the access token, so use permissions to create policies.

Don't even think about roles in the API. Roles make sense in the IAM in Auth0 side to manage users, but it's easy to create Policies based on Permissions.

The role management and permissions unpacking is an Auth0 responsibility.                                            
<img width="450" alt="image" src="https://github.com/affableashish/blazor-api-auth0/assets/30603497/b5de8f8f-b5fb-45a0-bb0a-99e2d830082c">

### Take it for a Test ride
Login with my regular account that doesn't have the "read:weather" permission which will run into "Forbidden" issue.
<img width="850" alt="image" src="https://github.com/affableashish/blazor-api-auth0/assets/30603497/7ba67863-c16c-478e-ac88-2ba7c9771a3d">

Handle that error better later.

But trying with the "weather-reader-guy@example.com", I'm able to read the weather data! 🎉
<img width="750" alt="image" src="https://github.com/affableashish/blazor-api-auth0/assets/30603497/3082b91d-876d-4ec6-8c47-13f171981667">
<img width="750" alt="image" src="https://github.com/affableashish/blazor-api-auth0/assets/30603497/24a173e2-aaa3-4248-a5e6-5d877ae7502c">

### View the permissions in the accessToken like this:
<img width="650" alt="image" src="https://github.com/affableashish/blazor-api-auth0/assets/30603497/79804dfb-d967-488a-a52f-e91e9ab4b1f7">

This user got those permissions because he was assigned from their "weather:reader" role. 
The role management and permissions unpacking is an Auth0 responsibility.

## Using Refresh Tokens in a Blazor Web that calls an API. [Reference](https://auth0.com/blog/use-refresh-tokens-in-aspnet-core-apps/).
Access tokens authorize your application to call a protected API.
You use them as Bearer tokens in your HTTP requests. Don't use ID tokens to call APIs.

1. At login time, your app requests a refresh token along with ID and access token.
2. When your app needs to call and API and finds that the access token is expired, it requests Auth0 a new access token by sending the refresh token.
3. Auth0 sends your app a new access token and a new refresh token.
4. Your app uses the new access token to call the API and will use the new refresh token when this new access token expires.

### Enable Refresh Token support
Go to Auth0 dashboard -> Applications -> APIs
Find your API -> Settings
<img width="450" alt="image" src="https://github.com/affableashish/blazor-api-auth0/assets/30603497/fbb36d17-9fba-4467-adbf-d43a5ce2834e">

Turn on "Allow Offline Access". Hit "Save".

### Enable Refresh Token rotation
Go to Auth0 dashboard -> Applications -> Applications
Find your Web App -> Settings
<img width="850" alt="image" src="https://github.com/affableashish/blazor-api-auth0/assets/30603497/3c657bf9-abbf-4732-b670-aaacc6b967a5">

Turn On "Rotation"
After the change:
<img width="850" alt="image" src="https://github.com/affableashish/blazor-api-auth0/assets/30603497/21eb28f3-daa9-4073-b1e1-1fa92ca6595f">

### Request refresh token in Program.cs of Web app
<img width="400" alt="image" src="https://github.com/affableashish/blazor-api-auth0/assets/30603497/6cb60d94-4ef9-42f8-b170-a8e5f908768d">

### Take it for a Test ride
Consent screen has changed:

<img width="350" alt="image" src="https://github.com/affableashish/blazor-api-auth0/assets/30603497/7a323193-7604-42ce-a377-48cbb899bea2">

## Test Authorization in .NET Web APIs using `user-jwts` tool
Testing a protected Web API is not at easy task. At the very least, you need to configure an authorization server, such as your Auth0 tenant, configure your app and get specific access tokens for your authorization scenarios.
`user-jwts` tool allows you to generate tokens customized for your needs and test your API without the need for a real authorization server.
It's a CLI tool integrated with .NET CLI from version 7.0 of the .NET SDK.

### Setup the code
Just for the testing, temporarily remove Auth0 setup from `Program.cs` in the API project:
<img width="750" alt="image" src="https://github.com/affableashish/blazor-api-auth0/assets/30603497/189f5a5e-fa4b-4f4a-a774-251257c94ed6">
<img width="750" alt="image" src="https://github.com/affableashish/blazor-api-auth0/assets/30603497/7568f016-07ea-44ce-ab9e-c46e67d77073">

### Create a JWT to read weather data
Go to the root folder of the API:

<img width="550" alt="image" src="https://github.com/affableashish/blazor-api-auth0/assets/30603497/1a7cf79e-41b9-4d15-b411-e4c0ef7f3123">

Run the following command:
`dotnet user-jwts create --claim permissions=read:weather`
<img width="850" alt="image" src="https://github.com/affableashish/blazor-api-auth0/assets/30603497/d31c5077-5be1-416b-b327-2ed795e9c065">

Take note of the identifier of the newly created JWT(b6290aa1).
The second line displays your username on the current machine. This is the user the JWT is issued to.
The third line shows the token's actual content. Take note of it.

### Infrastructure setup
When I ran that command, the tool added `UserSecretsId` to my `.csproj` and modified my `appsettings.Development.json`:
<img width="700" alt="image" src="https://github.com/affableashish/blazor-api-auth0/assets/30603497/a9e4f753-34dc-4355-8b2f-a2e02dc7e05e">
<img width="700" alt="image" src="https://github.com/affableashish/blazor-api-auth0/assets/30603497/830319f1-9a93-46c4-83bd-38073fa37d42">

A storage is created in your local machine's user profile folder and its identifier is added to your .NET project for future reference.
Valid audience has the url of my API. Audience is the API the token is meant for.

Keep in mind that the tokens issues by `user-jwts` tool are meant to be used only in your development envionment for testing purposes.

### Use the token to read weather data from the API
<img width="450" alt="image" src="https://github.com/affableashish/blazor-api-auth0/assets/30603497/9b7cf622-50d6-4e26-b1da-5b0e6082306c">

### Display Issued Tokens
<img width="850" alt="image" src="https://github.com/affableashish/blazor-api-auth0/assets/30603497/9d71c348-40df-4b6a-ab35-58abb3c6d673">

To learn more about an issued JWT, take note of its identifier and run a command like this:
`dotnet user-jwts print b6290aa1 --show-all`

To remove the token:
`dotnet user-jwts remove b6290aa1` or `dotnet user-jwts clear`
