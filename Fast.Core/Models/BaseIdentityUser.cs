using Microsoft.AspNetCore.Identity;
using System;
namespace Fast.Core
{
    public abstract class BaseIdentityUser :  IdentityUser, IEntity<string>
    {

        public Guid Guid { get; set; } = Guid.NewGuid();


    }
}
