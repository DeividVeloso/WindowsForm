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
    public class ProdutoTO : IClasse
    {
        private int _codProdID;
        private string _titulo;
        private string _iSBN;
        private int _paginas;
        private int _edicao;
        private string _editora;
        private int _anoLanca;
        private int _categoriaID;
        private string _idioma;
        private string _sinopse;
        private Decimal _preco;

        private DateTime? _datainclusao;
        private DateTime? _dataalteracao;
        private DateTime? _dataDesativacao;


        public int CodProdID
        {
            get { return _codProdID; }
            set { _codProdID = value; }
        }

        public string Titulo
        {
            get { return _titulo; }
            set { _titulo = value; }
        }

        public string ISBN
        {
            get { return _iSBN; }
            set { _iSBN = value; }
        }

        public int Paginas
        {
            get { return _paginas; }
            set { _paginas = value; }
        }

        public int Edicao
        {
            get { return _edicao; }
            set { _edicao = value; }
        }

        public string Editora
        {
            get { return _editora; }
            set { _editora = value; }
        }

        public int AnoLanca
        {
            get { return _anoLanca; }
            set { _anoLanca = value; }
        }

        public int CategoriaID
        {
            get { return _categoriaID; }
            set { _categoriaID = value; }
        }

        public string Idioma
        {
            get { return _idioma; }
            set { _idioma = value; }
        }

        public string Sinopse
        {
            get { return _sinopse; }
            set { _sinopse = value; }
        }

        public Decimal Preco
        {
            get { return _preco; }
            set { _preco = value; }
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
