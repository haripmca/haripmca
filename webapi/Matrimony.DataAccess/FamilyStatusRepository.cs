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
    public class FamilyStatusRepository : BaseRepository,IFamilyStatusRepository
    {
        public FamilyStatusRepository(string connectionString) : base(connectionString) { }
            
        public List<FamilyStatus> GetFamilyStatus(string familystatus)
        {
            List<FamilyStatus> familyStatuses;

            using(IDbConnection db = GetConnection())
            {
                try
                {
                    db.Open();

                    var para = new DynamicParameters();
                    para.Add("@TableName", TableName.FamilyType.ToString(), DbType.String, ParameterDirection.Input);
                    para.Add("@Parameter", familystatus, DbType.String, ParameterDirection.Input);

                    familyStatuses = db.Query<FamilyStatus>("usp_CRED_Family_Status", para, commandType: CommandType.StoredProcedure).AsList();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return familyStatuses;
        }

        public Task<int> PostFamilyStatus(FamilyStatus familyStatus)
        {
            int result = 0;

            try
            {
                using(IDbConnection db = GetConnection())
                {
                    db.Open();

                    if(familyStatus.FamilyStatusName != "")
                    {
                        var p = new DynamicParameters();

                        p.Add("@FamilyStatusId",familyStatus.FamilyStatusId,DbType.Int32,ParameterDirection.Input);
                        p.Add("@@FamilyStatusName", familyStatus.FamilyStatusName, DbType.String, ParameterDirection.Input);
                        p.Add("@FamilyStatusCreatedDate",familyStatus.FamilyStatusCreatedDate,DbType.DateTime,ParameterDirection.Input);
                        p.Add("@FamilyStatusCreatedBy",familyStatus.FamilyStatusCreatedBy,DbType.Int32,ParameterDirection.Input);
                        p.Add("@FamilyStatusModifiedDate", familyStatus.FamilyStatusModifiedDate, DbType.DateTime, ParameterDirection.Input);
                        p.Add("@FamilyStatusModifiedBy", familyStatus.FamilyStatusModifiedBy, DbType.Int32, ParameterDirection.Input);
                        p.Add("@FamilyStatusStatus", Convert.ToInt32(RecordStatus.Active), DbType.Int32, ParameterDirection.Input);

                        if(familyStatus.FamilyStatusId == 0)
                        {
                            p.Add("@ActionType", ActionType.Add.ToString(),DbType.String,ParameterDirection.Input);
                        }
                        else
                        {
                            p.Add("@ActionType", ActionType.Update.ToString(), DbType.String, ParameterDirection.Input);
                        }

                        result = db.Execute("usp_CRED_Family_Status",p,commandType:CommandType.StoredProcedure);
                    }

                    return Task.FromResult(result);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int DeleteFamilyStatus(int familyStatusId)
        {
            using(IDbConnection db = GetConnection())
            {
                db.Open();

                string deletequery = "UPDATE dbo.FamilyStatus SET FamilyStatusModifiedDate='"+DateTime.Now+"',FamilyStatusModifiedBy = 1,FamilyStatusStatus = '"+ Convert.ToInt32(RecordStatus.Delete)+ "' WHERE FamilyStatusId = @familyStatusId; ";

                db.Execute(deletequery, familyStatusId);

                return 1;
            }
        }
     }
}
