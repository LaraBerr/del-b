using System;
using System.Collections.Generic;

public class Student
{
    // här finns fält och egenskaper
    public string Name { get; set; }
    public List<Course> Courses { get; set; }

    // Konstruktor  för när en ny student ska skapas
    public Student(string name)
    {
        Name = name;
        Courses = new List<Course>();
    }

    // Metod för att boka en kurs i en studerande 
    public void Join(Course course)
    {
        // För att boka en kurs, används kursens metod (kapacitet, dubbletter)
        course.Enroll(this);
    }

    // detta är en metod för att lämna en kurs
    public void Leave(Course course)
    {
        // För att lämna en kurs, används kursens metod (kapacitet, dubbletter)
        course.Remove(this);
    }

    // man skriver ut vilka kurser den studerande går

    public void Schedule()
    {
        Console.WriteLine($"\nSchema för {Name}:");
        if (Courses.Count == 0)
        {
            Console.WriteLine("Inga kurser inbokade ännu.");
        }
        else
        {
            foreach (var course in Courses)
            {
                Console.WriteLine("- " + course.Name);
            }
        }
    }

    // här returnerar vi studerandes namn
    public override string ToString()
    {
        return Name;
    }
}

