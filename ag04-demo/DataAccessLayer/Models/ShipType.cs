using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Models
{
    [Table("ShipType")]
    public class ShipType : BaseEntity
    {
        public string Name { get; set; }
        public int NumberOfPoints { get; set; }

        public virtual ICollection<PointCoordinate> PointCoordinates { get; set; }
    }
}
