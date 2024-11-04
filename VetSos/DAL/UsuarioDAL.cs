using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using VetSos.Models;

namespace VetSos.DAL
{
    public class UsuarioDAL
    {
        private string conexion = ConfigurationManager.ConnectionStrings["ConexionDB"].ConnectionString;

        public List<Usuario> ObtenerUsuarios()
        {
            List<Usuario> lista = new List<Usuario>();
            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Usuarios", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Usuario usuario = new Usuario
                    {
                        UsuarioID = Convert.ToInt32(rdr["UsuarioID"]),
                        Nombre = rdr["Nombre"].ToString(),
                        Apellido = rdr["Apellido"].ToString(),
                        Email = rdr["Email"].ToString(),
                        NombreUsuario = rdr["NombreUsuario"].ToString(),
                        Contraseña = rdr["Contraseña"].ToString(),
                        Rol = rdr["Rol"].ToString(),
                        AdicionadoPor = rdr["AdicionadoPor"].ToString(),
                        FechaAdicion = Convert.ToDateTime(rdr["FechaAdicion"]),
                        ModificadoPor = rdr["ModificadoPor"].ToString(),
                        FechaModificacion = rdr["FechaModificacion"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(rdr["FechaModificacion"]),
                        UsuarioID_AdicionadoPor = rdr["UsuarioID_AdicionadoPor"] == DBNull.Value ? (int?)null : Convert.ToInt32(rdr["UsuarioID_AdicionadoPor"]),
                        UsuarioID_ModificadoPor = rdr["UsuarioID_ModificadoPor"] == DBNull.Value ? (int?)null : Convert.ToInt32(rdr["UsuarioID_ModificadoPor"]),
                    };

                    lista.Add(usuario);
                }
            }
            return lista;
        }

        public void AgregarUsuario(Usuario usuario)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string query = "INSERT INTO Usuarios (Nombre, Apellido, Email, NombreUsuario, Contraseña, Rol, AdicionadoPor, FechaAdicion, UsuarioID_AdicionadoPor) VALUES (@Nombre, @Apellido, @Email, @NombreUsuario, @Contraseña, @Rol, @AdicionadoPor, @FechaAdicion, @UsuarioID_AdicionadoPor)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                cmd.Parameters.AddWithValue("@Email", usuario.Email);
                cmd.Parameters.AddWithValue("@NombreUsuario", usuario.NombreUsuario);
                cmd.Parameters.AddWithValue("@Contraseña", usuario.Contraseña); // Asegúrate de encriptar la contraseña antes de almacenar
                cmd.Parameters.AddWithValue("@Rol", usuario.Rol);
                cmd.Parameters.AddWithValue("@AdicionadoPor", usuario.AdicionadoPor);
                cmd.Parameters.AddWithValue("@FechaAdicion", DateTime.Now);
                cmd.Parameters.AddWithValue("@UsuarioID_AdicionadoPor", (object)usuario.UsuarioID_AdicionadoPor ?? DBNull.Value);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ActualizarUsuario(Usuario usuario)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string query = "UPDATE Usuarios SET Nombre = @Nombre, Apellido = @Apellido, Email = @Email, NombreUsuario = @NombreUsuario, Contraseña = @Contraseña, Rol = @Rol, ModificadoPor = @ModificadoPor, FechaModificacion = @FechaModificacion, UsuarioID_ModificadoPor = @UsuarioID_ModificadoPor WHERE UsuarioID = @UsuarioID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UsuarioID", usuario.UsuarioID);
                cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                cmd.Parameters.AddWithValue("@Email", usuario.Email);
                cmd.Parameters.AddWithValue("@NombreUsuario", usuario.NombreUsuario);
                cmd.Parameters.AddWithValue("@Contraseña", usuario.Contraseña); // Asegúrate de encriptar la contraseña antes de almacenar
                cmd.Parameters.AddWithValue("@Rol", usuario.Rol);
                cmd.Parameters.AddWithValue("@ModificadoPor", usuario.ModificadoPor);
                cmd.Parameters.AddWithValue("@FechaModificacion", DateTime.Now);
                cmd.Parameters.AddWithValue("@UsuarioID_ModificadoPor", (object)usuario.UsuarioID_ModificadoPor ?? DBNull.Value);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public Usuario ObtenerUsuarioPorId(int id)
        {
            Usuario usuario = null;
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string query = "SELECT * FROM Usuarios WHERE UsuarioID = @UsuarioID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UsuarioID", id);
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    usuario = new Usuario
                    {
                        UsuarioID = Convert.ToInt32(rdr["UsuarioID"]),
                        Nombre = rdr["Nombre"].ToString(),
                        Apellido = rdr["Apellido"].ToString(),
                        Email = rdr["Email"].ToString(),
                        NombreUsuario = rdr["NombreUsuario"].ToString(),
                        Contraseña = rdr["Contraseña"].ToString(), // Asegúrate de manejar la contraseña con cuidado
                        Rol = rdr["Rol"].ToString(),
                        AdicionadoPor = rdr["AdicionadoPor"].ToString(),
                        FechaAdicion = Convert.ToDateTime(rdr["FechaAdicion"]),
                        ModificadoPor = rdr["ModificadoPor"].ToString(),
                        FechaModificacion = rdr["FechaModificacion"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(rdr["FechaModificacion"]),
                        UsuarioID_AdicionadoPor = rdr["UsuarioID_AdicionadoPor"] == DBNull.Value ? (int?)null : Convert.ToInt32(rdr["UsuarioID_AdicionadoPor"]),
                        UsuarioID_ModificadoPor = rdr["UsuarioID_ModificadoPor"] == DBNull.Value ? (int?)null : Convert.ToInt32(rdr["UsuarioID_ModificadoPor"]),
                    };
                }
            }
            return usuario;
        }

        public void EliminarUsuario(int id)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string query = "DELETE FROM Usuarios WHERE UsuarioID = @UsuarioID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UsuarioID", id);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}