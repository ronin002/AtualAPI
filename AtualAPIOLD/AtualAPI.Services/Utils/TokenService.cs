using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;
using System.Text;



using AtualAPI.Models;
using AtualAPI.Dtos;
using Newtonsoft.Json;

using JsonSerializer = System.Text.Json.JsonSerializer;
using Microsoft.Extensions.Configuration;
using AtualAPI.Models.Dtos;

namespace AtualAPI.Utils
{
    public static class TokenService
    {

        public static string GenerateToken(UserModel user, List<Role> roles)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile($"appsettings.json");

            var config = configuration.Build();
            //var connectionString = config.GetConnectionString("ConnectionString");
            //var keyJwt = config.GetValue<string>("JwtKey");
            
            var json = JsonSerializer.Serialize(roles);
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(UtilsSecurity.JWT_KEY);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Email, user.Email),
                    //new Claim(ClaimTypes.GroupSid, user.CompanyId.ToString()),
                    new Claim(ClaimTypes.Sid, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, json)

                }),

                Expires = DateTime.UtcNow.AddHours(8),

                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public static bool HasRole(ClaimsIdentity identity, ELevelAccess levelAccess, ETypeAccess eTypeAccess, Guid CompanyId)
        {
            //IEnumerable<Claim> claims = identity.Claims;
            // or
            //string baseClain = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/";
            string baseClain = "http://schemas.microsoft.com/ws/2008/06/identity/claims/";
            var clains = identity.Claims;
            foreach (var claim in clains)
            {
                if (claim.Type == baseClain + "sid")
                {

                }

                if (claim.Type == baseClain + "role")
                {
                    var roleClain = claim.Value;
                    if (!string.IsNullOrEmpty(roleClain))
                    {

                        List<Role> roles = new List<Role>();
                        try
                        {
                            roles = JsonConvert.DeserializeObject<List<Role>>(roleClain);
                        }
                        catch (Exception)
                        {
                            roles = null;
                            //throw;
                        }

                        if (roles != null)
                        {
                            foreach (Role role in roles)
                            {
                                switch (eTypeAccess)
                                {
                                    case ETypeAccess.LevelRoles:
                                        if (role.LevelRoles >= levelAccess)
                                            return true;
                                        break;
                                    case ETypeAccess.LevelProcess:
                                        if (role.LevelProcess >= levelAccess)
                                            return true;
                                        break;
                                    case ETypeAccess.LevelUsers:
                                        if (role.LevelUsers >= levelAccess)
                                            return true;
                                        break;
                                    case ETypeAccess.LevelOperations:
                                        if (role.LevelOperations >= levelAccess)
                                            return true;
                                        break;
                                    case ETypeAccess.LevelDashBoard:
                                        if (role.LevelDashBoard >= levelAccess)
                                            return true;
                                        break;
                                    case ETypeAccess.LevelAdmin:
                                        if (role.LevelAdmin >= levelAccess)
                                            return true;
                                        break;
                                    case ETypeAccess.LevelStations:
                                        if (role.LevelStations >= levelAccess)
                                            return true;
                                        break;
                                    case ETypeAccess.LevelWorkFlows:
                                        if (role.LevelWorkFlows >= levelAccess)
                                            return true;
                                        break;
                                }
                                
                            }
                        }

                        break;
                    }
                }
            }

            //var roleAccess = identity.FindFirst("sid").Value;
            //var rolesAccess = identity.FindFirst("role").Value;

            return false;
        }
    }
}
