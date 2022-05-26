using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GuestHouseApp.Models
{
    public class GovtIdCard
    {
        public virtual int Id { get; set; }
        public virtual string Description { get; set; }
        public virtual int Active { get; set; }
        public virtual string UpdatedBy { get; set; }
        public virtual DateTime UpdatedOn { get; set; }
    }
}