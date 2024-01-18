using Microsoft.Extensions.Hosting;

namespace VariacaoDoAtivo.Models
{
    public class CurrentTradingPeriod
    {
        public Pre? pre { get; set; }
        public Regular? regular { get; set; }
        public Post? post { get; set; }
    }
}
