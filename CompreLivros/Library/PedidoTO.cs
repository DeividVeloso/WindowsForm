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
    public class PedidoTO : IClasse
    {
        private int _codPedidoID;
        private int _codCliID;
        private int _codProdID;
        private DateTime? _dtCompra;
        private DateTime? _dtCancelado;
        private string _obs;
        private DateTime? _datainclusao;
        private DateTime? _dataalteracao;

        public int CodPedidoID
        {
            get { return _codPedidoID; }
            set { _codPedidoID = value; }
        }

        public int CodCliID
        {
            get { return _codCliID; }
            set { _codCliID = value; }
        }

        public int CodProdID
        {
            get { return _codProdID; }
            set { _codProdID = value; }
        }

        public DateTime? DtCompra
        {
            get { return _dtCompra; }
            set { _dtCompra = value; }
        }

        public DateTime? DtCancelado
        {
            get { return _dtCancelado; }
            set { _dtCancelado = value; }
        }

        public string Obs
        {
            get { return _obs; }
            set { _obs = value; }
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
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        private EnumTipoOperacao _operacao = EnumTipoOperacao.Nenhuma;

        public EnumTipoOperacao Operacao
        {
            get { return _operacao; }
            set { _operacao = value; }
        }

    }
}
