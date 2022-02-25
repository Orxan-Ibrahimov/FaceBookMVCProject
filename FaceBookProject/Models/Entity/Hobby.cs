using FaceBookProject.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceBookProject.Models.Entity
{
    public class Hobby : BaseEntity
    {
        public string Name { get; set; }
        public List<UserHobby> UserHobbies { get; set; }

    }
}
