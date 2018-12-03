using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CadastroPessoa.Models
{
    public class PessoaFisica 
    {
        public string Cpf { get; set; }
        public string DataNascimento { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }

        public int Id { get; set; }
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
    }
}