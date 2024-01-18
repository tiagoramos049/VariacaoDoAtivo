namespace VariacaoDoAtivo.Models
{
    public class Quote
    {
        public List<double?>? low { get; set; }
        public List<double?>? high { get; set; }
        public List<double?>? close { get; set; }
        public List<double?>? open { get; set; }
        public List<int?>? volume { get; set; }
    }
}
