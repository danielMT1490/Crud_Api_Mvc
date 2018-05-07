using Autofac;
using Student.Business.Logic.BusinessLogic;
using Student.Common.Logic.Log;
using StudentDao.Interfaces;
using StudentDao.Modules;
using StudentDao.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Business.Logic.Modules
{
    public class BusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<StudentDaoSql>()
                .As<IRepository>()
                .InstancePerRequest();

            builder
                .RegisterType<Log4netAdapter>()
                .As<ILogger>()
                .InstancePerRequest();

            builder.RegisterModule(new StudentDaoModule());

            base.Load(builder);
        }
    }
}
