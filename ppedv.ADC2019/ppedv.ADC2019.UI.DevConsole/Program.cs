﻿using ppedv.ADC2019.Logic;
using ppedv.ADC2019.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.ADC2019.UI.DevConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** ADC 2019 v01 ***");

            var core = new Core();
            core.CreateDemoData();

            Console.WriteLine($"{core.UnitOfWork.AutoRepository.Query().Count()} Autos in DB");
            foreach (var a in core.UnitOfWork.GetRepo<Auto>().GetAll())
            {
                Console.WriteLine($"Farbe: {a.Farbe}, Hersteller: {a.Hersteller}, Modell: {a.Modell}");
            }

            Console.WriteLine("Ende");
            Console.ReadLine();
        }
    }
}
