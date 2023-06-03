namespace Map_Data_to_CSV
{
    public class Country
    {
        public string? Name { get; set; }
        public float Value { get; set; }
        public string? Group { get; set; }
        public string? Coordinates { get; set; }
        public string? Label { get; set; }

        // public Continent Continent { get; set; } = new Continent("invalid");

        public Country() {}
    }
}