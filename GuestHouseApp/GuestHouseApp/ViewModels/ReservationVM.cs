using GuestHouseApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuestHouseApp.ViewModels
{
    public class ReservationVM
    {
        public virtual MasterTable MasterTable { get; set; }
        public virtual List<GovtIdCard> GovtIdCardList { get; set; }
        public virtual List<Country> CountryList { get; set; }
        public virtual List<PaymentMethod> PaymentMethodList { get; set; }
    }
}