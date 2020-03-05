using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Models
{
    public class GameStatus : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}
