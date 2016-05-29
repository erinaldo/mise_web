using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mise.model
{
    public class Categoria
    {
        public Categoria() { }
        public Categoria(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
        public int Id { get; set; }
        public string Nome { get; set; }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return obj != null && obj is Categoria && ((Categoria)obj).Id == this.Id;
        }
    }
}
