using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Data
{
    public class Repository : IRepository
    {
        SuperHeroContext _Context;

        public Repository(SuperHeroContext context)
        {
            _Context = context;
        }

        public int AddR(Registeration registeration)
        {
            if (registeration != null)
            { 
                _Context.Add(registeration);
                _Context.SaveChanges();
                int id = registeration.Id;
                return id;
            }
            else
            {
                return 0;
            }
        }
        public void AddSkiil(SkillSet sk,string user)
        {
            var data = _Context.Logins.Where(s => s.Username == user).FirstOrDefault();
            int reg_id = data.RegisterationId;
            sk.RegisterationId = reg_id;
            if (sk != null)
            {
                _Context.Add(sk);
                _Context.SaveChanges();
            }
        }
        public void AddL(Login login,int id)
        {
            if (login != null && id != 0)
            {
                login.RegisterationId = id;
                _Context.Add(login);
                _Context.SaveChanges();
                
            }

        }
        public int CustomerLogin(Login login)
        {
             Login Checkcust = (from c in _Context.Logins
                                where c.Username == login.Username && c.Password == login.Password
                                select c).FirstOrDefault();
            int id = Checkcust.RegisterationId;
            Registeration Checkrole = (from c in _Context.Registerations
                               where c.Id == id
                               select c).FirstOrDefault();
            int r_id = Checkrole.RoleId;
            if (Checkcust != null)
                 return r_id;
             else
                 return 0;
        }
        public IEnumerable<Registeration> GetUsers()
        {
            return _Context.Registerations.OrderBy(a => a.F_Name).ToList();
        }

        public Registeration GetCustomerById(int? id)
        {
            if (id > 0)
            {
                var customer = _Context.Registerations
                    .Where(c => c.Id == id)
                    .FirstOrDefault();
                if (customer != null)
                    return customer;
                else
                    return null;
            }
            else
            {
                throw new ArgumentException("Id cannot be less than 0");
            }
        }
        public void Edit(Registeration reg)
        {
            if (reg != null)
            {
                _Context.Entry(reg).State = EntityState.Modified;
                _Context.SaveChanges();
            }
        }
        public bool DeleteCustomerById(int? id)
        {
            if (id > 0)
            {
                var data = _Context.Registerations.Where(s => s.Id == id).FirstOrDefault();

                _Context.Remove(data);
                _Context.SaveChanges();
                return true;
            }
            else
            {
                throw new ArgumentException($"Cannot Found the data by that id ={id}");
            }
        }

    }
}
