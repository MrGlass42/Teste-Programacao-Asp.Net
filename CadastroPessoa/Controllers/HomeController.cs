using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CadastroPessoa.Models;
namespace CadastroPessoa.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            var daoPessoaFisica = new PsfDao();
            var daoPessoaJuridica = new PsjDao();

            var ListPsj = daoPessoaJuridica.listarTodos();
            var ListPsf = daoPessoaFisica.listarTodos();

            ViewBag.PessoaFisica = ListPsf;
            ViewBag.PessoaJuridica = ListPsj;

            return View();
        }

      
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(PessoaFisica fisica)
        {
            if (fisica != null)
            {
                var daoFisica = new PsfDao();
                daoFisica.Salvar(fisica);

                return RedirectToAction("/Index");
            }
            else
                return View();
        }

        [HttpPost]
        public ActionResult CadastrarJuridica(PessoaJuridica juridica)
        {
            if(juridica != null)
            {
                var daoJuridica = new PsjDao();
                daoJuridica.Salvar(juridica);

                return RedirectToAction("/Index");
            }
            else
                return View();
        }

        public ActionResult DetalhesFisica(int id)
        {
            var dao = new PsfDao();

            var pessoa = dao.ListaPorId(id);

            return View(pessoa);
        }

        public ActionResult DetalhesJuridica(int id)
        {
            var dao = new PsjDao();

            var pessoa = dao.ListaPorId(id);


            return View(pessoa);
        }

        public ActionResult AlterarFisica(int id)
        {
            var dao = new PsfDao();

            var pessoa = dao.ListaPorId(id);


            return View(pessoa);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AlterarFisica(PessoaFisica pessoa)
        {
            if(ModelState.IsValid)
            {
                var dao = new PsfDao();

                dao.Salvar(pessoa);

                return RedirectToAction("Index");
            }

            return View(pessoa);
            
        }


        public ActionResult AlterarJuridica(int id)
        {
            var dao = new PsjDao();

            var pessoa = dao.ListaPorId(id);


            return View(pessoa);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AlterarJuridica(PessoaJuridica pessoa)
        {
            if(ModelState.IsValid)
            {
                var dao = new PsjDao();

                dao.Salvar(pessoa);

                return RedirectToAction("Index");
            }

            return View(pessoa);
        }


        public ActionResult ExcluirFisica(int id)
        {
            var dao = new PsfDao();

            var pessoa = dao.ListaPorId(id);

            return View(pessoa);
        }

        [HttpPost, ActionName("ExcluirFisica")]
        [ValidateAntiForgeryToken]
        public ActionResult Excluir(int id)
        {
            var dao = new PsfDao();

            dao.Excluir(id);

            return RedirectToAction("Index");
        }

        public ActionResult ExcluirJuridica(int id)
        {
            var dao = new PsjDao();

            var pessoa = dao.ListaPorId(id);

            return View(pessoa);
        }

        [HttpPost, ActionName("ExcluirJuridica")]
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirJ(int id)
        {
            var dao = new PsjDao();

            dao.Excluir(id);

            return RedirectToAction("Index");
        }


    }
}