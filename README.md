using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace demoapi.Controllers
{
    public class Student
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public string Grade { get; set; }
    }


    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private static List<Student> students = new List<Student>();
        private static int Counter = 1;

        [HttpPost]
        public void Post([FromBody] Student value)
        {
            // var x = new Student
            // {
            //     Id = $"S{Counter++}",
            //     Name = value.Name,
            //     Score = value.Score,
            //     Grade = "A"
            // };
            // students.Add(x);

            value.Id = $"S{Counter++}";
            value.Grade = "A";
            students.Add(value);
        }

        [HttpGet]
        public ActionResult<ClassRoom> Get()
        {
            // var sum = 0;
            // for (int i = 0; i < students.Count; i++)
            // {
            //     sum += students[i].Score;
            // }
            // var avg = sum / students.Count;

            // var avg = students.Average(it=>it.Score);
            // var bAvg = Math.Round(students.Average(it=>it.Score), 2);

            var cr = new ClassRoom
            {
                StudentGroup = students,
                // Average = avg
                Average = Math.Round(students.Average(it=>it.Score), 2)
            };
            return cr;
        }
    }

    public class ClassRoom
    {
        public List<Student> StudentGroup { get; set; }
        public double Average { get; set; }
    }
}


// IONIC

myclassRoom: ClassRoom;

this.http.get<ClassRoom>("ENTER_YOUR_API_HERE").subscribe(
    it => {
        this.myclassRoom = it;
    });


    <ion-item *ngFor="let it of myclassRoom.studentGroup" (click)="removeStudent(it)">
      <ion-label fixed>ID: {{ it.id }}</ion-label>
      <ion-label fixed>NAME: {{ it.name }}</ion-label>
    </ion-item>
    {{ myclassRoom.average }}

class ClassRoom
{
   public studentGroup: Student[];
   public average: number;
}

class Student
{
   public Id: string;

}
