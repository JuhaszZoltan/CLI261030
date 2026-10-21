# nullable disable

const string FilePath = "..\\..\\..\\data\\arukeszlet.csv";

List<Product> products = [];

using StreamReader stream = new(FilePath);
_ = stream.ReadLine();
while (!stream.EndOfStream) products.Add(new(stream.ReadLine()));

//TESZ #01
//products.ForEach(x => Console.WriteLine($"{x}\n--------------------------------"));

var inventorySumValue = products.Sum(p => p.PriceHUF * p.StockQTY);
Console.WriteLine($"árukészlet: örrértéke: {inventorySumValue:N0} HUF");

var inventoryAvgRating = products.Average(p => p.Rating);
Console.WriteLine($"áruminőség átlagos értékelése: {inventoryAvgRating:0.00}/5");

var countOfLaptopOpt = products.Count(p => p.Category == "Laptop" && p.PriceHUF > 500000);
Console.WriteLine($"ennyi fajta laptop ára van 500K felett: {countOfLaptopOpt} db");

var maxPriceProd = products.MaxBy(p => p.PriceHUF);
Console.WriteLine($"a legdrágább termék:\n{maxPriceProd}");

var worstRatingProd = products.MinBy(p => p.Rating);
Console.WriteLine($"leggyengébb értékelésű termék:\n{worstRatingProd}");

//van .min és .max is, de ezek CSAK a delegate-ben lévő kiválaszásnak megfelelő ÉRTÉKET adják vissza!

bool isThereAnyNovaProd = products.Any(p => p.Manufacturer == "Nova");
Console.WriteLine($"{(isThereAnyNovaProd ? "VAN" : "NINCS")} Nova termék a kínálatban");

bool isAllProdsOver2K = products.All(p => p.PriceHUF > 2000);
Console.WriteLine($"{(isAllProdsOver2K ? "MINDEN" : "NEM MINDEN")} termék drágább, mint 2000 HUF");

//hasonló a .contains -> de az NEM LINQ, hanem a collection.generic method

var firstSignQtyProd = products.First(p => p.StockQTY >= 400);
Console.WriteLine($"az első olyan termék az árukészletben, amiből legalább 400 db van raktáron " +
    $"(ID: {firstSignQtyProd.Id}):\n{firstSignQtyProd}");

var lastSignQtyProd = products.Last(p => p.StockQTY >= 400);
Console.WriteLine($"az utolsó olyan termék az árukészletben, amiből legalább 400 db van raktáron " +
    $"(ID: {lastSignQtyProd.Id}):\n{lastSignQtyProd}");

var singleWirelessMouse = products.Single(p => p.Model == "Wireless Mouse");
Console.WriteLine($"az EGYETLEN vezeték nélküli egér:\n{singleWirelessMouse}");

//ha NINCS találat a firs, last v. single-re, akkor "Sequence contains no matching element" exceptiont dob!

Console.Write("írja be milyen terméket keres: ");
string keyword = Console.ReadLine().ToLower();
var firstIfExist = products.FirstOrDefault(p => p.Model.ToLower().Contains(keyword));

if (firstIfExist is not null)
{
    Console.WriteLine($"Az első olyan termék, melynek neve tartalmazza, " +
        $"hogy '{keyword}':\n{firstIfExist}");
}
else Console.WriteLine($"NINCS olyan termék, aminek a neve tartalmazná azt, hogy '{keyword}'");


/*
 * first()      firstordefault()
 * last()       lastordefault()
 * single()     singleordefault()
*/


//lastordefault az ue., csak a rendre utolsó példányt adja vissza a kollekcióból, ami megfelel a delegate <predicate>-jének

//a single és a singleordefault "Sequence contains more than one matching element" exceptiont dob, HA több találat van!

//a .find és az findidex, ezek szintén nem LINQ ext. methodok


//kiválasztás:

//pred.: a gyártó neve 'Apex'


Console.WriteLine("\n==========================");
Console.WriteLine("\n==========================");

int i = 0;
while (products[i].Manufacturer != "Apex") i++;

Console.WriteLine($"első apex termék:\n{products[i]}");