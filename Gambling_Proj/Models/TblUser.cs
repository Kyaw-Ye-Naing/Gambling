using System;
using System.Collections.Generic;

namespace Gambling_Proj.Models
{
    public partial class TblUser
    {
        internal string LoginErrorMessage;

        public decimal UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool? Lock { get; set; }
        public int? RoleId { get; set; }
        public decimal? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
