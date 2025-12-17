using ProyectoFinal.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ProyectoFinal.DAL
{
    public class ResenasDAL
    {
        private string cadena = ConfigurationManager
            .ConnectionStrings["ConexionBibliotecaDB"]
            .ConnectionString;

        // Listar todas las reseñas
        public List<Resenas> Listar()
        {
            List<Resenas> lista = new List<Resenas>();

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("sp_ListarResenas", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new Resenas
                    {
                        ResenaId = (int)dr["ResenaId"],
                        LibroId = (int)dr["LibroId"],
                        Libro = dr["Libro"].ToString(),
                        Comentario = dr["Comentario"].ToString(),
                        Calificacion = (int)dr["Calificacion"],
                        Fecha = (DateTime)dr["Fecha"],
                        UsuarioId = (int)dr["UsuarioId"],
                        Usuario = dr["Usuario"].ToString()

                    });
                }
            }

            return lista;
        }

        // Obtener reseña por ID
        public Resenas ObtenerPorId(int resenaId)
        {
            Resenas resena = null;

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerResenaPorId", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ResenaId", resenaId);

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    resena = new Resenas
                    {
                        ResenaId = (int)dr["ResenaId"],
                        LibroId = (int)dr["LibroId"],
                        Libro = dr["Libro"].ToString(),
                        Comentario = dr["Comentario"].ToString(),
                        Calificacion = (int)dr["Calificacion"],
                        Fecha = (DateTime)dr["Fecha"],
                        UsuarioId = (int)dr["UsuarioId"],
                        Usuario = dr["Usuario"].ToString()

                    };
                }
            }

            return resena;
        }

        // Insertar nueva reseña
        public void Insertar(int libroId, string comentario, int calificacion, int usuarioId)
        {
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("sp_InsertarResena", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LibroId", libroId);
                cmd.Parameters.AddWithValue("@Comentario", comentario);
                cmd.Parameters.AddWithValue("@Calificacion", calificacion);
                cmd.Parameters.AddWithValue("@UsuarioId", usuarioId);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Actualizar reseña
        public void Actualizar(int resenaId, string comentario, int calificacion)
        {
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("sp_ActualizarResena", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ResenaId", resenaId);
                cmd.Parameters.AddWithValue("@Comentario", comentario);
                cmd.Parameters.AddWithValue("@Calificacion", calificacion);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Eliminar reseña
        public void Eliminar(int resenaId)
        {
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("sp_EliminarResena", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ResenaId", resenaId);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }



    }
}
