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
    public class HeightRepository : BaseRepository,IHeightRepository
    {
        public HeightRepository(string connectionString) : base(connectionString) { }

        public List<Height> GetHeights(string heightType)
        {
            List<Height> heights;

            using (IDbConnection db = GetConnection())
            {
                db.Open();

                var para = new DynamicParameters();
                para.Add("@TableName",TableName.Height.ToString(),DbType.String,ParameterDirection.Input);
                para.Add("@Parameter", heightType,DbType.String,ParameterDirection.Input);

                heights = db.Query<Height>("usp_CRED_Height",para,commandType:CommandType.StoredProcedure).AsList();
            }
            return heights;
        }

        public Task<int> PostHeight(Height height)
        {
            int result = 0;

            using (IDbConnection db = GetConnection())
            {
                try
                {
                    db.Open();

                    if (height.HeightFeetorInches != "")
                    {
                        var p = new DynamicParameters();

                        p.Add("@HeightId", height.HeightId, DbType.Int32, ParameterDirection.Input);
                        p.Add("@HeightFeetorInches", height.HeightFeetorInches, DbType.String, ParameterDirection.Input);
                        p.Add("@HeightCreatedDate", height.HeightCreatedDate, DbType.DateTime, ParameterDirection.Input);
                        p.Add("@HeightCreatedBy", height.HeightCreatedBy, DbType.Int32, ParameterDirection.Input);
                        p.Add("@HeightModifiedDate", height.HeightModifiedDate, DbType.DateTime, ParameterDirection.Input);
                        p.Add("@HeightModifiedBy", height.HeightModifiedBy, DbType.Int32, ParameterDirection.Input);
                        p.Add("@HeightStatus", Convert.ToInt32(RecordStatus.Active), DbType.Int32, ParameterDirection.Input);

                        if (height.HeightId == 0)
                        {
                            p.Add("@ActionType", ActionType.Add.ToString(), DbType.String, ParameterDirection.Input);
                        }
                        else
                        {
                            p.Add("@ActionType", ActionType.Update.ToString(), DbType.String, ParameterDirection.Input);
                        }

                        result = db.Execute("usp_CRED_Height", p, commandType: CommandType.StoredProcedure);
                    }
                    return Task.FromResult(result);
                }
                catch (Exception)
                {

                    throw;
                }
                
            }
        }

        public int DeleteHeight(int heightId)
        {
            using(IDbConnection db = GetConnection())
            {
                db.Open();

                string deletequery = "UPDATE dbo.Height SET HeightModifiedDate='"+DateTime.Now+ "',HeightModifiedBy=1,HeightStatus='" + RecordStatus.Delete + "' WHERE HeightId = @heightId; ";

                db.Execute(deletequery,heightId);

                return 1;
            }
        }
    }
}
