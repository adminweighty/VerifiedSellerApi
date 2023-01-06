﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VerifiedSeller.Shared.Entities.Remote.Request
{
    public class OptOutRequest
    {
        [Required]
        [JsonPropertyName("Email")]
        public string Email { get; set; }
    }
}
