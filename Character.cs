using System;
using System.Collections.Generic;
using System.Text;

namespace OOPConsole
{
    class Character
    {
        string name;
        int health;
        int power;
        int x;
        int y;
        Characteristics lvl;

        public Character(string name, int x, int y, int level = 1, int expRule = 1000)
        {
            this.name = name;
            this.x = x;
            this.y = y;
            this.lvl = new Characteristics(level, expRule);
            this.health = this.lvl.Health;
            this.power = this.lvl.Power;
            Console.WriteLine($"Object {this.name} was created at {this.Coordinates}.");
        }

        public int Health {
            get {
                return this.health;
            }

            set {
                this.health = value;
            }
        }

        public int X {
            get {
                return this.x;
            }

        }

        public int Y {
            get {
                return this.y;
            }
        }

        public bool isAlive {
            get {
                return this.health > 0 ? true : false;
            }
        }

        public void Move(string direction)
        {
            switch (direction)
            {
                case "forward":
                    this.x++;
                    break;
                case "backward":
                    this.x--;
                    break;
                case "up":
                    this.y++;
                    break;
                case "down":
                    this.y--;
                    break;
            }
        }

        public string Coordinates {
            get {
                return Convert.ToString($"[ {this.x}, {this.y} ]");
            }

        }

        public bool Collide(Character ch)
        {
            if (ch.X == this.x && ch.Y == this.y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int Level {
            get {
                return this.lvl.Rank;
            }
        }

        public string Attack(Character ch)
        {
            ch.getDamage(this.power);
            if (ch.health <= 0)
            {
                int expPast = this.lvl.Exp;
                getExp(ch);
                return $"You've killed enemy!\nYou've got {this.lvl.Exp - expPast} experience";
            }
            return $"You have attacked {ch.name} and cause damage {this.power}. Enemy now has {ch.Health} HP";
        }

        public void getExp(Character ch)
        {
            this.lvl.UpExp(Convert.ToInt32(ch.lvl.Rank));
        }

        private void getDamage(int dmg)
        {
            this.Health -= dmg;
        }
    }
}