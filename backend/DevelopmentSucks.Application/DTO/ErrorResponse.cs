﻿namespace DevelopmentSucks.Application.DTO;

public class ErrorResponse
{
    public int StatusCode { get; set; }
    public string Message { get; set; } = string.Empty;
    public string? Detailed { get; set; }
}
