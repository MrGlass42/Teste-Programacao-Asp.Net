using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CadastroPessoa.Models
{
    public class PsfDao
    {
        private BdHandyMan door;

        private void Inserir(PessoaFisica pessoa)
        {
            string Query = "";

            Query += "INSERT INTO PessoaFisica (psf_nome, psf_sobreNome, psf_dt_nasc ,psf_cpf, psf_cep, psf_logradouro, psf_numero, psf_complemento, psf_bairro," +
                "psf_cidade, psf_uf)";

            Query += string.Format("VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{6}','{7}','{8}','{9}');", pessoa.Nome, pessoa.SobreNome, pessoa.DataNascimento,
                pessoa.Cpf, pessoa.CEP, pessoa.Logradouro, pessoa.Numero, pessoa.Complemento, pessoa.Bairro, pessoa.Cidade, pessoa.Uf);

            using (door = new BdHandyMan())
            {
                door.ExecutaComando(Query);
            }
        }

        private void Alterar(PessoaFisica pessoa)
        {
            string Query = "";


            Query += "UPDATE PessoaFisica SET";
            Query += string.Format(" psf_nome = '{0}', ", pessoa.Nome);
            Query += string.Format(" psf_sobreNome = '{0}', ", pessoa.SobreNome);
            Query += string.Format(" psf_dt_nasc = '{0}', ", pessoa.DataNascimento);
            Query += string.Format(" psf_cpf = '{0}', ", pessoa.Cpf);
            Query += string.Format(" psf_cep = '{0}', ", pessoa.CEP);
            Query += string.Format(" psf_logradouro = '{0}', ", pessoa.Logradouro);
            Query += string.Format(" psf_numero = '{0}', ", pessoa.Numero);
            Query += string.Format(" psf_complemento = '{0}', ", pessoa.Complemento);
            Query += string.Format(" psf_bairro = '{0}', ", pessoa.Bairro);
            Query += string.Format(" psf_cidade = '{0}', ", pessoa.Cidade);
            Query += string.Format(" psf_uf = '{0}' ", pessoa.Uf);
            Query += string.Format(" WHERE psf_id = '{0}' ", pessoa.Id);

            using (door = new BdHandyMan())
            {
                door.ExecutaComando(Query);
            }
        }

        public void Salvar(PessoaFisica pessoa)
        {
            if (pessoa.Id > 0)
                Alterar(pessoa);
            else
                Inserir(pessoa);
        }


        public void Excluir(int id)
        {
            string Query = string.Format("DELETE FROM PessoaFisica WHERE psf_id = {0}", id);

            using (door = new BdHandyMan())
            {
                door.ExecutaComando(Query);
            }
        }

        public List<PessoaFisica> listarTodos()
        {
            string Query = "SELECT * FROM PessoaFisica";

            using (door = new BdHandyMan())
            {
                var retorno = door.ExecutaComandoComRetorno(Query);

                return toList(retorno);
            }
        }



        private List<PessoaFisica> toList(SqlDataReader reader)
        {
            var pessoas = new List<PessoaFisica>();

            while(reader.Read())
            {
                var objeto = new PessoaFisica()
                {
                    Id = int.Parse(reader["psf_id"].ToString()),
                    Nome = reader["psf_nome"].ToString(),
                    SobreNome = reader["psf_sobreNome"].ToString(),
                    Cpf = reader["psf_cpf"].ToString(),
                    CEP = reader["psf_cep"].ToString(),
                    Logradouro = reader["psf_logradouro"].ToString(),
                    Numero = reader["psf_numero"].ToString(),
                    Complemento = reader["psf_complemento"].ToString(),
                    Bairro = reader["psf_bairro"].ToString(),
                    Cidade = reader["psf_cidade"].ToString(),
                    Uf = reader["psf_uf"].ToString(),
                    DataNascimento = reader["psf_dt_nasc"].ToString()
                };

                pessoas.Add(objeto);
            }

            return pessoas;
        }

        public PessoaFisica ListaPorId(int id)
        {
            string Query = string.Format("SELECT * FROM PessoaFisica WHERE psf_id = {0}", id);


            using (door = new BdHandyMan())
            {
                var retorno = door.ExecutaComandoComRetorno(Query);
                return toList(retorno).FirstOrDefault();
            }           
        }
    }
}