using System;
using Nest;

public class Log
{
    public string Author { get; set; }
    [Text(Name = "logged_date")]
    public DateTime LoggedDate { get; set; }
    [Text(Name = "log_level")]
    public int LogLevel { get; set; }
    public string Message { get; set; }
    public string Reference { get; set; }
    public string Type { get; set; }
}