﻿using Obligatorio.LogicaNegocio.InterfacesDominio;
using Obligatorio.LogicaNegocio.Vo.Envio;

namespace Obligatorio.LogicaNegocio.Entidades
{
	public abstract class Envio : IEntity
	{
		public int Id { get; set; }
		public Tracking Tracking { get; set; }
		public Empleado Empleado { get; set; }
		public int EmpleadoId { get; set; }
		public Cliente Cliente { get; set; }
		public int ClienteId { get; set; }
		public Peso Peso { get; set; }
		public Estado? Estado { get; set; }
		public string? Discriminator { get; set; }
		public List<Seguimiento> Seguimientos { get; set; }
		public DateTime? FechaFinalizacion { get; set; }
        public DateTime? FechaCreacion { get; set; }

        public Envio(int id, Tracking tracking, int empleadoId, int clienteId, Peso peso, Estado? estado, List<Seguimiento> seguimientos, DateTime? fechaFinalizacion, DateTime? fechaCreacion)
		{
			Id = id;
			Tracking = tracking;
			EmpleadoId = empleadoId;
			ClienteId = clienteId;
			Estado = estado;
			Peso = peso;
			Seguimientos = seguimientos;
			FechaFinalizacion = fechaFinalizacion;
			FechaCreacion = fechaCreacion;
			Validar();

		}
		protected Envio() { } // Constructor protegido para EF Core

		public void Validar()
		{
		}

		public void Update(Envio obj)
		{
			Estado = obj.Estado;
		}
	}
}
