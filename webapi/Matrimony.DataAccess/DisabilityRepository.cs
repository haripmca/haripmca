using ConsolidatedBilling.DataAccess;
using Dapper;
using Matrimony.Entities;
using Matrimony.Entities.Untility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Matrimony.DataAccess
{
    public class DisabilityRepository : BaseRepository
    {
        public DisabilityRepository(string connectionString) : base(connectionString) { }

        public List<Disability> GetDisability(string disabilityName)
        {
            List<Disability> disDisability;

            using(IDbConnection db = GetConnection())
            {
                db.Open();

                var para = new DynamicParameters();

                para.Add("@TableName",TableName.Disability.ToString(),DbType.String,ParameterDirection.Input);
                para.Add("@Parameter", disabilityName, DbType.String, ParameterDirection.Input);

                disDisability = db.Query<Disability>("usp_Read_Single_Row_From_Table",para,commandType:CommandType.StoredProcedure).AsList();

            }

            return disDisability;
        }

        public Task<int> PostDisability(Disability disability)
        {
            int result = 0;

            try
            {
                using(IDbConnection db = GetConnection())
                {
                    db.Open();

                    var p = new DynamicParameters();

                    p.Add("@AnyDisabilityId", disability.AnyDisabilityId, DbType.Int32,ParameterDirection.Input);
                    p.Add("@AnyDisabilityOrNot", disability.AnyDisabilityOrNot, DbType.Boolean, ParameterDirection.Input);
                    p.Add("@AnyDisabilityCreatedDate", disability.AnyDisabilityCreatedDate, DbType.Int32, ParameterDirection.Input);
                    p.Add("@AnyDisabilityCreatedBy", disability.AnyDisabilityCreatedBy, DbType.Int32, ParameterDirection.Input);
                    p.Add("@AnyDisabilityModifiedDate",disability.AnyDisabilityModifiedDate,DbType.DateTime,ParameterDirection.Input);
                    p.Add("@AnyDisabilityModifiedBy", disability.AnyDisabilityModifiedBy, DbType.Int32, ParameterDirection.Input);
                    p.Add("AnyDisabilityStatus", Convert.ToInt32(RecordStatus.Active), DbType.Int32, ParameterDirection.Input);
                    if (disability.AnyDisabilityId == 0)
                    {
                        p.Add("@ActionType", Convert.ToInt32(ActionType.Add.ToString()),DbType.String,ParameterDirection.Input);
                    }
                    else
                    {
                        p.Add("@ActionType", Convert.ToInt32(ActionType.Update.ToString()), DbType.String, ParameterDirection.Input);
                    }

                    p.Add("@OutputData", disability.AnyDisabilityId, DbType.Int32, ParameterDirection.Input);

                    result = db.Execute("usp_CRED_Disability",p,commandType:CommandType.StoredProcedure);

                }

                return Task.FromResult(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int DeleteDisability(int anyDisabilityId)
        {
            using (IDbConnection db = GetConnection())
            {
                db.Open();

                string deletequery = "UPDATE dbo.Disability SET AnyDisabilityModifiedDate='"+DateTime.Now+ "',AnyDisabilityModifiedBy=1,AnyDisabilityStatus = '" + Convert.ToInt32(RecordStatus.Delete) + "' WHERE AnyDisabilityId = @anyDisabilityId; ";

                db.Execute(deletequery, anyDisabilityId);

                return 1;
            }
        }
    }
}
