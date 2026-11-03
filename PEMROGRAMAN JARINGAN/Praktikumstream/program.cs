using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Xml.Serialization;
using System.IO;

namespace PraktikumStream
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Membuat objek Mahasiswa di memori
            var mhs = new Mahasiswa(
                2410098, 
                "Cucumu Indah", 
                "Teknik Informatika", 
                new List<string> { "Pemrograman Jaringan", "Sistem Operasi" }
            );

            Console.WriteLine("=== DATA ASLI DI MEMORI ===");
            mhs.TampilkanInfo();

            // ==========================================
            // A. SERIALISASI KE FORMAT JSON
            // ==========================================
            string jsonString = JsonSerializer.Serialize(mhs, new JsonSerializerOptions { WriteIndented = true });
            
            Console.WriteLine("\n=== HASIL SERIALISASI JSON ===");
            Console.WriteLine(jsonString);

            // ==========================================
            // B. SERIALISASI KE FORMAT XML
            // ==========================================
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Mahasiswa));
            using StringWriter stringWriter = new StringWriter();
            xmlSerializer.Serialize(stringWriter, mhs);
            string xmlString = stringWriter.ToString();

            Console.WriteLine("\n=== HASIL SERIALISASI XML ===");
            Console.WriteLine(xmlString);
        }
    }
}