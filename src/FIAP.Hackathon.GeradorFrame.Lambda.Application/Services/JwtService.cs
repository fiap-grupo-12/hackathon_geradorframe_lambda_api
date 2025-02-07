using FIAP.Hackathon.GeradorFrame.Lambda.Application.Services.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAP.Hackathon.GeradorFrame.Lambda.Application.Services
{
    public class JwtService : IJwtService
    {
        public string GetEmail(string jwtToken)
        {
            jwtToken = jwtToken.Replace("Bearer ", "");

            var handler = new JwtSecurityTokenHandler();
            if (!handler.CanReadToken(jwtToken))
            {
                return null;
            }

            string email = string.Empty;
            var jsonToken = handler.ReadJwtToken(jwtToken);
            var payload = jsonToken.Payload;

            foreach (var item in payload)
            {
                if (item.Key == "email")
                    email =  item.Value.ToString();
            }
            return email;
        }
    }
}
