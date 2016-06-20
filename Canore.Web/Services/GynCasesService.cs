using Canore.Web.Domain;
using Canore.Web.Models.Requests.GynCases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Canore.Web.Services
{
    public class GynCasesService : BaseService/*, IGynCasesService*/
    {
        public static int Get()
        {
            return 0;
        }

        public static int CreateGynCase(GynCasesAddRequest model)//, string caseId)
        {
            var id = 0;

            DataProvider.ExecuteNonQuery(GetConnection, "dbo.GynCases_Insert",
                inputParamMapper: delegate (SqlParameterCollection InsertGynCase)
                {
                    InsertGynCase.AddWithValue("@PatientID", model.PatientID);
                    InsertGynCase.AddWithValue("@Age", model.Age);
                    InsertGynCase.AddWithValue("@Gravity", model.Gravity);
                    InsertGynCase.AddWithValue("@Parity", model.Parity);
                    InsertGynCase.AddWithValue("@Admission", model.Admission);
                    InsertGynCase.AddWithValue("@Treatment", model.Treatment);
                    InsertGynCase.AddWithValue("@SurgicalPath", model.SurgicalPath);
                    InsertGynCase.AddWithValue("@ComplicationsID", model.ComplicationsID);
                    InsertGynCase.AddWithValue("@HospitalID", model.HospitalID);
                    InsertGynCase.AddWithValue("@DaysInHospital", model.DaysInHospital);

                    SqlParameter param = new SqlParameter("@Id", SqlDbType.Int);
                    param.Direction = ParameterDirection.Output;

                    InsertGynCase.Add(param);
                },

                returnParameters: delegate (SqlParameterCollection par)
                {
                    int.TryParse(par["@Id"].Value.ToString(), out id);
                }
                );

            return id;

        }

        public static void ModifyGynCase(GynCasesUpdateRequest model)
        {
            DataProvider.ExecuteNonQuery(GetConnection, "dbo.GynCases_Update",
                inputParamMapper: delegate (SqlParameterCollection UpdateGynCase)
                {
                    UpdateGynCase.AddWithValue("@Id", model.Id);
                    UpdateGynCase.AddWithValue("@PatientID", model.PatientID);
                    UpdateGynCase.AddWithValue("@Age", model.Age);
                    UpdateGynCase.AddWithValue("@Gravity", model.Gravity);
                    UpdateGynCase.AddWithValue("@Parity", model.Parity);
                    UpdateGynCase.AddWithValue("@Admission", model.Admission);
                    UpdateGynCase.AddWithValue("@Treatment", model.Treatment);
                    UpdateGynCase.AddWithValue("@Treatment", model.Treatment);
                    UpdateGynCase.AddWithValue("@SurgicalPath", model.SurgicalPath);
                    UpdateGynCase.AddWithValue("@ComplicationsID", model.ComplicationsID);
                    UpdateGynCase.AddWithValue("@HospitalID", model.HospitalID);
                    UpdateGynCase.AddWithValue("@DaysInHospital", model.DaysInHospital);
                });
        }

        public static GynCases GetGynCase(int id)
        {
            GynCases item = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.GynCases_SelectById",
                inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@Id", id);
                }, map: delegate (IDataReader reader, short set)
                {
                    item = MapGynCase(reader);
                });

            return item;
        }

        public static List<GynCases> GetGynCaseList()
        {
            List<GynCases> list = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.GynCases_SelectAll",
                inputParamMapper: null,
                map: delegate (IDataReader reader, short set)
                {
                    GynCases item = MapGynCase(reader);
                    if (list == null)
                    {
                        list = new List<GynCases>();
                    }

                    list.Add(item);
                });

            return list;
        }

        public static void DeleteGynCase(int id)
        {
            DataProvider.ExecuteNonQuery(GetConnection, "dbo.GynCases_DeleteById",
                inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@Id", id);
                });
        }

        private static GynCases MapGynCase(IDataReader reader)
        {
            GynCases item = new GynCases();
            Hospitals hosp = new Hospitals();
            GynCategories comp = new GynCategories();

            int startingIndex = 0;

            item.Id = reader.GetInt32(startingIndex++);
            item.PatientID = reader.GetString(startingIndex++);
            item.Age = reader.GetInt32(startingIndex++);
            item.Gravity = reader.GetInt32(startingIndex++);
            item.Parity = reader.GetInt32(startingIndex++);
            item.Admission = reader.GetString(startingIndex++);
            item.Treatment = reader.GetString(startingIndex++);
            item.SurgicalPath = reader.GetString(startingIndex++);
            comp.Id = reader.GetInt32(startingIndex++);
            comp.Category = reader.GetString(startingIndex++);
            hosp.Id = reader.GetInt32(startingIndex++);
            hosp.Name = reader.GetString(startingIndex++);
            item.DaysInHospital = reader.GetInt32(startingIndex++);
            item.DateAdded = reader.GetDateTime(startingIndex++);
            item.DateModified = reader.GetDateTime(startingIndex++);

            item.Hospital = hosp;
            item.Complication = comp;
            return item;
        }
    }


}