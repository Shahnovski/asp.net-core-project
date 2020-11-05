using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University.Models
{
    public class StaffingStructure
    {
        // должность преподавателя
        [Display(Name = "Должность")]
        [Required(ErrorMessage = "Пожалуйста, введите должность преподавателя")]
        [RegularExpression(@"([А-Яа-я]+\s?)+", ErrorMessage = "Вы ввели некорректную должность")]
        public string Post { get; set; }
        // ставка преподавателя
        [Display(Name = "Ставка")]
        [Required(ErrorMessage = "Пожалуйста, введите ставку")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Пожалуйста, введите положительное значение для ставки")]
        public double Rate { get; set; }
        //id преподавателя
        [Key]
        [Column(Order = 1)]
        [Display(Name = "Преподаватель")]
        [Required(ErrorMessage = "Пожалуйста, выберите преподавателя")]
        public int? TeacherId { get; set; }
        //преподаватель
        public Teacher Teacher { get; set; }
        //id кафедры
        [Key]
        [Column(Order = 2)]
        [Display(Name = "Кафедра")]
        [Required(ErrorMessage = "Пожалуйста, выберите кафедру")]
        public int? DepartmentId { get; set; }
        //кафедра
        public Department Department { get; set; }
    }
}