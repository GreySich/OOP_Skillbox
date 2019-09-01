using System;
using System.Collections.Generic;
using System.Text;

namespace OOPConsole
{
    class Characteristics
    {

        int level;
        int exp;
        int nextLevelExp;
        int health = 100;
        int power = 15;
        // Данный параметр используется для правила расчёта следующего уровня
        // В методе nextRank не получилось использовать как константу :(
        int expRule = 1000;
        // Ограничение на уровень
        int maxLevel = 20;

        public Characteristics(int level = 1, int expRule = 1000)
        {
            this.level = level;
            this.expRule = expRule;
            SetExp(level);
        }

        public void UpExp(int level)
        {
            exp += Math.Max(0, 75 + (level - this.level) * this.level);
            while (this.level < this.maxLevel && this.exp >= this.nextLevelExp)
            {
                levelUp();
            }
        }

        public int Rank {
            get {
                return this.level;
            }

            set {
                this.level = value;
            }
        }

        // Устанавливаем уровень относительно опыта
        // Используется при создании
        private void SetExp(int level)
        {
            nextLevelExp = expRule;
            for (int i = 1; i < level; i++)
            {
                nextLevelExp += nextRank(i);
            }
            exp = nextLevelExp - nextRank(this.level);
        }

        private int nextRank(int level)
        {
            return level * this.expRule;
        }

        private void setHealth(int level)
        {
            // каждый уровень + 5 хп
            // каждый уровень хп восстанавливаются
            this.health = 100 + (level - 1) * 5;
        }

        private void upDamage()
        {
            // Каждые 3 уровня + 2 урона
            if (level % 3 != 0)
                this.power++;
            else
                this.power += 2;
        }

        public int Health {
            get {
                return this.health;
            }
            set {
                this.health = value;
            }
        }

        public int Power {
            get {
                return this.power;
            }
        }

        public int Exp {
            get {
                return this.exp;
            }
        }

        private void levelUp()
        {
            this.level++;
            Console.WriteLine($"Congratulations! Now your level {this.level}");
            // Повышение уровня как в старой доброй D&D 3.5:
            // каждый следующий уровень на 1000 дороже
            this.nextLevelExp += nextRank(this.level);
            setHealth(this.level);
            upDamage();
        }

    }
}