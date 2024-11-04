using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VetSos.Models
{
    public class Mascota
    {
            public int MascotaID { get; set; }
            public string Nombre { get; set; }
            public string Especie { get; set; }
            public string Raza { get; set; }
            public DateTime? FechaNacimiento { get; set; }
            public string Color { get; set; }
            public double Peso { get; set; }
            public int DueñoID { get; set; }
            public string AdicionadoPor { get; set; }
            public DateTime FechaAdicion { get; set; }
            public string ModificadoPor { get; set; }
            public DateTime? FechaModificacion { get; set; }

            // Relación con Dueño
            public Dueño Dueño { get; set; }

            // Relación: una mascota puede tener varios registros de historial clínico
            public ICollection<HistorialClinico> HistorialClinico { get; set; }
        }
    }
