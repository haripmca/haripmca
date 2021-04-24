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
    public class LocationCountryRepository : BaseRepository,ILocationCountryRepository
    {
        public LocationCountryRepository(string connectionString) : base(connectionString) { }

        public List<LocationCountry> GetLocationCountries(string locationCountryName)
        {
            List<LocationCountry> locationCountries;

            using (IDbConnection db = GetConnection())
            {
                db.Open();

                var para = new DynamicParameters();
                para.Add("@TableName",TableName.LocationCountry,DbType.String,ParameterDirection.Input);
                para.Add("@Parameter", locationCountryName,DbType.String,ParameterDirection.Input);

                locationCountries = db.Query<LocationCountry>("usp_CRED_LocationCountry",para,commandType:CommandType.StoredProcedure).AsList();
            }
            return locationCountries;
        }

        public Task<int> PostLocationCountry(LocationCountry locationCountry)
        {
            int result = 0;

            using(IDbConnection db = GetConnection())
            {
                db.Open();

                if(locationCountry.LocationName != "")
                {
                    var p = new DynamicParameters();

                    p.Add("@LocationId", locationCountry.LocationId,DbType.Int32,ParameterDirection.Input);
                    p.Add("@LocationName",locationCountry.LocationName,DbType.String,ParameterDirection.Input);
                    p.Add("@LocationCreatedDate",locationCountry.LocationCreatedDate,DbType.String,ParameterDirection.Input);
                    p.Add("@LocationCreatedBy", locationCountry.LocationCreatedBy, DbType.Int32, ParameterDirection.Input);
                    p.Add("@LocationModifiedDate",locationCountry.LocationModifiedDate,DbType.DateTime,ParameterDirection.Input);
                    p.Add("@LocationModifiedBy", locationCountry.LocationModifiedBy, DbType.Int32, ParameterDirection.Input);
                    p.Add("@LocationStatus", Convert.ToInt32(RecordStatus.Active), DbType.Int32,ParameterDirection.Input);
                    

                    if(locationCountry.LocationId == 0)
                    {
                        p.Add("@ActionType", ActionType.AddLocationCountry.ToString(), DbType.String, ParameterDirection.Input);
                    }
                    else
                    {
                        p.Add("@ActionType", ActionType.UpdateLocationCountry.ToString(), DbType.String, ParameterDirection.Input);
                    }

                    result = db.Execute("usp_CRED_LocationCountry",p,commandType:CommandType.StoredProcedure);
                }

                return Task.FromResult(result);
            }
        }

        public int DeleteLocationCountry(int locationid)
        {
            using(IDbConnection db = GetConnection())
            {
                db.Open();

                string deletequery = "UPDATE dbo.LocationCountry SET LocationModifiedDate='"+DateTime.Now+"',LocationModifiedBy = 1,LocationStatus = '"+ RecordStatus.Delete+ "' WHERE LocationId = @LocationId; ";

                db.Execute(deletequery,locationid);

                return 1;
            }
        }
    }
}
