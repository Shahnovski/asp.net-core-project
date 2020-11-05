using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace University.Models
{
    public class Specialty
    {
        // ID специальности
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        // название спецальности
        [Display(Name = "Название")]
        [Required(ErrorMessage = "Пожалуйста, введите название специальности")]
        [RegularExpression(@"([А-Яа-я]+\s?)+", ErrorMessage = "Вы ввели некорректное название специальности!")]
        public string Title { get; set; }
        //id кафедры
        [Display(Name = "Кафедра")]
        [Required(ErrorMessage = "Пожалуйста, выберите кафедру")]
        public int? DepartmentId { get; set; }
        //кафедра
        public Department Department { get; set; }
        //список групп
        [HiddenInput(DisplayValue = false)]
        public ICollection<Group> Groups { get; set; }
        public Specialty()
        {
            Groups = new List<Group>();
        }
    }
}