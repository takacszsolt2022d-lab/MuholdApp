using MuholdApp;
using System.IO;
List<Muhold> lista = new List<Muhold>();
int hibassorok = 0;

foreach(string sor in File.ReadAllLines("muholdak.txt").Skip(1))
{
    if (string.IsNullOrWhiteSpace(sor))
    {
        hibassorok++;
        continue;
    }
    string[] adatok = sor.Split("|");

    if(adatok.Length != 4)
    {
        hibassorok++;
        continue;
    }
    string azon = adatok[1].Trim();
    string tipus = adatok[0].Trim();

    if (tipus != "M" && tipus != "K")
    {
        hibassorok++;
        continue;
    }

    if (!int.TryParse(adatok[2],out int tomeg))
    {
        hibassorok++;
        continue;

    }
    if (!int.TryParse(adatok[3], out int muszerek))
    {
        hibassorok++;
        continue;
    }
    if(tipus == "M")
    {
        lista.Add(new Muhold(adatok[1], tomeg));
    }
    if(tipus == "K")
    {
        lista.Add(new KutatasiMuhold(adatok[1], tomeg, muszerek));
    }



}
foreach (Muhold kiir in lista)
{
    Console.WriteLine(kiir);
}

Console.WriteLine($"Összesen {lista.Count} műholdat sikerült beolvasni, {hibassorok} hibás sor volt.");

Console.WriteLine("Átlagos műhold tömeg: " + lista.Average(x => x.SulyKg) + " kg");

Console.WriteLine("A legnehezebb műhold: " + lista.MaxBy(x => x.SulyKg));


var legolcsobb = lista.MinBy(x => x.NapiKoltseg());
Console.WriteLine("A legolcsóbb uzemeltetésű műhold: " + legolcsobb);

Console.WriteLine("AZ osszes műhold ami legalább 1000 kg:" + lista.Count(x => x.SulyKg >= 1000));


foreach (var m in lista)
{
    if (m is KutatasiMuhold km)
    {
        Console.WriteLine(km.Azonosito + " kutatási műhold műszereinek száma: " + km.MuszerekSzama + " db");
    }
}


var nagyobb = lista.Where(x => x.NapiKoltseg() > 2000).OrderByDescending(x => x.NapiKoltseg()).Select(x => $"{x.Azonosito};{x.SulyKg};{x.NapiKoltseg()}");

var riport = nagyobb;

File.WriteAllLines("riport.txt",riport);

Console.WriteLine("A riport.txt fájl sikeresen elkészült a kimeneti mappában.");



