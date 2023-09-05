using PRUEBA_BRAHAN_A_ACOSTA.Models;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Routing.Patterns;

namespace PRUEBA_BRAHAN_A_ACOSTA.Datos
{
    public class PacienteDatos
    {
        //LISTA
        public List<PacienteModel> Listar()
        {
            var oLista = new List<PacienteModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_LISTAR", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using(var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new PacienteModel()
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            tipoDocumento = dr["tipoDocumento"].ToString(),
                            numeroDocumento = dr["numeroDocumento"].ToString(),
                            nombres = dr["nombres"].ToString(),
                            apellidos = dr["apellidos"].ToString(),
                            correo = dr["correo"].ToString(),
                            telefono = dr["telefono"].ToString(),
                            fecha_nacimiento = Convert.ToDateTime(dr["fecha_nacimiento"]),
                            estado = dr["estado"].ToString(),

                        });
                    }
                }

            }
            return oLista;
        }

        //OBTENER
        public PacienteModel obtener(int Id)
        {
            var opaciente = new PacienteModel();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_OBTENER", conexion);
                cmd.Parameters.AddWithValue("Id", Id);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        opaciente.Id = Convert.ToInt32(dr["Id"]);
                        opaciente.tipoDocumento = dr["tipoDocumento"].ToString();
                        opaciente.numeroDocumento = dr["numeroDocumento"].ToString();
                        opaciente.nombres = dr["nombres"].ToString();
                        opaciente.apellidos = dr["apellidos"].ToString();
                        opaciente.correo = dr["correo"].ToString();
                        opaciente.telefono = dr["telefono"].ToString();
                        opaciente.fecha_nacimiento = Convert.ToDateTime(dr["fecha_nacimiento"]);
                        opaciente.estado = dr["estado"].ToString();

                    }
                }

            }
            return opaciente;
        }

        //GUARDAR
        public bool Guardar(PacienteModel opaciente)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_GUARDAR", conexion);
                    cmd.Parameters.AddWithValue("tipoDocumento", opaciente.tipoDocumento);
                    cmd.Parameters.AddWithValue("numeroDocumento", opaciente.numeroDocumento);
                    cmd.Parameters.AddWithValue("nombres", opaciente.nombres);
                    cmd.Parameters.AddWithValue("apellidos", opaciente.apellidos);
                    cmd.Parameters.AddWithValue("correo", opaciente.correo);
                    cmd.Parameters.AddWithValue("telefono", opaciente.telefono);
                    cmd.Parameters.AddWithValue("fecha_nacimiento", opaciente.fecha_nacimiento);
                    cmd.Parameters.AddWithValue("estado", opaciente.estado);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                }
                rpta = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                rpta = false;
            }

            return rpta;
        }

        //EDITAR
        public bool Editar(PacienteModel opaciente)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_EDITAR", conexion);
                    cmd.Parameters.AddWithValue("Id", opaciente.Id);
                    cmd.Parameters.AddWithValue("tipoDocumento", opaciente.tipoDocumento);
                    cmd.Parameters.AddWithValue("numeroDocumento", opaciente.numeroDocumento);
                    cmd.Parameters.AddWithValue("nombres", opaciente.nombres);
                    cmd.Parameters.AddWithValue("apellidos", opaciente.apellidos);
                    cmd.Parameters.AddWithValue("correo", opaciente.correo);
                    cmd.Parameters.AddWithValue("telefono", opaciente.telefono);
                    cmd.Parameters.AddWithValue("fecha_nacimiento", opaciente.fecha_nacimiento);
                    cmd.Parameters.AddWithValue("estado", opaciente.estado);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                }
                rpta = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                rpta = false;
            }

            return rpta;
        }

        //ELIMINAR
        public bool Eliminar(int Id)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_ELIMINAR", conexion);
                    cmd.Parameters.AddWithValue("Id", Id);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                }
                rpta = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                rpta = false;
            }

            return rpta;
        }
    }
}
