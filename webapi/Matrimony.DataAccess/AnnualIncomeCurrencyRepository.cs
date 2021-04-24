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
    public class AnnualIncomeCurrencyRepository : BaseRepository
    {
        public AnnualIncomeCurrencyRepository(string connectionString) : base(connectionString) { }

        public List<AnnualIncomeCurrency> GetAnnualIncomeCurrencies(string annualIncomeCurrencyName)
        {
            List<AnnualIncomeCurrency> annualIncomeCurrencies;

            using(IDbConnection db = GetConnection())
            {
                db.Open();

                var para = new DynamicParameters();

                para.Add("@TableName", TableName.AnnualIncomeCurrency.ToString(), DbType.String, ParameterDirection.Input);
                para.Add("@Parameter", annualIncomeCurrencyName, DbType.String, ParameterDirection.Input);

                annualIncomeCurrencies = db.Query<AnnualIncomeCurrency>("usp_Read_Single_Row_From_Table", para, commandType: CommandType.StoredProcedure).AsList();
            }

            return annualIncomeCurrencies;
        }

        public Task<int> PostAnnualIncomeCurrency(AnnualIncomeCurrency annualIncomeCurrency)
        {
            int results = 0;

            try
            {
                using(IDbConnection db= GetConnection())
                {
                    db.Open();

                    var p = new DynamicParameters();

                    p.Add("@AnnualIncomeCurrencyId", annualIncomeCurrency.AnnualIncomeCurrencyId,DbType.Int32,ParameterDirection.Input);
                    p.Add("@AnnualIncomeCurrencyName", annualIncomeCurrency.AnnualIncomeCurrencyName, DbType.String, ParameterDirection.Input);
                    p.Add("@AnnualIncomeCreatedDate", annualIncomeCurrency.AnnualIncomeCreatedDate, DbType.DateTime, ParameterDirection.Input);
                    p.Add("@AnnualIncomeCreatedBy", annualIncomeCurrency.AnnualIncomeCreatedBy, DbType.Int32, ParameterDirection.Input);
                    p.Add("@AnnualIncomeModifiedDate", annualIncomeCurrency.AnnualIncomeModifiedDate, DbType.DateTime, ParameterDirection.Input);
                    p.Add("@@AnnualIncomeModifiedBy", annualIncomeCurrency.AnnualIncomeModifiedBy, DbType.Int32, ParameterDirection.Input);
                    p.Add("@AnnualIncomeStatus", annualIncomeCurrency.AnnualIncomeStatus, DbType.Int32, ParameterDirection.Input);

                    if (annualIncomeCurrency.AnnualIncomeCurrencyId == 0)
                    {
                        p.Add("@ActionType", ActionType.Add.ToString(), DbType.String, ParameterDirection.Input);
                    }
                    else
                    {
                        p.Add("@ActionType", ActionType.Update.ToString(), DbType.String, ParameterDirection.Input);
                    }

                    p.Add("@OutputData", annualIncomeCurrency.AnnualIncomeCurrencyId, DbType.Int32, ParameterDirection.Input);

                    results = db.Execute("usp_CRED_AnnualIncomeCurrency", p, commandType: CommandType.StoredProcedure);
                }
                return Task.FromResult(results);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int DeleteAnnualIncomeCurrency(int anyCasteId)
        {
            using (IDbConnection db = GetConnection())
            {
                db.Open();

                string deletequery = "UPDATE  dbo.AnnualIncomeCurrency SET AnnualIncomeModifiedDate='" + DateTime.Now + "',AnnualIncomeModifiedBy = 1,AnnualIncomeStatus = '" + Convert.ToInt32(RecordStatus.Delete) + "' WHERE AnnualIncomeCurrencyId = @annualIncomeCurrencyId; ";

                db.Execute(deletequery, anyCasteId);

                return 1;
            }
        }
    }
}
