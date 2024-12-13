using System;
using System.Collections.Generic;

namespace SistemaApartados.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? CorreoElectronico { get; set; }

    public string? Contrasena { get; set; }

    public string? Rol { get; set; }

    public string? Telefono { get; set; }

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
