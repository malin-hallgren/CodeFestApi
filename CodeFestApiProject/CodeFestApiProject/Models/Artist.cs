using Microsoft.EntityFrameworkCore;

namespace CodeFestApiProject.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Artist(string name)
        {
            Name = name;
        }
    }
}
