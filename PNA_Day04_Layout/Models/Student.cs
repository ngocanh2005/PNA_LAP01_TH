using System.ComponentModel.DataAnnotations.Schema;

namespace PNA_Day04_Layout.Models
{
    //dinh nghia lop Student:gom cac thuoc tinh sau
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public BranchType Branch { get; set; }
        public GenderType Gender { get; set; }
        public bool IsRegular { get; set; }//true:chinhquy, false: k chinh quy
        public string Adddress { get; set; }
        public DateTime DateOfBorth { get; set; } // ngay sinh
        public string? AvatarUrl { get; set; } // URL of the student's avatar image
        [NotMapped] // khong luu vao database
        public IFormFile? AvartaFile { get; set; } // Uploaded avatar file


    }
}
