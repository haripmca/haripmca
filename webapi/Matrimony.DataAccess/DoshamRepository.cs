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
    public class DoshamRepository : BaseRepository,IDoshamRepository
    {
        public DoshamRepository(string connectionString) : base(connectionString) { }

        public List<Dosham> GetDoshams(string doshamName)
        {
            List<Dosham> doshams;

            using(IDbConnection db = GetConnection())
            {
                db.Open();

                var para = new DynamicParameters();

                para.Add("@TableName", TableName.Dosham.ToString(),DbType.String,ParameterDirection.Input);
                para.Add("@Parameter", doshamName,DbType.String,ParameterDirection.Input);

                doshams = db.Query<Dosham>("usp_Read_Single_Row_From_Table",para,commandType:CommandType.StoredProcedure).AsList();
            }
            return doshams;
        }

        public Task<int> PostDosham(Dosham dosham)
        {
            int result = 0;
            try
            {
                using(IDbConnection db = GetConnection())
                {
                    db.Open();

                    if(dosham.DoshamName != "")
                    {
                        var p = new DynamicParameters();

                        p.Add("@DoshamId",dosham.DoshamId,DbType.Int32,ParameterDirection.Input);
                        p.Add("@DoshamName", dosham.DoshamName, DbType.String, ParameterDirection.Input);
                        p.Add("@DoshamCreatedDate", dosham.DoshamCreatedDate, DbType.DateTime, ParameterDirection.Input);
                        p.Add("@DoshamCreatedBy",dosham.DoshamCreatedBy,DbType.Int32,ParameterDirection.Input);
                        p.Add("@DoshamModifiedDate", dosham.DoshamModifiedDate, DbType.DateTime, ParameterDirection.Input);
                        p.Add("@DoshamModifiedBy", dosham.DoshamModifiedBy, DbType.Int32, ParameterDirection.Input);
                        p.Add("@DoshamStatus", RecordStatus.Active, DbType.Int32, ParameterDirection.Input);

                        if(dosham.DoshamId == 0)
                        {
                            p.Add("@ActionType", ActionType.Add.ToString(), DbType.String, ParameterDirection.Input);
                        }
                        else
                        {
                            p.Add("@ActionType", ActionType.Update.ToString(), DbType.String, ParameterDirection.Input);
                        }
                        p.Add("@OutputData", dosham.DoshamId, DbType.Int32, ParameterDirection.Output);

                        result = db.Execute("usp_CRED_Dosham", p, commandType: CommandType.StoredProcedure);
                    }

                    return Task.FromResult(result);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int DeleteDosham(int doshamId)
        {
            using (IDbConnection db = GetConnection())
            {
                db.Open();

                string deletequery = "UPDATE dbo.Dosham SET DoshamModifiedDate='" + DateTime.Now + "',DoshamModifiedBy = 1,DoshamStatus = '" + Convert.ToInt32(RecordStatus.Delete) + "' WHERE DoshamId = @doshamId; ";

                db.Execute(deletequery, doshamId);

                return 1;
            }
        }
    }
}
