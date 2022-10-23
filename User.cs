using System;
namespace ApiTutorial
{
    public class User
    {
        public string Username { set; get; } = string.Empty;
        public byte[] PasswordHash { set; get; }
        public byte[] PasswordSalt { set; get; }
    }
}

