using Student.Common.Logic.Log;
using Student.Common.Logic.Model;
using StudentDao.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDao.Repository
{
    public class StudentDaoSql : IRepository
    {
        private readonly ILogger log;
        public StudentDaoSql(ILogger log)
        {
            this.log = log;
        }
        public Alumno Create(Alumno entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Alumno> GetAll()
        {
            throw new NotImplementedException();
        }

        public Alumno SelectById(int id)
        {
            throw new NotImplementedException();
        }

        public Alumno Update(int id, Alumno entity)
        {
            throw new NotImplementedException();
        }
    }
}
