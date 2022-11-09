using API.Context;
using API.Handlers;
using API.Models;
using API.Repository.Interface;
using API.Repositorys;
using API.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace API.Repository.Data
{
    public class AccountRepository : GeneralRepository<User>
    {
        private MyContext _context;
        

        public AccountRepository(MyContext context) : base (context)
        {
            _context = context;
            
        }

      

        public ResponseLogin Login(string Email, string Password)
        {

            var data = _context.Users
                  .Include(x => x.Employee)
                  .Include(x => x.Role)
                  .SingleOrDefault(x => x.Employee.Email.Equals(Email));
            if (data != null)
            {
                
                if (Hashing.ValidatePassword(Password, data.Password))
                {
                    ResponseLogin responseLogin = new ResponseLogin()
                    {
                        FullName = data.Employee.FullName,
                        Email = data.Employee.Email,
                        Role = data.Role.Name


                    };
                    return responseLogin;
                   /* var claims = new[]
                    {
                        new Claim (JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim (JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim ("UserId", data.Employee.Id.ToString()),
                        new Claim ("DisplayName",data.Employee.FullName),
                        new Claim ("Email", data.Employee.Email),
                        new Claim ("Roles",data.Role.Name)
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);
                    var result = new JwtSecurityTokenHandler().WriteToken(token);

                    return result;*/
                   
                }
                return null;
               
            }
            return null;
        }





        public int Register(string FullName, string Email, DateTime BirthDate, string Password)
        {
            var data = _context.Users
                .Include(x => x.Employee)
                .SingleOrDefault(x => x.Employee.Email.Equals(Email));
            if (data == null)
            {
                Employee employee = new Employee()
                {
                    Email = Email,
                    FullName = FullName,
                    BirthDate = BirthDate
                };
                _context.Employees.Add(employee);
                var result = _context.SaveChanges();
                if (result > 0)
                {
                    var id = _context.Employees.SingleOrDefault(x => x.Email.Equals(Email)).Id;
                    User user = new User()
                    {
                        Id = id,
                        Password = Hashing.HashPassword(Password),
                        RoleId = 1
                    };
                    _context.Users.Add(user);
                    var resultUser = _context.SaveChanges();
                    if (resultUser > 0)
                    {
                        return resultUser;
                    }
                    return result;
                }
                return 0;
            }
            return 0;
        }



        public int ChangePassword(string Email,  string Password, string Passnew)
        {
            var data = _context.Users
               .Include(x => x.Employee)
               .SingleOrDefault(x => x.Employee.Email.Equals(Email));
            if (data != null)
            {

                if (Hashing.ValidatePassword(Password,data.Password))
                {
                    data.Password = Hashing.HashPassword(Passnew);
                    _context.Entry(data).State = EntityState.Modified;
                    var result = _context.SaveChanges();
                    if (result > 0)
                    {
                        return result;
                    }
                    return 0;
                }
                return 0;
            }

            return 0;
        }
        public int ForgotPassword(string Fullname, string Email, string NewPass)
        {

            var data = _context.Users
            .Include(x => x.Employee)

            .SingleOrDefault(x => x.Employee.Email.Equals(Email) && x.Employee.FullName.Equals(Fullname));

            if (data != null)
            {

                data.Password = Hashing.HashPassword(NewPass);

                _context.Entry(data).State = EntityState.Modified;

                var result = _context.SaveChanges();
                if (result > 0)
                {
                    return result;
                }
                return 0;
            }
            return 0;
        }

       
        public IEnumerable<User> Get()
        {
            return _context.Users.ToList();
        }

        public User GetById(Key id)
        {
            return _context.Users.Find(id);
        }

        public int Create(User Entity)
        {
            throw new NotImplementedException();
        }

        public int Update(User Entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(Key id)
        {
            throw new NotImplementedException();
        }
    }
}
        
        
    

