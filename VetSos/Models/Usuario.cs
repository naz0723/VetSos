using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VetSos.Models
{
    public class Usuario
    {
            public int UsuarioID { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string Email { get; set; }
            public string NombreUsuario { get; set; }
            public string Contraseña { get; set; }
            public string Rol { get; set; }
            public string AdicionadoPor { get; set; }
            public DateTime FechaAdicion { get; set; }
            public string ModificadoPor { get; set; }
            public DateTime? FechaModificacion { get; set; }
            public int? UsuarioID_AdicionadoPor { get; set; }
            public int? UsuarioID_ModificadoPor { get; set; }

            // Relaciones opcionales para referencia a quien añadió o modificó este usuario
            public Usuario UsuarioAdicionadoPor { get; set; }
            public Usuario UsuarioModificadoPor { get; set; }
        }
    }
