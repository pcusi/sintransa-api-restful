using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using Microsoft.IdentityModel.Tokens;
using sintransa_api_restful.DTO.Requests.Token;
using sintransa_api_restful.DTO.Responses.Token;
using sintransa_api_restful.Models;
using sintransa_api_restful.Resources;

namespace sintransa_api_restful.Controllers
{
    public class TokenController : AppController
    {

        public TokenController(SintransaDbContext db, IConfiguration config, IStringLocalizer<SharedResource> stringLocalizer) : base (db, config, stringLocalizer) { }

        [HttpPost("acceder")]
        public async Task<TokenResponse> Acceder([FromBody] AccederRequest request)
        {
            string token = null;

            var usuario = await _db.Usuarios.Where(u => u.Usuario == request.Usuario).SingleOrDefaultAsync();

            if (usuario != null)
            {

                var autenticado = BCrypt.Net.BCrypt.Verify(request.Clave, usuario.Clave);

                if (autenticado)
                {
                    var secretKey = _config.GetValue<string>("SecretKey");
                    var key = Encoding.ASCII.GetBytes(secretKey);
                    var claims = new ClaimsIdentity();
                    claims.AddClaim(new Claim("Id", usuario.Id.ToString()));

                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = claims,
                        Expires = DateTime.UtcNow.AddDays(30),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };

                    var tokenHandler = new JwtSecurityTokenHandler();
                    var createdToken = tokenHandler.CreateToken(tokenDescriptor);
                    token = tokenHandler.WriteToken(createdToken);
                }
                else
                {
                    throw Error(_stringLocalizer["ClaveError"], 403);
                }
            }
            else
            {
                throw Error(_stringLocalizer["UsuarioNoEncontrado"], 400);
            }

            return new TokenResponse
            {
                Token = token
            };

        }
    }
}
