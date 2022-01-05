using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueAlarmaq.Domain
{
    public class Produto
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Produto(string codigo, string name, string description)
        {
            Codigo = codigo;
            Name = name;
            Description = description;
        }

    }
}
