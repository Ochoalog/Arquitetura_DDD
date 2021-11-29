using Domain.Dtos.Uf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.Municipio
{
    public class MunicipioCompleto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int CodIBGE { get; set; }
        public Guid UfId { get; set; }

        public UfDto Uf { get; set; }
    }
}
