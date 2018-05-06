using Student.Common.Logic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDao.Interfaces
{
    public interface IRead
    {
        Alumno SelectById(int id);
        List<Alumno> GetAll();
    }
}
