using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Models
{
    public class BaseEntity
    {
        public DateTime CreatedUTC { get; set; }
        public DateTime ModifiedUTC { get; set; }
    }
}
