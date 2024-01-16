using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.EntityFrameworkCore;
using PAPP2.Data;
using PAPP2.Models;
using System.Diagnostics;

namespace PAPP2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UnidadesCurriculares
        public async Task<IActionResult> Index()
        {
            return _context.UnidadesCurriculares != null ?
                        View(await _context.UnidadesCurriculares.Include(i => i.Inscricoes.Where(x=>x.Ano == DateTime.Now.Year)).ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.UnidadesCurriculares'  is null.");
        }

        [Authorize]
        public async Task<int> Inscreve(string id)
        {
            Inscricao nova = new Inscricao();
            nova.Ano = DateTime.Now.Year;
            nova.Username = User.Identity.Name;
            nova.UCId = id;

            _context.Inscricoes.Add(nova);

            await _context.SaveChangesAsync();

            int contagem = _context.Inscricoes.Where(i => i.UCId == id && i.Ano == DateTime.Now.Year).Count();

            return contagem;
        }

        [Authorize]
        public async Task<int> Desinscreve(string id)
        {
            Inscricao existente= _context.Inscricoes.SingleOrDefault(i => i.UCId == id && 
                                                            i.Ano== DateTime.Now.Year && i.Username == User.Identity.Name);
            if(existente != null)
            {
                _context.Inscricoes.Remove(existente);

                await _context.SaveChangesAsync();
            }

            // interessa a contagem das inscrições desta UC neste ano civil (independentemente do utilizador)
            int contagem = _context.Inscricoes.Where(i => i.UCId == id && i.Ano == DateTime.Now.Year).Count();

            return contagem;
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
