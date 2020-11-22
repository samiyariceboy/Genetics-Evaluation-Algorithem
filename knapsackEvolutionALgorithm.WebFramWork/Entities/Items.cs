namespace knapsackEvolutionALgorithm.Service.Entities
{
    public record Item
    {
        public Item(int weight, int value)
        {
            Weight = weight;
            Value = value;
        }
        public int ItemId { get; init; }
        public int Weight { get; init; }
        public int Value { get; init; }
    }
}
