using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

/*IEnumerable<string> FindFiles(string folderName)
{
    List<string> salesFiles = new List<string>();
// 
    var foundFiles = Directory.EnumerateFiles(folderName, "*", SearchOption.AllDirectories); // MÈTODO QUE UBICA ARCHIVOS EN UNA CARPETA

    var currentDirectory = Directory.GetCurrentDirectory();
    var storesDirectory = Path.Combine(currentDirectory, "stores");

    var ventaDirectorio = Path.Combine(currentDirectory, "directorioNuevo");
    Directory.CreateDirectory(ventaDirectorio); // CREACION DEL DIRECTORIO ANTERIOR "sales"

    var sales = FindFiles(storesDirectory);

    //ESCRITURA DE ARCHIVO DE TEXTO DENTRO DEL DIRECTORIO CON File.Write

    File.WriteAllText(Path.Combine(ventaDirectorio, "textoCreado.text"), String.Empty);

    /*foreach (var file in foundFiles)
    {
        // The file name will contain the full path, so only check the end of it
        if (file.EndsWith("sales.json"))
        {
            salesFiles.Add(file);
        }
    }

    return salesFiles;
}

var salesFiles = FindFiles("stores");

foreach (var file in salesFiles)
{
    Console.WriteLine(file);
}

Console.WriteLine($@"Este es el directorio  =     
                            {Directory.GetCurrentDirectory()}"); //MÈTODO QUE UBICA EL DIRECOTIRO ACTUAL*/





// VERSIOÒN MICROSOFT


var currentDirectory = Directory.GetCurrentDirectory();
var storesDirectory = Path.Combine(currentDirectory, "stores");

var salesTotalDir = Path.Combine(currentDirectory, "salesTotalDir");
Directory.CreateDirectory(salesTotalDir);   

var salesFiles = FindFiles(storesDirectory);

var salesTotal = CalculateSalesTotal(salesFiles);

File.AppendAllText(Path.Combine(salesTotalDir, "totals.txt"), $"{salesTotal}{Environment.NewLine}");

IEnumerable<string> FindFiles(string folderName)
{
    List<string> salesFiles = new List<string>();

    var foundFiles = Directory.EnumerateFiles(folderName, "*", SearchOption.AllDirectories);

    foreach (var file in foundFiles)
    {
        var extension = Path.GetExtension(file);
        if (extension == ".json")
        {
            salesFiles.Add(file);
        }
    }

    return salesFiles;
}

double CalculateSalesTotal(IEnumerable<string> salesFiles)
{
    double salesTotal = 0;
    
    // Loop over each file path in salesFiles
    foreach (var file in salesFiles)
    {      
        // Read the contents of the file
        string salesJson = File.ReadAllText(file);
    
        // Parse the contents as JSON
        SalesData? data = JsonConvert.DeserializeObject<SalesData?>(salesJson);
    
        // Add the amount found in the Total field to the salesTotal variable
        salesTotal += data?.Total ?? 0;
    }
    
    return salesTotal;
}

record SalesData (double Total);