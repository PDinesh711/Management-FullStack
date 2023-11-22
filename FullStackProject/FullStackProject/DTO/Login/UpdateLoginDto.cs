namespace FullStackProject.DTO.Login
{
    public class UpdateLoginDto
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string UserEmail { get; set; }

        public string UserPassword { get; set; }

        public long UserPhoneNumber { get; set; }
    }
}
