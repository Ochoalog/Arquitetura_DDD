using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class UfModel
    {
        private string _sigla;

        public string Sigla
        {
            get { return _sigla; }
            set { _sigla = value; }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}
