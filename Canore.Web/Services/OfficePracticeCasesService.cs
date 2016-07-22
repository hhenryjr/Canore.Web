using Canore.Web.Domain;
using Canore.Web.Models.Requests.OfficePracticeCases;
using Sabio.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Canore.Web.Services
{
    public class OfficePracticeCasesService : BaseService/*, IOfficePracticeCasesService*/
    {
        public static int Get()
        {
            return 0;
        }

        public static int CreateOfficePracticeCase(OfficePracticeCasesAddRequest model)//, string caseId)
        {
            var id = 0;

            DataProvider.ExecuteNonQuery(GetConnection, "dbo.OfficePracticeCases_Insert",
                inputParamMapper: delegate (SqlParameterCollection InsertOfficePracticeCase)
                {
                    InsertOfficePracticeCase.AddWithValue("@PatientID", model.PatientID);
                    InsertOfficePracticeCase.AddWithValue("@Age", model.Age);
                    InsertOfficePracticeCase.AddWithValue("@Gravity", model.Gravity);
                    InsertOfficePracticeCase.AddWithValue("@Parity", model.Parity);
                    InsertOfficePracticeCase.AddWithValue("@Visits", model.Visits);
                    InsertOfficePracticeCase.AddWithValue("@Problem", model.Problem);
                    InsertOfficePracticeCase.AddWithValue("@DiagnosticProc", model.DiagnosticProc);
                    InsertOfficePracticeCase.AddWithValue("@ComplicationID", model.ComplicationID);
                    InsertOfficePracticeCase.AddWithValue("@Treatment", model.Treatment);
                    InsertOfficePracticeCase.AddWithValue("@Result", model.Result);

                    SqlParameter param = new SqlParameter("@Id", SqlDbType.Int);
                    param.Direction = ParameterDirection.Output;

                    InsertOfficePracticeCase.Add(param);
                },

                returnParameters: delegate (SqlParameterCollection par)
                {
                    int.TryParse(par["@Id"].Value.ToString(), out id);
                }
                );

            return id;

        }

        public static void ModifyOfficePracticeCase(OfficePracticeCasesUpdateRequest model)
        {
            DataProvider.ExecuteNonQuery(GetConnection, "dbo.OfficePracticeCases_Update",
                inputParamMapper: delegate (SqlParameterCollection UpdateOfficePracticeCase)
                {
                    UpdateOfficePracticeCase.AddWithValue("@Id", model.Id);
                    UpdateOfficePracticeCase.AddWithValue("@PatientID", model.PatientID);
                    UpdateOfficePracticeCase.AddWithValue("@Age", model.Age);
                    UpdateOfficePracticeCase.AddWithValue("@Gravity", model.Gravity);
                    UpdateOfficePracticeCase.AddWithValue("@Parity", model.Parity);
                    UpdateOfficePracticeCase.AddWithValue("@Visits", model.Visits);
                    UpdateOfficePracticeCase.AddWithValue("@Problem", model.Problem);
                    UpdateOfficePracticeCase.AddWithValue("@DiagnosticProc", model.DiagnosticProc);
                    UpdateOfficePracticeCase.AddWithValue("@ComplicationID", model.ComplicationID);
                    UpdateOfficePracticeCase.AddWithValue("@Treatment", model.Treatment);
                    UpdateOfficePracticeCase.AddWithValue("@Result", model.Result);
                });
        }

        public static OfficePracticeCases GetOfficePracticeCase(int id)
        {
            OfficePracticeCases item = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.OfficePracticeCases_SelectById",
                inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@Id", id);
                }, map: delegate (IDataReader reader, short set)
                {
                    item = MapOfficePracticeCase(reader);
                });

            return item;
        }

        public static List<OfficePracticeCases> GetOfficePracticeCaseList()
        {
            List<OfficePracticeCases> list = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.OfficePracticeCases_SelectAll",
                inputParamMapper: null,
                map: delegate (IDataReader reader, short set)
                {
                    OfficePracticeCases item = MapOfficePracticeCase(reader);
                    if (list == null)
                    {
                        list = new List<OfficePracticeCases>();
                    }

                    list.Add(item);
                });

            return list;
        }

        public static void DeleteOfficePracticeCase(int id)
        {
            DataProvider.ExecuteNonQuery(GetConnection, "dbo.OfficePracticeCases_DeleteById",
                inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@Id", id);
                });
        }

        private static OfficePracticeCases MapOfficePracticeCase(IDataReader reader)
        {
            OfficePracticeCases item = new OfficePracticeCases();
            OfficeCategories cat = new OfficeCategories();

            int startingIndex = 0;

            item.Id = reader.GetSafeInt32(startingIndex++);
            item.PatientID = reader.GetSafeString(startingIndex++);
            item.Age = reader.GetSafeInt32(startingIndex++);
            item.Gravity = reader.GetSafeInt32(startingIndex++);
            item.Parity = reader.GetSafeInt32(startingIndex++);
            item.Visits = reader.GetSafeInt32(startingIndex++);
            item.Problem = reader.GetSafeString(startingIndex++);
            item.DiagnosticProc = reader.GetSafeString(startingIndex++);
            cat.Id = reader.GetSafeInt32(startingIndex++);
            cat.Category = reader.GetSafeString(startingIndex++);
            item.Treatment = reader.GetSafeString(startingIndex++);
            item.Result = reader.GetSafeString(startingIndex++);
            item.DateAdded = reader.GetSafeDateTime(startingIndex++);
            item.DateModified = reader.GetSafeDateTime(startingIndex++);
            
            item.Complication = cat;
            return item;
        }
    }


}