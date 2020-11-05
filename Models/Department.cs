using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace University.Models
{
    public class Department
    {
        // ID кафедры
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        // название кафедры
        [Display(Name = "Название")]
        [RegularExpression(@"([А-Яа-я]+\s?)+", ErrorMessage = "Вы ввели некорректное название кафедры!")]
        [Required(ErrorMessage = "Пожалуйста, введите название кафедры")]
        public string Title { get; set; }
        // номер кабинета
        [Display(Name = "Номер кабинета")]
        [RegularExpression(@"\d+[А-Яа-я]?", ErrorMessage = "Вы ввели некорректный номер кабинета!")]
        [Required(ErrorMessage = "Пожалуйста, введите номер кабинета кафедры")]
        public string NumberOfCabinet { get; set; }
        // номер телефона
        [Display(Name = "Номер телефона")]
        [RegularExpression(@"\+\d{12}", ErrorMessage = "Вы ввели некорректный номер телефона!")]
        [Required(ErrorMessage = "Пожалуйста, введите номер телефона кафедры")]
        public string PhoneNumber { get; set; }
        //id заведующего кафедрой
        [Display(Name = "Заведующий кафедрой")]
        [Required(ErrorMessage = "Пожалуйста, выберите заведующего кафедрой")]
        public int? HeadOfDepartmentId { get; set; }
        //заведующий кафедрой
        public Teacher HeadOfDepartment { get; set; }
        //список преподавателей кафедры
        [HiddenInput(DisplayValue = false)]
        public ICollection<StaffingStructure> StaffingStructures { get; set; }
        //список специальностей кафедры
        [HiddenInput(DisplayValue = false)]
        public ICollection<Specialty> Specialties { get; set; }
        public Department()
        {
            StaffingStructures = new List<StaffingStructure>();
            Specialties = new List<Specialty>();
        }

    }
}