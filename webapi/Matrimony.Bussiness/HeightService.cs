using Matrimony.Entities;
using Matrimony.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Matrimony.Bussiness
{
    public class HeightService
    {
        readonly IHeightRepository heightRepositoryobj;

        public HeightService(IHeightRepository heightRepository)
        {
            heightRepositoryobj = heightRepository;
        }

        public List<Height> GetHeights(string heightType)
        {
            return heightRepositoryobj.GetHeights(heightType);
        }

        public Task<int> PostHeight(Height height)
        {
            return heightRepositoryobj.PostHeight(height);
        }

        public int DeleteHeight(int heightId)
        {
            return heightRepositoryobj.DeleteHeight(heightId);
        }
    }
}
