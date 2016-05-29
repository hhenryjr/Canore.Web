using Canore.Web.Domain;
using Canore.Web.Models.ObstetricalCases;
using Canore.Web.Models.Requests.ObstetricalCases;
using Canore.Web.Services.Interfaces;
using Sabio.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Canore.Web.Services
{
    public class ObstetricalCasesService : BaseService/*, IObstetricalCasesService*/
    {
        public static int Get()
        {
            return 0;
        }

        public static int CreateObCase(ObstetricalCasesAddRequest model)//, string caseId)
        {
            var id = 0;

            DataProvider.ExecuteNonQuery(GetConnection, "dbo.ObstetricalCases_Insert",
                inputParamMapper: delegate(SqlParameterCollection InsertObCase)
                {
                    InsertObCase.AddWithValue("@PatientID", model.PatientID);
                    InsertObCase.AddWithValue("@Age", model.Age);
                    InsertObCase.AddWithValue("@Gravity", model.Gravity);
                    InsertObCase.AddWithValue("@Parity", model.Parity);
                    InsertObCase.AddWithValue("@AntepartumID", model.AntepartumID);
                    InsertObCase.AddWithValue("@PostpartumID", model.PostpartumID);
                    InsertObCase.AddWithValue("@Treatment", model.Treatment);
                    InsertObCase.AddWithValue("@BirthWeight", model.BirthWeight);
                    InsertObCase.AddWithValue("@Death", model.Death);
                    InsertObCase.AddWithValue("@OneMinScore", model.OneMinScore);
                    InsertObCase.AddWithValue("@FiveMinScore", model.FiveMinScore);
                    InsertObCase.AddWithValue("@HospitalID", model.HospitalID);
                    InsertObCase.AddWithValue("@DaysInHospital", model.DaysInHospital);

                    SqlParameter param = new SqlParameter("@Id", System.Data.SqlDbType.Int);
                    param.Direction = System.Data.ParameterDirection.Output;

                    InsertObCase.Add(param);
                },

                returnParameters: delegate(SqlParameterCollection par)
                {
                    int.TryParse(par["@Id"].Value.ToString(), out id);
                }
                );

            return id;

        }

        public static void ModifyObCase(ObstetricalCasesUpdateRequest model)
        {
            DataProvider.ExecuteNonQuery(GetConnection, "dbo.ObstetricalCases_Update",
                inputParamMapper: delegate(SqlParameterCollection UpdateObCase)
                {
                    UpdateObCase.AddWithValue("@Id", model.Id);
                    UpdateObCase.AddWithValue("@PatientID", model.PatientID);
                    UpdateObCase.AddWithValue("@Age", model.Age);
                    UpdateObCase.AddWithValue("@Gravity", model.Gravity);
                    UpdateObCase.AddWithValue("@Parity", model.Parity);
                    UpdateObCase.AddWithValue("@AntepartumID", model.AntepartumID);
                    UpdateObCase.AddWithValue("@PostpartumID", model.PostpartumID);
                    UpdateObCase.AddWithValue("@Treatment", model.Treatment);
                    UpdateObCase.AddWithValue("@BirthWeight", model.BirthWeight);
                    UpdateObCase.AddWithValue("@Death", model.Death);
                    UpdateObCase.AddWithValue("@OneMinScore", model.OneMinScore);
                    UpdateObCase.AddWithValue("@FiveMinScore", model.FiveMinScore);
                    UpdateObCase.AddWithValue("@HospitalID", model.HospitalID);
                    UpdateObCase.AddWithValue("@DaysInHospital", model.DaysInHospital);
                });
        }

        public static ObstetricalCases GetObCase(int id)
        {
            ObstetricalCases item = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.ObstetricalCases_SelectById",
                inputParamMapper: delegate(SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@Id", id);
                }, map: delegate(IDataReader reader, short set)
                {
                    item = MapObCase(reader);
                });

            return item;
        }

        public static List<ObstetricalCases> GetObCaseList()
        {
            List<ObstetricalCases> list = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.ObstetricalCases_SelectAll",
                inputParamMapper: null,
                map: delegate (IDataReader reader, short set)
                {
                    ObstetricalCases item = MapObCase(reader);
                    if (list == null)
                    {
                        list = new List<ObstetricalCases>();
                    }

                    list.Add(item);
                });

            return list;
        }

        public static void DeleteObCase(int id)
        {
            DataProvider.ExecuteNonQuery(GetConnection, "dbo.ObstetricalCases_DeleteById",
                inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@Id", id);
                });
        }

        private static ObstetricalCases MapObCase(IDataReader reader)
        {
            ObstetricalCases item = new ObstetricalCases();
            Hospitals hosp = new Hospitals();
            ObCategories ante = new ObCategories();
            ObCategories post = new ObCategories();

            int startingIndex = 0;

            item.Id = reader.GetSafeInt32(startingIndex++);
            item.PatientID = reader.GetSafeString(startingIndex++);
            item.Age = reader.GetSafeInt32(startingIndex++);
            item.Gravity = reader.GetSafeInt32(startingIndex++);
            item.Parity = reader.GetSafeInt32(startingIndex++);
            ante.Id = reader.GetSafeInt32(startingIndex++);
            ante.Category = reader.GetSafeString(startingIndex++);
            post.Id = reader.GetSafeInt32(startingIndex++);
            post.Category = reader.GetSafeString(startingIndex++);
            item.Treatment = reader.GetSafeString(startingIndex++);
            item.BirthWeight = reader.GetSafeInt32(startingIndex++);
            item.Death = reader.GetSafeString(startingIndex++);
            item.OneMinScore = reader.GetSafeInt32(startingIndex++);
            item.FiveMinScore = reader.GetSafeInt32(startingIndex++);
            hosp.Id = reader.GetSafeInt32(startingIndex++);
            hosp.Name = reader.GetSafeString(startingIndex++);
            item.DaysInHospital = reader.GetSafeInt32(startingIndex++);
            item.DateAdded = reader.GetSafeDateTime(startingIndex++);
            item.DateModified = reader.GetSafeDateTime(startingIndex++);

            item.Hospital = hosp;
            item.Antepartum = ante;
            item.Postpartum = post;
            return item;
        }
    }
}