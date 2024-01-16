using PAPP2.Models;

namespace PAPP2.Data
{
    public class DbInitializer
    {
        private ApplicationDbContext _context;

        public DbInitializer(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Run()
        {
            _context.Database.EnsureCreated();

            if (_context.UnidadesCurriculares.Any())
            {
                return;
            }

            var ucs = new UnidadeCurricular[]
            {
                new UnidadeCurricular{ Codigo = "14204", Nome="Álgebra linear", ECTS = 6},
                new UnidadeCurricular{ Codigo = "20232", Nome="Análise matemática I", ECTS = 6},
                new UnidadeCurricular{ Codigo = "14205", Nome="Laboratório de informática e computadores", ECTS = 3},
                new UnidadeCurricular{ Codigo = "14203", Nome="Tópicos de matemática discreta", ECTS = 6},
                new UnidadeCurricular{ Codigo = "14202", Nome="Programação procedimental", ECTS = 6},
                new UnidadeCurricular{ Codigo = "14206", Nome="Seminário de informática", ECTS = 3},
                new UnidadeCurricular{ Codigo = "20233", Nome="Análise matemática II", ECTS = 6},
                new UnidadeCurricular{ Codigo = "14209", Nome="Elementos de física geral", ECTS = 6},
                new UnidadeCurricular{ Codigo = "14210", Nome="Engenharia nas organizações", ECTS = 3},
                new UnidadeCurricular{ Codigo = "14208", Nome="Laboratório de programação", ECTS = 3},
                new UnidadeCurricular{ Codigo = "20234", Nome="Programação Orientada a Objetos", ECTS = 6},
                new UnidadeCurricular{ Codigo = "14996", Nome="Sistemas computacionais", ECTS = 6}
            };

            _context.UnidadesCurriculares.AddRange(ucs);

            _context.SaveChanges();
        }
    }
}
