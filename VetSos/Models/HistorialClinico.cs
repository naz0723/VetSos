using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VetSos.Models
{
    public class HistorialClinico
    {
            public int HistorialID { get; set; }
            public DateTime FechaVisita { get; set; }
            public string Sintomas { get; set; }
            public string Diagnostico { get; set; }
            public string Tratamiento { get; set; }
            public string Veterinario { get; set; }
            public int MascotaID { get; set; }
            public string AdicionadoPor { get; set; }
            public DateTime FechaAdicion { get; set; }
            public string ModificadoPor { get; set; }
            public DateTime? FechaModificacion { get; set; }

            // Relación con Mascota
            public Mascota Mascota { get; set; }
        }
    }