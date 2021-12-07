using System;

namespace Settings
{
    public class DatabaseSettings
    {
        public const string SectionName = "ConnectionStrings";
        
        public static string DefaultConnection { get; set; }
    }
}