using System;
using Health.API;
using Health.API.Entities;
using Health.API.Services;

namespace Health.Core.Services
{
    /// <summary>
    /// ������ �����������.
    /// </summary>
    /// <typeparam name="TCandidate">��� ���������.</typeparam>
    public class RegistrationService<TCandidate> : CoreService, IRegistrationService
        where TCandidate : class, ICandidate, new()
    {
        protected RegistrationService(IDIKernel di_kernel, ICoreKernel core_kernel) : base(di_kernel, core_kernel)
        {
            DefaultCandidateRole = Instance<IRole>(o =>
                                                       {
                                                           o.Name = "Patient";
                                                           o.Code = 4;
                                                       });
        }

        protected IRole DefaultCandidateRole;

        #region IRegistrationService<ICandidate> Members

        /// <summary>
        /// ������� ������.
        /// </summary>
        /// <param name="candidate">��������.</param>
        public void AcceptBid(ICandidate candidate)
        {
            Logger.Info(String.Format("������ �� ����������� ��� {0} - �������.", candidate.Login));
        }

        /// <summary>
        /// ��������� ������.
        /// </summary>
        /// <param name="candidate">��������.</param>
        public void SaveBid(ICandidate candidate)
        {
            candidate.Role = DefaultCandidateRole;
            CoreKernel.CandRepo.Save(candidate);
            Logger.Info(String.Format("��������� ������ �� ����������� - {0}.", candidate.Login));
        }

        /// <summary>
        /// ��������� ������.
        /// </summary>
        /// <param name="candidate">��������.</param>
        public void RejectBid(ICandidate candidate)
        {
            CoreKernel.CandRepo.Delete(candidate);
            Logger.Info(String.Format("������ �� ����������� ��� {0} - ���������.", candidate.Login));
        }

        #endregion
    }
}