// See https://aka.ms/new-console-template for more information
using System;
using System.Globalization;

internal class Program
{
    private static void Main(string[] args)
    {
        // Create a HijriCalendar object
        HijriCalendar hijri = new HijriCalendar();

        // Get the current date in Gregorian and Hijri calendars
        DateTime today = DateTime.Today;
        int gregorianYear = today.Year;
        int hijriYear = hijri.GetYear(today);

        // Find the start date of Ramadan in the current Hijri year
        DateTime ramadanStart = new DateTime(hijriYear, 9, 1, hijri);

        // Convert the start date of Ramadan to Gregorian calendar
        ramadanStart = ramadanStart.Date;

        // Calculate the number of days until Ramadan
        int daysUntilRamadan = (int)ramadanStart.Subtract(today).TotalDays;

        // Display the result
        Console.WriteLine("Today is {0} in Gregorian calendar and {1} in Hijri calendar.", today.ToString("yyyy/MM/dd"), hijri.ToString());
        Console.WriteLine("The start date of Ramadan is {0} in Gregorian calendar and {1} in Hijri calendar.", ramadanStart.ToString("yyyy/MM/dd"), hijri.ToString());
        Console.WriteLine("There are {0} days until Ramadan.", daysUntilRamadan);


// Ask the user to enter their Gregorian birthday in yyyy/MM/dd format
Console.WriteLine("Please enter your Gregorian birthday in yyyy/MM/dd format:");
        string input = Console.ReadLine();

        // Try to parse the input as a DateTime object
        DateTime birthday;
        if (DateTime.TryParseExact(input, "yyyy/MM/dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out birthday))
        {
            // Convert the birthday to Hijri date using the HijriCalendar object
            int year = hijri.GetYear(birthday);
            int month = hijri.GetMonth(birthday);
            int day = hijri.GetDayOfMonth(birthday);

            // Display the Hijri date in yyyy/MM/dd format
            Console.WriteLine("Your Hijri birthday is {0}/{1}/{2}", year, month, day);
        }
        else
        {
            // Display an error message if the input is invalid
            Console.WriteLine("Invalid input. Please try again.");
        }
    }
}