using System.IO;
using System.Collections.Generic;

IEnumerable<string> FindFiles(string folderName)
{
    List<string> salesFiles = new List<string>();

    var foundFiles = Directory.EnumerateFiles(folderName, "*", SearchOption.AllDirectories); // MÈTODO QUE UBICA ARCHIVOS EN UNA CARPETA

    foreach (var file in foundFiles)
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
                            {Directory.GetCurrentDirectory()}"); //MÈTODO QUE UBICA EL DIRECOTIRO ACTUAL