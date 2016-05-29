﻿using Canore.Web.Domain;
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

    }
}