using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ExpenseTracker.Model
{
    public class JwtHelper
    {
        private readonly string _issuer;
        private readonly string _audience;
        private readonly string _secretKey;
        private readonly int _expiryMinutes;

        public JwtHelper(IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("JwtSettings");
            _issuer = jwtSettings["Issuer"];
            _audience = jwtSettings["Audience"];
            _secretKey = jwtSettings["SecretKey"];
            _expiryMinutes = int.Parse(jwtSettings["ExpiryMinutes"] ?? "30");
        }

        // Generate a JWT token
        public string GenerateToken(IEnumerable<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_expiryMinutes),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        public ClaimsPrincipal? ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_secretKey);

            try
            {
                var parameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true, // Automatically checks token expiration

                    ValidIssuer = _issuer,
                    ValidAudience = _audience,
                    IssuerSigningKey = new SymmetricSecurityKey(key),

                    // Optional: Removes 5 minutes default clock skew (you can adjust as needed)
                    ClockSkew = TimeSpan.Zero
                };

                // Validate the token and get the claims principal
                var principal = tokenHandler.ValidateToken(token, parameters, out var validatedToken);

                // Check token type and validity
                if (validatedToken is JwtSecurityToken jwtToken &&
                    jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                {
                    return principal;
                }

                return null; // Return null if token is not a valid JWT or has invalid signature
            }
            catch (SecurityTokenExpiredException)
            {
                // Token has expired
                // Optionally log the expiration or handle it differently
                return null; // Return null for expired token
            }
            catch (SecurityTokenException ex)
            {
                // This will handle other security token exceptions, such as invalid signature, etc.
                // Optionally log the exception or provide more details
                Console.WriteLine($"Security Token Error: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                // Catch any other general exceptions
                Console.WriteLine($"Token validation failed: {ex.Message}");
                return null;
            }
        }
        public bool IsTokenExpired(string token)
        {
            if (string.IsNullOrEmpty(token)) return true;

            var jwtHandler = new JwtSecurityTokenHandler();
            if (!jwtHandler.CanReadToken(token)) return true;

            var jwtToken = jwtHandler.ReadJwtToken(token);
            var expiryDate = jwtToken.ValidTo;

            return expiryDate < DateTime.UtcNow;
        }
    }
}
