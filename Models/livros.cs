namespace todoapi.models
{
    public class Livros
    {
        public int Id { get; set; }

        public string Titulo { get; set; }

        public int Ano { get; set; }

        public string[] Categorias { get; set; }

    }
}