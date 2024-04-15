namespace Product_Prices.Models;

public partial class ProductPrice
{
    public int Id { get; set; }

    public int? ProductId { get; set; }

    public decimal? Prices { get; set; }
}
