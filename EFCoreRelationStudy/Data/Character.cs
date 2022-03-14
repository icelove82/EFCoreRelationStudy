using System.Text.Json.Serialization;

namespace EFCoreRelationStudy.Data
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string RpgClass { get; set; } = "Knight";

        /* Relation 1:1 */
        public int UserId { get; set; }
        [JsonIgnore]
        public User? User { get; set; }

        /* Relation 1:1 */
        public Weapon? Weapon { get; set; }
    }
}
