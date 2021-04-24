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
    public class EducationRepository : BaseRepository,IEducationRepository
    {
        public EducationRepository(string connectionString) : base(connectionString) { }

        public List<Education> GetEducations(string educationDegreeName)
        {
            List<Education> educations;

            using(IDbConnection db = GetConnection())
            {
                try
                {
                    db.Open();

                    var para = new DynamicParameters();

                    para.Add("@TableName", TableName.Education.ToString(), DbType.String,ParameterDirection.Input);
                    para.Add("@Parameter", educationDegreeName,DbType.String,ParameterDirection.Input);

                    educations = db.Query<Education>("usp_Read_Single_Row_From_Table", para, commandType: CommandType.StoredProcedure).AsList();
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return educations;
        }

        public Task<int> PostEducation(Education education)
        {
            int result = 0;

            try
            {
                using (IDbConnection db = GetConnection())
                {
                    db.Open();

                    if (education.EducationDegree != "")
                    {
                        var p = new DynamicParameters();

                        p.Add("@EducationId", education.EducationId, DbType.Int32, ParameterDirection.Input);
                        p.Add("@EducationBranch", education.EducationBranch, DbType.String, ParameterDirection.Input);
                        p.Add("@EducationDegree", education.EducationDegree, DbType.String, ParameterDirection.Input);
                        p.Add("@EducationCreatedDate", education.EducationCreatedDate, DbType.String, ParameterDirection.Input);
                        p.Add("@EducationCreatedBy", education.EducationCreatedBy, DbType.Int32, ParameterDirection.Input);
                        p.Add("@EducationModifiedDate", education.EducationModifiedDate, DbType.DateTime, ParameterDirection.Input);
                        p.Add("@EducationModifiedBy", education.EducationModifiedBy, DbType.Int32, ParameterDirection.Input);
                        p.Add("@EducationStatus", Convert.ToInt32(RecordStatus.Active), DbType.Int32, ParameterDirection.Input);

                        if (education.EducationId == 0)
                        {
                            p.Add("@EducationStatus", ActionType.Add.ToString(), DbType.String, ParameterDirection.Input);
                        }
                        else
                        {
                            p.Add("@EducationStatus", ActionType.Update.ToString(), DbType.String, ParameterDirection.Input);
                        }
                        p.Add("@OutputData", education.EducationId, DbType.Int32, ParameterDirection.Input);

                        result = db.Execute("usp_CRED_Education", p, commandType: CommandType.StoredProcedure);
                    }
                    return Task.FromResult(result);
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        public int DeleteEducation(int educationId)
        {
            using (IDbConnection db = GetConnection())
            {
                db.Open();

                string deletequery = "UPDATE dbo.Education SET EducationModifiedDate='"+DateTime.Now+"',EducationModifiedBy=1,EducationStatus = '"+Convert.ToInt32(RecordStatus.Delete)+ "' WHERE EducationId = @educationId; ";

                db.Execute(deletequery, educationId);

                return 1;
            }
        }
    }
}
