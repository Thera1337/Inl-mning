using System;
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
        public string Token { get; set; }
        public Polis(int xPosition, int yPosition, int xMovment, int yMovment, string token)
            : base(xPosition, yPosition, xMovment,  yMovment)
        {
            Token = token;
        }
    }
    class Tjuv : Person
    {
        public string Token { get; set; }
        public Tjuv(int xPosition, int yPosition, int xMovment, int yMovment, string token)
            : base(xPosition, yPosition, xMovment, yMovment)
        {
            Token = token;
        }
    }
    class Medborgare : Person
    {
        public string Token { get; set; }
        public Medborgare(int xPosition, int yPosition, int xMovment, int yMovment, string token)
            : base(xPosition, yPosition, xMovment, yMovment)
        {
            Token = token;
            Inventory.Add("Pånbok");
            Inventory.Add("Mobiltelefon");
            Inventory.Add("Nycklar");
            Inventory.Add("Klocka");
        }
    }
}
