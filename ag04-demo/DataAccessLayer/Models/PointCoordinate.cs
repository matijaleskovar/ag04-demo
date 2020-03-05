using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Models
{
    [Table("PointCoordinate")]
    public class PointCoordinate : BaseEntity
    {
        public int BoardId { get; set; }
        public int AxisX { get; set; }
        public int AxisY { get; set; }
        public bool Hit { get; set; }
        public int ShipTypeId { get; set; }

        public virtual Board Board { get; set; }
        public virtual ShipType ShipType { get; set; }
    }
}
