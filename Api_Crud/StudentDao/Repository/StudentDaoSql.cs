using Student.Common.Logic.Log;
using Student.Common.Logic.Model;
using StudentDao.Exceptions;
using StudentDao.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDao.Repository
{
    public class StudentDaoSql : IRepository
    {
        private readonly ILogger log;
        private readonly string connectionString;
        public StudentDaoSql(ILogger log)
        {
            this.log = log;
            connectionString = "Data Source=LAPTOP-UVGFLCJ7;Initial Catalog=AlumnosCrud;Integrated Security=true;";
        }
        public Alumno Create(Alumno entity)
        {
            try
            {
                var sql = "insert into dbo.Alumnos  (UUID,Nombre,Apellido,Dni,DateRegistry,DateBorn,Edad) values (@UUID,@Nombre,@Apellido,@Dni,@Registro,@Nacimiento,@Edad);";
                using (SqlConnection _conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand _cmd = new SqlCommand(sql, _conn))
                    {
                        _conn.Open();

                        _cmd.Parameters.AddWithValue("@UUID", entity.Guid.ToString());
                        _cmd.Parameters.AddWithValue("@Nombre", entity.Nombre);
                        _cmd.Parameters.AddWithValue("@Apellido", entity.Apellidos);
                        _cmd.Parameters.AddWithValue("@Dni", entity.Dni);
                        _cmd.Parameters.AddWithValue("@Nacimiento", entity.Nacieminto);
                        _cmd.Parameters.AddWithValue("@Registro", entity.Registro);
                        _cmd.Parameters.AddWithValue("@Edad", entity.Edad);
                        _cmd.ExecuteNonQuery();
                        _cmd.Parameters.Clear();

                        _cmd.CommandText = "SELECT @@IDENTITY";

                        // Obtenga la última identificación insertada. 
                        var id = Convert.ToInt32(_cmd.ExecuteScalar());
                        return SelectById(id);
                    }

                }
            }
            catch (SqlException ex)
            {
                log.Error(ex + System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw new StudentDaoException(ex.Message, ex);
            }
            catch (InvalidOperationException ex)
            {
                log.Error(ex + System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw new StudentDaoException(ex.Message, ex);
            }
        }

        public int Delete(int id)
        {
            try
            {
                string sql = $"Delete from dbo.Alumnos where Id = {id}";
                using (SqlConnection _conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand _cmd = new SqlCommand(sql, _conn))
                    {
                        _cmd.Parameters.AddWithValue("@ID", id);
                        return _cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                log.Error(ex+ System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw new StudentDaoException(ex.Message, ex);
            }
            catch (InvalidOperationException ex)
            {
                log.Error(ex+ System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw new StudentDaoException(ex.Message, ex);
            }
        }

        public List<Alumno> GetAll()
        {
            var students = new List<Alumno>();

            string sql = "select * from dbo.Alumnos;";

            log.Debug(""+ System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                using (SqlConnection _conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand _cmd = new SqlCommand(sql, _conn))
                    {
                        _conn.Open();
                        using (SqlDataReader srd = _cmd.ExecuteReader())
                        {
                            while (srd.Read())
                            {
                                var student = new Alumno
                                {
                                    Guid = Guid.Parse(srd["UUID"].ToString()),
                                    Id = Convert.ToInt32(srd["Id"].ToString()),
                                    Nombre = srd["Nombre"].ToString(),
                                    Apellidos = srd["Apellido"].ToString(),
                                    Dni = srd["Dni"].ToString(),
                                    Registro = Convert.ToDateTime(srd["DateRegistry"].ToString()),
                                    Nacieminto = Convert.ToDateTime(srd["DateBorn"].ToString()),
                                    Edad = Convert.ToInt32(srd["Edad"].ToString())
                                };
                                log.Debug(""+ System.Reflection.MethodBase.GetCurrentMethod().Name);
                                students.Add(student);
                            }
                            return students;

                        }


                    }
                }
            }
            catch (InvalidOperationException ex)
            {
                log.Error(ex+ System.Reflection.MethodBase.GetCurrentMethod().Name);

                throw new StudentDaoException(ex.Message, ex);
            }
            catch (SqlException ex)
            {
                log.Error(ex+ System.Reflection.MethodBase.GetCurrentMethod().Name);

                throw new StudentDaoException(ex.Message, ex);
            }
        }

        public Alumno SelectById(int id)
        {
            log.Debug(""+ System.Reflection.MethodBase.GetCurrentMethod().Name);

            string sql = $"select * from dbo.Students where Id ={id}";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        using (SqlDataReader srd = cmd.ExecuteReader())
                        {
                            var student = new Alumno
                            {
                                Guid = Guid.Parse(srd["UUID"].ToString()),
                                Id = Convert.ToInt32(srd["Id"].ToString()),
                                Nombre = srd["Nombre"].ToString(),
                                Apellidos = srd["Apellido"].ToString(),
                                Dni = srd["Dni"].ToString(),
                                Registro = Convert.ToDateTime(srd["DateRegistry"].ToString()),
                                Nacieminto = Convert.ToDateTime(srd["DateBorn"].ToString()),
                                Edad = Convert.ToInt32(srd["Edad"].ToString())
                            };
                            return student;
                        }
                    }
                }
               
            }
            catch (SqlException ex)
            {
                log.Error(ex+ System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw new StudentDaoException(ex.Message, ex);
            }
            catch (InvalidOperationException ex)
            {
                log.Error(ex+ System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw new StudentDaoException(ex.Message, ex);
            }
        }

        public Alumno Update(int id, Alumno entity)
        {
            try
            {
                var sql = $"update  dbo.Alumnos set " +
                    $"Nombre=@Nombre,Apellido=@Apellido,Dni=@Dni,DateRegistry=@Registro," +
                    $"DateBorn=@Nacimiento,Edad=@Edad where Id = {id};";

                using (SqlConnection _conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand _cmd = new SqlCommand(sql, _conn))
                    {
                        _conn.Open();

                        _cmd.Parameters.AddWithValue("@UUID", entity.Guid.ToString());
                        _cmd.Parameters.AddWithValue("@Nombre", entity.Nombre);
                        _cmd.Parameters.AddWithValue("@Apellido", entity.Apellidos);
                        _cmd.Parameters.AddWithValue("@Dni", entity.Dni);
                        _cmd.Parameters.AddWithValue("@Nacimiento", entity.Nacieminto);
                        _cmd.Parameters.AddWithValue("@Registro", entity.Registro);
                        _cmd.Parameters.AddWithValue("@Edad", entity.Edad);
                        _cmd.ExecuteNonQuery();
                        _cmd.Parameters.Clear();

                        
                        return SelectById(id);
                    }

                }
            }
            catch (SqlException ex)
            {
                log.Error(ex + System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw new StudentDaoException(ex.Message, ex);
            }
            catch (InvalidOperationException ex)
            {
                log.Error(ex + System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw new StudentDaoException(ex.Message, ex);
            }
        }
    }
}
