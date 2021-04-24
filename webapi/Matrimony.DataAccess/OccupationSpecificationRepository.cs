using ConsolidatedBilling.DataAccess;
using Dapper;
using Matrimony.Entities;
using Matrimony.Entities.Interface;
using Matrimony.Entities.Untility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrimony.DataAccess
{
    public class OccupationSpecificationRepository : BaseRepository, IOccupationSpecificationRepository
    {
        public OccupationSpecificationRepository(string connectionString) : base(connectionString) { }

        IEnumerable<OccupationSpecification> occupationSpecificationResults;
        public List<OccupationSpecification> OccupationSpecificationServiceResults(string religions)
        {
            List<OccupationSpecification> religionResult;
            using (IDbConnection db = GetConnection())
            {
                db.Open();
                var para = new DynamicParameters();
                para.Add("@TableName", TableName.OccupationSpecification, DbType.String, ParameterDirection.Input);
                para.Add("@Parameter", religions, DbType.String, ParameterDirection.Input);
                religionResult = db.Query<OccupationSpecification>("usp_Read_Single_Row_From_Table", para, commandType: CommandType.StoredProcedure).ToList();
            }
            return religionResult.ToList();
        }

        public Task<int> PostOccupationSpec(OccupationSpecification occupationSpecificationInsertUpdate)
        {
            int result = 0;
            using(IDbConnection db = GetConnection())
            {
                try
                {
                    db.Open();
                    if(occupationSpecificationInsertUpdate.OccupationSpecificationType != "")
                    {
                        var p = new DynamicParameters();

                        p.Add("@OccupationSpecificationId", occupationSpecificationInsertUpdate.OccupationSpecificationId,DbType.Int32,ParameterDirection.Input);
                        p.Add("@OccupationId", occupationSpecificationInsertUpdate.OccupationId,DbType.Int32,ParameterDirection.Input);
                        p.Add("@OccupationSpecificationType", occupationSpecificationInsertUpdate.OccupationSpecificationType, DbType.String, ParameterDirection.Input);
                        p.Add("@OccupationSpecificationCreatedDate", occupationSpecificationInsertUpdate.OccupationSpecificationCreatedDate, DbType.DateTime, ParameterDirection.Input);
                        p.Add("@OccupationSpecificationCreatedBy", occupationSpecificationInsertUpdate.OccupationSpecificationCreatedBy,DbType.Int32,ParameterDirection.Input);
                        p.Add("@OccupationSpecificationModifiedDate", occupationSpecificationInsertUpdate.OccupationSpecificationModifiedDate,DbType.Date,ParameterDirection.Input);
                        p.Add("@OccupationSpecificationModifiedBy", occupationSpecificationInsertUpdate.OccupationSpecificationModifiedBy,DbType.Int32,ParameterDirection.Input);
                        p.Add("@OccupationSpecificationStatus", occupationSpecificationInsertUpdate.OccupationSpecificationStatus,DbType.Int32,ParameterDirection.Input);
                        if(occupationSpecificationInsertUpdate.OccupationSpecificationId == 0)
                        {
                            p.Add("@ActionType", ActionType.AddOccupation.ToString(), DbType.String, ParameterDirection.Input);
                        }
                        else
                        {
                            p.Add("@ActionType", ActionType.UpdateOccupation.ToString(), DbType.String, ParameterDirection.Input);
                        }
                        
                        p.Add("@OutputData", occupationSpecificationInsertUpdate.OccupationId, DbType.Int32, ParameterDirection.Output);

                        result = db.Execute("usp_CRED_OcupationSpecification",p,commandType:CommandType.StoredProcedure);
                    }
                    return Task.FromResult(result);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public int DeleteOccupationSpec(int occupationSpecificationId)
        {
            using (IDbConnection db = GetConnection())
            {
                db.Open();

                string deleteQuery = "update dbo.usp_CRED_OcupationSpecification set OccupationSpecificationModifiedDate='"+DateTime.Now+ "',OccupationSpecificationModifiedBy=1, OccupationSpecificationStatus='" + Convert.ToInt32(RecordStatus.Delete) + "' where OccupationSpecificationId=@occupationSpecificationId";

                db.Execute(deleteQuery, new { occupationSpecificationId });

                return 1;
            }
        }
    }
}
