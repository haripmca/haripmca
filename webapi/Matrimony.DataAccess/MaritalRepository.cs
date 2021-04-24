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
    public class MaritalRepository : BaseRepository,IMaritalRepository
    {
        public MaritalRepository(string connectionString) : base(connectionString) { }

        public List<Marital> GetMaritals(string martialName)
        {
            List<Marital> maritalsResults;
            using (IDbConnection db = GetConnection())
            {
                db.Open();

                var para = new DynamicParameters();
                para.Add("@TableName",TableName.Marital,DbType.String,ParameterDirection.Input);
                para.Add("@Parameter", martialName, DbType.String,ParameterDirection.Input);

                maritalsResults = db.Query<Marital>("usp_Read_Single_Row_From_Table",para,commandType:CommandType.StoredProcedure).AsList();
            }
            return maritalsResults;
        }

        public Task<int> PostMarital(Marital marital)
        {
            int result = 0;
            using(IDbConnection db = GetConnection())
            {
                try
                {
                    db.Open();

                    if (marital.MaritalName != "")
                    {
                        var p = new DynamicParameters();

                        p.Add("@MaritalId", marital.MaritalId, DbType.Int32, ParameterDirection.Input);
                        p.Add("@MaritalName", marital.MaritalName, DbType.String, ParameterDirection.Input);
                        p.Add("@MaritalCreatedDate", marital.MaritalCreatedDate, DbType.DateTime, ParameterDirection.Input);
                        p.Add("@MaritalCreatedBy", marital.MaritalCreatedBy, DbType.Int32, ParameterDirection.Input);
                        p.Add("@MaritalModifiedDate", marital.MaritalModifiedDate, DbType.DateTime, ParameterDirection.Input);
                        p.Add("@MaritalModifiedBy", marital.MaritalModifiedBy, DbType.Int32, ParameterDirection.Input);
                        p.Add("@MaritalStatus", Convert.ToInt32(RecordStatus.Active), DbType.Int32, ParameterDirection.Input);
                        if (marital.MaritalId == 0)
                        {
                            p.Add("@ActionType", ActionType.AddMarital, DbType.Int32, ParameterDirection.Input);
                        }
                        else
                        {
                            p.Add("@ActionType", ActionType.UpdateMarital, DbType.Int32, ParameterDirection.Input);
                        }
                        p.Add("@OutputData", marital.MaritalId, DbType.Int32, ParameterDirection.Input);

                        result = db.Execute("usp_CRED_Marital", p, commandType: CommandType.StoredProcedure);

                    }
                    return Task.FromResult(result);
                }
                catch (Exception)
                {

                    throw;
                }
                
            }
        }

        public int DeleteMarital(int maritalid)
        {
            using (IDbConnection db = GetConnection())
            {
                db.Open();

                string deletequery = "UPDATE dbo.Marital SET MaritalModifiedDate='" + DateTime.Now.ToString() + "' , MaritalModifiedBy = 1, MaritalStatus = '" + RecordStatus.Delete + "' WHERE MaritalId = @maritalid; ";

                db.Execute(deletequery, maritalid);

                return 1;
            }
        }


    }
}
