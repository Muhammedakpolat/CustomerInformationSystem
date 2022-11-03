using CustomerInformationSystem.Core.Entities;

namespace CustomerInformationSystem.Entities.Concrete
{
    public class Customer : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int IdentityNumber { get; set; }
        public string Gender { get; set; }
        public string Occupation { get; set; }
        public bool IsExtraordinaryName { get; set; }
    }
}
