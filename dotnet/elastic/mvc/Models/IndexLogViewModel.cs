using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

public class IndexLogViewModel
{
    public List<Log> Logs;
    public SelectList Types;
    public string Type { get; set; }
    public string Reference { get; set; }
}