﻿namespace FromForm.Models
{
    public class UserModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
        public string Gender { get; set; }
        public string Country { get; set; }
        public List<string> Hobbies { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
