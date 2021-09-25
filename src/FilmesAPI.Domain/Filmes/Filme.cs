using System.Collections.Generic;

namespace FilmesAPI.Filmes
{
    public class Filme// : Entity<Guid>
    {
        public int Id { get; set; }

        //[Required(ErrorMessage = "Nome do Filme é obrigatório.")]
        //[MaxLength(20, ErrorMessage = "Este Campo deve constar entre 2 e 20 caracteres.")]
        //[MinLength(20, ErrorMessage = "Este Campo deve constar entre 2 e 20 caracteres.")]
        public string Título { get; set; }

        public decimal Score { get; set; }

        public List<Filme_Espectador> Filmes_Espectadores { get; set; }
    }
}
