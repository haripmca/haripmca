using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Matrimony.Entities.Interface
{
    public interface IEducationService
    {
        List<Education> GetEducations(string educationDegreeName);

        Task<int> PostEducation(Education education);

        int DeleteEducation(int educationId);
    }
}
