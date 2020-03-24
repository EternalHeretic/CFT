namespace CFT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    public partial class BugTrackers
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int BugTrackerId { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 30 символов")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public int ApplicationId { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public DateTime DateEndDevelopment { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 30 символов")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [StringLength(80, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 80 символов")]
        public string Description { get; set; }

        public virtual Applications Applications { get; set; }
    }
}
