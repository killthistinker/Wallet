using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Wallet.Models.ViewModels
{
    public class RegistrationViewModel
    {
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [Remote("CheckAccountName", "AccountValidation", ErrorMessage = "Логин занят")]
        public string UserName { get; set; }
        
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Данные введены неверно")]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [Remote("CheckAccountEmail", "AccountValidation", ErrorMessage = "Email занят")]
        public string Email { get; set; }
        
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [DataType(DataType.Password)]
        [Compare((nameof(Password)), ErrorMessage = "Пароли не совпадают")]
        [Display(Name = "Подтвердить пароль")]

        public string PasswordConfirm { get; set; }
    }
}