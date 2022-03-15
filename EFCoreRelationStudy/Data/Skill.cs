using System.Text.Json.Serialization;

namespace EFCoreRelationStudy.Data
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public int Damage { get; set; }

        /* Relation n:n */
        [JsonIgnore]
        public List<Character>? Characters { get; set; }
    }
}
