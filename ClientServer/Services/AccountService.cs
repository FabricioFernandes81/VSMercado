using AutoMapper;
using ClientServer.Context;
using ClientServer.DTOs;
using ClientServer.Models;
using ClientServer.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace ClientServer.Services
{
    public class AccountService : IAccountService
    {
        private IWebHostEnvironment webHostEnvironment;
        private readonly AppDbContext _context;

        private readonly UserManager<AppUsers> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUsers> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public AccountService(IWebHostEnvironment environment,AppDbContext context, RoleManager<IdentityRole> roleManager, SignInManager<AppUsers> signInManager, IConfiguration configuration, UserManager<AppUsers> userManager, IMapper mapper)
        {
            webHostEnvironment = environment;
            _context = context;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _userManager = userManager;
            _mapper = mapper;
        }

        public void InitializeSeedRoles()
        {
            if(!_roleManager.RoleExistsAsync(ConfigIdedentityRole.Admin).Result)
            {
                IdentityRole roleAdmin = new IdentityRole();
                roleAdmin.Name = ConfigIdedentityRole.Admin;
                roleAdmin.NormalizedName = ConfigIdedentityRole.Admin.ToUpper();
                _roleManager.CreateAsync(roleAdmin).Wait();
            }
            if (!_roleManager.RoleExistsAsync(ConfigIdedentityRole.Client).Result)
            {
                IdentityRole roleClient = new IdentityRole();
                roleClient.Name = ConfigIdedentityRole.Client;
                roleClient.NormalizedName = ConfigIdedentityRole.Client.ToUpper();
                _roleManager.CreateAsync(roleClient).Wait();
            }

        }

        public async Task<TokenResponse> ResgistrarLoja(RegistroDTO registroDto)
        {
            var response = new TokenResponse();
          
            if (await EmailExiste(registroDto.Email) != false)
            {
                
                
                Empresa empresaEntity = new()
                {
                    CNPJ = Regex.Replace(registroDto.CNPJ, "[^0-9]", ""),
                    Nome = registroDto.Nome,
                    Email = registroDto.Email,
                    Fone = Regex.Replace(registroDto.Fone, "[^0-9]", ""),
                    Celular = Regex.Replace(registroDto.Celular, "[^0-9]", ""),

                    Imagens = registroDto.Imagens.FileName,
                    EstadosId = registroDto.EstadosId,
                    CidadesId = registroDto.CidadesId,
                    Endereco = registroDto.Endereco,
                    Numero = registroDto.Numero
                };
                await _context.AddAsync(empresaEntity);
                await _context.SaveChangesAsync();
                if ((registroDto.Imagens.FileName != null) && registroDto.Imagens.FileName != string.Empty)
                {

                    await UploadFile(registroDto.Imagens);
                }
                if (await RegisterIdenty(registroDto, empresaEntity.Id) == true)
                {
                    response.Success = true;
                    response.Message = "Resgistrado Com Sucesso!";
                }
                else
                {
                    response.Success = false;
                    response.Message = "User already exists.";
                }

            }
            else 
            {
                response.Success = false;
                response.Message = "User already exists.";
            }


            return response;
        }

        private async Task<bool> RegisterIdenty(RegistroDTO register,int id) 
        {

            AppUsers user = new()
            {
                Email = register.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = register.Email,
                NormalizedEmail = register.Email.ToUpper(),
                EmailConfirmed = true,
                LockoutEnabled = false,
                PhoneNumber = "55"+ register.Celular,
                EmpresaId = id,
            };
            IdentityResult resultUser = _userManager.CreateAsync(user, register.Password).Result;

            if (resultUser.Succeeded)
            {
                 _userManager.AddToRoleAsync(user, ConfigIdedentityRole.Admin).Wait();
                await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.GivenName, register.Nome));
                return true;
            }
            return false;
        }
        private async Task<bool> UploadFile(IFormFile file) 
        {
            string caminho = Path.Combine(webHostEnvironment.WebRootPath, "Images/" + file.FileName);
            using (var stream = new FileStream(caminho, FileMode.Create))
            {

                await file.CopyToAsync(stream);
            };

            return true;
        }
        private async Task<bool> EmailExiste(string email)
        {
            if ((await _userManager.FindByEmailAsync(email)==null) && _context.empresas.Any(e => e.Email == email)==false)
                return true;
            else
                return false;
    }
    }
   
}
