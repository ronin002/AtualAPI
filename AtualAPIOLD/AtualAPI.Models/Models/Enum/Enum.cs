namespace AtualAPI.Models 
{ 
    public enum ArrowType
    {
        Success,
        Failure,
        Condition
    }
    public enum ELevelAccess
    {
        None = 0,
        View = 1,
        Add = 2,
        Edit = 3,
        Remove = 4,
        All = 5,
        OWner = 6
    }
    public enum ETypeAccess
    {
        LevelProcess = 0,
        LevelDashBoard = 1,
        LevelAdmin = 2,
        LevelOperations = 3,
        LevelUsers = 4,
        LevelRoles = 5,
        LevelStations = 6,
        LevelWorkFlows = 7
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
