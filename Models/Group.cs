using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace University.Models
{
    public class Group
    {
        // ID группы
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        // номер группы
        [Display(Name = "Номер группы")]
        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Пожалуйста, введите положительное значение для номера группы")]
        public int Number { get; set; }
        // форма обучения
        [Display(Name = "Форма обучения")]
        [RegularExpression(@"([А-Яа-я]+\s?)+", ErrorMessage = "Вы ввели некорректную форму обучения00000!")]
        [Required(ErrorMessage = "Пожалуйста, введите форму обучения")]
        public string FormOfLearning { get; set; }
        //id специальности
        [Display(Name = "Специальность")]
        [Required(ErrorMessage = "Пожалуйста, выберите специальность")]
        public int? SpecialtyId { get; set; }
        //специальность
        public Specialty Specialty { get; set; }
    }
}