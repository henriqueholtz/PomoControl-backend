namespace PomoControl.Service.DTO
{
    public class ClaimDTO
    {
        public ClaimDTO(string type, string value)
        {
            Type = type;
            Value = value;
        }

        public string Type { get; set; }
        public string Value { get; set; }
    }
}
