using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using University_Core.Models;

namespace University.Models
{
    public class Teacher
    {
        // ID преподавателя
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        
        // фамилия преподавателя
        [Display(Name = "Фамилия")]
        [RegularExpression(@"[А-Яа-я]+", ErrorMessage = "Вы ввели некорректную фамилию!")]
        [Required(ErrorMessage = "Пожалуйста, введите фамилию преподавателя")]
        public string LastName { get; set; }
        
        // имя преподавателя
        [Display(Name = "Имя")]
        [RegularExpression(@"[А-Яа-я]+", ErrorMessage = "Вы ввели некорректное имя!")]
        [Required(ErrorMessage = "Пожалуйста, введите имя преподавателя")]
        public string FirstName { get; set; }
        
        // отчество преподавателя
        [Display(Name = "Отчество")]
        [RegularExpression(@"[А-Яа-я]+", ErrorMessage = "Вы ввели некорректное отчество!")]
        [Required(ErrorMessage = "Пожалуйста, введите отчество преподавателя")]
        public string MiddleName { get; set; }
        
        // ученая степень
        [Display(Name = "Учёная степень")]
        [RegularExpression(@"([А-Яа-я]+\s?)+", ErrorMessage = "Вы ввели некорректную учёную степень!")]
        [Required(ErrorMessage = "Пожалуйста, введите учёную степень преподавателя")]
        public string ScienceDegree { get; set; }
        
        // ученое звание
        [Display(Name = "Учёное звание")]
        [RegularExpression(@"([А-Яа-я]+\s?)+", ErrorMessage = "Вы ввели некорректное учёное звание!")]
        [Required(ErrorMessage = "Пожалуйста, введите учёное звание преподавателя")]
        public string AcadimicTitle { get; set; }
        
        [HiddenInput(DisplayValue = false)]
        public ICollection<StaffingStructure> StaffingStructures { get; set; }
        public Teacher() {
            StaffingStructures = new List<StaffingStructure>();
        }

        public string UserId { get; set; }
        public User User { get; set; }
    }
}