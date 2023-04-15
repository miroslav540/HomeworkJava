namespace animals.model
{
    internal abstract class Animals
    {
        internal static int counter = 0;
        internal static Dictionary<string, List<Animals>> pets = new();
        internal static Dictionary<string, List<Animals>> packedAnimals = new();

        internal static List<string> petsSpecies = new()
        {
            "cat",
            "dog",
            "humster"
        };

        internal static List<string> packAnimalSpecies = new()
        {
            "horse",
            "camel",
            "donkey"
        };

        internal Animals(string name, string specias)
        {
            Name = name;
            Specias = specias;
            Commands = new();
            counter++;
        }
        public string Name { get; }
        public string Specias { get; }
        public List<string> Commands { get; }
    }
}