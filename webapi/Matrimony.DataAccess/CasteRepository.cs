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
    public class CasteRepository : BaseRepository, ICasteRepository
    {
        public CasteRepository(string connectionString) : base(connectionString) { }

        public List<Caste> GetCastes(string casteName)
        {
            List<Caste> castes;

            using(IDbConnection db = GetConnection())
            {
                db.Open();

                var para = new DynamicParameters();

                para.Add("@TableName",TableName.Caste.ToString(),DbType.String,ParameterDirection.Input);
                para.Add("@Parameter", casteName, DbType.String, ParameterDirection.Input);

                castes = db.Query<Caste>("usp_Read_Single_Row_From_Table", para, commandType: CommandType.StoredProcedure).AsList();
            }

            return castes;
        }

        public Task<int> PostCastes(Caste caste)
        {
            int results = 0;

            try
            {
                using(IDbConnection db = GetConnection())
                {
                    db.Open();

                    var p = new DynamicParameters();

                    p.Add("@CasteId",caste.CasteId,DbType.Int32,ParameterDirection.Input);
                    p.Add("@CasteName", caste.CasteName, DbType.String, ParameterDirection.Input);
                    p.Add("@CasteCreatedDate", caste.CasteCreatedDate, DbType.DateTime, ParameterDirection.Input);
                    p.Add("@CasteCreatedBy",caste.CasteCreatedBy,DbType.Int64,ParameterDirection.Input);
                    p.Add("@CasteModifiedDate", caste.CasteModifiedDate, DbType.DateTime, ParameterDirection.Input);
                    p.Add("@CasteModifiedBy",caste.CasteModifiedBy,DbType.Int32,ParameterDirection.Input);
                    p.Add("@CasteStatus", caste.CasteStatus, DbType.Int32, ParameterDirection.Input);
                    if(caste.CasteId == 0)
                    {
                        p.Add("@ActionType", ActionType.Add.ToString(), DbType.String, ParameterDirection.Input);
                    }
                    else
                    {
                        p.Add("@ActionType",ActionType.Update.ToString(),DbType.String,ParameterDirection.Input);
                    }

                    p.Add("@OutputData",caste.CasteId,DbType.Int32,ParameterDirection.Input);

                    results = db.Execute("usp_CRED_Caste",p,commandType:CommandType.StoredProcedure);
                    
                }

                return Task.FromResult(results);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int DeleteCaste(int anyCasteId)
        {
            using (IDbConnection db = GetConnection())
            {
                db.Open();

                string deletequery = "UPDATE dbo.Caste SET CasteModifiedDate='" + DateTime.Now + "',CasteModifiedBy=1, CasteStatus = '" + Convert.ToInt32(RecordStatus.Delete) + "' WHERE CasteId = @anyCasteId; ";

                db.Execute(deletequery, anyCasteId);

                return 1;
            }
        }

    }
}
