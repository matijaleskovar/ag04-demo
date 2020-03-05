using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Models
{
    public class ShipType : BaseEntity
    {
        public string Name { get; set; }
        public int NumberOfPoints { get; set; }

        public virtual ICollection<PointCoordinate> PointCoordinates { get; set; }
    }
}
