using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Canore.Web.Models.ViewModels
{
    public class ItemViewModel<Type> : BaseViewModel
    {
        public Type Item { get; set; }
    }
}