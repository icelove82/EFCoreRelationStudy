namespace EFCoreRelationStudy.Data
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string RpgClass { get; set; } = "Knight";

        /* Relation 1:1 */
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
