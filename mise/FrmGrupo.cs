using mise.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mise
{
    public partial class FrmGrupo : Form
    {
        private Grupo _grupo;
        private GrupoRepo _repo = GrupoRepo.Instance;
        public FrmGrupo(Grupo g)
        {
            _grupo = g ?? new Grupo();
            InitializeComponent();
        }

        public FrmGrupo() : this(null) { }

        private void FrmGrupo_Load(object sender, EventArgs e)
        {
            txtDescricao.Text = _grupo.Nome;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            _grupo.Nome = txtDescricao.Text;
            try
            {
                if (_grupo.Id == 0)
                {
                    _repo.Incluir(_grupo);
                }
                else
                {
                    _repo.Alterar(_grupo);
                }
                fadingLabel.ShowAndFade();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        public Grupo Grupo
        {
            get { return _grupo; }
        }
    }
}
