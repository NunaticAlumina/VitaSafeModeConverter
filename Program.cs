using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace VitaSafeModeConverter {
    class Program {
        static void ProcessSafeMode(string path) {
            using(var fs = new FileStream(path, FileMode.Open)) {
                fs.Position = 0x80;

                if (fs.ReadByte() == 1) {
                    fs.Position--;
                    fs.WriteByte(2);
                    Console.WriteLine("Converted as safe mode: " + path);
                }
            }
        }

        static void Main(string[] args) {
            if (args.Length != 1) {
                Console.WriteLine("There is no input.");
                return;
            }

            var path = args[0];
            do {
                if (path.Contains("eboot.bin")) break;                
                if (path.Contains("eboot_origin.bin")) break;

                Console.WriteLine("Input does not matches to 'eboot.bin' or 'eboot_origin.bin'.");
                return;
            } while(false);

            ProcessSafeMode(path);

            Console.WriteLine("Done.");
        }
    }
}
