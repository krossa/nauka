using System;
using System.ComponentModel.DataAnnotations;
using Nest;

public class Log
{
    public int Id { get; set; }
    public string Author { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Logged Date")]
    [Text(Name = "logged_date")]
    public DateTime LoggedDate { get; set; }
    
    [Display(Name = "Log Level")]
    [Range(1,5)]
    [Text(Name = "log_level")]
    public int LogLevel { get; set; }
    public string Message { get; set; }
    public string Reference { get; set; }
    public string Type { get; set; }
}

// dotnet aspnet-codegenerator controller -name LogsController -m Log -dc LogContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries