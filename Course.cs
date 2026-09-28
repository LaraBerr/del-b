using System;
using System.Collections.Generic;

public class Course
{
    // här finns fält och egenskaper för kurs namn, max antal platser och lista med studerande
    public string Name { get; set; }
    public int MaxSeats { get; set; }
    public List<Student> Students { get; set; }

    // Konstruktor för att skapa ny kurs med namn och max antal platser
    public Course(string name, int maxSeats)
    {
        Name = name;
        MaxSeats = maxSeats;
        Students = new List<Student>();
    }

    // här man kan lägga till en studerande i kursen, med kontroll av kapacitet och dubbletter
    public void Enroll(Student student)
    {
        // 1. Kapacitet: Kontrollera om kursen redan full
        if (Students.Count >= MaxSeats)
        {
            Console.WriteLine($"[Avvisad] {Name} är full. {student.Name} kan inte anmälas.");
            return; // Avbryt processen med return
        }

        // 2. inte dubbletter: Kontrollera om studenten redan är anmäld
        if (Students.Contains(student))
        {
            Console.WriteLine($"[Dubblett] {student.Name} är redan anmäld till {Name}.");
            return; // Avbryt processen med return 
        }

        // 3. det ska stämma åt båda hållen: Lägg till studenten i kursen och kursen i studentens lista
        Students.Add(student);
        student.Courses.Add(this);
        Console.WriteLine($"[Lyckades] {student.Name} anmäldes till {Name}.");
    }

    // remove metod är för att ta bort en studerande från kursen
    public void Remove(Student student)
    {
        // 4. no krasch: Kontrollera om studenten är anmäld innan borttagning i kursen och studentens lista 
        if (Students.Contains(student))
        {
            // Ta bort från båda hållen: kursens lista och studentens lista
            Students.Remove(student);
            student.Courses.Remove(this);
            Console.WriteLine($"[Borttagen] {student.Name} togs bort från {Name}.");
        }
        else
        {
            Console.WriteLine($"[Fel] {student.Name} är inte anmäld till {Name}.");
        }
    }

    // Skriver ut alla studerande i kursen med namn
    public void RollCall()
    {
        Console.WriteLine($"\nDeltagarlista för {Name}:");
        if (Students.Count == 0)
        {
            Console.WriteLine(" Inga studerande i kursen.");
        }
        else
        {
            foreach (var student in Students)
            {
                Console.WriteLine("- " + student.Name);
            }
        }
    }

    // här Returnerar vi kursens namn och antalet platser t.ex. "Matematik (2/5 platser)"
    public override string ToString()
    {
        return $"{Name} ({Students.Count}/{MaxSeats} platser)";
    }
}