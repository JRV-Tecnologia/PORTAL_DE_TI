namespace PORTAL_DE_TI.Models
{
    public class ResultUserAD
    {
        public string nome { get; set; }
        public string nomeCompleto { get; set; }
        public string login { get; set; }
        public string matricula { get; set; }
        public bool encontrado { get; set; }
        public bool? erro { get; set; }
        public string message { get; set; }
        public string mail { get; set; }

    }
}