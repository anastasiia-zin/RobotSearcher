using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IAuthService
    {
        string GenerateToken(string id, IList<string> roles);
    }
}