using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using VetSos.Models;

namespace VetSos.DAL
{
    public class HistorialClinDAL
    {

        private string conexion = ConfigurationManager.ConnectionStrings["ConexionDB"].ConnectionString;

        public List<HistorialClinico> ObtenerHistorialClinico()
        {
            List<HistorialClinico> lista = new List<HistorialClinico>();
            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM HistorialClinico", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    HistorialClinico historial = new HistorialClinico
                    {
                        HistorialID = Convert.ToInt32(rdr["HistorialID"]),
                        FechaVisita = Convert.ToDateTime(rdr["FechaVisita"]),
                        Sintomas = rdr["Sintomas"].ToString(),
                        Diagnostico = rdr["Diagnostico"].ToString(),
                        Tratamiento = rdr["Tratamiento"].ToString(),
                        Veterinario = rdr["Veterinario"].ToString(),
                        MascotaID = Convert.ToInt32(rdr["MascotaID"]),
                        AdicionadoPor = rdr["AdicionadoPor"].ToString(),
                        FechaAdicion = Convert.ToDateTime(rdr["FechaAdicion"]),
                        ModificadoPor = rdr["ModificadoPor"].ToString(),
                        FechaModificacion = rdr["FechaModificacion"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(rdr["FechaModificacion"]),
                    };

                    lista.Add(historial);
                }
            }
            return lista;
        }

        public void AgregarHistorialClinico(HistorialClinico historial)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string query = "INSERT INTO HistorialClinico (FechaVisita, Sintomas, Diagnostico, Tratamiento, Veterinario, MascotaID, AdicionadoPor, FechaAdicion) VALUES (@FechaVisita, @Sintomas, @Diagnostico, @Tratamiento, @Veterinario, @MascotaID, @AdicionadoPor, @FechaAdicion)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@FechaVisita", historial.FechaVisita);
                cmd.Parameters.AddWithValue("@Sintomas", historial.Sintomas);
                cmd.Parameters.AddWithValue("@Diagnostico", historial.Diagnostico);
                cmd.Parameters.AddWithValue("@Tratamiento", historial.Tratamiento);
                cmd.Parameters.AddWithValue("@Veterinario", historial.Veterinario);
                cmd.Parameters.AddWithValue("@MascotaID", historial.MascotaID);
                cmd.Parameters.AddWithValue("@AdicionadoPor", historial.AdicionadoPor);
                cmd.Parameters.AddWithValue("@FechaAdicion", DateTime.Now);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ActualizarHistorialClinico(HistorialClinico historial)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string query = "UPDATE HistorialClinico SET FechaVisita = @FechaVisita, Sintomas = @Sintomas, Diagnostico = @Diagnostico, Tratamiento = @Tratamiento, Veterinario = @Veterinario, MascotaID = @MascotaID, ModificadoPor = @ModificadoPor, FechaModificacion = @FechaModificacion WHERE HistorialID = @HistorialID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@HistorialID", historial.HistorialID);
                cmd.Parameters.AddWithValue("@FechaVisita", historial.FechaVisita);
                cmd.Parameters.AddWithValue("@Sintomas", historial.Sintomas);
                cmd.Parameters.AddWithValue("@Diagnostico", historial.Diagnostico);
                cmd.Parameters.AddWithValue("@Tratamiento", historial.Tratamiento);
                cmd.Parameters.AddWithValue("@Veterinario", historial.Veterinario);
                cmd.Parameters.AddWithValue("@MascotaID", historial.MascotaID);
                cmd.Parameters.AddWithValue("@ModificadoPor", historial.ModificadoPor);
                cmd.Parameters.AddWithValue("@FechaModificacion", DateTime.Now);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public HistorialClinico ObtenerHistorialClinicoPorId(int id)
        {
            HistorialClinico historial = null;
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string query = "SELECT * FROM HistorialClinico WHERE HistorialID = @HistorialID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@HistorialID", id);
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    historial = new HistorialClinico
                    {
                        HistorialID = Convert.ToInt32(rdr["HistorialID"]),
                        FechaVisita = Convert.ToDateTime(rdr["FechaVisita"]),
                        Sintomas = rdr["Sintomas"].ToString(),
                        Diagnostico = rdr["Diagnostico"].ToString(),
                        Tratamiento = rdr["Tratamiento"].ToString(),
                        Veterinario = rdr["Veterinario"].ToString(),
                        MascotaID = Convert.ToInt32(rdr["MascotaID"]),
                        AdicionadoPor = rdr["AdicionadoPor"].ToString(),
                        FechaAdicion = Convert.ToDateTime(rdr["FechaAdicion"]),
                        ModificadoPor = rdr["ModificadoPor"].ToString(),
                        FechaModificacion = rdr["FechaModificacion"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(rdr["FechaModificacion"]),
                    };
                }
            }
            return historial;
        }

        public void EliminarHistorialClinico(int id)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string query = "DELETE FROM HistorialClinico WHERE HistorialID = @HistorialID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@HistorialID", id);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
