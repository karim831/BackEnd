namespace Main.Models;

public class StudentBL{
    IList<Student> students;

    public StudentBL(){
        students = new List<Student>(10);
        students.Add(new Student(){Id = 1,Name = "Kareem Osama",ImageURL = "favicon.ico"});
        students.Add(new Student(){Id = 2,Name = "Mohamed Ahmed",ImageURL = "favicon.ico"});
        students.Add(new Student(){Id = 3,Name = "Mohaned Ahmed",ImageURL = "favicon.ico"});
    }

    public IList<Student> GetAllStudents() => students;

    public Student? GetStudentById(int id) => students.FirstOrDefault(s => s.Id == id);

    

}