using Microsoft.AspNetCore.Mvc;
using PNA_Day04_Layout.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Hosting;

namespace PNA_Day04_Layout.Controllers
{
    // cau hinh route cho Student
    [Route("Admin/Student")]
    public class StudentController : Controller
    {
        
        //viet ham tao danh sach sinh vien
        private static List<Student> listStudents = new List<Student>();
        public StudentController(IWebHostEnvironment env)
        {
            _env = env;
            listStudents = new List<Student>()
            {
                new Student() {Id=101, Name="Nguyen Van A", Branch=BranchType.IT,Gender= GenderType.Male, IsRegular= true,
                Adddress="A1-2018",Email="nam@gmail.com"},
                new Student() {Id=102, Name="Tran Thi B", Branch=BranchType.BE, Gender=GenderType.Female, IsRegular=false,
                Adddress="B2-2019", Email="tranb@gmail.com"},

                new Student() {Id=103, Name="Le Van C", Branch=BranchType.CE, Gender=GenderType.Male, IsRegular=true,
                Adddress="C3-2020", Email="levanc@gmail.com"},

                new Student() {Id=104, Name="Pham Thi D", Branch=BranchType.EE, Gender=GenderType.Female, IsRegular=true,
                Adddress="D4-2021", Email="phamd@gmail.com"},

                new Student() {Id=105, Name="Hoang Van E", Branch=BranchType.IT, Gender=GenderType.Male, IsRegular=false,
                Adddress="E5-2022", Email="hoange@gmail.com"}
            };


        }
        [Route("List")]
        public IActionResult Index()
        {
            //tra ve view index cung model la danh sach sv listStuden
            ViewBag.Students = listStudents;
            return View(listStudents);
        }
       
        [HttpGet("Add")]
       
        public IActionResult Create()
        {
            //lay danh sach cac gia tri GenderType de hien thi radio button tren form
            ViewBag.AllGender = Enum.GetValues(typeof(GenderType)).Cast<GenderType>().ToList();
            //lay danh sach cac gia tri BranchType de hien thi select optin tren form
            ViewBag.AllBranches = new List<SelectListItem>()
            {
                new SelectListItem() { Text="IT", Value="1"},
                new SelectListItem() { Text="BE", Value="2"},
                new SelectListItem() { Text="CE", Value="3"},
                new SelectListItem() { Text="EE", Value="4"},
            };
            return View();
        }
        private readonly IWebHostEnvironment _env;
        [HttpPost("Add")]
       
      
        public IActionResult Create(Student s)
        {
            // xu li su kien load anh
            if(s.AvartaFile != null)
            {
                //tao duong dan luu file
                string uploadFoder= Path.Combine(_env.WebRootPath,"images");
                Directory.CreateDirectory(uploadFoder);// dam bao thu muc ton tai
                string uniqueFileName= Guid.NewGuid().ToString() + "_" + s.AvartaFile.FileName;
                string filePath= Path.Combine(uploadFoder, uniqueFileName);
                using (var fileStream= new FileStream (filePath, FileMode.Create))
                {
                    s.AvartaFile.CopyTo(fileStream);
                }
                s.AvatarUrl = uniqueFileName;
            }
            //them sv moi vao danh sach
            listStudents.Add(s);
            //chuyen huong ve action Index
            return RedirectToAction("Index");
        }
    }
}
