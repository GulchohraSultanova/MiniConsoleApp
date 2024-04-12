using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class School
    {
        public int No { get; set; }
        public int ClassLimit{ get; set; }
        public static ClassRoom[] classRooms = { };
        public School(int  no,int classLimit ) { 
            No = no;
            ClassLimit = classLimit;
        }
        //Creat
        public void AddClass(ClassRoom room)
        {
            
            
                Array.Resize(ref classRooms, classRooms.Length+1);
                classRooms[classRooms.Length-1] = room;
               
            
        }
      
        //Delete
        public void DeleteClass(int id)
        {
            ClassRoom[] newClassRooms = { };
           foreach(ClassRoom room in classRooms)
            {
                if(room.Id != id)
                {
                    Array.Resize(ref newClassRooms, newClassRooms.Length+1);
                    newClassRooms[newClassRooms.Length-1] =room;
                }
            }
           classRooms = newClassRooms;
            Console.WriteLine("Sinif mektebden silindi!");
        }
        //Show
        public void ShowClasses()
        {
            foreach(ClassRoom room in classRooms)
            {
                Console.WriteLine(room);
            }
        }
        //Uptade
        public void UptadeClass(int id,string name)
        {

            foreach (ClassRoom room in classRooms)
            {
                if(room.Id == id)
                {
                    room.Name = name;
                    
                }
            }
            Console.WriteLine("Sinif deyisdirildi!");
        }

    }
}
