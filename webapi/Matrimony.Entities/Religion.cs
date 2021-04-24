using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Matrimony.Entities
{
    public class Religion
    {
        public int ReligionId { get; set; }
        public string ReligionName { get; set; }
        public DateTime ReligionCreatedDate { get; set; }
        [JsonIgnore]
        public int ReligionCreatedBy { get; set; }       
        public DateTime ReligionModifiedDate { get; set; }
        [JsonIgnore]
        public int ReligionModifiedBy { get; set; }        
        public int ReligionStatus { get; set; }
        [JsonIgnore]
        public string ActionType { get; set; }

        

        
    }
    public class ReligionResultValues
    {
        public List<Religion> ReligionsresultsInsert { get; set; }
        public List<Religion> ReligionsresultsUpdate { get; set; }
    }
    public class ReligionResult
    {
        public int ReligionId { get; set; }
        public string ReligionName { get; set; }
        //public DateTime ReligionCreatedDate { get; set; }
        //public int ReligionCreatedBy { get; set; }
       
    }
}


