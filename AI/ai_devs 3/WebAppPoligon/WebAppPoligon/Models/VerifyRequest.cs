namespace WebAppPoligon.Models
{
    public class VerifyRequest
    {
        public string task { get; set; } = string.Empty;
        public string apikey { get; set; } = "af019d7c-4164-48bf-b104-342658d4ff44";
        public List<string> answer { get; set; } = new List<string>();
    }
}
