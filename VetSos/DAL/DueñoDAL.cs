using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using VetSos.Models;

namespace VetSos.DAL
{

    //Método para obtener todos los estudiantes//
    public class DueñoDAL

    {
        private string conexion = ConfigurationManager.ConnectionStrings["ConexionDB"].ConnectionString;

        public List<Dueño> ObtenerDueños()
        {
            List<Dueño> lista = new List<Dueño>();
            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Dueños", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Dueño dueno = new Dueño
                    {
                        DueñoID = Convert.ToInt32(rdr["DueñoID"]),
                        Nombre = rdr["Nombre"].ToString(),
                        Apellido = rdr["Apellido"].ToString(),
                        Direccion = rdr["Direccion"].ToString(),
                        Telefono = rdr["Telefono"].ToString(),
                        Email = rdr["Email"].ToString(),
                        Identificacion = rdr["Identificacion"].ToString(),
                        AdicionadoPor = rdr["AdicionadoPor"].ToString(),
                        FechaAdicion = Convert.ToDateTime(rdr["FechaAdicion"]),
                        ModificadoPor = rdr["ModificadoPor"].ToString(),
                        FechaModificacion = rdr["FechaModificacion"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(rdr["FechaModificacion"])
                    };

                    lista.Add(dueno);
                }
            }
            return lista;
        }

        public void AgregarDueño(Dueño dueno)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string query = "INSERT INTO Dueños (Nombre, Apellido, Direccion, Telefono, Email, Identificacion, AdicionadoPor, FechaAdicion) VALUES (@Nombre, @Apellido, @Direccion, @Telefono, @Email, @Identificacion, @AdicionadoPor, @FechaAdicion)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Nombre", dueno.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", dueno.Apellido);
                cmd.Parameters.AddWithValue("@Direccion", dueno.Direccion);
                cmd.Parameters.AddWithValue("@Telefono", dueno.Telefono);
                cmd.Parameters.AddWithValue("@Email", dueno.Email);
                cmd.Parameters.AddWithValue("@Identificacion", dueno.Identificacion);
                cmd.Parameters.AddWithValue("@AdicionadoPor", dueno.AdicionadoPor);
                cmd.Parameters.AddWithValue("@FechaAdicion", DateTime.Now);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ActualizarDueño(Dueño dueno)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string query = "UPDATE Dueños SET Nombre = @Nombre, Apellido = @Apellido, Direccion = @Direccion, Telefono = @Telefono, Email = @Email, Identificacion = @Identificacion, ModificadoPor = @ModificadoPor, FechaModificacion = @FechaModificacion WHERE DueñoID = @DueñoID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@DueñoID", dueno.DueñoID);
                cmd.Parameters.AddWithValue("@Nombre", dueno.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", dueno.Apellido);
                cmd.Parameters.AddWithValue("@Direccion", dueno.Direccion);
                cmd.Parameters.AddWithValue("@Telefono", dueno.Telefono);
                cmd.Parameters.AddWithValue("@Email", dueno.Email);
                cmd.Parameters.AddWithValue("@Identificacion", dueno.Identificacion);
                cmd.Parameters.AddWithValue("@ModificadoPor", dueno.ModificadoPor);
                cmd.Parameters.AddWithValue("@FechaModificacion", DateTime.Now);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public Dueño ObtenerDueñoPorId(int id)
        {
            Dueño dueno = null;
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string query = "SELECT * FROM Dueños WHERE DueñoID = @DueñoID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@DueñoID", id);
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    dueno = new Dueño
                    {
                        DueñoID = Convert.ToInt32(rdr["DueñoID"]),
                        Nombre = rdr["Nombre"].ToString(),
                        Apellido = rdr["Apellido"].ToString(),
                        Direccion = rdr["Direccion"].ToString(),
                        Telefono = rdr["Telefono"].ToString(),
                        Email = rdr["Email"].ToString(),
                        Identificacion = rdr["Identificacion"].ToString(),
                        AdicionadoPor = rdr["AdicionadoPor"].ToString(),
                        FechaAdicion = Convert.ToDateTime(rdr["FechaAdicion"]),
                        ModificadoPor = rdr["ModificadoPor"].ToString(),
                        FechaModificacion = rdr["FechaModificacion"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(rdr["FechaModificacion"])
                    };
                }
            }
            return dueno;
        }

        public void EliminarDueño(int id)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string query = "DELETE FROM Dueños WHERE DueñoID = @DueñoID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@DueñoID", id);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
