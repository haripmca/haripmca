using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Matrimony.Entities.Interface
{
    public interface IReligionRepository
    {
        Task<int> PostReligionsAdd(Religion ReligionsresultsInsert);

        Task<int> PostReligionsUpdate(Religion ReligionsresultsUpdate);

        List<ReligionResult> ReligionResults(Religion religions);

        Task<int> ReligionDelete(List<Religion> ReligionsresultsDelete);
    }
}
