using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Matrimony.Entities.Interface
{
    public interface IOccupationService
    {
        List<Occupation> Occupations(string occupationName);
        Task<int> PostOccuptions(Occupation occupation);
        int DeleteOccupation(int occupationid);
    }
}
