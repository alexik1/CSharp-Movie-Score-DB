namespace FilmesAPI.Filmes
{
    public class Filme_Espectador// : Entity<Guid>
    {
        public Filme Filme { get; set; }
        public int FilmeId { get; set; }

        public Espectador Espectador { get; set; }
        public int EspectadorId { get; set; }

        public int Score { get; set; }
    }
}
