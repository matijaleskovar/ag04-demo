using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Models
{
    public class Board : BaseEntity
    {
        public int GameId { get; set; }
        public int PlayerId { get; set; }

        public virtual Game Game { get; set; }
        public virtual Player Player { get; set; }
        public virtual ICollection<PointCoordinate> PointCoordinates { get; set; }
    }
}
