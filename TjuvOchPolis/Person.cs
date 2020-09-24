﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TjuvOchPolis
{
    class Person
    {
        public int XPositoin { get; set; }
        public int YPosition { get; set; }
        public int XMovment { get; set; }
        public int YMovment { get; set; }

        public List<string> Inventory = new List<string>();

        public Person(int xPosition, int yPosition, int xMovment, int yMovment)
        {
            XPositoin = xPosition;
            YPosition = yPosition;
            XMovment = xMovment;
            YMovment = yMovment;
        }
    }
    class Polis : Person
    {
        public Polis(int xPosition, int yPosition, int xMovment, int yMovment)
            : base(xPosition, yPosition, xMovment,  yMovment)
        {

        }
    }
    class Tjuv : Person
    {
        public Tjuv(int xPosition, int yPosition, int xMovment, int yMovment)
            : base(xPosition, yPosition, xMovment, yMovment)
        {

        }
    }
    class Medborgare : Person
    {
        public Medborgare(int xPosition, int yPosition, int xMovment, int yMovment)
            : base(xPosition, yPosition, xMovment, yMovment)
        {
            Inventory.Add("Pånbok");
            Inventory.Add("Mobiltelefon");
            Inventory.Add("Nycklar");
            Inventory.Add("Klocka");
        }
    }
}