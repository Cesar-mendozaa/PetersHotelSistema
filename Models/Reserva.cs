using System;
using System.Collections.Generic;

namespace SistemaApartados.Models;

public partial class Reserva
{
    public int Id { get; set; }

    public int? HabitacionId { get; set; }

    public int? UsuarioId { get; set; }

    public DateTime FechaInicio { get; set; }

    public DateTime FechaFin { get; set; }

    public string? Estado { get; set; }

    public decimal PrecioTotal { get; set; }

    public DateOnly? FechaReserva { get; set; }

    public virtual Habitacione? Habitacion { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
