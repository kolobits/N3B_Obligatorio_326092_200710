﻿using Obligatorio.LogicaNegocio.Vo.Usuario;

namespace Obligatorio.LogicaNegocio.Entidades
{
	public class Cliente : Usuario
	{
		public Cliente(int id, NombreCompleto nombreCompleto, Email email, Password password) : base(id, nombreCompleto, email, password)
		{
		}

		protected Cliente() { }
	}
}
