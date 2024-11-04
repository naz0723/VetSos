using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using VetSos.Models;

namespace VetSos.DAL
{
    public class MascotaDAL
    {
        private string conexion = ConfigurationManager.ConnectionStrings["ConexionDB"].ConnectionString;

        public List<Mascota> ObtenerMascotas()
        {
            List<Mascota> lista = new List<Mascota>();
            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Mascotas", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Mascota mascota = new Mascota
                    {
                        MascotaID = Convert.ToInt32(rdr["MascotaID"]),
                        Nombre = rdr["Nombre"].ToString(),
                        Especie = rdr["Especie"].ToString(),
                        Raza = rdr["Raza"].ToString(),
                        FechaNacimiento = rdr["FechaNacimiento"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(rdr["FechaNacimiento"]),
                        Color = rdr["Color"].ToString(),
                        Peso = Convert.ToDouble(rdr["Peso"]),
                        DueñoID = Convert.ToInt32(rdr["DueñoID"]),
                        AdicionadoPor = rdr["AdicionadoPor"].ToString(),
                        FechaAdicion = Convert.ToDateTime(rdr["FechaAdicion"]),
                        ModificadoPor = rdr["ModificadoPor"].ToString(),
                        FechaModificacion = rdr["FechaModificacion"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(rdr["FechaModificacion"])
                    };

                    lista.Add(mascota);
                }
            }
            return lista;
        }

        public void AgregarMascota(Mascota mascota)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string query = "INSERT INTO Mascotas (Nombre, Especie, Raza, FechaNacimiento, Color, Peso, DueñoID, AdicionadoPor, FechaAdicion) VALUES (@Nombre, @Especie, @Raza, @FechaNacimiento, @Color, @Peso, @DueñoID, @AdicionadoPor, @FechaAdicion)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Nombre", mascota.Nombre);
                cmd.Parameters.AddWithValue("@Especie", mascota.Especie);
                cmd.Parameters.AddWithValue("@Raza", mascota.Raza);
                cmd.Parameters.AddWithValue("@FechaNacimiento", (object)mascota.FechaNacimiento ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Color", mascota.Color);
                cmd.Parameters.AddWithValue("@Peso", mascota.Peso);
                cmd.Parameters.AddWithValue("@DueñoID", mascota.DueñoID);
                cmd.Parameters.AddWithValue("@AdicionadoPor", mascota.AdicionadoPor);
                cmd.Parameters.AddWithValue("@FechaAdicion", DateTime.Now);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ActualizarMascota(Mascota mascota)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string query = "UPDATE Mascotas SET Nombre = @Nombre, Especie = @Especie, Raza = @Raza, FechaNacimiento = @FechaNacimiento, Color = @Color, Peso = @Peso, DueñoID = @DueñoID, ModificadoPor = @ModificadoPor, FechaModificacion = @FechaModificacion WHERE MascotaID = @MascotaID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@MascotaID", mascota.MascotaID);
                cmd.Parameters.AddWithValue("@Nombre", mascota.Nombre);
                cmd.Parameters.AddWithValue("@Especie", mascota.Especie);
                cmd.Parameters.AddWithValue("@Raza", mascota.Raza);
                cmd.Parameters.AddWithValue("@FechaNacimiento", (object)mascota.FechaNacimiento ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Color", mascota.Color);
                cmd.Parameters.AddWithValue("@Peso", mascota.Peso);
                cmd.Parameters.AddWithValue("@DueñoID", mascota.DueñoID);
                cmd.Parameters.AddWithValue("@ModificadoPor", mascota.ModificadoPor);
                cmd.Parameters.AddWithValue("@FechaModificacion", DateTime.Now);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public Mascota ObtenerMascotaPorId(int id)
        {
            Mascota mascota = null;
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string query = "SELECT * FROM Mascotas WHERE MascotaID = @MascotaID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@MascotaID", id);
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    mascota = new Mascota
                    {
                        MascotaID = Convert.ToInt32(rdr["MascotaID"]),
                        Nombre = rdr["Nombre"].ToString(),
                        Especie = rdr["Especie"].ToString(),
                        Raza = rdr["Raza"].ToString(),
                        FechaNacimiento = rdr["FechaNacimiento"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(rdr["FechaNacimiento"]),
                        Color = rdr["Color"].ToString(),
                        Peso = Convert.ToDouble(rdr["Peso"]),
                        DueñoID = Convert.ToInt32(rdr["DueñoID"]),
                        AdicionadoPor = rdr["AdicionadoPor"].ToString(),
                        FechaAdicion = Convert.ToDateTime(rdr["FechaAdicion"]),
                        ModificadoPor = rdr["ModificadoPor"].ToString(),
                        FechaModificacion = rdr["FechaModificacion"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(rdr["FechaModificacion"])
                    };
                }
            }
            return mascota;
        }

        public void EliminarMascota(int id)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string query = "DELETE FROM Mascotas WHERE MascotaID = @MascotaID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@MascotaID", id);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
