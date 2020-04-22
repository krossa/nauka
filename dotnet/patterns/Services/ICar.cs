namespace patterns.Services
{
    public interface ICar
    {
        //required
        int Year { get; set;}
        string Make { get; set;}
        string Model { get; set;}
        //optional
        string Trim { get; set;}
        string Color { get; set;}
        int Mileage { get; set;}
        string Vin { get; set;}

        string Summary();
    }
}
