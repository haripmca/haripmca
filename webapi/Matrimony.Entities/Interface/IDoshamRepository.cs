using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Matrimony.Entities.Interface
{
    public interface IDoshamRepository
    {
        List<Dosham> GetDoshams(string doshamName);

        Task<int> PostDosham(Dosham dosham);

        int DeleteDosham(int doshamId);
    }
}
