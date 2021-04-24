using Matrimony.Entities;
using Matrimony.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Matrimony.Bussiness
{
    public class CasteService : ICasteRepository
    {
        readonly ICasteRepository casteRepositoryobj;

        public CasteService(ICasteRepository casteRepository)
        {
            casteRepositoryobj = casteRepository;
        }

        public List<Caste> GetCastes(string casteName)
        {
            return casteRepositoryobj.GetCastes(casteName);        
        }

        public Task<int> PostCastes(Caste caste)
        {
            return casteRepositoryobj.PostCastes(caste);
        }

        public int DeleteCaste(int anyCasteId)
        {
            return casteRepositoryobj.DeleteCaste(anyCasteId);
        }
    }
}
