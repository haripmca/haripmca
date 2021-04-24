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
    public class OccupationRepository : BaseRepository,IOccupationRepository
    {
        public OccupationRepository(string connectionString) : base(connectionString) { }

        public List<Occupation> Occupations(string occupationName)
        {
            List<Occupation> occupationsResult;
            using (IDbConnection db = GetConnection())
            {
                db.Open();
                var para = new DynamicParameters();
                para.Add("@TableName", TableName.Occupation,DbType.String,ParameterDirection.Input);
                para.Add("@Parameter", occupationName,DbType.String,ParameterDirection.Input);

                occupationsResult = db.Query<Occupation>("usp_Read_Single_Row_From_Table",para,commandType:CommandType.StoredProcedure).AsList();
            }
            return occupationsResult;
        }

        public Task<int> PostOccuptions(Occupation occupation)
        {
            int result = 0;
            using(IDbConnection db = GetConnection())
            {
                try
                {
                    db.Open();
                    if(occupation.OccupationDepartment != "")
                    {
                        var p = new DynamicParameters();

                        p.Add("@OccupationId",occupation.OccupationId,DbType.Int32,ParameterDirection.Input);
                        p.Add("@OccupationDepartment",occupation.OccupationDepartment,DbType.String,ParameterDirection.Input);
                        p.Add("@OccupationCreatedDate",occupation.OccupationCreatedDate,DbType.String,ParameterDirection.Input);
                        p.Add("@OccupationCreatedBy",occupation.OccupationCreatedBy,DbType.Int32,ParameterDirection.Input);
                        p.Add("@OccupationModifiedDate",occupation.OccupationModifiedDate,DbType.DateTime,ParameterDirection.Input);
                        p.Add("@OccupationModifiedBy",occupation.OccupationModifiedBy,DbType.Int32,ParameterDirection.Input);
                        p.Add("@OccupationStatus", occupation.OccupationStatus, DbType.Int32, ParameterDirection.Input);

                        if(occupation.OccupationId == 0)
                        {
                            p.Add("@ActionType", ActionType.AddOccup,DbType.String,ParameterDirection.Input);
                        }
                        else
                        {
                            p.Add("@ActionType", ActionType.UpdateOccup, DbType.String, ParameterDirection.Input);
                        }

                        p.Add("@OutputData",occupation.OccupationId,DbType.Int32,ParameterDirection.Output);

                        result = db.Execute("usp_CRED_Occupation",p,commandType:CommandType.StoredProcedure);
                    }

                    return Task.FromResult(result);
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public int DeleteOccupation(int occupationid)
        {
            using(IDbConnection db = GetConnection())
            {
                db.Open();

                string deletequery = "update dbo.Occupation set OccupationModifiedDate='"+DateTime.Now+ "',OccupationModifiedBy=1,OccupationStatus='"+Convert.ToInt32(RecordStatus.Delete)+ "' where OccupationId=@occupationid";

                db.Execute(deletequery,new { occupationid });

                return 1;
            }
        }
    }
}
