using Matrimony.Entities;
using Matrimony.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Matrimony.Bussiness
{
    public class OccupationService : IOccupationService
    {
        readonly IOccupationRepository occupationRepositoryobj;

        public OccupationService(IOccupationRepository occupationRepository)
        {
            occupationRepositoryobj = occupationRepository;
        }

        public List<Occupation> Occupations(string occupationName)
        {
           return occupationRepositoryobj.Occupations(occupationName);
        }

        public Task<int> PostOccuptions(Occupation occupation)
        {
            return occupationRepositoryobj.PostOccuptions(occupation);
        }

        public int DeleteOccupation(int occupationid)
        {
            return occupationRepositoryobj.DeleteOccupation(occupationid);
        }
    }
}
