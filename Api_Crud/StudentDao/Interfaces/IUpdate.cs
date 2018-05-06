using Student.Common.Logic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDao.Interfaces
{
    public interface IUpdate
    {
        Alumno Update(int id , Alumno entity);
    }
}
