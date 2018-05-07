using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student.Business.Logic.Exceptions;
using Student.Common.Logic.Log;
using Student.Common.Logic.Model;
using StudentDao.Exceptions;
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
            try
            {
                Log.Debug(""+ System.Reflection.MethodBase.GetCurrentMethod().Name);
                return repository.Create(entity);

            }
            catch (StudentDaoException ex)
            {
                Log.Error(ex+ System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw new BusinessException(ex.Message,ex.InnerException);
            }
        }

        public int Delete(int id)
        {
            try
            {
                Log.Debug(""+ System.Reflection.MethodBase.GetCurrentMethod().Name);
                return repository.Delete(id);

            }
            catch (StudentDaoException ex)
            {
                Log.Error(ex+ System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw new BusinessException(ex.Message, ex.InnerException);
            }
        }

        public List<Alumno> GetAll()
        {
            try
            {
                Log.Debug(""+ System.Reflection.MethodBase.GetCurrentMethod().Name);
                return repository.GetAll();

            }
            catch (StudentDaoException ex)
            {
                Log.Error(ex+ System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw new BusinessException(ex.Message, ex.InnerException);
            }
        }

        public Alumno SelectById(int id)
        {
            try
            {
                Log.Debug(""+ System.Reflection.MethodBase.GetCurrentMethod().Name);
                return repository.SelectById(id);

            }
            catch (StudentDaoException ex)
            {
                Log.Error(ex+ System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw new BusinessException(ex.Message, ex.InnerException);
            }
        }

        public Alumno Update(int id, Alumno entity)
        {
            try
            {
                Log.Debug(""+ System.Reflection.MethodBase.GetCurrentMethod().Name);
                return repository.Update(id,entity);

            }
            catch (StudentDaoException ex)
            {
                Log.Error(ex+ System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw new BusinessException(ex.Message, ex.InnerException);
            }
        }
    }
}
