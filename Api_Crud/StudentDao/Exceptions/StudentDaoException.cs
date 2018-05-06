using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDao.Exceptions
{
    public class StudentDaoException : Exception
    {
        public StudentDaoException()
        {
        }

        public StudentDaoException(string message) : base(message)
        {
        }

        public StudentDaoException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
