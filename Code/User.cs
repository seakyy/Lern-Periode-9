namespace WebAPI_295.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = "User";
        public string? RefreshToken { get; set; }  //Refresh Token speichern
        public DateTime? RefreshTokenExpiryTime { get; set; }  //Ablaufdatum
    }

}
