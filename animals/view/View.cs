namespace animals.view
{
    internal class View
    {
        public View() { }

        internal void Print(string message)
        {
            Console.WriteLine(message);
        }

        internal string GetString()
        {
            return Console.ReadLine();
        }
        internal void ReadKey()
        {
            Console.ReadKey();
        }

    }
}