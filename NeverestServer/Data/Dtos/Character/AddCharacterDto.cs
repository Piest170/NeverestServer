namespace NeverestServer.Data.Dtos.Character
{
    public class AddCharacterDto
    {
        public string? CharacterName { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
