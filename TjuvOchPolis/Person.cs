using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TjuvOchPolis
{
    class Person
    {
        public int XPositoin { get; set; }
        public int YPosition { get; set; }
        public int XMovment { get; set; }
        public int YMovment { get; set; }
        public string Token { get; set; }
        public string Kollision { get; set; }
        public bool HasCollided { get; set; }

        public List<Tillhörighet> Inventory = new List<Tillhörighet>();

        public Person(int yPosition, int xPosition, int yMovment, int xMovment)
        {
            XPositoin = xPosition;
            YPosition = yPosition;
            XMovment = xMovment;
            YMovment = yMovment;
            Kollision = "X";
            HasCollided = false;
        }
    }
    class Polis : Person
    {
        public Polis(int yPosition, int xPosition, int yMovment, int xMovment)
            : base(yPosition, xPosition, yMovment,  xMovment)
        {
            Token = "P";
        }
    }
    class Tjuv : Person
    {
        public Tjuv(int yPosition, int xPosition, int yMovment, int xMovment)
            : base(yPosition, xPosition, yMovment, xMovment)
        {
            Token = "T";
        }
    }
    class Medborgare : Person
    {
        public Medborgare(int yPosition, int xPosition, int yMovment, int xMovment)
            : base(yPosition, xPosition, yMovment, xMovment)
        {
            Token = "M";
            Inventory.Add(new Tillhörighet ("Plånbok"));
            Inventory.Add(new Tillhörighet("Mobiltelefon"));
            Inventory.Add(new Tillhörighet("Nycklar"));
            Inventory.Add(new Tillhörighet("Klocka"));
        }
    }
    class Dummy : Person
    {
        public Dummy(int yPosition, int xPosition, int yMovment, int xMovment)
            : base(yPosition, xPosition, yMovment, xMovment)
        {
            Token = " ";
        }
    }
    class Tillhörighet
    {
        public string Pryl { get; set; }

        public Tillhörighet(string pryl)
        {
            Pryl = pryl;
        }
    }
}
