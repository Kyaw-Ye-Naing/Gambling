using System;
using System.Collections.Generic;

namespace Gambling_Proj.Models
{
    public partial class TblFootballTeam
    {
        public decimal FootballTeamId { get; set; }
        public string FootballTeam { get; set; }
        public string FootballTeamMyan { get; set; }
        public string League { get; set; }
        public bool? Active { get; set; }
        public decimal? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
