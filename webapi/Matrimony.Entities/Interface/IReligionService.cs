using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Matrimony.Entities.Interface
{
    public interface IReligionService
    {
        Task<int> PostReligionsAsync(Religion religions);

        Task<int> PostReligionsAsyncUpdate(Religion religions);

        List<ReligionResult> ReligionResults(Religion religions);

        Task<int> ReligionDelete(List<Religion> ReligionsresultsDelete);
    }
}
