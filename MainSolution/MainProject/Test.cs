using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject
{
    class Test
    {
        public string userName;


        public void Run()
        {
            Console.WriteLine("Vad heter du?");
            userName = Console.ReadLine();
            Console.WriteLine(string.Format("Hejsan {0}!", userName));
        }
    }
}
