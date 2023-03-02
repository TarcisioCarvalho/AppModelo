using DEVIO.UI.Site.Data;
using DEVIO.UI.Site.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace DEVIO.UI.Site.Controllers
{
    public class TesteCrudController : Controller
    {
        private readonly MeuDbContext _meuDbContext;

        public TesteCrudController(MeuDbContext meuDbContext)
        {
            _meuDbContext = meuDbContext;
        }

        public IActionResult Create()
        {
            // Create
            var aluno = new Aluno()
            {
                Name = "Tarcísio",
                Email = "tarcisio@email.com",
                DataNascimento = DateTime.Now,
            };


            _meuDbContext.Alunos.Add(aluno);
            _meuDbContext.SaveChanges();

            

            return Ok("Criado");
        }

        public IActionResult Read()
        {
            var aluno1 = _meuDbContext.Alunos.FirstOrDefault(aluno => aluno.Email == "tarcisio@email.com");
            return Ok(aluno1.Name + "--------" + aluno1.Email);
        }

        public IActionResult Update()
        {
            var aluno = _meuDbContext.Alunos.FirstOrDefault(aluno => aluno.Email == "tarcisio@email.com");
            aluno.Name = "Tarcísio Carvalho";
            _meuDbContext.Update(aluno);
            _meuDbContext.SaveChanges();

            return Ok("Atualizado");
        }

        public IActionResult Delete()
        {
            var aluno = _meuDbContext.Alunos.FirstOrDefault(aluno => aluno.Email == "tarcisio@email.com");
           
            _meuDbContext.Remove(aluno);
            _meuDbContext.SaveChanges();

            return Ok("deletado");
        }
    }
}
