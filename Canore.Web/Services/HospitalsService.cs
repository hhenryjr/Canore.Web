using Canore.Web.Domain;
using Canore.Web.Models.Requests.Hospitals;
using Sabio.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Canore.Web.Services
{
    public class HospitalsService : BaseService
    {
        public static int Get()
        {
            return 0;
        }

        public static int AddHospital(HospitalsAddRequest model)
        {
            var id = 0;

            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Hospitals_Insert",
                inputParamMapper: delegate (SqlParameterCollection InsertHospital)
                {
                    //InsertHospital.AddWithValue("@HospitalId", model.HospitalId);
                    InsertHospital.AddWithValue("@Name", model.Name);
                    InsertHospital.AddWithValue("@Abbrev", model.Abbrev);
                    InsertHospital.AddWithValue("@Address", model.Address);
                    InsertHospital.AddWithValue("@City", model.City);
                    InsertHospital.AddWithValue("@State", model.State);
                    InsertHospital.AddWithValue("@ZipCode", model.ZipCode);

                    SqlParameter param = new SqlParameter("@Id", System.Data.SqlDbType.Int);
                    param.Direction = System.Data.ParameterDirection.Output;

                    InsertHospital.Add(param);
                },

                returnParameters: delegate (SqlParameterCollection par)
                {
                    int.TryParse(par["@Id"].Value.ToString(), out id);
                }
                );

            return id;
        }

        public static void UpdateHopsital(HospitalsUpdateRequest model)
        {
            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Hospitals_Update",
                inputParamMapper: delegate (SqlParameterCollection UpdateHospital)
                {
                    UpdateHospital.AddWithValue("@Id", model.Id);
                    //UpdateHospital.AddWithValue("@HospitalId", model.HospitalId);
                    UpdateHospital.AddWithValue("@Name", model.Name);
                    UpdateHospital.AddWithValue("@Abbrev", model.Abbrev);
                    UpdateHospital.AddWithValue("@Address", model.Address);
                    UpdateHospital.AddWithValue("@City", model.City);
                    UpdateHospital.AddWithValue("@State", model.State);
                    UpdateHospital.AddWithValue("@ZipCode", model.ZipCode);
                });
        }

        public static Hospitals GetHospital(int id)
        {
            Hospitals item = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.Hospitals_SelectById",
                inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@Id", id);
                }, map: delegate (IDataReader reader, short set)
                {
                    item = MapHospital(reader);
                });

            return item;
        }

        public static List<Hospitals> GetHospitalList()
        {
            List<Hospitals> list = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.Hospitals_SelectAll",
                inputParamMapper: null,
                map: delegate (IDataReader reader, short set)
                {
                    Hospitals item = MapHospital(reader);
                    if (list == null)
                    {
                        list = new List<Hospitals>();
                    }

                    list.Add(item);
                });

            return list;
        }

        public static void DeleteHospital(int id)
        {
            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Hospitals_DeleteById",
                inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@Id", id);
                });
        }

        private static Hospitals MapHospital(IDataReader reader)
        {
            Hospitals item = new Hospitals();
            int startingIndex = 0;

            item.Id = reader.GetSafeInt32(startingIndex++);
            item.Name = reader.GetSafeString(startingIndex++);
            item.Abbrev = reader.GetSafeString(startingIndex++);
            item.Address = reader.GetSafeString(startingIndex++);
            item.City = reader.GetSafeString(startingIndex++);
            item.State = reader.GetSafeString(startingIndex++);
            item.ZipCode = reader.GetSafeInt32(startingIndex++);
            item.GynExams = reader.GetSafeInt32(startingIndex++);
            item.ObExams = reader.GetSafeInt32(startingIndex++);
            item.Deliveries = reader.GetSafeInt32(startingIndex++);

            return item;
        }
    }
}