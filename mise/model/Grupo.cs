using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mise.model
{
    public class Grupo
    {
        private int _id;
        private string _nome;

        public Grupo(int id, string nome)
        {
            _id = id;
            _nome = nome;
        }

        public Grupo() { }

        public string Nome {
            get { return _nome; }
            set { _nome = value; }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public override int GetHashCode()
        {
            return _id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return obj != null && obj is Grupo && ((Grupo)obj)._id == this._id;
        }
    }
}
