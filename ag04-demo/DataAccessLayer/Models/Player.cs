using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Models
{
    [Table("Players")]
    public class Player : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Game> Games { get; set; }
        public virtual ICollection<Game> GamesOpponent { get; set; }
        public virtual ICollection<Board> Boards { get; set; }
    }
}
