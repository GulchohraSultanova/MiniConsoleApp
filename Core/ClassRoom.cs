using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class ClassRoom
    {
        private static int _id;
        private int _studentIdCounter = 0;
        public int Id { get; }
        public string Name { get; set; }
        public Student[] Students = { };
        public ClassRoomType ClassRoomType { get; set; }
        public ClassRoom(string name, ClassRoomType classRoomType)
        {
            Id = ++_id;
            Name = name;
            ClassRoomType = classRoomType;
            Students = new Student[0];
            _studentIdCounter = 0;
        }
        //Tələbənin sinifə əlavə olunması
        public void AddStudent(Student student)
        {
            student.Id = ++_studentIdCounter;

            if (Students.Length >= (ClassRoomType==ClassRoomType.Backend ?20 :15)){
                Console.WriteLine("Sinif limitine catilmisdir.");
            }
            else {
                Array.Resize(ref Students, Students.Length + 1);
                Students[Students.Length - 1] = student;
                Console.WriteLine("Telebe sinife elave olundu!");
            }
        }
        public void Delete(int id)
        {
            Student[] newStudents = { };
            foreach (Student student in Students)
            {
                if (student.Id != id)
                {
                    Array.Resize(ref newStudents, newStudents.Length + 1);
                    newStudents[newStudents.Length - 1] = student;
                }
            }
            Students = newStudents;
         
            Console.WriteLine("Telebe sinifden silindi!");

        }
        public void ShowStudents()
        {
            foreach (Student student in Students)
            {
                Console.WriteLine(student);
            }

        }
        //telebenin nomresine gore qaytarilmasi
        public Student FindId(int id)
        {
            foreach (Student student in Students)
            {
                if (student.Id == id) return student;
            }
            return null;
        }
        //Telebenin sinifden silinmesi
       
        //Uptade
        public void Uptade(int id, Student student)
        {
            foreach (Student student1 in Students)
            {
                if (student1.Id == id)
                {
                    student1.Name = student.Name;
                    student1.Surname = student.Surname;
                }
            }
          
        }
        //Show
       
        public override string ToString()
        {
            return $"Sinifin nomresi:{Id}; Sinif adi:{Name}; Sinifin tipi: {ClassRoomType}; Sinifdeki telebelerin sayi:{Students.Length};";
        }

    }
}
