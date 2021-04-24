using Matrimony.Entities;
using Matrimony.Entities.Interface;
using Matrimony.Entities.Untility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Matrimony.Bussiness
{
    public class ReligionService : IReligionService
    {
        readonly IReligionRepository religionRepositoryobj;

        public ReligionService(IReligionRepository religionRepository)
        {
            religionRepositoryobj = religionRepository;
        }
        public async Task<int> PostReligionsAsync(Religion religions)
        {   
            List<ReligionResult> religionsresults = ReligionResults(religions);

            if(religionsresults.Count > 0)
            {                 
                return await religionRepositoryobj.PostReligionsAdd(religions);
            }            
            else
            {
                return 0;
            }
        }

        public async Task<int> PostReligionsAsyncUpdate(Religion religions)
        {
            List<ReligionResult> religionsresults = ReligionResults(religions);

            if (religionsresults.Count > 0)
            {
                return await religionRepositoryobj.PostReligionsUpdate(religions);
            }
            else
            {
                return 0;
            }
        }

        List<Religion> religionResults;

        public List<ReligionResult> ReligionResults(Religion religions)
        {
           return religionRepositoryobj.ReligionResults(religions);
        }

        //public ReligionResultValues ReligionResults(List<Religion> religions)
        //{
        //    ReligionResultValues religionListResult = new ReligionResultValues();
        //    List<Religion> myListUpdate = new List<Religion>();
        //    List<Religion> myList = new List<Religion>();
        //    string getResultReigions = ReturnListtoStringReligionName(religions);
        //    religionResults = religionRepositoryobj.ReligionResults(getResultReigions);
        //    /** which not available in database that is get in result1 after we got the value we saving the value **/
        //    var result1 = religions.Where(x => !religionResults.Any(y => y.ReligionName == x.ReligionName));

        //    var result2 = religionResults.Where(x => !religions.Any(y => y.ReligionName == x.ReligionName));

        //    if (result1.Count() > 0)
        //    {
        //        myList = result1.Cast<Religion>().ToList();
        //        myList.Select(i => { i.ActionType = "ReligionInsert"; return i; }).ToList();
        //    }
        //    if(result2.Count() == 0 && religionResults.Count() <= religions.Count())
        //    {
        //        myListUpdate = religionResults.Cast<Religion>().ToList();
        //        var mySKUs = religionResults.Select(l => l.ReligionName).ToList();
        //        myListUpdate.Select(i => { i.ActionType = "ReligionUpdate"; return i; }).ToList();
        //        for (int i=0;i < mySKUs.Count(); i++)
        //        {
        //            myListUpdate[i].ReligionName = mySKUs[i].ToString();
        //        }
        //    }

        //    religionListResult.ReligionsresultsInsert = myList.ToList();
        //    religionListResult.ReligionsresultsUpdate = myListUpdate.ToList();


        //    return religionListResult;
        //}

        //private string ReturnListtoStringReligionName(List<Religion> religions)
        //{
        //   return religions.Select(x => x.ReligionName).ToArray().Select(a => a.ToString()).Aggregate((i, j) => i + "," + j);
        //}
        public Task<int> ReligionDelete(List<Religion> ReligionsresultsDelete)
        {
            ReligionsresultsDelete.Select(x => x.ReligionModifiedDate =DateTime.Now).ToList();
            ReligionsresultsDelete.Select(x => x.ReligionStatus = Convert.ToInt32(ActionType.ReligionDelete)).ToList();
            
            return religionRepositoryobj.ReligionDelete(ReligionsresultsDelete);
        }
    }
}
