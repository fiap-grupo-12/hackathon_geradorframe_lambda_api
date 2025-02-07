using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAP.Hackathon.GeradorFrame.Lambda.Application.Services.Interfaces
{
    public interface IJwtService
    {
        string GetEmail(string jwtToken);
    }
}
