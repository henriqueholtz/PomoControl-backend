using AutoMapper;
using PomoControl.Domain;

namespace PomoControl.Service.DTO
{
    [AutoMap(typeof(User))]
    public class TokenClaimsDTO
    {
        public int Code { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
    }
}
