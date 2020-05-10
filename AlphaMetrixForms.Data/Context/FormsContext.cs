using AlphaMetrixForms.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlphaMetrixForms.Data.Context
{
    public class FormsContext : IdentityDbContext<User, Role, Guid>
    {

    }
}
