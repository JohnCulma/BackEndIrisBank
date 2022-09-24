using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IrisBanck.DataAccess.Context
{
    public partial class AppContextIrisBank : IdentityDbContext
    {
        public AppContextIrisBank(DbContextOptions<AppContextIrisBank> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}
