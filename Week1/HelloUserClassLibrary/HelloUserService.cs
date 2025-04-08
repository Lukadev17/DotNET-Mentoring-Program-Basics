using System;

namespace HelloUserClassLibrary
{
    public static class HelloUserService
    {
        public static string HelloUser(string username)
        {
            return $"{DateTime.Now:HH:mm:ss} Hello, {username}!";
        }
    }
}
