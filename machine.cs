using System;
using System.Collections.Generic;
using System.Text;

namespace DrinkMachine
{
    class machine
    {
        private Drink[] drinks;//מערך שישמור בתוכו את המשקאות 
        private double moneyCollected;

        public machine()
        {
            drinks = new Drink[5];//יצירה של מערך משקאות עם 5 מקומות למשקאות שלנו
            for (int i = 0; i < drinks.Length; i++)
            {
                drinks[i] = new Drink();//לולאה שתיצור אובייקט חדש לכל מקום שלנו במערך כדי שלא יחזיר null
            }
            //הכנסת ערך לכל מקום במערך מסוג משקה אנחנו מכניסים שם מחיר וכמות במכונה לכל אחד
            drinks[0].Name = "Coke";
            drinks[0].Price = 1.00;
            drinks[0].Quantity = 20;
            drinks[1].Name = "Root beer";
            drinks[1].Price = 1.00;
            drinks[1].Quantity = 20;
            drinks[2].Name = "Orange soda";
            drinks[2].Price = 1.00;
            drinks[2].Quantity = 20;
            drinks[3].Name = "Grape soda";
            drinks[3].Price = 1.00;
            drinks[3].Quantity = 20;
            drinks[4].Name = "Bottled water";
            drinks[4].Price = 1.50;
            drinks[4].Quantity = 20;
        }
        public void DisplayChoices()//פעולה שמדפיסה לקונסול את ההודעה בחר משקה מהתפריט ואת סוגי המשקאות
        {
            Console.WriteLine("Select a product from the menu:");
            for (int i = 0; i < drinks.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {drinks[i].Name} - {drinks[i].Price}$");
            }
        }

        public void BuyDrink(int choice)
        {
            if (choice == 2023)
            {
                DailyReport();//בודק אם קיבלנו מהמשתמש את המספר 2023 ומפעיל את הפונקציה
                return;
            }
            else  if (choice < 1 || choice > drinks.Length)
            {
                Console.WriteLine("Invalid choice \n");//הדפסה של הודעת שגיאה אם המוצר לא קיים בתפריט
                return;
            }

            Drink selectedDrink = drinks[choice - 1];//מוצא את המיקום במערך של המשקה לפי המספר שהמשתמש הכניס
            
            if (selectedDrink.Quantity == 0)//בודק אם המיקום הנבחר במערך .כמות במכונה ריק אז מדפיס הודעה שנגמר
            {
                Console.WriteLine("Sorry this drink is sold out \n");
                return;
            }
            
            double insertedMoney = InputMoney(selectedDrink.Price);//מקבל את הכמות כסף שקיבלנו מהמשתמש
            
            if (insertedMoney < selectedDrink.Price)
            {
                Console.WriteLine("Insufficient funds \n");//בודק אם הסכום קטן אז מדפיד הודעה שאין מספיק כסף
                return;
            }

            selectedDrink.Quantity--;//למקרה שכל התנאים לא עבדו אז הוא משנה במכונה את כמות המשקאות הקיימים מאותו סוג אם היה לנו 20 עכשיו יהיה 19
            Console.WriteLine("Here's your drink and enjoy\n");//ומדפיס הודעה הנה המשקה שלך תהנה
            moneyCollected += selectedDrink.Price;
            
            double change = insertedMoney - selectedDrink.Price;//חישוב של כמות העודף
            if (change > 0)//תנאי בדיקה אם קיים עודף
            {
                Console.WriteLine($"Your excess is: ${change}\n");//והדפסה אם כן זה כמות העודף עם הודעה זה העודף
            }
        }

        private double InputMoney(double price)
        {
            Console.WriteLine($"Please insert ${price}:");//הדפסה למשתמש להכניס כמות כסף לפי המחיר של המשקה שבחר
           
            double insertedMoney;//משתנה שיאחסן את הסכום שהמשתמש יכניס
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out insertedMoney))//פעולת בדיקה אם המשתמש הכניס סכום
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input Please enter a valid amount:");// מדפיס למשתמש שגיאה אם הוא שולח ערך שהוא לא סכום ונותן לו להכניס שוב ערך מספרי
                }
            }
            return insertedMoney;
        }

    public void DailyReport()
        {
            Console.WriteLine("\nYour daily report is: ");
            Console.WriteLine("Amount of money collected: " + moneyCollected + "$");//מדפיס את הדוח היומי שזה כמות הכסף שנאסף במכונה
            Console.WriteLine("Amount of drinks remained: ");
            for(int i = 0; i < drinks.Length; i++)//לולאה שמורידה משקה מהמכונה כל פעם שהמשתמש קנה אחד כזה
            {
                Console.WriteLine($"{i + 1}. {drinks[i].Name} - {drinks[i].Quantity}");
            }
        }
    }

}
