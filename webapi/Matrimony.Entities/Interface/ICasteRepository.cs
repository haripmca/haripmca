using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Matrimony.Entities.Interface
{
    public interface ICasteRepository
    {
        List<Caste> GetCastes(string casteName);

        Task<int> PostCastes(Caste caste);

        int DeleteCaste(int anyCasteId);
    }
}
