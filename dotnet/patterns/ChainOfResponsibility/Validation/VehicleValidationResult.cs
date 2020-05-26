using System.Collections.Generic;

namespace patterns.cor.validation
{
    public class VehicleValidationResult
    {
        public bool IsValid { get; set; }
        public List<string> Messages { get; set; } = new List<string>();
        public override string ToString() => $"{IsValid} - {string.Join(", ", Messages)}";
    }
}