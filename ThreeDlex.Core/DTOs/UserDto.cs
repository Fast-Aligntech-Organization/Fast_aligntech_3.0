using ThreeDlex.Core.Interfaces;
namespace ThreeDlex.Core.DTOs
{
    public class UserDto : IEntity
    {


        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string UserName { get; set; }
        public string ImagePath { get; set; }



    }
}
