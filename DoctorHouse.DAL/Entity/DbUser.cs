using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DoctorHouse.DAL.Entity
{
    public class DbUser : IdentityUser<long>
    {
       
        public virtual ICollection<DbUserRole> UserRoles { get; set; }
    }
}
