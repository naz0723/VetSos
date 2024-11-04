using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VetSos.Models
{
    public class Dueño
    {
            public int DueñoID { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string Direccion { get; set; }
            public string Telefono { get; set; }
            public string Email { get; set; }
            public string Identificacion { get; set; }
            public string AdicionadoPor { get; set; }
            public DateTime FechaAdicion { get; set; }
            public string ModificadoPor { get; set; }
            public DateTime? FechaModificacion { get; set; }

            // Relación: un dueño puede tener varias mascotas
            public ICollection<Mascota> Mascotas { get; set; }
        }
    }
}
