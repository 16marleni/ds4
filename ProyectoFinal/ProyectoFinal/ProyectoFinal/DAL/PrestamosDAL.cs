using ProyectoFinal.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ProyectoFinal.DAL
{
    public class PrestamosDAL
    {
        private string conexion = ConfigurationManager.ConnectionStrings["ConexionBibliotecaDB"].ConnectionString;

        // Listar todos los préstamos
        public List<Prestamos> Listar()
        {
            List<Prestamos> lista = new List<Prestamos>();

            using (SqlConnection cn = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ListarPrestamos", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new Prestamos
                    {
                        PrestamoId = Convert.ToInt32(dr["PrestamoId"]),
                        UsuarioId = Convert.ToInt32(dr["UsuarioId"]),
                        LibroId = Convert.ToInt32(dr["LibroId"]),
                        Usuario = dr["Usuario"].ToString(),
                        Libro = dr["Libro"].ToString(),
                        FechaPrestamo = Convert.ToDateTime(dr["FechaPrestamo"]),
                        FechaVencimiento = Convert.ToDateTime(dr["FechaVencimiento"]),
                        FechaDevolucion = dr["FechaDevolucion"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FechaDevolucion"]),
                        Estado = dr["Estado"].ToString()
                    });
                }
            }

            return lista;
        }

        // Listar préstamos activos
        public List<Prestamos> ListarActivos()
        {
            List<Prestamos> lista = new List<Prestamos>();

            using (SqlConnection cn = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("sp_PrestamosActivos", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new Prestamos
                    {
                        PrestamoId = Convert.ToInt32(dr["PrestamoId"]),
                        Usuario = dr["Usuario"].ToString(),
                        Libro = dr["Libro"].ToString(),
                        FechaPrestamo = Convert.ToDateTime(dr["FechaPrestamo"]),
                        FechaVencimiento = Convert.ToDateTime(dr["FechaVencimiento"])
                    });
                }
            }

            return lista;
        }

        // Registrar un préstamo
        public void RegistrarPrestamo(int usuarioId, int libroId)
        {
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("sp_RegistrarPrestamo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UsuarioId", usuarioId);
                cmd.Parameters.AddWithValue("@LibroId", libroId);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Obtener préstamo por ID
        public Prestamos ObtenerPorId(int prestamoId)
        {
            Prestamos prestamo = null;

            using (SqlConnection cn = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerPrestamoPorId", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PrestamoId", prestamoId);

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    prestamo = new Prestamos
                    {
                        PrestamoId = Convert.ToInt32(dr["PrestamoId"]),
                        UsuarioId = Convert.ToInt32(dr["UsuarioId"]),
                        LibroId = Convert.ToInt32(dr["LibroId"]),
                        Usuario = dr["Usuario"].ToString(),
                        Libro = dr["Libro"].ToString(),
                        FechaPrestamo = Convert.ToDateTime(dr["FechaPrestamo"]),
                        FechaVencimiento = Convert.ToDateTime(dr["FechaVencimiento"]),
                        FechaDevolucion = dr["FechaDevolucion"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FechaDevolucion"]),
                        Estado = dr["Estado"].ToString()
                    };
                }
            }

            return prestamo;
        }

        // Devolver libro
        public void DevolverLibro(int prestamoId)
        {
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("sp_DevolverLibro", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PrestamoId", prestamoId);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Eliminar préstamo
        public void Eliminar(int prestamoId)
        {
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("sp_EliminarPrestamo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PrestamoId", prestamoId);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Listar préstamos de un usuario específico
        public List<Prestamos> ListarPorUsuario(int usuarioId)
        {
            List<Prestamos> lista = new List<Prestamos>();

            using (SqlConnection cn = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ListarPrestamos", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    // Solo agregar los préstamos que coincidan con el usuarioId
                    if (Convert.ToInt32(dr["UsuarioId"]) == usuarioId)
                    {
                        lista.Add(new Prestamos
                        {
                            PrestamoId = Convert.ToInt32(dr["PrestamoId"]),
                            UsuarioId = Convert.ToInt32(dr["UsuarioId"]),
                            LibroId = Convert.ToInt32(dr["LibroId"]),
                            Usuario = dr["Usuario"].ToString(),
                            Libro = dr["Libro"].ToString(),
                            FechaPrestamo = Convert.ToDateTime(dr["FechaPrestamo"]),
                            FechaVencimiento = Convert.ToDateTime(dr["FechaVencimiento"]),
                            FechaDevolucion = dr["FechaDevolucion"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FechaDevolucion"]),
                            Estado = dr["Estado"].ToString()
                        });
                    }
                }
            }

            return lista;
        }

    }
}
