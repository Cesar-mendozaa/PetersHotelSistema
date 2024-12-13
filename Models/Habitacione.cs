using System;
using System.Collections.Generic;

namespace SistemaApartados.Models;

public partial class Habitacione
{
    public int Id { get; set; }

    public int NumeroHabitacion { get; set; }

    public string? Tipo { get; set; }

    public decimal Precio { get; set; }

    public bool Disponibilidad { get; set; }

    public string? Descripcion { get; set; }

    public int? Capacidad { get; set; }

    public string? Servicios { get; set; }

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
