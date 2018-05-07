using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Student.Common.Logic.Logger;
using Student.Common.Logic.Model;
using Student.Common.Logic.Tools;

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
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<AlumnoService> GetAll()
        {
            throw new NotImplementedException();
        }

        public AlumnoService SelectById(int id)
        {
            throw new NotImplementedException();
        }

        public AlumnoService Update(int id, AlumnoService entity)
        {
            throw new NotImplementedException();
        }
    }
}
