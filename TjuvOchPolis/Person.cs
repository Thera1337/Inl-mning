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

        public List<string> Inventory = new List<string>();

        public Person(int yPosition, int xPosition, int yMovment, int xMovment)
        {
            XPositoin = xPosition;
            YPosition = yPosition;
            XMovment = xMovment;
            YMovment = yMovment;
        }

        //public virtual void PlacePerson(string[,] map) 
        //{}
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
            Inventory.Add("Plånbok");
            Inventory.Add("Mobiltelefon");
            Inventory.Add("Nycklar");
            Inventory.Add("Klocka");
        }

        //public override void PlacePerson(string[,] map)
        //{
        //    map[YPosition, XPositoin] = Token;
        //}
    }
}
