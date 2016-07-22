using Canore.Web.Domain;
using Canore.Web.Models.Requests;
using Sabio.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Canore.Web.Services
{
    public class UncomplicatedCasesService : BaseService
    {
        public static int Get()
        {
            return 0;
        }

        public static int CreateUncomplicatedCase(UncomplicatedCasesAddRequest model)//, string caseId)
        {
            var id = 0;

            DataProvider.ExecuteNonQuery(GetConnection, "dbo.UncomplicatedCases_Insert",
                inputParamMapper: delegate (SqlParameterCollection InsertUncomplicatedCase)
                {
                    InsertUncomplicatedCase.AddWithValue("@HospitalID", model.HospitalID);

                    SqlParameter param = new SqlParameter("@Id", SqlDbType.Int);
                    param.Direction = ParameterDirection.Output;

                    InsertUncomplicatedCase.Add(param);
                },

                returnParameters: delegate (SqlParameterCollection par)
                {
                    int.TryParse(par["@Id"].Value.ToString(), out id);
                }
                );

            return id;

        }

        public static List<UncomplicatedCases> GetCaseByHospital(int hospitalId)
        {
            List<UncomplicatedCases> list = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.UncomplicatedCases_SelectByHospitalID",
                inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@HospitalID", hospitalId);
                }, map: delegate (IDataReader reader, short set)
                {
                    UncomplicatedCases item = MapCase(reader);
                    if (list == null)
                    {
                        list = new List<UncomplicatedCases>();
                    }

                    list.Add(item);
                    //list = MapGynCase(reader);
                });

            return list;
        }

        private static UncomplicatedCases MapCase(IDataReader reader)
        {
            UncomplicatedCases item = new UncomplicatedCases();
            Hospitals hosp = new Hospitals();

            int startingIndex = 0;

            item.Id = reader.GetSafeInt32(startingIndex++);
            hosp.Id = reader.GetSafeInt32(startingIndex++);
            hosp.Name = reader.GetSafeString(startingIndex++);
            item.DateAdded = reader.GetSafeDateTime(startingIndex++);

            item.Hospital = hosp;
            return item;
        }

    }
}