using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mise.model
{
    public class Lancamento
    {
        public Lancamento() { }

        public long Id { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public Categoria Categoria { get; set; }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return obj != null && obj is Lancamento && ((Lancamento)obj).Id == this.Id;
        }
    }
}
