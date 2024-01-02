namespace AtualAPI.Models 
{ 
    public enum ArrowType
    {
        Success,
        Failure,
        Condition
    }
    
    
    public enum ELevelRisc
    {
        None = 0,
        LowRisc = 1,
        HighRisc = 2,
        CriticalRisc = 3

    }

    public enum ETriggerState
    {
        Waiting,
        Used
    }
    public enum ETypeActivity
    {
        Klango,
        Python
    }
}
