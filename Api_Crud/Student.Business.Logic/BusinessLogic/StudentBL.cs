using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student.Common.Logic.Log;
using Student.Common.Logic.Model;
using StudentDao.Interfaces;

namespace Student.Business.Logic.BusinessLogic
{
    public class StudentBL : IBusiness
    {
        private readonly ILogger Log;
        private readonly IRepository repository;

        public StudentBL(ILogger Logger,IRepository dao)
        {
            this.Log = Logger;
            this.repository = dao;
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
