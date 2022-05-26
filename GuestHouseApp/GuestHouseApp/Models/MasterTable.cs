using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GuestHouseApp.Models
{
    public class MasterTable
    {
        public virtual int Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        [EmailAddress]
        public virtual string Email { get; set; }
        public virtual GovtIdCard GovtIdCard { get; set; }
        public virtual string GovtIdNo { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public virtual DateTime DateOfArr { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public virtual DateTime DateOfDep { get; set; }
        public virtual Country Country { get; set; }
        public virtual int NumberOfPerson { get; set; }
        public virtual string Remarks { get; set; }
        public  virtual PaymentMethod  PaymentMethod { get; set; }
        public virtual int Active { get; set; }
        public virtual string UpdatedBy { get; set; }
        public virtual DateTime UpdatedOn { get; set; }
    }
}