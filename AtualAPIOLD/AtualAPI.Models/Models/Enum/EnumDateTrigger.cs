namespace AtualAPI.Models 
{ 

    public enum ETypeDateTrigger
    {
        EspecificDate,
        Daily,
        Monthly,
        Yearly,
        DayOfWeek,
        Every_X_Months,
        Every_X_Minutes,
        Every_X_Hours,
        X_DayOfWeekEspecificWeek, //X -> First, Second, Third, four or Fiveth week of month
        //EveryDayOfWeek,
    }
    public enum ETypeDateException
    {
        EspecificDate,
        BetweenDates,
        BetweenHours,
        BetwennMonths,
        ExpecificDayOfWeek,
        ExpecificWeekOfMonth,
        ExpecificMonthOfYear
    }
}
