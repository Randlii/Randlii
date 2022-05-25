using System;
using System.Collections.Generic;

namespace _30._04_student
{
    public class Program
    {
        private static Student[] STUD = new Student[]
        {
            new Student("Артем Блинников Игоревич", "09-101", "ИВМиИТ", "БИ", 4.67),
            new Student("Мухамедьяров Ренат Максимович", "09-103", "ИВМиИТ","БИ", 3.00)
        };

        static void Main(string[] args)
        {
            Console.WriteLine("Информация о всех студентах:");
            foreach (Student student in STUD)
                Console.WriteLine(student);

            Console.WriteLine("\nСтуденты, которые учатся в 09-122 группе:");
            foreach (Student student in ApplyFilter(FilterByGroup, STUD))
                Console.WriteLine(student);

            Console.WriteLine("\nСтуденты, которые имеют средний балл больше 4.00:");
            foreach (Student student in ApplyFilter(FilterByGrade, STUD))
                Console.WriteLine(student);

            Console.WriteLine("\nСтуденты, которые учатся в ИВМиИТе:");
            foreach (Student student in ApplyFilter(FilterByFaculty, STUD))
                Console.WriteLine(student);

            Console.WriteLine("\nСтуденты, которые учатся на БИ:");
            foreach (Student student in ApplyFilter(FilterBySpeciality, STUD))
                Console.WriteLine(student);

            Console.ReadLine();
        }

        //Фильтры для методов
        private static bool FilterByFaculty(Student student)
        {
            return student.faculty.Equals("ИВМиИТ");
        }

        private static bool FilterBySpeciality(Student student)
        {
            return student.speciality.Equals("БИ");
        }

        private static bool FilterByGroup(Student student)
        {
            return student.group.Equals("09-122");
        }

        private static bool FilterByGrade(Student student)
        {
return student.middleGrade > 4.00;
        }

        //Сам метод
        private static List<Student> ApplyFilter(FilterDelegate filter, Student[] initialArray)
        {
            List<Student> filteredStudents = new List<Student>();
            foreach (Student student in initialArray)
                if (filter.Invoke(student))
                    filteredStudents.Add(student);
            return filteredStudents;
        }
    }

    public delegate bool FilterDelegate(Student student); //Тот самый делегат, виду которого должны соответствовать наши фильтры

    public class Student
    {
        public string fio;
        public string group;
        public string faculty;
        public string speciality;
        public double middleGrade;

        public Student(string fio, string group, string faculty, string speciality, double middleGrade)
        {
            this.fio = fio;
            this.group = group;
            this.faculty = faculty;
            this.speciality = speciality;
            this.middleGrade = middleGrade;
        }

        public override string ToString() => $"Студент: {fio} - {faculty}, {speciality}, {group}. Балл: {middleGrade}"; //красивый вывод на консоль
    }
}
