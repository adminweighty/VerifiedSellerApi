using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerifiedSeller.Shared.Entities.Database
{
    public class UserRoles
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset DateModified { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public int status { get; set; }

    }
}
