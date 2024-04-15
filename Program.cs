using System;

public class Character
{
   public string Name { get; set; }
   public int HitPoints { get; set; }
   public int AttackStrength { get; set; }
   public int DefenseStrength { get; set; }

   public Character(string name, int hitPoints, int attackStrength, int defenseStrength)
   {
      Name = name;
      HitPoints = hitPoints;
      AttackStrength = attackStrength;
      DefenseStrength = defenseStrength;
   }

   public bool IsAlive()
   {
      return HitPoints > 0;
   }

   public void Attack(Character other)
   {
      if (IsAlive() && other.IsAlive())
      {
         int damage = AttackStrength - other.DefenseStrength;
         if (damage < 0) damage = 0;
         other.HitPoints -= damage;
         Console.WriteLine($"{Name} attacks {other.Name} causing {damage} damage. {other.Name} has {other.HitPoints} HP left.");
         if (!other.IsAlive())
         {
            Console.WriteLine($"{other.Name} has died.");
         }
      }
   }
}

public class Program
{
   public static void Main()
   {
      Character hero = new Character("Hero", 100, 20, 5);
      Character villain = new Character("Villain", 80, 15, 10);

      while (hero.IsAlive() && villain.IsAlive())
      {
         hero.Attack(villain);
         if (villain.IsAlive())
         {
            villain.Attack(hero);
         }
      }

      if (!hero.IsAlive())
      {
         Console.WriteLine("Villain wins!");
      }
      else if (!villain.IsAlive())
      {
         Console.WriteLine("Hero wins!");
      }
   }
}