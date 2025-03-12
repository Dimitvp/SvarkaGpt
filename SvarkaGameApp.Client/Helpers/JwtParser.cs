using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;

namespace SvarkaGameApp.Client.Helpers
{
    public static class JwtParser
    {
        // Method to extract username or any claim from the JWT token
        public static string? GetUsernameFromJwt(string jwtToken)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(jwtToken);

            // Extract the username from the JWT token claims
            return jwt.Claims.FirstOrDefault(c => c.Type == "name")?.Value;
        }

        // Method to extract a specific claim
        public static string? GetClaimFromJwt(string jwtToken, string claimType)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(jwtToken);

            // Extract specific claim
            return jwt.Claims.FirstOrDefault(c => c.Type == claimType)?.Value;
        }

        // ✅ New Method: Parse claims from a JWT token
        public static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var payload = jwt.Split('.')[1];  // Get the payload part of the JWT
            var jsonBytes = ParseBase64WithoutPadding(payload);  // Decode from Base64
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

            // Extract claims
            return keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString() ?? ""));
        }

        // Helper method to decode Base64 with or without padding
        private static byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }
    }
}
