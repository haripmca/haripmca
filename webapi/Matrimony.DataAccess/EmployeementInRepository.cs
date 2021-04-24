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
    public class EmployeementInRepository : BaseRepository,IEmployeementInRepository
    {
        public EmployeementInRepository(string connectionString) : base(connectionString) { }

        public List<EmployeementIn> GetEmployeementIns(string EmployeementInName)
        {
            List<EmployeementIn> employeementIns;

            using(IDbConnection db = GetConnection())
            {
                try
                {
                    db.Open();

                    var para = new DynamicParameters();

                    para.Add("@TableName", TableName.EmployeementIn.ToString(), DbType.String, ParameterDirection.Input);
                    para.Add("@Parameter", EmployeementInName, DbType.String, ParameterDirection.Input);

                    employeementIns = db.Query<EmployeementIn>("usp_CRED_EmployeementIn", para, commandType: CommandType.StoredProcedure).AsList();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return employeementIns;
        }

        public Task<int> PostEmployeementIn(EmployeementIn familyStatus)
        {
            int result = 0;

            try
            {
                using (IDbConnection db = GetConnection())
                {
                    db.Open();

                    if(familyStatus.EmployeementInName != "")
                    {
                        var p = new DynamicParameters();

                        p.Add("@EmployeementId", familyStatus.EmployeementId, DbType.Int32, ParameterDirection.Input);
                        p.Add("@EmployeementInName", familyStatus.EmployeementInName, DbType.String, ParameterDirection.Input);
                        p.Add("@EmployeementCreatedDate", familyStatus.EmployeementCreatedDate, DbType.String, ParameterDirection.Input);
                        p.Add("@EmployeementCreatedBy", familyStatus.EmployeementCreatedBy, DbType.String, ParameterDirection.Input);
                        p.Add("@EmployeementModifiedDate", familyStatus.EmployeementModifiedDate, DbType.String, ParameterDirection.Input);
                        p.Add("@EmployeementModifiedBy", familyStatus.EmployeementModifiedBy, DbType.String, ParameterDirection.Input);
                        p.Add("@EmployeementStatus", Convert.ToInt32(RecordStatus.Active), DbType.String, ParameterDirection.Input);

                        if(familyStatus.EmployeementId == 0)
                        {
                            p.Add("@ActionType", ActionType.Add.ToString(), DbType.String, ParameterDirection.Input);
                        }
                        else
                        {
                            p.Add("@ActionType", ActionType.Update.ToString(), DbType.String, ParameterDirection.Input);
                        }

                        p.Add("@OutputData", familyStatus.EmployeementId,DbType.Int32,ParameterDirection.Input);

                        result = db.Execute("usp_CRED_EmployeementIn", p, commandType: CommandType.StoredProcedure);
                    }

                    return Task.FromResult(result);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int DeleteEmployeementIn(int familyStatusId)
        {
            using (IDbConnection db = GetConnection())
            {
                db.Open();

                string deletequery = "UPDATE dbo.EmployeementIn SET EmployeementModifiedDate='" + DateTime.Now + "',EmployeementModifiedBy = 1,EmployeementStatus = '" + Convert.ToInt32(ActionType.Delete) + "' WHERE EmployeementId = @familyStatusId; ";

                db.Execute(deletequery, familyStatusId);

                return 1;
            }
        }
    }
}
