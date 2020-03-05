using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Models
{
    [Table("Board")]
    public class Board : BaseEntity
    {
        public int GameId { get; set; }
        public int PlayerId { get; set; }

        public virtual Game Game { get; set; }
        public virtual Player Player { get; set; }
        public virtual ICollection<PointCoordinate> PointCoordinates { get; set; }
    }
}
