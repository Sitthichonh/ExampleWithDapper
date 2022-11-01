namespace ExampleWithDapper.Models
{
    public class StudentModel
    {
        public int StudentID { get; set; } = default(int);
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Age { get; set; } = default(int);
        public string AddressN { get; set; } = string.Empty; 
        public string BD { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
    }

    public class RequestStudentModel
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Age { get; set; } = default(int);
        public string AddressN { get; set; } = string.Empty;
        public string BD { get; set; } = string.Empty;
    }

}
