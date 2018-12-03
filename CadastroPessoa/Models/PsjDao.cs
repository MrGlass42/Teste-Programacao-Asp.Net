using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CadastroPessoa.Models
{
    public class PsjDao
    {
        private BdHandyMan door;

        private void Inserir(PessoaJuridica pessoa)
        {
            string Query = "";

            Query += "INSERT INTO PessoaJuridica (psj_cnpj, psj_razaoSocial, psj_nomeFantasia, psj_logradouro, psj_numero, psj_complemento, psj_bairro," +
                "psj_cidade, psj_uf, psj_cep)";

            Query += string.Format("VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}', '{9}')", pessoa.Cnpj, pessoa.RazaoSocial
                , pessoa.NomeFantasia, pessoa.Logradouro2, pessoa.Numero2, pessoa.Complemento2, pessoa.Bairro2, pessoa.Cidade2, pessoa.Uf2,
                pessoa.CEP2);

            using (door = new BdHandyMan())
            {
                door.ExecutaComando(Query);
            }
        }

        private void Alterar(PessoaJuridica pessoa)
        {
            string Query = "";


            Query += "UPDATE PessoaJuridica SET";
            Query += string.Format(" psj_cnpj = '{0}', ", pessoa.Cnpj);
            Query += string.Format(" psj_cep = '{0}', ", pessoa.CEP2);
            Query += string.Format(" psj_razaoSocial = '{0}', ", pessoa.RazaoSocial);
            Query += string.Format(" psj_nomeFantasia = '{0}', ", pessoa.NomeFantasia);
            Query += string.Format(" psj_logradouro = '{0}', ", pessoa.Logradouro2);
            Query += string.Format(" psj_numero = '{0}', ", pessoa.Numero2);
            Query += string.Format(" psj_complemento = '{0}', ", pessoa.Complemento2);
            Query += string.Format(" psj_bairro = '{0}', ", pessoa.Bairro2);
            Query += string.Format(" psj_cidade = '{0}', ", pessoa.Cidade2);
            Query += string.Format(" psj_uf = '{0}' ", pessoa.Uf2);
            Query += string.Format(" WHERE psj_id = '{0}' ", pessoa.Id);

            using (door = new BdHandyMan())
            {
                door.ExecutaComando(Query);
            }
        }

        public void Salvar(PessoaJuridica pessoa)
        {
            if (pessoa.Id > 0)
                Alterar(pessoa);
            else
                Inserir(pessoa);
        }


        public void Excluir(int id)
        {
            string Query = string.Format("DELETE FROM PessoaJuridica WHERE psj_id = {0}", id);

            using (door = new BdHandyMan())
            {
                door.ExecutaComando(Query);
            }
        }

        public List<PessoaJuridica> listarTodos()
        {
            string Query = "SELECT * FROM PessoaJuridica";

            using (door = new BdHandyMan())
            {
                var retorno = door.ExecutaComandoComRetorno(Query);

                return toList(retorno);
            }
        }


        private List<PessoaJuridica> toList(SqlDataReader reader)
        {
            var pessoas = new List<PessoaJuridica>();

            while (reader.Read())
            {
                var objeto = new PessoaJuridica()
                {
                    Id = int.Parse(reader["psj_id"].ToString()),
                    Cnpj = reader["psj_cnpj"].ToString(),
                    RazaoSocial = reader["psj_razaoSocial"].ToString(),
                    NomeFantasia = reader["psj_nomeFantasia"].ToString(),
                    Logradouro2 = reader["psj_logradouro"].ToString(),
                    CEP2 = reader["psj_cep"].ToString(),
                    Numero2 = reader["psj_numero"].ToString(),
                    Complemento2 = reader["psj_complemento"].ToString(),
                    Bairro2 = reader["psj_bairro"].ToString(),
                    Cidade2 = reader["psj_cidade"].ToString(),
                    Uf2 = reader["psj_uf"].ToString()
                };

                pessoas.Add(objeto);
            }

            return pessoas;
        }

        public PessoaJuridica ListaPorId(int id)
        {
            string Query = string.Format("SELECT * FROM PessoaJuridica WHERE psj_id = {0}", id);


            using (door = new BdHandyMan())
            {
                var retorno = door.ExecutaComandoComRetorno(Query);
                return toList(retorno).FirstOrDefault();
            }
        }

    }
}