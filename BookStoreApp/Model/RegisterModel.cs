using System;

namespace Model
{
    public class RegisterModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }
        public string Password { get; set; }
    }
}
