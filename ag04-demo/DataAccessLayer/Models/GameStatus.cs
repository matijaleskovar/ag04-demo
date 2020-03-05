using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Models
{
    [Table("GameStatus")]
    public class GameStatus : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}
