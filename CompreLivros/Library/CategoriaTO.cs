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
    public class CategoriaTO : IClasse
    {
        private int _categoriaID;
        private string _nome;
        private DateTime? _datainclusao;
        private DateTime? _dataalteracao;
        private DateTime? _dataDesativacao;

        public int CategoriaID
        {
            get { return _categoriaID; }
            set { _categoriaID = value; }
        }
     
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }
      
        public DateTime? DataAlteracao
        {
            get { return _dataalteracao; }
            set { _dataalteracao = value; }
        }

      
        public DateTime? DataInclusao
        {
            get { return _datainclusao; }
            set { _datainclusao = value; }
        }

        public DateTime? DataDesativacao
        {
            get { return _dataDesativacao; }
            set { _dataDesativacao = value; }
        }

        private EnumTipoOperacao _operacao = EnumTipoOperacao.Nenhuma;

        public EnumTipoOperacao Operacao
        {
            get { return _operacao; }
            set { _operacao = value; }
        }

    }
}
