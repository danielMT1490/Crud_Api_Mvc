using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Student.Common.Logic.Logger;
using Student.Common.Logic.Model;
using Student.Common.Logic.Tools;
using StudentService.ServiceLogic.Exceptions;

namespace StudentService.ServiceLogic
{
    public class ApiService : IService
    {
        private readonly ILogger Log;
        private readonly HttpClient client;

        public ApiService(ILogger log ,HttpClient client )
        {
            this.Log = log;
            this.client = ServiceConfiguration.InitClient(client);
        }
        public AlumnoService Create(AlumnoService entity)
        {
            try
            {
                var response = Task.Run(() => client.PutAsJsonAsync<AlumnoService>("Alumno/Create", entity));
                response.Result.EnsureSuccessStatusCode();
                using (var content = response.Result.Content)
                {
                    return content.ReadAsAsync<AlumnoService>().GetAwaiter().GetResult();
                }
            }
            catch (Exception ex)
            {

                throw new ServiceExceptions(ex.Message,ex.InnerException);
            }
          
        }

        public int Delete(int id)
        {
            try
            {
                var response = Task.Run(() => client.DeleteAsync($"Alumno/Delete?Id={id}"));
                response.Result.EnsureSuccessStatusCode();
                using (var content = response.Result.Content)
                {
                    return content.ReadAsAsync<int>().GetAwaiter().GetResult();
                }
            }
            catch (Exception ex)
            {

                throw new ServiceExceptions(ex.Message, ex.InnerException);
            }
        }

        public List<AlumnoService> GetAll()
        {
            try
            {
                var response = Task.Run(() => client.GetAsync($"Alumno/GetAll"));
                response.Result.EnsureSuccessStatusCode();
                using (var content = response.Result.Content)
                {
                    return content.ReadAsAsync<List<AlumnoService>>().GetAwaiter().GetResult();
                }
            }
            catch (Exception ex)
            {

                throw new ServiceExceptions(ex.Message, ex.InnerException);
            }
        }

        public AlumnoService SelectById(int id)
        {
            try
            {
                var response = Task.Run(() => client.GetAsync($"Alumno/SelectById?Id={id}"));
                response.Result.EnsureSuccessStatusCode();
                using (var content = response.Result.Content)
                {
                    return content.ReadAsAsync<AlumnoService>().GetAwaiter().GetResult();
                }
            }
            catch (Exception ex)
            {

                throw new ServiceExceptions(ex.Message, ex.InnerException);
            }
        }

        public AlumnoService Update(int id, AlumnoService entity)
        {
            try
            {
                var response = Task.Run(() => client.PutAsJsonAsync<AlumnoService>($"Alumno/Delete?Id={id}",entity));
                response.Result.EnsureSuccessStatusCode();
                using (var content = response.Result.Content)
                {
                    return content.ReadAsAsync<AlumnoService>().GetAwaiter().GetResult();
                }
            }
            catch (Exception ex)
            {

                throw new ServiceExceptions(ex.Message, ex.InnerException);
            }
        }
    }
}
