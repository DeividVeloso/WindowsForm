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
    public class ClienteTO : IClasse
    {

        private int _codCliID;
        private string _nome;
        private string _cPF;
        private DateTime? _dtNascimento;
        private string _telefone;
        private string _celular;
        private string _email;
        private string _sexo;
        private DateTime? _datainclusao;
        private DateTime? _dataalteracao;
        private DateTime? _dataDesativacao;


        public int CodCliID
        {
            get { return _codCliID; }
            set { _codCliID = value; }
        }

        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        public string CPF
        {
            get { return _cPF; }
            set { _cPF = value; }
        }

        public DateTime? DtNascimento
        {
            get { return _dtNascimento; }
            set { _dtNascimento = value; }
        }

        public string Telefone
        {
            get { return _telefone; }
            set { _telefone = value; }
        }

        public string Celular
        {
            get { return _celular; }
            set { _celular = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Sexo
        {
            get { return _sexo; }
            set { _sexo = value; }
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
