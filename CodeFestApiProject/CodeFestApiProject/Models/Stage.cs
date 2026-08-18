namespace CodeFestApiProject.Models
{
    public class Stage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public Stage(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
        }
    }
}
