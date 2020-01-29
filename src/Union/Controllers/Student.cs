using System.ComponentModel.DataAnnotations;

namespace GroupBy.Controllers {
    public class Student1 {
        [Key]
        public int Id { set; get; }
        public string Name { set; get; } = "wk";
        public string Course { set; get; }
        public int Score { set; get; }
    }

    public class Student2 {
        [Key]
        public int Id { set; get; }
        public string Name { set; get; } = "wk";
        public string Course { set; get; }
        public int Score { set; get; }
    }
}