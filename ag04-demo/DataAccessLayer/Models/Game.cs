using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Models
{
    [Table("Game")]
    public class Game : BaseEntity
    {
        public int PlayerId { get; set; }
        public int OpponentId { get; set; }
        public int GameStatusId { get; set; }

        public virtual Player Player { get; set; }
        public virtual Player Opponent { get; set; }
        public virtual GameStatus GameStatus { get; set; }

        public virtual ICollection<Board> Boards { get; set; }
    }
}
