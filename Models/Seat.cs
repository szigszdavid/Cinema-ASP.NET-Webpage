using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Web.Models
{
    public class Seat
    {
        [Key]
        public int Id { get; set; }

        public int RowID { get; set; }

        public int ColumnID { get; set; }

        public int SeatValue { get; set; }

        public int ScreeningId { get; set; }
    }
}
