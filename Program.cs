using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("--- KUNSKAPSKONTROLL DEL B ---");

        // 1. här skapar vi några kurser och studerande
        // Skapar en kurs med max 2 platser och en annan med max 5 platser (för att testa kapacitet)
        Course cSharp = new Course("Programmering i C#", 2);
        Course spelUtveckling = new Course("Spelutveckling", 5);

        Student lara = new Student("Lara"); // Skapar en ny studerande
        Student ali = new Student("Ali");
        Student sara = new Student("Sara");

        // 2. här testar vi att anmälan fungerar (både via Student och Course) och att kapacitet och dubbletter fungerar korrekt (inklusive RollCall och Schedule) 
        Console.WriteLine("\n--- TEST: Anmälan ---");
        // Anmäler via Student-klassen (Join) - så att både sätten fungerar korrekt
        lara.Join(cSharp);
        // Anmäler via Course-klassen (Enroll) 
        cSharp.Enroll(ali);

        // 3. Testar att kapacitet för kursen(MaxSeats respekteras)
        Console.WriteLine("\n--- TEST: Kapacitet (Kursen är full) ---");
        // cSharp kursen har bara 2 platser (Lara och Ali tog dem). Sara borde inte få plats. Försöker anmäla
        sara.Join(cSharp);

        // 4. Testar att dubblettanmälan fungerar (Inga dubbletter)
        Console.WriteLine("\n--- TEST: Dubblettanmälan ---");
        // Lara är redan med i C#-kursen, försöker igen
        lara.Join(cSharp);

        // 5. Testa RollCall och Schedule ( här testar vi att båda hållen hänger ihop)
        Console.WriteLine("\n--- TEST: Utskrifter ---");
        cSharp.RollCall(); // koden skriver ut alla studenter i kursen
        lara.Schedule();   // Listar Laras (jag:)) kurser

        // Vi skriver ut hur kursen ser ut med ToString() metoden 
        Console.WriteLine($"\nKursinfo: {cSharp.ToString()}");

        // 6. här testar vi att borttagning fungerar  
        Console.WriteLine("\n--- TEST: Borttagning ---");
        // Sara är inte med i cSharp, vi försöker ta bort henne (Ska inte krascha)
        cSharp.Remove(sara);

        // Ali lämnar kursen
        ali.Leave(cSharp);

        // Laras  andra kurs
        lara.Join(spelUtveckling);
        lara.Schedule();

        Console.WriteLine("\n--- TEST KLAR ---");
    }
}