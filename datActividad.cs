using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidades;

namespace CapaAccesoDatos
{
    public class DatActividad
    {
        private static readonly DatActividad _instancia = new DatActividad();

        public static DatActividad Instancia
        {
            get
            {
                return _instancia;
            }
        }

        private DatActividad() { }

        public List<Actividad> ListarActividades()
        {
            List<Actividad> lista = new List<Actividad>();
            SqlConnection cn = Conexion.Instancia.Conectar();
            try
            {
                SqlCommand cmd = new SqlCommand("spListarActividades", cn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Actividad actividad = new Actividad
                    {
                        IdActividad = Convert.ToInt32(dr["IdActividad"]),
                        IdEmpleado = Convert.ToInt32(dr["IdEmpleado"]),
                        Nombres = dr["Nombres"].ToString(),
                        Apellidos = dr["Apellidos"].ToString(),
                        DocumentoIdentidad = dr["DocumentoIdentidad"].ToString(),
                        TipoDocumento = dr["TipoDocumento"].ToString(),
                        TipoParticipante = dr["TipoParticipante"].ToString(),
                        Celular = dr["Celular"].ToString(),
                        Correo = dr["Correo"].ToString(),
                        Estado = Convert.ToBoolean(dr["Estado"])
                    };
                    lista.Add(actividad);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
            return lista;
        }

        public bool InsertarActividad(Actividad actividad)
        {
            SqlConnection cn = Conexion.Instancia.Conectar();
            try
            {
                SqlCommand cmd = new SqlCommand("spInsertarActividad", cn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@IdEmpleado", actividad.IdEmpleado);
                cmd.Parameters.AddWithValue("@Nombres", actividad.Nombres);
                cmd.Parameters.AddWithValue("@Apellidos", actividad.Apellidos);
                cmd.Parameters.AddWithValue("@DocumentoIdentidad", actividad.DocumentoIdentidad);
                cmd.Parameters.AddWithValue("@TipoDocumento", actividad.TipoDocumento);
                cmd.Parameters.AddWithValue("@TipoParticipante", actividad.TipoParticipante);
                cmd.Parameters.AddWithValue("@Celular", actividad.Celular);
                cmd.Parameters.AddWithValue("@Correo", actividad.Correo);
                cmd.Parameters.AddWithValue("@Estado", actividad.Estado);

                cn.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                cn.Close();
            }
        }

        public bool ActualizarActividad(Actividad actividad)
        {
            SqlConnection cn = Conexion.Instancia.Conectar();
            try
            {
                SqlCommand cmd = new SqlCommand("spActualizarActividad", cn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@IdActividad", actividad.IdActividad);
                cmd.Parameters.AddWithValue("@IdEmpleado", actividad.IdEmpleado);
                cmd.Parameters.AddWithValue("@Nombres", actividad.Nombres);
                cmd.Parameters.AddWithValue("@Apellidos", actividad.Apellidos);
                cmd.Parameters.AddWithValue("@DocumentoIdentidad", actividad.DocumentoIdentidad);
                cmd.Parameters.AddWithValue("@TipoDocumento", actividad.TipoDocumento);
                cmd.Parameters.AddWithValue("@TipoParticipante", actividad.TipoParticipante);
                cmd.Parameters.AddWithValue("@Celular", actividad.Celular);
                cmd.Parameters.AddWithValue("@Correo", actividad.Correo);
                cmd.Parameters.AddWithValue("@Estado", actividad.Estado);

                cn.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                cn.Close();
            }
        }

        public bool EliminarActividad(int idActividad)
        {
            SqlConnection cn = Conexion.Instancia.Conectar();
            try
            {
                SqlCommand cmd = new SqlCommand("spEliminarActividad", cn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@IdActividad", idActividad);

                cn.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                cn.Close();
            }
        }
    }
}
