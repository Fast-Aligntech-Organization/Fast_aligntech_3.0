
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Fast.Core
{
    [Table("users")]
    //[Microsoft.EntityFrameworkCore.Index(nameof(Email), IsUnique = true)]
    //[Microsoft.EntityFrameworkCore.Index(nameof(Id))]

    public class PrivateUser : BaseIdentityUser
    {


        [StringLength(64)]
        public string Name
        {
            get; set;
        }
        [StringLength(64)]
        public string Lastname
        {
            get; set;
        }
        [DataType(DataType.Date)]

        public string ProfileImg
        {
            get; set;
        }

        public DateTime? Birthday
        {
            get; set;
        }

        public string? Gender
        {
            get; set;
        }

        public string Clock { get; set; }
      

       

    }
}
