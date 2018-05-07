using Student.Common.Logic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentService.ServiceLogic
{
    public interface IService
    {
        AlumnoService Create(AlumnoService entity);
        AlumnoService SelectById(int id);
        List<AlumnoService> GetAll();
        AlumnoService Update(int id, AlumnoService entity);
        int Delete(int id);
    }
}
