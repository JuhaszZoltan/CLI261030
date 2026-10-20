class Product
{
    public int Id { get; set; }
    public string Category { get; set; }
    public string Manufacturer { get; set; }
    public string Model { get; set; }
    public int PriceHUF { get; set; }
    public int StockQTY { get; set; }
    public float Rating { get; set; }

    public override string ToString() =>
        $"\tCategory:     {Category}\n" +
        $"\tManufacturer: {Manufacturer}\n" +
        $"\tModel:        {Model}\n" +
        $"\tPrice:        {PriceHUF:N0} HUF\n" +
        $"\tStock:        {StockQTY} pcs\n" +
        $"\tRating:       {Rating:0.0}";

    public Product(string row)
    {
        var tmp = row.Split(',');
        Id = int.Parse(tmp[0]);
        Category = tmp[1];
        Manufacturer = tmp[2];
        Model = tmp[3];
        PriceHUF = int.Parse(tmp[4]);
        StockQTY = int.Parse(tmp[5]);
        Rating = float.Parse(tmp[6].Replace('.', ','));
    }
}