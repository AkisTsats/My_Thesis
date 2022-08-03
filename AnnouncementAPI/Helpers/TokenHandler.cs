using System.IdentityModel.Tokens.Jwt;
using DTOs.Data;
using Microsoft.AspNetCore.Http;

namespace AnnouncementAPI.Helpers
{
    public class TokenHandler
    {
        //TODO find field name of userid and set dummy jwt for testing
        public TokenDTO myHandler(HttpRequest Request)
        {
            var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJ0cm9sQG1haWwuY29tIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.y17qvQLeqxvmxoslLPD7dcHfJCG3VCF9ga7BF3namSE";
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            var toReturn = new TokenDTO
            {
                UserID = jwtSecurityToken.Subject
            };
            return toReturn;
            
        }
    }
}
