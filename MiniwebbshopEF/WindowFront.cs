﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniwebbshopEF
{
    internal class WindowFront
    {
        public static void ShowFrontMenu()
        {
            // Hämtar från databasen
            List<string> categoriesText = new List<string> { "1. Byxor", "2. Tröjor", "3. Skor", "4. Skjortor" };
            foreach (var text in categoriesText)
            {
                Console.WriteLine(text);
            }

            // Detta hämtas från databas
            List<string> cartText = new List<string> { "1 st Blå byxor", "2 st Grön tröja", "1 st Röd skjorta", "Tryck X för att checka ut" };
            var windowCart = new Window("Din varukorg", 30, 6, cartText);
            windowCart.Draw();

            var windowCategories = new Window("Kategorier", 2, 6, categoriesText);
            windowCategories.Draw();

            List<string> topText = new List<string> { "# Fina butiken #", "Allt inom kläder" };
            var windowTop = new Window("", 2, 1, topText);
            windowTop.Draw();


            List<string> topText2 = new List<string> { "28 st Keps med tryck", "23 st Gröna byxor", "19 st Ulltröjor", "11 st badbyxor" };
            var windowTop2 = new Window("Bäst säljande produkter", 2, 15, topText2);
            windowTop2.Draw();

            List<string> topText3 = new List<string> { "1. Visa kategorier och produkter",
            "2. Sök efter produkt",
            "3. Visa varukorg",
            "4. Töm varukorg",
            "5. Gå till kassan",
            "6. Adminpanel",
            "7. Avsluta" };
            var windowTop3 = new Window("Kundmeny", 40, 15, topText3);
            windowTop3.Draw();

            List<string> topText4 = new List<string> { "1. Administrera produkter", "2. Administrera kategorier", "3. Administrera kunder", "4. Se statistik(Queries)" };
            var windowTop4 = new Window("Admin", 70, 15, topText4);
            windowTop4.Draw();

            windowTop.Left = 45;
            windowTop.Draw();

            Console.WriteLine("Nån annan text");
        } 
    }
}
