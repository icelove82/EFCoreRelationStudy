namespace EFCoreRelationStudy.Data
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;

        /* Relation 1:n */
        public List<Character> Characters { get; set; }
    }
}
