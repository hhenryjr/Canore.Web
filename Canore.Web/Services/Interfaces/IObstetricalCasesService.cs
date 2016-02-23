using Canore.Web.Domain;
using Canore.Web.Models.ObstetricalCases;
using Canore.Web.Models.Requests.ObstetricalCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canore.Web.Services.Interfaces
{
    /*public */interface IObstetricalCasesService
    {
        int CreateObCase(ObstetricalCasesAddRequest model);

        void ModifyObCase(ObstetricalCasesUpdateRequest model);

        ObstetricalCases GetObCase(int id);

        List<ObstetricalCases> GetObCaseList();

        void DeleteObCase(int id);
    }
}
