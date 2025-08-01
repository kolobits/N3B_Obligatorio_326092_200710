﻿namespace Obligatorio.WebApi.Services
{
	public class JwtSettings
	{
		public string Key { get; set; }
		public string Issuer { get; set; }
		public string Audience { get; set; }
		public int ExpirationMinutes { get; set; } = 60;
	}
}
