using System;
using System.ComponentModel.DataAnnotations;

namespace task1.Models
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Логин")]
        public string Login { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Аватар")]
        public string Avatar { get; set; }
        [Required]
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Информация о пользователе")]
        public string UserDescription { get; set; }
        [Required]
        [Display(Name = "Номер телефон")]
        public string PhoneNumber { get; set; }
        [Required]
        [Display(Name = "Пол")]
        public string Gender { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        public string PasswordConfirm { get; set; }
    }

    public enum Gender
    {
        Мужчина,
        Женщина
    }
}