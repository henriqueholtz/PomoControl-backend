namespace PomoControl.Service.DTO
{
    public class UserSimpleDTO
    {
        public int Code { get; set; }
        public string Name { get; private set; }
        public string Email { get; set; }
        public bool Active { get; set; }
    }
}
