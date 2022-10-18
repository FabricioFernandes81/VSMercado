using System.ComponentModel.DataAnnotations;

namespace WebAdmin.Models
{
    public class RegistroView
    {
        [Display(Name = "CPNJ")]
        [Required(ErrorMessage = "CNPJ é Obrigatorio")]
        [MaxLength(18)]
        public string? CNPJ 
        { 
            get;
            set;
        }
        [Display(Name = "Nome Fantasia")]
        [Required(ErrorMessage = "Digite o Nome Fantasia")]
        public string? Nome {
            get;
            set;
        }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "O email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string? Email
        {
            get;
            set;
        }
        [Display(Name = "Fone")]
        public string? Fone { 
            get;
            set; 
        }
        [Display(Name = "Celular")]
        public string? Celular { 
            get;
            set;
        }
        public IFormFile? Imagens {
            get;
            set;
        }
        [Display(Name = "Estado")]
        [Required(ErrorMessage = "Selecione o Estado")]
        public int EstadoId {
            get;
            set;
        }
        [Display(Name = "Cidade")]
        [Required(ErrorMessage = "Selecione a Cidade")]
        public int CidadeId {
            get;
            set;
        }
        [Display(Name = "Endereço")]
        public string? Endereco {
            get;
            set;
        }
        [Display(Name = "Nº")]
        public string? Numero { 
            get;
            set;
        }
        [Required(ErrorMessage = "A senha é obrigatória")]
        [DataType(DataType.Password)]
        public string? Password 
        { 
            get; 
            set;
        }
        [DataType(DataType.Password)]
        [Display(Name = "Confirme a senha")]
        [Compare("Password", ErrorMessage = "As senhas não conferem")]
        public string? ConfirmPassword { 
            get; 
            set;
        }
    }
}
