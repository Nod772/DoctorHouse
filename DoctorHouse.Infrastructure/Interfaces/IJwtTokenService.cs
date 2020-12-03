using DoctorHouse.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoctorHouse.Infrastructure.Interfaces
{
    public interface IJwtTokenService
    {
        string CreateToken(DbUser user);
    }

    
}
