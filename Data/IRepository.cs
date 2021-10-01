using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IRepository
    {
        IEnumerable<SkillSet> GetUsers();
        SkillSet GetSkill(string user);
        Registeration GetCustomerById(int? id);
        bool DeleteCustomerById(int? id);
        int AddR(Registeration registeration);
        void AddSkiil(SkillSet sk,string user);
        void AddL(Login login,int id);
        int CustomerLogin(Login login);
        void Edit(Registeration reg,int id);
        void EditSkill(SkillSet sk,string user);
        Registeration GetProfile(string user);
    }
}
