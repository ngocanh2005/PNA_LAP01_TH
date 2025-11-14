using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;



namespace PNA_Day04_Layout.Models
{
    //dinh nghia lop Student:gom cac thuoc tinh sau
    public class Student
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required(ErrorMessage ="Email bat buoc phai duoc nhap")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Email khong hop le")]
        public string Email { get; set; }
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Mat khau phai co do dai tu 6 den 100 ky tu")]
        [Required]
        public string Password { get; set; }
        [Required]
        public BranchType Branch { get; set; }
        [Required]
        public GenderType Gender { get; set; }

        public bool IsRegular { get; set; }//true:chinhquy, false: k chinh quy
        [DataType(DataType.MultilineText)]
        [Required]
        public string Adddress { get; set; }
        [Range(typeof(DateTime), "1/1/1900", "12/31/2099", ErrorMessage = "Ngay sinh khong hop le")]
        [DataType(DataType.Date)]
        public DateTime DateOfBorth { get; set; } // ngay sinh
        public string? AvatarUrl { get; set; } // URL of the student's avatar image
        [NotMapped] // khong luu vao database
        public IFormFile? AvartaFile { get; set; } // Uploaded avatar file


    }
}
