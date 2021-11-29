using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.Municipio
{
    public class MunicipioDtoUpdate
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        [StringLength(60)]
        public string Name { get; set; }
        [Range(0, int.MaxValue)]
        public int CodIBGE { get; set; }
        [Required]
        public Guid UfId { get; set; }
    }
}
