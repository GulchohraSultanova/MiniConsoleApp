using Core;
using Core.Enums;
using Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniConsoleApp
{
    internal class ClassMenu
    {
        static void Main(string[] args)
        {
            int no;
            do
            {
                Console.Write("Mektebin nomresini daxil edin: ");

            } while (!int.TryParse(Console.ReadLine(), out no));
            Console.WriteLine();
            int limit;
            do
            {
                Console.Write("Mektebe elave ede bilecek maksimum sinif sayini daxil edin: ");

            } while (!int.TryParse(Console.ReadLine(), out limit) || limit < 0 || limit > 200);
            Console.WriteLine();
            School school = new School(no, limit);
            Console.WriteLine("----------------------XOSH GELMISHSINIZ!-------------------------");
        ClassMenu:
            Console.WriteLine("ClassesMenu: ");
            Console.WriteLine("1.Sinif yarat!");
            Console.WriteLine("2.Mektebdeki sinifleri goster!");
            Console.WriteLine("3.Mektebden sinifleri sil!");
            Console.WriteLine("4.Mektebdeki sinifleri redakte et!");
            Console.WriteLine("5.Mektebdeki siniflere muraciet et!");
            Console.WriteLine("6.Programi dayandir!");
            Console.WriteLine();
            Console.WriteLine("Seciminizi daxil edin: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":

                    if (School.classRooms.Length >= school.ClassLimit)
                    {
                        Console.WriteLine("Limit doldu.Sinif elave etmek olmaz!");
                        Console.WriteLine();
                        goto ClassMenu;
                    }

                    else
                    {
                        string name;
                        do
                        {
                            Console.Write("Sinifin adini daxil et (Ilk 2 herfi boyuk diger 3-u ise reqem):");
                            name = Console.ReadLine();

                        } while (!name.CheckClassRoomName());
                        Console.WriteLine();
                        ClassRoomType type;
                        do
                        {
                            Console.WriteLine("Sinif tipini daxil edin (Backend/FrontEnd):");

                        } while (!Enum.TryParse(Console.ReadLine(), out type));


                        ClassRoom classRoom = new ClassRoom(name, type);
                        school.AddClass(classRoom);
                        Console.WriteLine("Sinif elave olundu!");
                        Console.WriteLine();

                        goto ClassMenu;
                    }
                case "2":
                    if (School.classRooms.Length == 0)
                    {
                        Console.WriteLine("Mektebde sinif yoxdur!");
                        Console.WriteLine();
                        goto ClassMenu;
                    }
                    else
                    {
                        Console.WriteLine("Sinifler: ");
                        school.ShowClasses();
                        Console.WriteLine();
                        goto ClassMenu;
                    }
                case "3":
                    if (School.classRooms.Length == 0)
                    {

                        Console.WriteLine("Mektebde sinif yoxdur!");
                        Console.WriteLine();
                        goto ClassMenu;
                    }
                    else
                    {
                        int id;
                        do
                        {
                            Console.Write("Silmek istediyiniz sinifin nomresini daxil edin: ");

                        } while (!int.TryParse(Console.ReadLine(), out id));
                        if (id > School.classRooms.Length)
                        {
                            Console.WriteLine("Mektebde bu nomreli sinif yoxdur!");
                            Console.WriteLine();
                            goto ClassMenu;
                        }
                        else
                        {
                            school.DeleteClass(id);
                            Console.WriteLine();

                            goto ClassMenu;
                        }
                    }
                case "4":
                    if (School.classRooms.Length == 0)  
                    {

                        Console.WriteLine("Mektebde sinif yoxdur!");
                        Console.WriteLine();
                        goto ClassMenu;
                    }
                    else
                    {
                        int uptadeId;
                        bool check = false;
                        do
                        {
                            Console.Write("Adini deyismek istediyiniz sinifin nomresini daxil edin: ");

                        } while (!int.TryParse(Console.ReadLine(), out uptadeId));
                        foreach(ClassRoom classRoom in School.classRooms)
                        {
                            if (classRoom.Id == uptadeId)
                            {
                                check=true;
                              
                            }
                        }
                        if (!check)
                        {
                            Console.WriteLine("Mektebde bu nomreli sinif yoxdur!");
                            Console.WriteLine();
                            goto ClassMenu;
                        }

                        else
                        {
                            string newClassName;

                            do
                            {
                                Console.WriteLine("Adi daxil edin: ");
                                newClassName = Console.ReadLine();

                            } while (!newClassName.CheckClassRoomName());


                            school.UptadeClass(uptadeId, newClassName);
                            Console.WriteLine();
                            goto ClassMenu;
                        }
                    }


                case "5":
                    if (School.classRooms.Length == 0)
                    {
                        try
                        {

                            throw new ClassroomNotFoundException("Mektebde sinif yoxdur!");
                        }
                        catch (ClassroomNotFoundException ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.WriteLine();
                            goto ClassMenu;

                        }
                    }
                    else
                    {
                    StudentMenu:
                        Console.WriteLine("StudentMenu: ");
                        Console.WriteLine("1.Verilmis nomreli sinife elamet elave et!");
                        Console.WriteLine("2.Verilmis nomreli sinifin telebelerini goster!");
                        Console.WriteLine("3.Verilmis nomreli sinifden axtarilan nomreli telebeni sil!");
                        Console.WriteLine("4.Verilmis nomreli sinifden axtarilan telebeni goster!");
                        Console.WriteLine("5.Verilmis nomreli sinifden axtarilan telebenin melumatlarini deyis!");
                        Console.WriteLine("6.Sinif menysuna qayit!");
                        Console.WriteLine();
                        Console.WriteLine("Seciminizi daxil edin: ");
                        string choice1 = Console.ReadLine();
                        switch (choice1)
                        {
                            case "1":



                                int searchId;
                                bool flag = false;
                                do
                                {
                                    Console.Write("Telebe elave etmek istediyiniz sinifin nomresini daxil edin: ");

                                } while (!int.TryParse(Console.ReadLine(), out searchId));
                                foreach (ClassRoom classRoom1 in School.classRooms)
                                {

                                    if (searchId == classRoom1.Id)
                                    {
                                        flag = true;
                                        break;
                                    }

                                }
                                if (!flag)
                                {
                                    Console.WriteLine("Mektebde bu nomreli sinif yoxdur!");
                                    Console.WriteLine();
                                    goto StudentMenu;
                                }
                                else
                                {

                                    string name;
                                    do
                                    {
                                        Console.Write("Telebenin adini daxil edin: ");
                                        name = Console.ReadLine();
                                    } while (!name.CheckNameandSurname());
                                    string surname;
                                    do
                                    {
                                        Console.Write("Telebenin soyadini daxil edin: ");
                                        surname = Console.ReadLine();
                                    } while (!surname.CheckNameandSurname());
                                    Student student = new Student(name, surname);

                                    foreach (ClassRoom classRoom1 in School.classRooms)
                                    {
                                        if (searchId == classRoom1.Id)

                                        {

                                            classRoom1.AddStudent(student);
                                            Console.WriteLine();
                                            goto StudentMenu;
                                        }
                                    }
                                    Console.WriteLine();
                                    goto StudentMenu;
                                }



                            case "2":

                                int searchId1;
                                bool flag1 = false;
                                do
                                {
                                    Console.Write("Telebelerini gormek istediyiniz sinifin nomresini daxil edin: ");

                                } while (!int.TryParse(Console.ReadLine(), out searchId1));
                                foreach (ClassRoom classRoom1 in School.classRooms)
                                {

                                    if (searchId1 == classRoom1.Id)
                                    {
                                        flag1 = true;
                                        break;
                                    }

                                }
                                if (!flag1)
                                {
                                    Console.WriteLine("Mektebde bu nomreli sinif yoxdur!");
                                    Console.WriteLine();
                                    goto StudentMenu;
                                }
                                else
                                {
                                    foreach (ClassRoom classRoom in School.classRooms)
                                    {
                                        if (searchId1 == classRoom.Id)
                                        {
                                            if (classRoom.Students.Length == 0)
                                            {
                                                Console.WriteLine("Sinifde telebe yoxdur!");
                                                Console.WriteLine();
                                                goto StudentMenu;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Telebeler: ");
                                                classRoom.ShowStudents();
                                                Console.WriteLine();
                                                goto StudentMenu;
                                            }

                                        }
                                    }
                                    Console.WriteLine();
                                    goto StudentMenu;

                                }

                            case "3":


                                int searchId2;
                                bool flag2 = false;
                                do
                                {
                                    Console.Write("Telebe silmek istediyiniz sinifin nomresini daxil edin: ");

                                } while (!int.TryParse(Console.ReadLine(), out searchId2));
                                foreach (ClassRoom classRoom1 in School.classRooms)
                                {

                                    if (searchId2 == classRoom1.Id)
                                    {
                                        flag2 = true;
                                        break;
                                    }

                                }
                                if (!flag2)
                                {
                                    Console.WriteLine("Mektebde bu nomreli sinif yoxdur!");
                                    Console.WriteLine();
                                    goto StudentMenu;
                                }
                                else
                                {
                                    foreach (ClassRoom classRoom in School.classRooms)
                                    {
                                        if (searchId2 == classRoom.Id)
                                        {
                                            if (classRoom.Students.Length == 0)
                                            {
                                                Console.WriteLine("Sinifde telebe yoxdur!");
                                                Console.WriteLine();
                                                goto StudentMenu;
                                            }
                                            else
                                            {
                                                int deleteId;
                                                bool flag3 = false;
                                                do
                                                {
                                                    Console.Write("Silmek istediyiniz telebenin nomresini daxil edin: ");

                                                } while (!int.TryParse(Console.ReadLine(), out deleteId));
                                                foreach (ClassRoom classRoom1 in School.classRooms)
                                                {

                                                    foreach (Student student in classRoom1.Students)
                                                    {
                                                        if (deleteId == student.Id)
                                                        {
                                                            flag3 = true;
                                                            break;
                                                        }
                                                    }

                                                }
                                                if (!flag3)
                                                {
                                                    try
                                                    {
                                                        throw new StudentNotFoundException("Bu nomreli telebe sinifde yoxdur!");
                                                    }
                                                    catch (StudentNotFoundException ex)
                                                    {

                                                        Console.WriteLine(ex.Message);
                                                        Console.WriteLine();
                                                        goto StudentMenu;
                                                    }
                                                }
                                                else
                                                {
                                                    foreach (ClassRoom classRoom1 in School.classRooms)
                                                    {
                                                        foreach (Student student in classRoom1.Students)
                                                        {
                                                            if (student.Id == deleteId)
                                                            {
                                                                classRoom1.Delete(deleteId);
                                                            }
                                                        }
                                                    }
                                                    Console.WriteLine();
                                                    goto StudentMenu;
                                                }

                                            }

                                        }

                                    }
                                    Console.WriteLine();
                                    goto StudentMenu;


                                }


                            case "4":

                                int searchId3;
                                bool flag4 = false;
                                do
                                {
                                    Console.Write("Gormek istediyiniz telebenin sinif nomresini daxil edin: ");

                                } while (!int.TryParse(Console.ReadLine(), out searchId3));
                                foreach (ClassRoom classRoom1 in School.classRooms)
                                {

                                    if (searchId3 == classRoom1.Id)
                                    {
                                        flag4 = true;
                                        break;
                                    }

                                }
                                if (!flag4)
                                {
                                    Console.WriteLine("Mektebde bu nomreli sinif yoxdur!");
                                    Console.WriteLine();
                                    goto StudentMenu;
                                }
                                else

                                {

                                    foreach (ClassRoom classRoom in School.classRooms)
                                    {
                                        if (searchId3 == classRoom.Id)
                                        {
                                            if (classRoom.Students.Length == 0)
                                            {
                                                Console.WriteLine("Sinifde telebe yoxdur!");
                                                Console.WriteLine();
                                                goto StudentMenu;
                                            }
                                            else
                                            {
                                                int searchStudentId;
                                                bool flag5 = false;
                                                do
                                                {
                                                    Console.Write("Gormek istediyiniz telebenin nomresini daxil edin: ");

                                                } while (!int.TryParse(Console.ReadLine(), out searchStudentId));
                                                foreach (ClassRoom classRoom1 in School.classRooms)
                                                {

                                                    foreach (Student student in classRoom1.Students)
                                                    {
                                                        if (searchStudentId == student.Id)
                                                        {
                                                            flag5 = true;
                                                            break;
                                                        }
                                                    }

                                                }
                                                if (!flag5)
                                                {
                                                    Console.WriteLine("Sinifde bu nomreli telebe yoxdur!");
                                                    Console.WriteLine();
                                                    goto StudentMenu;

                                                }
                                                else
                                                {
                                                    foreach (ClassRoom classRoom1 in School.classRooms)
                                                    {
                                                        if (classRoom1.Id == searchId3)
                                                        {
                                                            foreach (Student student in classRoom1.Students)
                                                            {
                                                                if (searchStudentId == student.Id)
                                                                {

                                                                    Console.WriteLine(classRoom1.FindId(searchStudentId).ToString());
                                                                }
                                                            }
                                                        }
                                                    }
                                                    Console.WriteLine();
                                                    goto StudentMenu;
                                                }

                                            }


                                        }
                                    }
                                    Console.WriteLine();
                                    goto StudentMenu;
                                }



                            case "5":

                                int searchId4;
                                bool flag6 = false;
                                do
                                {
                                    Console.Write("Deyisdirmek istediyiniz telebenin sinif nomresini daxil edin: ");

                                } while (!int.TryParse(Console.ReadLine(), out searchId4));
                                foreach (ClassRoom classRoom1 in School.classRooms)
                                {

                                    if (searchId4 == classRoom1.Id)
                                    {
                                        flag6 = true;
                                        break;
                                    }

                                }
                                if (!flag6)
                                {
                                    Console.WriteLine("Mektebde bu nomreli sinif yoxdur!");
                                    Console.WriteLine();
                                    goto StudentMenu;
                                }
                                else
                                {
                                    foreach (ClassRoom classRoom in School.classRooms)
                                    {
                                        if (searchId4 == classRoom.Id)
                                        {
                                            if (classRoom.Students.Length == 0)
                                            {
                                                Console.WriteLine("Sinifde telebe yoxdur!");
                                                Console.WriteLine();
                                                goto StudentMenu;
                                            }
                                            else
                                            {
                                                int uptadeStudentId;
                                                bool flag7 = false;
                                                do
                                                {
                                                    Console.Write("Deyisdirmek istediyiniz telebenin nomresini daxil edin: ");

                                                } while (!int.TryParse(Console.ReadLine(), out uptadeStudentId));
                                                foreach (ClassRoom classRoom1 in School.classRooms)
                                                {

                                                    foreach (Student student in classRoom1.Students)
                                                    {
                                                        if (uptadeStudentId == student.Id)
                                                        {
                                                            flag7 = true;
                                                            break;
                                                        }
                                                    }

                                                }
                                                if (!flag7)
                                                {
                                                    Console.WriteLine("Sinifde bu nomreli telebe yoxdur!");
                                                    Console.WriteLine();
                                                    goto StudentMenu;

                                                }
                                                else
                                                {
                                                    string name;
                                                    do
                                                    {
                                                        Console.Write("Telebenin yeni adini daxil edin: ");
                                                        name = Console.ReadLine();

                                                    } while (!name.CheckNameandSurname());
                                                 
                                                    string surname;
                                                    do
                                                    {
                                                        Console.Write("Telebenin yeni soyadini daxil edin: ");
                                                        surname = Console.ReadLine();

                                                    } while (!surname.CheckNameandSurname());
                                                   
                                                    foreach (ClassRoom classRoom1 in School.classRooms)
                                                    {
                                                        foreach (Student student in classRoom1.Students)
                                                        {
                                                            if (uptadeStudentId == student.Id)
                                                            {

                                                                classRoom1.Uptade(uptadeStudentId, new Student(name, surname));
                                                            }
                                                        }
                                                    }
                                                    Console.WriteLine("Telebe deyisdirildi!");
                                                    Console.WriteLine();
                                                    goto StudentMenu;
                                                }

                                            }


                                        }
                                    }
                                    Console.WriteLine();
                                    goto StudentMenu;
                                }


                            case "6":
                                Console.WriteLine();
                                goto ClassMenu;


                            default:
                                Console.WriteLine("Duzgun secim daxil edin!");
                                Console.WriteLine();
                                goto StudentMenu;
                        }
                    }



                case "6":
                    Console.WriteLine("Program dayandi......");
                    break;
                default:
                    Console.WriteLine("Duzgun secim daxil edin!");
                    goto ClassMenu;
            }

        }

    }
}

