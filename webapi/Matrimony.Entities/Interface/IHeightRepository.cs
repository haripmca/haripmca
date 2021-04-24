using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Matrimony.Entities.Interface
{
    public interface IHeightRepository
    {
        List<Height> GetHeights(string heightType);

        Task<int> PostHeight(Height height);

        int DeleteHeight(int heightId);
    }
}
