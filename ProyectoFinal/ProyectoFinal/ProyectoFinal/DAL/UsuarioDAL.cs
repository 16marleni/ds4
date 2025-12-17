using ProyectoFinal.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ProyectoFinal.DAL
{
    public class UsuarioDAL
    {
        string cadena = ConfigurationManager
            .ConnectionStrings["ConexionBibliotecaDB"]
            .ConnectionString;

        // Lista todos los usuarios
        public List<Usuario> Listar()
        {
            List<Usuario> lista = new List<Usuario>();
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("sp_ListarUsuarios", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new Usuario
                    {
                        UsuarioId = (int)dr["UsuarioId"],
                        Nombre = dr["Nombre"].ToString(),
                        Correo = dr["Correo"].ToString(),
                        TipoUsuario = dr["TipoUsuario"].ToString(),
                        FechaRegistro = (DateTime)dr["FechaRegistro"]
                    });
                }
            }
            return lista;
        }

        // Inserta un nuevo usuario
        public void Insertar(Usuario usuario)
        {
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("sp_InsertarUsuario", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                cmd.Parameters.AddWithValue("@Correo", usuario.Correo);
                cmd.Parameters.AddWithValue("@TipoUsuario", usuario.TipoUsuario);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Actualiza un usuario existente
        public void Actualizar(Usuario usuario)
        {
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("sp_ActualizarUsuario", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UsuarioId", usuario.UsuarioId);
                cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                cmd.Parameters.AddWithValue("@Correo", usuario.Correo);
                cmd.Parameters.AddWithValue("@TipoUsuario", usuario.TipoUsuario);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Elimina un usuario por ID
        public void Eliminar(int usuarioId)
        {
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("sp_EliminarUsuario", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UsuarioId", usuarioId);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Obtiene un usuario por ID
        public Usuario ObtenerPorId(int usuarioId)
        {
            Usuario usuario = null;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerUsuarioPorId", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UsuarioId", usuarioId);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    usuario = new Usuario
                    {
                        UsuarioId = (int)dr["UsuarioId"], //dr es el DataReader
                        Nombre = dr["Nombre"].ToString(),
                        Correo = dr["Correo"].ToString(),
                        TipoUsuario = dr["TipoUsuario"].ToString(),
                        FechaRegistro = (DateTime)dr["FechaRegistro"]
                    };
                }
            }
            return usuario;
        }

        // Obtiene un usuario por correo usando el SP
        public Usuario ObtenerUsuarioPorCorreo(string correo)
        {
            Usuario usuario = null;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerUsuarioPorCorreo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Correo", correo);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    usuario = new Usuario
                    {
                        UsuarioId = (int)dr["UsuarioId"],
                        Nombre = dr["Nombre"].ToString(),
                        Correo = dr["Correo"].ToString(),
                        TipoUsuario = dr["TipoUsuario"].ToString(),
                        FechaRegistro = (DateTime)dr["FechaRegistro"]
                    };
                }
            }
            return usuario;
        }

    }
}
