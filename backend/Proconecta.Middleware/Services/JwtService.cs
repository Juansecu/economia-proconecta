namespace Proconecta.Middleware.Services
{
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using Proconecta.Data;
    using Proconecta.Data.DTO;
    using Proconecta.Middleware.Interfaces;

    public class JwtService : IJwtService
    {
        #region Attributes
        private readonly string JWT_ISSUER;
        private readonly string JWT_AUDIENCE;
        private readonly string JWT_SIGNING_KEY;
        private readonly int JWT_EXPIRES;
        #endregion

        #region Constructors
        public JwtService(IConfiguration config)
        {
            JWT_ISSUER = config["Jwt:Issuer"];
            JWT_AUDIENCE = config["Jwt:Audience"];
            JWT_SIGNING_KEY = config["Jwt:SigningKey"];
            JWT_EXPIRES = config.GetValue<int>("Jwt:ExpiresMinutes");
        }
        #endregion

        #region Public Methods
        public string GenerateJSONWebToken(UserDTO user)
        {
            // Assign claims.
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, user.FirstName),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role),
            };

            // Credentials and security key.
            var securityKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(JWT_SIGNING_KEY));
            var credentials = new SigningCredentials(securityKey,
                    SecurityAlgorithms.HmacSha256);

            // JWT.
            var token = new JwtSecurityToken(
                issuer: JWT_ISSUER,
                audience: JWT_AUDIENCE,
                claims: claims,
                expires: DateTime.Now.AddMinutes(JWT_EXPIRES),
                signingCredentials: credentials
                ); ;

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        #endregion

    }
}
