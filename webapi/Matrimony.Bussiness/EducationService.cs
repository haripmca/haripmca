using ConsolidatedBilling.DataAccess;
using Matrimony.Entities;
using Matrimony.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Matrimony.Bussiness
{
    public class EducationService :IEducationRepository
    {
        readonly IEducationRepository educationRepositoryobj;

        public EducationService(IEducationRepository educationService)
        {
            educationRepositoryobj = educationService;
        }

        public List<Education> GetEducations(string EducationName)
        {
            return educationRepositoryobj.GetEducations(EducationName);
        }

        public Task<int> PostEducation(Education education)
        {
            return educationRepositoryobj.PostEducation(education);
        }

        public int DeleteEducation(int educationId)
        {
            return educationRepositoryobj.DeleteEducation(educationId);
        }
    }
}
