using Canore.Web.Models.ObstetricalCases;
using Canore.Web.Models.Requests.ObstetricalCases;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Canore.Web.Services
{
    public class ObstetricalCasesService : BaseService
    {
        public int Get()
        {
            return 0;
        }

        public static int CreateObCase(ObstetricalCasesAddRequest model)//, string caseId)
        {
            var id = 0;

            DataProvider.ExecuteNonQuery(GetConnection, "dbo.ObstetricalCases_Insert",
                inputParamMapper: delegate (SqlParameterCollection InsertObCase)
                {
                    InsertObCase.AddWithValue("@PatientId", model.PatientId);
                    InsertObCase.AddWithValue("@Age", model.Age);
                    InsertObCase.AddWithValue("@Gravity", model.Gravity);
                    InsertObCase.AddWithValue("@Parity", model.Parity);
                    InsertObCase.AddWithValue("@Antepartum", model.Antepartum);
                    InsertObCase.AddWithValue("@Postpartum", model.Postpartum);
                    InsertObCase.AddWithValue("@Treatment", model.Treatment);
                    InsertObCase.AddWithValue("@BirthWeight", model.BirthWeight);
                    InsertObCase.AddWithValue("@Death", model.Death);
                    InsertObCase.AddWithValue("@OneMinScore", model.OneMinScore);
                    InsertObCase.AddWithValue("@FiveMinScore", model.FiveMinScore);
                    InsertObCase.AddWithValue("@DaysInHospital", model.DaysInHospital);

                    SqlParameter param = new SqlParameter("@Id", System.Data.SqlDbType.Int);
                    param.Direction = System.Data.ParameterDirection.Output;

                    InsertObCase.Add(param);
                },

                returnParameters: delegate (SqlParameterCollection par)
                {
                    int.TryParse(par["@Id"].Value.ToString(), out id);
                }
                );

            return id;

        }

        public static void ModifyObCase(ObstetricalCasesUpdateRequest model)
        {
            DataProvider.ExecuteNonQuery(GetConnection, "dbo.ObstetricalCases_Update",
                inputParamMapper: delegate (SqlParameterCollection UpdateObCase)
                {
                    UpdateObCase.AddWithValue("@Id", model.Id);
                    UpdateObCase.AddWithValue("@PatientId", model.PatientId);
                    UpdateObCase.AddWithValue("@Age", model.Age);
                    UpdateObCase.AddWithValue("@Gravity", model.Gravity);
                    UpdateObCase.AddWithValue("@Parity", model.Parity);
                    UpdateObCase.AddWithValue("@Antepartum", model.Antepartum);
                    UpdateObCase.AddWithValue("@Postpartum", model.Postpartum);
                    UpdateObCase.AddWithValue("@Treatment", model.Treatment);
                    UpdateObCase.AddWithValue("@BirthWeight", model.BirthWeight);
                    UpdateObCase.AddWithValue("@Death", model.Death);
                    UpdateObCase.AddWithValue("@OneMinScore", model.OneMinScore);
                    UpdateObCase.AddWithValue("@FiveMinScore", model.FiveMinScore);
                    UpdateObCase.AddWithValue("@DaysInHospital", model.DaysInHospital);
                });
        }
    }
}