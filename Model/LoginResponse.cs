﻿namespace ConfigurationTool.Model;

public class LoginResponse
{
    public string JwtToken { get; set; }
    public DateTime Expiration { get; set; }
    public string RefreshToken { get; set; }
}