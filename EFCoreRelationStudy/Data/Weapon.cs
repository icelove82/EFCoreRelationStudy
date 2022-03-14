using System.Text.Json.Serialization;

namespace EFCoreRelationStudy.Data
{
    public class Weapon
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public int Damage { get; set; }

        /* Relation 1:1 */
        public int CharacterId { get; set; }
        [JsonIgnore]
        public Character? Character { get; set; }
    }
}
