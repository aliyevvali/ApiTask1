using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTask1.Dtos.ActorDtos
{
    public class ActorDto
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Image { get; set; }
    }
}
