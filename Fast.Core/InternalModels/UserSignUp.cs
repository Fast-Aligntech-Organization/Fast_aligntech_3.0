﻿
using System;
using System.ComponentModel.DataAnnotations;

namespace Fast.Core
{
    public class UserSignUp
    {
        [StringLength(64), Required]
        public string Name { get; set; }
        [StringLength(64), Required]
        public string Lastname { get; set; }
        [DataType(DataType.Date), Required]
        public DateTime Birthday { get; set; }
        [Required, RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")]
        public string Email { get; set; }
        [Required]
        public RoleType Role { get; set; }
        [Required, StringLength(128)]
        public string Password { get; set; }

        [Required, StringLength(64)]
        public string Username { get; set; }

        [Required,StringLength(64)]
        public string ClockNumber { get; set; }








    }
}
