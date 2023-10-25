﻿namespace Games.API.Configurations
{
    public record DatabaseConfiguration
    {
        public string? ConnectionString { get; set; }
        public string? Database { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
