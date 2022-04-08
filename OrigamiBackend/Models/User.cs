namespace OrigamiBackend
{
    public class User: BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Team Team { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool isTeamAdmin { get; set; }
    }
}