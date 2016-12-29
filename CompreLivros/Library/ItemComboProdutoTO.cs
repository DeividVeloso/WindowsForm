using Library.Enumeradores;
using Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    [Serializable]
    public class ItemComboProdutoTO : IClasse
    {
        string _idItem;
        string _descricao;
        decimal _preco;

       


            /// <summary>
        /// ID do item
        /// </summary>
        public string IDItem
        {
            get { return _idItem; }
            set { _idItem = value; }
        }

        /// <summary>
        /// Descrição do item
        /// </summary>
        public string Descricao
        {
            get { return _descricao; }
            set { _descricao = value; }
        }

        public decimal Preco
        {
            get { return _preco; }
            set { _preco = value; }
        }

        /// <summary>
        /// Override do ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (String.IsNullOrEmpty(_descricao))
                return "";
            else
                return _descricao;
        }

        #region IClasse Members

  
        public string UsuarioAlteracao
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public DateTime? DataAlteracao
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string UsuarioInclusao
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public DateTime? DataInclusao
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public DateTime? DataDesativacao
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        private EnumTipoOperacao _operacao = EnumTipoOperacao.Nenhuma;

        public EnumTipoOperacao Operacao
        {
            get { return _operacao; }
            set { _operacao = value; }
        }
    }
}
