using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Obligatorio.CasoDeUsoCompartida.DTOs.Usuarios;
using Obligatorio.CasoDeUsoCompartida.InterfacesCU.Usuario;

namespace Obligatorio.WebApi.Services
{
	public class JwtGenerator : IJwtGenerator
	{

		private readonly JwtSettings _settings;

		public JwtGenerator(JwtSettings settings)
		{
			_settings = settings;
		}

		public string GenerateToken(UsuarioListadoDto usuario)
		{
			var key = Encoding.UTF8.GetBytes(_settings.Key);

			var claims = new[]
			{
				new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
				new Claim("id", usuario.Id.ToString()),
				new Claim(ClaimTypes.Role, "cliente")
			};

			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(claims),
				Expires = DateTime.UtcNow.AddMinutes(_settings.ExpirationMinutes),
				SigningCredentials = new SigningCredentials(
					new SymmetricSecurityKey(key),
					SecurityAlgorithms.HmacSha256Signature),
			};



			var tokenHandler = new JwtSecurityTokenHandler();
			var token = tokenHandler.CreateToken(tokenDescriptor);

			return tokenHandler.WriteToken(token);
		}

	}
}




