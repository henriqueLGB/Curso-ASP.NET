using DEMO.App.Data;
using DEMO.App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DEMO.App.Controllers
{
    public class TesteGrudController : Controller
    {

        private readonly MeuDbContext _contexto;

        public TesteGrudController(MeuDbContext contexto)
        {
            _contexto = contexto;
        }

        public IActionResult Index()
        {
            //CRIANDO UM NOVO ALUNO
            var aluno = new Aluno
            {
                Nome = "Eduardo",
                DataNascimento = DateTime.Now,
                Email = "teste@hotmail.com"

            };

            //PARA INSERIR UM NOVO REGITRO NO BANCO
            _contexto.Alunos.Add(aluno);
            _contexto.SaveChanges();

            //REALIZANDO A CONSULTA DE UM ALUNO (OU VÁRIOS) NO BANCO
            var aluno2 = _contexto.Alunos.Find(aluno.Id);
            var aluno3 = _contexto.Alunos.FirstOrDefault(a => a.Email == "teste@hotmail.com");
            var aluno4 = _contexto.Alunos.Where(a => a.Nome == "Henrique");

            //PARA DAR UM UPDATE
            aluno.Nome = "joão";
            _contexto.Alunos.Update(aluno);
            _contexto.SaveChanges();

            //PARA REMOVER
            _contexto.Alunos.Remove(aluno);
            _contexto.SaveChanges();

            return View();
        }
    }
}
