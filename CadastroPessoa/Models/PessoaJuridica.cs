using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CadastroPessoa.Models
{
    public class PessoaJuridica 
    {
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }

        public int Id { get; set; }
        public string CEP2 { get; set; }
        public string Logradouro2 { get; set; }
        public string Numero2 { get; set; }
        public string Complemento2 { get; set; }
        public string Bairro2 { get; set; }
        public string Cidade2 { get; set; }
        public string Uf2 { get; set; }
    }
}