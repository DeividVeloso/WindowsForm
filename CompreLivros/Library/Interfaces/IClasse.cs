using Library.Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Interfaces
{
    public interface IClasse
    {

        /// <summary>
        /// Data Alteração
        /// </summary>
        DateTime? DataAlteracao
        {
            get;
            set;
        }

       
        /// <summary>
        /// Data Inclusao
        /// </summary>
        DateTime? DataInclusao
        {
            get;
            set;
        }

        /// <summary>
        /// Data Desativacao
        /// </summary>
        DateTime? DataDesativacao
        {
            get;
            set;
        }

        EnumTipoOperacao Operacao
        {
            get;
            set;
        }
    }
}
