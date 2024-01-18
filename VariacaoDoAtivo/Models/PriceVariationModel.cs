namespace VariacaoDoAtivo.Models
{
    public class PriceVariationModel
    {
        public DateTime? Date { get; set; }
        public double? VariationFromPreviousDay { get; set; }
        public double? VariationFromFirstDay { get; set; }
    }
}