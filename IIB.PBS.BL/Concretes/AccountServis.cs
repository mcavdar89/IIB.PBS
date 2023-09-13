using Core.Model.Dtos;
using IIB.PBS.BL.Abstracts;
using IIB.PBS.DAL.Abstracts;
using IIB.PBS.DAL.Contexts;
using IIB.PBS.Model.Dtos;
using IIB.PBS.Model.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IIB.PBS.BL.Concretes
{
    public class AccountServis : IAccountServis
    {
        IPBSRepository _repository;
        IConfiguration _configuration;
        public AccountServis(IPBSRepository repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }

        public ResultDto Login(LoginDto loginDto)
        {
            //kullanıcı doğrulama LDAP ,veritabanı 

            var kullanici = _repository.Get<Kullanici>(d => d.KullaniciAdi == loginDto.KullaniciAdi && d.Sifre == loginDto.Sifre);

            if (kullanici == null)
            {
                return new ResultDto()
                {
                    Satatus = false,
                    Message = "Kullanıcı adı veya şifre hatalı"
                };

            }

            var token = CreateToken(kullanici);




            return new ResultDto()
            {
                Satatus = true,
                Message = "Giriş Başarılı",
                Data = token
            };



        }


        private string CreateToken(Kullanici kullanici)
        {
            TokenOptions tokenOptions = _configuration.GetSection("TokenOptions").Get<TokenOptions>();


            //token oluşturulacak
            SecurityKey securityKey;
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, kullanici.Ad));
            claims.Add(new Claim(ClaimTypes.Surname, kullanici.Soyad));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, kullanici.KullaniciAdi));
            claims.Add(new Claim(ClaimTypes.Role, "Admin"));
            claims.Add(new Claim(ClaimTypes.Role, "Kullanici"));

            securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.SecurityKey));


            //var crenentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var crenentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

            var token = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                claims: claims,
                DateTime.Now,
                expires: DateTime.Now.AddMinutes(tokenOptions.AccessTokenExpiration), 
                signingCredentials: crenentials
                );
            var tokenKey = new JwtSecurityTokenHandler().WriteToken(token);




            return tokenKey;
        }

    }
}
