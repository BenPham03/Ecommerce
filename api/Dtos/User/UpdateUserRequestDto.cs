using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.User
{
    public class UpdateUserRequestDto
    {
        public string Email { get; set; } = string.Empty;
        public string PassWord { get; set; } = string.Empty;
        public Decimal Fund { get; set; }
        public int Type { get; set; }
        public string UserName { get; set; } = string.Empty;
        public int? CustomerId { get; set; }

    }
}