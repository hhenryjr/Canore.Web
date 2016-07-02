using Canore.Web.Domain;
using System;
using Sabio.Data;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Canore.Web.Services
{
    public class CategoriesService : BaseService
    {
        public static int Get()
        {
            return 0;
        }

        //OBSTETRICAL///////////////////////////////////////////////////////////////
        public static ObCategories GetObCategory(int id)
        {
            ObCategories item = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.ObCategories_SelectById",
                inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@Id", id);
                }, map: delegate (IDataReader reader, short set)
                {
                    item = MapObCategory(reader);
                });

            return item;
        }

        public static List<ObCategories> GetObCategoryList()
        {
            List<ObCategories> list = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.ObCategories_SelectAll",
                inputParamMapper: null,
                map: delegate (IDataReader reader, short set)
                {
                    ObCategories item = MapObCategory(reader);
                    if (list == null)
                    {
                        list = new List<ObCategories>();
                    }

                    list.Add(item);
                });

            return list;
        }

        private static ObCategories MapObCategory(IDataReader reader)
        {
            ObCategories item = new ObCategories();
            int startingIndex = 0;

            item.Id = reader.GetSafeInt32(startingIndex++);
            item.Category = reader.GetSafeString(startingIndex++);

            return item;
        }

        //GYNECOLOGICAL///////////////////////////////////////////////////////////////
        public static GynCategories GetGynCategory(int id)
        {
            GynCategories item = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.GynCategories_SelectById",
                inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@Id", id);
                }, map: delegate (IDataReader reader, short set)
                {
                    item = MapGynCategory(reader);
                });

            return item;
        }

        public static List<GynCategories> GetGynCategoryList()
        {
            List<GynCategories> list = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.GynCategories_SelectAll",
                inputParamMapper: null,
                map: delegate (IDataReader reader, short set)
                {
                    GynCategories item = MapGynCategory(reader);
                    if (list == null)
                    {
                        list = new List<GynCategories>();
                    }

                    list.Add(item);
                });

            return list;
        }

        private static GynCategories MapGynCategory(IDataReader reader)
        {
            GynCategories item = new GynCategories();
            int startingIndex = 0;

            item.Id = reader.GetSafeInt32(startingIndex++);
            item.Category = reader.GetSafeString(startingIndex++);

            return item;
        }

        //OFFICE PRACTICE///////////////////////////////////////////////////////////////
        public static OfficeCategories GetOfficeCategory(int id)
        {
            OfficeCategories item = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.OfficeCategories_SelectById",
                inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@Id", id);
                }, map: delegate (IDataReader reader, short set)
                {
                    item = MapOfficeCategory(reader);
                });

            return item;
        }

        public static List<OfficeCategories> GetOfficeCategoryList()
        {
            List<OfficeCategories> list = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.OfficeCategories_SelectAll",
                inputParamMapper: null,
                map: delegate (IDataReader reader, short set)
                {
                    OfficeCategories item = MapOfficeCategory(reader);
                    if (list == null)
                    {
                        list = new List<OfficeCategories>();
                    }

                    list.Add(item);
                });

            return list;
        }

        private static OfficeCategories MapOfficeCategory(IDataReader reader)
        {
            OfficeCategories item = new OfficeCategories();
            int startingIndex = 0;

            item.Id = reader.GetSafeInt32(startingIndex++);
            item.Category = reader.GetSafeString(startingIndex++);

            return item;
        }
    }
}