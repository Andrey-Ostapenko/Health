using System;
using Health.API.Entities;
using Health.API.Repository;
using Health.API.Services;
using Ninject;

namespace Health.Core.Services
{
    /// <summary>
    /// ������ �����������
    /// </summary>
    /// <typeparam name="TCandidate">��� ���������</typeparam>
    public class RegistrationService<TCandidate> : CoreService, IRegistrationService<ICandidate>
        where TCandidate : class, ICandidate, new()
    {
        /// <summary>
        /// ������� ������
        /// </summary>
        /// <param name="candidate">��������</param>
        public void AcceptBid(ICandidate candidate)
        {

        }

        /// <summary>
        /// ��������� ������
        /// </summary>
        /// <param name="candidate">��������</param>
        public void SaveBid(ICandidate candidate)
        {
            CoreKernel.CandRepo.Save(candidate);
        }

        /// <summary>
        /// ��������� ������
        /// </summary>
        /// <param name="candidate">��������</param>
        public void RejectBid(ICandidate candidate)
        {
            CoreKernel.CandRepo.Delete(candidate);
        }
    }
}