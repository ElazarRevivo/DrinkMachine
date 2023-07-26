using System;

namespace DrinkMachine
{
    class Program
    { 
        static void Main(string[] args) // המכונה תרוץ עד שתקבל את הערך 2023 המסמן את סוף היום
        {
            machine m1 = new machine();//יצירת משתנה מסוג הקלאס מכונה שיצרנו
            while (true)
            {
                m1.DisplayChoices();//הפעלה של הפעולה שמדפיסה למשתמש את התפריט
                Console.WriteLine("Enter your choice:");//הדפסה שיבחר משהו
                int choice = int.Parse(Console.ReadLine());//קליטה איזה משקה הוא בחר
                m1.BuyDrink(choice);//הפעלה של הפעולה שבודקת אם יש שגיאות בבחירה
                if (choice == 2023) break;
            }
        }
    }
}
