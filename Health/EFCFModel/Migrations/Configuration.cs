using System;
using System.Data.Entity.Migrations;
using System.Text;
using EFCFModel.Entities;

namespace EFCFModel.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<EFHealthContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(EFHealthContext context)
        {
            var functionalClass1 = new FunctionalClass
                                       {
                                           Code = "�������������� ����� I",
                                           Description =
                                               "�������� � ������������ ������, � ������� ������� ���������� �������� �� �������� ������, ��������� ��� ������������."
                                       };
            var functionalClass2 = new FunctionalClass
                                       {
                                           Code = "�������������� ����� II",
                                           Description =
                                               "�������� � ������������ ������ � ��������� ������������ ���������� ����������. ��� ������� ���������� ��������� ����������� ������, ��������� � ������������."
                                       };
            var functionalClass3 = new FunctionalClass
                                       {
                                           Code = "�������������� ����� III",
                                           Description =
                                               "�������� � ������������ ������ � ���������� ������������ ���������� ����������. � ��������� ����� ������ �����������, �� ���� ��� �������������� ���������� ��������� ���������� ������, ��������� � ������������."
                                       };
            var functionalClass4 = new FunctionalClass
                                       {
                                           Code = "�������������� ����� IV",
                                           Description =
                                               "�������� � ������������ ������, � ������� ����� ������� ���������� ���������� �������� ��������� ���� ������������ ��������. ��������� ��������� � � ��������� �����."
                                       };
            context.FunctionalClasses.AddOrUpdate(functionalClass1, 
                                                  functionalClass2, 
                                                  functionalClass3,
                                                  functionalClass4);
            var survey1 = new Survey
                              {
                                  Name = "�������� ���� �� �������� ������� ������� � �������� ��.",
                                  Description = "�������� ���� �� �������� ������� ������� � �������� ��."
                              };
            var survey2 = new Survey
                              {
                                  Name = "�������� ����,����,����,�������� ��������,�����.�������. ������� �����.",
                                  Description =
                                      "�������� ����,����,����,�������� ��������,�����.�������. ������� �����."
                              };
            var survey3 = new Survey
                              {
                                  Name = "������������� ���� ������ �� ��.",
                                  Description = "������������� ���� ������ �� ��."
                              };
            context.Set<Survey>().AddOrUpdate(survey1, survey2, survey3);
            var roleAdmin = new Role {Name = "Admin"};
            var roleDoctor = new Role {Name = "Doctor"};
            var rolePatient = new Role {Name = "Patient"};
            context.Set<Role>().AddOrUpdate(roleAdmin, roleDoctor, rolePatient);
            var u1 = new User
                         {
                             FirstName = "�����",
                             LastName = "������",
                             ThirdName = "������������",
                             Login = "anton",
                             Password = "anton",
                             Birthday = DateTime.Now.AddYears(-27),
                             Role = roleAdmin
                         };
            context.Set<User>().AddOrUpdate(u1);
            var specialty1 = new Specialty {Name = "��������"};
            var specialty2 = new Specialty {Name = "���������"};
            context.Set<Specialty>().AddOrUpdate(specialty1, specialty2);
            var doctor1 = new Doctor
                              {
                                  FirstName = "�����",
                                  LastName = "���������",
                                  ThirdName = "������������",
                                  Login = "makar",
                                  Password = "makar",
                                  Birthday = DateTime.Now.AddYears(-38),
                                  Role = roleDoctor,
                                  Specialty = specialty1
                              };
            var doctor2 = new Doctor
                              {
                                  FirstName = "�����",
                                  LastName = "���������",
                                  ThirdName = "������������",
                                  Login = "anton",
                                  Password = "anton",
                                  Birthday = DateTime.Now.AddYears(-38),
                                  Role = roleDoctor,
                                  Specialty = specialty2
                              };
            context.Set<Doctor>().AddOrUpdate(doctor1, doctor2);
            var parameter1 = new DoubleParameter
                                 {
                                     Name = "�����",
                                     DefaultValue = BitConverter.GetBytes(60.0),
                                     MinValue = 15,
                                     MaxValue = 250
                                 };
            var parameter2 = new StringParameter
                                 {
                                     Name = "��������",
                                     DefaultValue = Encoding.UTF8.GetBytes("120x80")
                                 };
            context.Set<Parameter>().AddOrUpdate(parameter1, parameter2);
            var patient1 = new Patient
                               {
                                   FirstName = "����",
                                   LastName = "���������",
                                   ThirdName = "������������",
                                   Login = "ilja",
                                   Password = "ilja",
                                   Birthday = DateTime.Now.AddYears(-12),
                                   Role = rolePatient,
                                   Card = "9A5CD8E5",
                                   Mother = "���� �����������",
                                   StartDateOfObservation = DateTime.Now.AddYears(-2),
                                   Doctor = doctor1,
                                   Policy = "9A5CD8E5",
                                   HomePhone = "89751452367"
                               };
            patient1.Parameters.Add(parameter1);
            patient1.Parameters.Add(parameter2);
            patient1.FunctionalClass = functionalClass2;
            context.Set<Patient>().AddOrUpdate(patient1);
            var surveyStorage1 = new SurveyStorage
                                     {
                                         Patient = patient1,
                                         Survey = survey2,
                                         Date = DateTime.Now.AddDays(-5)
                                     };
            var surveyStorage2 = new SurveyStorage
                                     {
                                         Patient = patient1,
                                         Survey = survey3,
                                         Date = DateTime.Now.AddDays(-1)
                                     };
            context.Set<SurveyStorage>().AddOrUpdate(surveyStorage1, surveyStorage2);
            var appointment1 = new Appointment
                                   {
                                       Doctor = doctor1,
                                       Patient = patient1,
                                       Date = DateTime.Now.AddMonths(-1)
                                   };
            context.Set<Appointment>().AddOrUpdate(appointment1);
            var diagnosisClass1 = new DiagnosisClass
                                      {
                                          Name = "������� ������� ��������������",
                                          Code = "IX"
                                      };
            var diagnosisClass2 = new DiagnosisClass
                                      {
                                          Name =
                                              "���������� �������� [������ �����], ���������� � ����������� ���������",
                                          Code = "XVII"
                                      };
            context.Set<DiagnosisClass>().AddOrUpdate(diagnosisClass1, diagnosisClass2);
            var diagnosis1 = new Diagnosis
                                 {
                                     Name = "������ �������������� ��������� ����� �������� �� ������",
                                     Code = "I97.1",
                                     DiagnosisClass = diagnosisClass1
                                 };
            var diagnosis2 = new Diagnosis
                                 {
                                     Name =
                                         "������ ��������� ������� �������������� ����� ����������� ��������, �� ������������������ � ������ ��������",
                                     Code = "I97.8",
                                     DiagnosisClass = diagnosisClass1
                                 };
            var diagnosis3 = new Diagnosis
                                 {
                                     Name = "������ ����������� �����������",
                                     Code = "Q21.1",
                                     DiagnosisClass = diagnosisClass2
                                 };
            var diagnosis4 = new Diagnosis
                                 {
                                     Name = "���������� ����� ������ ������������",
                                     Code = "Q24.9",
                                     DiagnosisClass = diagnosisClass2
                                 };
            diagnosis1.Patients.Add(patient1);
            diagnosis2.Patients.Add(patient1);
            diagnosis4.Patients.Add(patient1);
            context.Set<Diagnosis>().AddOrUpdate(diagnosis1, diagnosis2, diagnosis3, diagnosis4);
        }
    }
}
