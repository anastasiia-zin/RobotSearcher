using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Services.Interfaces;
using Settings;

namespace Services
{
    public class AuthService : IAuthService
    {
        private readonly AuthSettings _settings;

        public AuthService(IOptions<AuthSettings> settings)
        {
            _settings = settings.Value;
        }

        private ClaimsIdentity GetIdentity(string id, IList<string> roles)
        {
            var claims = new List<Claim>
            {
                new(ClaimsIdentity.DefaultNameClaimType, id),
            };
            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));
            var claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
            return claimsIdentity;
        }

        public string GenerateToken(string id, IList<string> roles)
        {
            var identity = GetIdentity(id, roles);
            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                _settings.Issuer,
                audience: _settings.Audience,
                notBefore: now,
                claims: identity.Claims,
                expires: DateTime.UtcNow.AddDays(_settings.LifeTimeDays),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Key)),
                    SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}