﻿using System.Windows.Forms;
using Ninject;
using PrototypeHM.DB.DI;
using PrototypeHM.DB.Mappers;
using PrototypeHM.Diagnosis;
using PrototypeHM.Doctor;
using PrototypeHM.DB;
using PrototypeHM.Forms;
using PrototypeHM.Patient;
using PrototypeHM.Specialty;
using PrototypeHM.User;
using PrototypeHM.Parameter;

namespace PrototypeHM
{
    internal class YApplication : ApplicationContext
    {
        private const string ConnectionString =
            "Data Source=.;Initial Catalog=Health.MsSqlDatabase;Integrated Security=true;";

        private readonly IKernel _kernel;

        internal YApplication()
        {
            _kernel = new StandardKernel();
            Bind();
            BindCommand();
            BindOperations();
            MainForm = _kernel.Get<DIMainForm>();
            MainForm.Show();
        }

        internal void Bind()
        {
            // General
            _kernel.Bind<IDIKernel>().To<DIKernel>();
            _kernel.Bind<DB.DB>().ToSelf().InSingletonScope().WithConstructorArgument("connectionString",
                                                                                      ConnectionString);

            // Mappers
            _kernel.Bind<PropertyToColumnMapper<UserFullData>>().ToSelf().InSingletonScope();
            _kernel.Bind<PropertyToColumnMapper<QueryStatus>>().ToSelf().InSingletonScope();

            // Repositories
            _kernel.Bind<QueryRepository>().ToSelf().InSingletonScope();
            _kernel.Bind<DoctorRepository>().ToSelf().InSingletonScope();
            _kernel.Bind<DiagnosisRepository>().ToSelf().InSingletonScope();
            _kernel.Bind<OperationsRepository>().ToSelf().InSingletonScope();
            _kernel.Bind<Parameter.ParameterRepository>().ToSelf().InSingletonScope();

        }

        internal void BindCommand()
        {
            _kernel.Get<QueryRepository>().AddProcedure("GetAllDoctorShowData");
            _kernel.Get<QueryRepository>().AddProcedure("GetAllUserShowData");
            _kernel.Get<QueryRepository>().AddProcedure("GetAllDiagnosis");
            _kernel.Get<QueryRepository>().Add("DeleteDoctor", "exec [dbo].[DeleteDoctor] [doctorId]");
            _kernel.Get<QueryRepository>().Add("GetAllPatientsForDoctor", "exec [dbo].[GetAllPatientsForDoctor] [doctorId]");
            _kernel.Get<QueryRepository>().AddProcedure("GetAllParameterShowData");
            _kernel.Get<QueryRepository>().Add("GetAllMetadataForParameter", "[dbo].[GetAllMetadataForParameter] [parameterId]");
            _kernel.Get<QueryRepository>().Add("NewParameter", "[dbo].[NewParameter] [nameParameter] [defaultValue]");
            _kernel.Get<QueryRepository>().Add("GetParameterById", "[dbo].[GetParameterById] [parameterId]");
            
        }

        internal void BindOperations()
        {
            _kernel.Get<OperationsRepository>().Operations.Add(new OperationsContext<DoctorFullData>
                                                                   {
                                                                       Load = _kernel.Get<DoctorRepository>().GetAll,
                                                                       Detail = _kernel.Get<DoctorRepository>().Detail,
                                                                       Delete = _kernel.Get<DoctorRepository>().Delete
                                                                   });
            _kernel.Get<OperationsRepository>().Operations.Add(new OperationsContext<PatientForDoctor>
                                                                   {
                                                                       Detail = _kernel.Get<PatientRepository>().GetPatientFullDataById
                                                                   });
            _kernel.Get<OperationsRepository>().Operations.Add(new OperationsContext<Specialty.Specialty>
                                                                   {
                                                                       Load = _kernel.Get<SpecialtyRepository>().GetAll
                                                                   });
            _kernel.Get<OperationsRepository>().Operations.Add(new OperationsContext<ParameterBaseData>
            {                
                
                            
            });

            _kernel.Get<OperationsRepository>().Operations.Add(new OperationsContext<ParameterDetail> { 
            Save = _kernel.Get<ParameterRepository>().Save
            });

            _kernel.Get<OperationsRepository>().Operations.Add(new OperationsContext<ParameterDetail> { 
            Save = _kernel.Get<ParameterRepository>().Save,
            Detail = _kernel.Get<ParameterRepository>().Detail,
            Load = _kernel.Get<ParameterRepository>().GetAll,   
            });

        }
    }
}
