using Composite.Example;
using System;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            Component fileSystem = new Directory("Файловая система");
            // Определяем новый диск.
            Component diskC = new Directory("Диск С");
            // Новые файлы.
            Component pngFile = new File("12345.png");
            Component docxFile = new File("Document.docx");
            // Добавляем файлы на диск C.
            diskC.Add(pngFile);
            diskC.Add(docxFile);
            // Добавляем диск C в файловую систему.
            fileSystem.Add(diskC);
            // Выводим все данные.
            fileSystem.Print();
            Console.ReadLine();

            // Удаляем с диска C файл.
            diskC.Remove(pngFile);
            // Создаем новую папку.
            Component docsFolder = new Directory("Мои Документы");
            // Добавляем в нее файлы.
            Component txtFile = new File("readme.txt");
            Component csFile = new File("Program.cs");
            docsFolder.Add(txtFile);
            docsFolder.Add(csFile);
            // Добавляем папку на диск C.
            diskC.Add(docsFolder);
            // Выводим все данные.
            fileSystem.Print();
            Console.ReadLine();
        }
    }
}
