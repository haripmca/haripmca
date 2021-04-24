using ConsolidatedBilling.DataAccess;
using Dapper;
using Matrimony.Entities;
using Matrimony.Entities.Interface;
using Matrimony.Entities.Untility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Matrimony.DataAccess
{
    public class FamilyValuesRepository : BaseRepository,IFamilyValuesRepository
    {
        public FamilyValuesRepository(string connectionString) : base(connectionString) { }

        public List<FamilyValues> GetFamilyValues(string familyValues)
        {
            List<FamilyValues> families;

            using (IDbConnection db = GetConnection())
            {
                db.Open();

                var para = new DynamicParameters();
                para.Add("@TableName", TableName.FamilyValues.ToString(),DbType.String,ParameterDirection.Input);
                para.Add("@Parameter", familyValues,DbType.String,ParameterDirection.Input);

                families = db.Query<FamilyValues>("usp_Read_Single_Row_From_Table", para,commandType:CommandType.StoredProcedure).AsList();
            }
            return families;
        }

        public Task<int> PostFamilyValues(FamilyValues familyValues)
        {
            int result = 0;

            using(IDbConnection db = GetConnection())
            {
                db.Open();

                if(familyValues.FamilyValuesName != "")
                {
                    var p = new DynamicParameters();

                    p.Add("@FamilyValuesId",familyValues.FamilyValuesId,DbType.Int32,ParameterDirection.Input);
                    p.Add("@FamilyValuesName",familyValues.FamilyValuesName,DbType.String,ParameterDirection.Input);
                    p.Add("@FamilyValuesCreatedDate",familyValues.FamilyValuesCreatedDate,DbType.DateTime,ParameterDirection.Input);
                    p.Add("@FamilyValuesCreatedBy",familyValues.FamilyValuesCreatedBy,DbType.Int32,ParameterDirection.Input);
                    p.Add("@FamilyValuesModifiedDate",familyValues.FamilyValuesModifiedDate,DbType.DateTime,ParameterDirection.Input);
                    p.Add("@FamilyValuesModifiedBy",familyValues.FamilyValuesModifiedBy,DbType.Int32,ParameterDirection.Input);
                    p.Add("@FamilyValuesStatus", familyValues.FamilyValuesStatus, DbType.Int32, ParameterDirection.Input);

                    if(familyValues.FamilyValuesId == 0)
                    {
                        p.Add("@ActionType",ActionType.Add.ToString(),DbType.String,ParameterDirection.Input);
                    }
                    else
                    {
                        p.Add("@ActionType", ActionType.Update.ToString(), DbType.String, ParameterDirection.Input);
                    }

                    result = db.Execute("usp_CRED_FamilyValues",p,commandType:CommandType.StoredProcedure);

                }

                return Task.FromResult(result);
            }
        }

        public int DeleteFamilyValues(int familyvaluesId)
        {
            using(IDbConnection db= GetConnection())
            {
                db.Open();

                string deletequery = "UPDATE dbo.FamilyValues SET FamilyValuesModifiedDate='" + DateTime.Now + "', FamilyValuesModifiedBy = 1, FamilyValuesStatus = '" + RecordStatus.Delete + "' WHERE FamilyValuesId = @familyvaluesId; ";

                db.Execute(deletequery, familyvaluesId);

                return 1;
            }
        }
    }
}
