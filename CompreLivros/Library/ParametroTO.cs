using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    [Serializable]
    public class ParametroTO
    {
        string _txtNomeFormulario;
        string _menuToolStripMenuItem;

        public string MenuToolStripMenuItem
        {
            get { return _menuToolStripMenuItem; }
            set { _menuToolStripMenuItem = value; }
        }

        public string TxtNomeFormulario
        {
            get { return _txtNomeFormulario; }
            set { _txtNomeFormulario = value; }
        }
        //string _qtdLicencaLote;

        //public string LoteSimNao
        //{
        //    get { return _loteSimNao; }
        //    set { _loteSimNao = value; }
        //}


        //public string QtdLicencaLote
        //{
        //    get { return _qtdLicencaLote; }
        //    set { _qtdLicencaLote = value; }
        //}

    }
}
