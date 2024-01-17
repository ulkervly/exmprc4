using Microsoft.AspNetCore.Http;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Core.Entities
{
    public class Trainer:BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public string MediaLinks { get; set; }
        public string? ImageUrl {  get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
