﻿namespace DigitalStore.BL.Auth.Entities;

public class TokenResponce
{
    public string? AccessToken { get; set; }
    public string? RefreshToken { get; set; }
}