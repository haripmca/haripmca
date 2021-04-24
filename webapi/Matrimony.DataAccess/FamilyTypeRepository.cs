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
    public class FamilyTypeRepository : BaseRepository,IFamilyTypeRepository
    {
        public FamilyTypeRepository(string connectionString) : base(connectionString) { }

        public List<FamilyType> GetFamilyTypes(string familytype)
        {
            List<FamilyType> familyTypes;

            using(IDbConnection db = GetConnection())
            {
                db.Open();

                var para = new DynamicParameters();
                para.Add("@TableName", TableName.FamilyType.ToString(),DbType.String,ParameterDirection.Input);
                para.Add("@Parameter", familytype,DbType.String,ParameterDirection.Input);

                familyTypes = db.Query<FamilyType>("usp_Read_Single_Row_From_Table",para,commandType:CommandType.StoredProcedure).AsList();
            }
            return familyTypes;
        }

        public Task<int> PostFamilyType(FamilyType familyType)
        {
            int result = 0;

            try
            {
                using (IDbConnection db = GetConnection())
                {

                    db.Open();

                    if (familyType.FamilyValuesName != "")
                    {
                        var p = new DynamicParameters();

                        p.Add("@FamilyTypeId", familyType.FamilyValuesId, DbType.Int32, ParameterDirection.Input);
                        p.Add("@FamilyTypeName", familyType.FamilyValuesName, DbType.String, ParameterDirection.Input);
                        p.Add("@FamilyTypeCreatedDate", familyType.FamilyValuesCreatedDate, DbType.DateTime, ParameterDirection.Input);
                        p.Add("@FamilyTypeCreatedBy", familyType.FamilyValuesCreatedBy, DbType.Int32, ParameterDirection.Input);
                        p.Add("@FamilyTypeModifiedDate", familyType.FamilyValuesModifiedDate, DbType.DateTime, ParameterDirection.Input);
                        p.Add("@FamilyTypeModifiedBy", familyType.FamilyValuesModifiedBy, DbType.Int32, ParameterDirection.Input);
                        p.Add("@FamilyTypeStatus", Convert.ToInt32(RecordStatus.Active), DbType.Int32, ParameterDirection.Input);

                        if (familyType.FamilyValuesId == 0)
                        {
                            p.Add("@ActionType", ActionType.Add.ToString(), DbType.String, ParameterDirection.Input);
                        }
                        else
                        {
                            p.Add("@ActionType", ActionType.Update.ToString(), DbType.String, ParameterDirection.Input);
                        }
                        p.Add("@OutputData", familyType.FamilyValuesId, DbType.Int32, ParameterDirection.Input);

                        result = db.Execute("usp_CRED_FamilyType", p, commandType: CommandType.StoredProcedure);
                    }
                }

                return Task.FromResult(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int DeleteFamilyType(int familyTypeId)
        {
            using(IDbConnection db = GetConnection())
            {
                db.Open();

                string deletequery = "UPDATE dbo.FamilyType SET FamilyTypeModifiedDate='"+DateTime.Now+"',FamilyTypeModifiedBy = 1,FamilyTypeStatus = '"+ Convert.ToInt32(RecordStatus.Delete) + "' WHERE FamilyTypeId = @familyTypeId ";

                db.Execute(deletequery, familyTypeId);

                return 1;
            }
        }



    }
}
