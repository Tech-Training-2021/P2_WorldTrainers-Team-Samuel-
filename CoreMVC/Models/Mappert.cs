using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVC.Models
{
    public class Mappert
    {
        public static CoreMVC.Models.Registeration Map(Data.Entities.Registeration registeration)
        {
            return new CoreMVC.Models.Registeration()
            {
                Id = registeration.Id,
                F_Name = registeration.F_Name,
                L_Name = registeration.L_Name,
                Mobile = registeration.Contact,
                Email = registeration.Email,
                Locations = registeration.Locations,
                Role_id=registeration.RoleId
            };
        }
        public static Data.Entities.Registeration Map(CoreMVC.Models.RegisterationViewModel registeration)
        {
            return new Data.Entities.Registeration()
            {
                Id = registeration.Id,
                F_Name = registeration.F_Name,
                L_Name = registeration.L_Name,
                Contact = registeration.Mobile,
                Email = registeration.Email,
                Locations = registeration.Locations,
                RoleId = registeration.Role_id
            };
        }
        public static Data.Entities.Registeration Map(CoreMVC.Models.Registeration registeration)
        {
            return new Data.Entities.Registeration()
            {
                Id = registeration.Id,
                F_Name = registeration.F_Name,
                L_Name = registeration.L_Name,
                Contact = registeration.Mobile,
                Email = registeration.Email,
                Locations = registeration.Locations,
                RoleId = registeration.Role_id
            };
        }
        public static Data.Entities.Login Maplogin(CoreMVC.Models.RegisterationViewModel registeration)
        {
            return new Data.Entities.Login()
            {
                Username = registeration.Username,
                Password = registeration.Password,
            };
        }
        public static Data.Entities.Login Maploguser(CoreMVC.Models.Login lcustomer)
        {
            return new Data.Entities.Login()
            {
                Username = lcustomer.Username,
                Password = lcustomer.Password,
            };
        }
        public static Data.Entities.SkillSet MapSkill(CoreMVC.Models.SkillSet s)
        {
            return new Data.Entities.SkillSet()
            {
                Id=s.Id,
                Education = s.Education,
                Experience = s.Experience,
                Skill = s.Skill,
                Domain = s.Domain
            };
        }
        public static CoreMVC.Models.SkillSet MapSkill(Data.Entities.SkillSet s)
        {
            return new CoreMVC.Models.SkillSet()
            {
                Id = s.Id,
                Education = s.Education,
                Experience = s.Experience,
                Skill = s.Skill,
                Domain = s.Domain
            };
        }
        public static Data.Entities.SkillSet MaptSkill(CoreMVC.Models.Skillsett s)
        {
            return new Data.Entities.SkillSet()
            {
                Id = s.Id,
                Education = s.Education,
                Experience = s.Experience,
                Skill = s.Skill,
                Domain = s.Domain           
            };
        }
        public static CoreMVC.Models.Skillsett MaptSkill(Data.Entities.SkillSet s)
        {
            return new CoreMVC.Models.Skillsett()
            {
                Id = s.Id,
                Education = s.Education,
                Experience = s.Experience,
                Skill = s.Skill,
                Domain = s.Domain,
                F_Name = s.Registeration.F_Name,
                L_Name = s.Registeration.L_Name,
                Email = s.Registeration.Email
            };
        }
        public static CoreMVC.Models.Registeration MapCVM(Data.Entities.Registeration registeration)
        {
            return new CoreMVC.Models.Registeration()
            {
                Id = registeration.Id,
                F_Name = registeration.F_Name,
                L_Name = registeration.L_Name,
                Mobile = registeration.Contact,
                Email = registeration.Email,
                Locations = registeration.Locations,
                Role_id = registeration.RoleId
            };
        }
    }
}
