using System;
using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class PlayerSignInReqModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
