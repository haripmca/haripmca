using ConsolidatedBilling.DataAccess;
using Matrimony.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Matrimony.Entities.Interface;
using Matrimony.Entities.Untility;
using System.Linq;

namespace Matrimony.DataAccess
{
    public class ReligionRepository : BaseRepository, IReligionRepository
    {
        public ReligionRepository(string connectionString) : base(connectionString) { }

        public Task<int> PostReligionsAdd(Religion ReligionsresultsInsert)
        {
            int result = 0;
            using (IDbConnection db = GetConnection())
            {

                try
                {
                    db.Open();

                    if (ReligionsresultsInsert.ReligionName != "")
                    {

                        var p = new DynamicParameters();

                        p.Add("@ReligionId", ReligionsresultsInsert.ReligionId, DbType.Int32,ParameterDirection.Input);
                        p.Add("@ReligionName", ReligionsresultsInsert.ReligionName,DbType.String,ParameterDirection.Input);
                        p.Add("@ReligionCreatedDate", ReligionsresultsInsert.ReligionCreatedDate, DbType.DateTime, ParameterDirection.Input);
                        p.Add("@ReligionCreatedBy", ReligionsresultsInsert.ReligionCreatedBy, DbType.Int32, ParameterDirection.Input);
                        p.Add("@ReligionModifiedDate", ReligionsresultsInsert.ReligionModifiedDate, DbType.DateTime, ParameterDirection.Input);
                        p.Add("@ReligionModifiedBy", ReligionsresultsInsert.ReligionModifiedBy, DbType.Int32, ParameterDirection.Input);
                        p.Add("@ReligionStatus", ReligionsresultsInsert.ReligionStatus, DbType.Int32, ParameterDirection.Input);
                        p.Add("@ActionType", ActionType.ReligionInsert.ToString(), DbType.String, ParameterDirection.Input);
                        p.Add("@OutputData", ReligionsresultsInsert.ReligionModifiedBy, DbType.Int32, ParameterDirection.Output);

                        result =   db.Execute("usp_CRED_Religion", p,commandType: CommandType.StoredProcedure);
                    }
                    
                }
                catch (Exception ex)
                {
                    throw;
                }

            }
            return Task.FromResult(result);
        }

        public Task<int> PostReligionsUpdate(Religion ReligionsresultsUpdate)
        {
            int result = 0;
            using (IDbConnection db = GetConnection())
            {
                try
                {
                    db.Open();

                    if (ReligionsresultsUpdate.ReligionName != "")
                    {
                        var p = new DynamicParameters();

                        p.Add("@ReligionId", ReligionsresultsUpdate.ReligionId, DbType.Int32, ParameterDirection.Input);
                        p.Add("@ReligionName", ReligionsresultsUpdate.ReligionName, DbType.String, ParameterDirection.Input);
                        p.Add("@ReligionCreatedDate", ReligionsresultsUpdate.ReligionCreatedDate, DbType.DateTime, ParameterDirection.Input);
                        p.Add("@ReligionCreatedBy", ReligionsresultsUpdate.ReligionCreatedBy, DbType.Int32, ParameterDirection.Input);
                        p.Add("@ReligionModifiedDate", ReligionsresultsUpdate.ReligionModifiedDate, DbType.DateTime, ParameterDirection.Input);
                        p.Add("@ReligionModifiedBy", ReligionsresultsUpdate.ReligionModifiedBy, DbType.Int32, ParameterDirection.Input);
                        p.Add("@ReligionStatus", ReligionsresultsUpdate.ReligionStatus, DbType.Int32, ParameterDirection.Input);
                        p.Add("@ActionType", ActionType.ReligionUpdate.ToString(), DbType.String, ParameterDirection.Input);
                        p.Add("@OutputData", ReligionsresultsUpdate.ReligionModifiedBy, DbType.Int32, ParameterDirection.Output);

                        result = db.Execute("usp_CRED_Religion", p, commandType: CommandType.StoredProcedure);
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }

            }
            return Task.FromResult(result);

        }
        IEnumerable<ReligionResult> religionResults;
        
        public List<ReligionResult> ReligionResults(Religion religions)
        {
            List<ReligionResult> religion = new List<ReligionResult>();
            using (IDbConnection db = GetConnection())
            {
                try
                {
                    
                    db.Open();

                    if (religions.ReligionName != "")
                    {
                        var p = new DynamicParameters();

                        p.Add("@TableName", TableName.Religion.ToString(), DbType.String, ParameterDirection.Input);
                        p.Add("@Parameter", religions.ReligionName, DbType.String, ParameterDirection.Input);

                        religion = db.Query<ReligionResult>("usp_Read_Single_Row_From_Table", p, commandType: CommandType.StoredProcedure).ToList();
                    }
                }
                catch
                {

                }
                return religion.ToList();
            }
        }

        public Task<int> ReligionDelete(List<Religion> ReligionsresultsDelete)
        {
            int result = 0;
            
            using (IDbConnection db = GetConnection())
            {
                db.Open();

                int getvalstatus = Convert.ToInt32(ActionType.ReligionDelete);
                string updateQuery = $@"update [Matriomony].[dbo].Religion set ReligionModifiedDate=@ReligionModifiedDate,
                                        ReligionModifiedBy=@ReligionModifiedBy,ReligionStatus='"+ getvalstatus  + "' where ReligionId=@ReligionId";
                db.ExecuteAsync(updateQuery, ReligionsresultsDelete);
            }
            return Task.FromResult(result);
        }
    }
}
