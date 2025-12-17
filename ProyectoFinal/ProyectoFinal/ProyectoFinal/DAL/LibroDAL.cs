using ProyectoFinal.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ProyectoFinal.DAL
{
    public class LibroDAL
    {
        string cadena = ConfigurationManager
            .ConnectionStrings["ConexionBibliotecaDB"]
            .ConnectionString;

        // Lista todos los libros
        public List<Libro> Listar()
        {
            List<Libro> lista = new List<Libro>();
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("sp_ListarLibros", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new Libro
                    {
                        LibroId = (int)dr["LibroId"],
                        Titulo = dr["Titulo"].ToString(),
                        Autor = dr["Autor"].ToString(),
                        Categoria = dr["Categoria"].ToString(),
                        Disponible = (bool)dr["Disponible"],
                        Cantidad = (int)dr["Cantidad"],
                        FechaRegistro = (DateTime)dr["FechaRegistro"]
                    });
                }
            }
            return lista;
        }

        // Lista solo los libros disponibles
        public List<Libro> ListarDisponibles()
        {
            List<Libro> lista = new List<Libro>();
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("sp_LibrosDisponibles", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new Libro
                    {
                        LibroId = (int)dr["LibroId"],
                        Titulo = dr["Titulo"].ToString(),
                        Autor = dr["Autor"].ToString(),
                        Categoria = dr["Categoria"].ToString(),
                        Disponible = (bool)dr["Disponible"],
                        Cantidad = (int)dr["Cantidad"],
                        FechaRegistro = (DateTime)dr["FechaRegistro"]
                    });
                }
            }
            return lista;
        }

        // Inserta un nuevo libro
        public void Insertar(Libro libro)
        {
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("sp_InsertarLibro", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Titulo", libro.Titulo);
                cmd.Parameters.AddWithValue("@Autor", libro.Autor);
                cmd.Parameters.AddWithValue("@Categoria", libro.Categoria);
                cmd.Parameters.AddWithValue("@Cantidad", libro.Cantidad);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Actualiza un libro existente
        public void Actualizar(Libro libro)
        {
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("sp_ActualizarLibro", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LibroId", libro.LibroId);
                cmd.Parameters.AddWithValue("@Titulo", libro.Titulo);
                cmd.Parameters.AddWithValue("@Autor", libro.Autor);
                cmd.Parameters.AddWithValue("@Categoria", libro.Categoria);
                cmd.Parameters.AddWithValue("@Cantidad", libro.Cantidad);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Elimina un libro por ID 
        public void Eliminar(int libroId)
        {
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("sp_EliminarLibro", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LibroId", libroId);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Busca un libro por ID 
        public Libro ObtenerPorId(int libroId)
        {
            Libro libro = null;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerLibroPorId", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LibroId", libroId);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    libro = new Libro
                    {
                        LibroId = (int)dr["LibroId"],
                        Titulo = dr["Titulo"].ToString(),
                        Autor = dr["Autor"].ToString(),
                        Categoria = dr["Categoria"].ToString(),
                        Disponible = (bool)dr["Disponible"],
                        Cantidad = (int)dr["Cantidad"],
                        FechaRegistro = (DateTime)dr["FechaRegistro"]
                    };
                }
            }
            return libro;
        }
    }
}
