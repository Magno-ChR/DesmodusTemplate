﻿using AutoMapper;
using DesmodusTemplate.Data;
using DesmodusTemplate.DTOs;
using DesmodusTemplate.Entities.Artec;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace DesmodusTemplate.LogicServices
{
    public class AuthLS
    {
        private readonly HomeContext context;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;

        public AuthLS( HomeContext context, IMapper mapper, IConfiguration configuration)
        {
            this.context = context;
            this.mapper = mapper;
            this.configuration = configuration;
        }
        public async Task<ObjectResult> register(UsuarioEditDto data)
        {
            CreatePassword(data.Clave, out string passwordSalt, out string passwordHash);
            var entidad = mapper.Map<Usuario>(data);
            entidad.Clave = passwordHash;
            entidad.Salt = passwordSalt;
            context.Add(entidad);
            await context.SaveChangesAsync();
            //return new ObjectResult("Registrado correctamente.") { StatusCode = StatusCodes.Status200OK };
            return Responses.Ok("Registrado correctamente.");
        }
        public async Task<ObjectResult> login(UsuarioLoginDto data)
        {
            var entidad = await  context.Usuario
                .Include(x => x.IdPersonaNavigation)
                .Include(x => x.IdRolNavigation)
                .FirstOrDefaultAsync(x => x.Correo == data.Correo);
            if (entidad == null)
                //return new ObjectResult("Usuario no encontrado.") { StatusCode = StatusCodes.Status400BadRequest };
                return Responses.Error400("Usuario no encontrado.");
            else
            {
                if (VerifyPassword(data.Clave, entidad.Clave, entidad.Salt))
                {
                    return Responses.Get(CreateToken(entidad));
                }
                else
                    return Responses.Error400("Contraseña incorrecta.") ;
            }
        }
        private bool VerifyPassword(string enteredPassword, string storedPasswordHash, string storedPasswordSalt)
        {
            byte[] salt = Convert.FromBase64String(storedPasswordSalt);
            byte[] hash = Convert.FromBase64String(storedPasswordHash);

            using (var hmac = new HMACSHA256(salt))
            {
                byte[] enteredHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(enteredPassword));

                return enteredHash.SequenceEqual(hash);
            }
        }
        private void CreatePassword(string password, out string passwordSalt, out string passwordHash)
        {

            using (var hmac = new HMACSHA256())
            {
                passwordSalt = Convert.ToBase64String(hmac.Key);
                passwordHash = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(password)));
            }
        }
        private string CreateToken(Usuario user)
        {
            List<Claim> clains = new List<Claim>
            {
                new Claim("ID", user.IdUsuario.ToString()),
                new Claim("Documento", user.IdPersonaNavigation.NroDocumento),
                new Claim(ClaimTypes.Name, user.IdPersonaNavigation.Nombre + " " + user.IdPersonaNavigation.PrimerApellido + " " + user.IdPersonaNavigation.SegundoApellido),
                new Claim(ClaimTypes.Gender, user.IdPersonaNavigation.Sexo == false ? "Masculino" : "Femenino"),
                new Claim(ClaimTypes.Email, user.Correo),
                new Claim("IdRol", user.IdRolNavigation.IdRol.ToString()),
                new Claim(ClaimTypes.Role, user.IdRolNavigation.Nombre)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("jwtSettings:secretKey").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(
              claims: clains,
              expires: DateTime.Now.AddMinutes(15),
              signingCredentials: creds);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}
