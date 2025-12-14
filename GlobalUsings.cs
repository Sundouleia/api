global using System;
global using System.Threading.Tasks;
global using System.Collections.Generic;

global using IPCMoodleAccessTuple = (// Maybe include ptr/objectIdx or not idk
    SundouleiaAPI.Enums.MoodleAccess OtherAccess, long OtherMaxTime,
    SundouleiaAPI.Enums.MoodleAccess CallerAccess, long CallerMaxTime
);

global using MoodlesStatusInfo = (
    System.Guid GUID,
    int IconID,
    string Title,
    string Description,
    byte StatusType,        // Moodles StatusType enum, as a byte.
    string CustomVFXPath,   // What VFX to show on application.
    int Stacks,             // Usually 1 when no stacks are used.
    long ExpireTicksUTC,    // Permanent if -1, referred to as 'NoExpire' in MoodleStatus
    string Applier,         // Who applied the moodle. (Only relevant when updating active moodles)
    string Dispeller,       // When set, only this person can dispel your moodle.
    bool Permanent,         // Referred to as 'Sticky' in the Moodles UI
    System.Guid StatusOnDispell, // What status is applied upon the moodle being right-clicked off.
    bool ReapplyIncStacks,  // If stacks increase on reapplication.
    int StackIncCount       // How many stacks get added on each reapplication.
);

global using MoodlePresetInfo = (System.Guid GUID, System.Collections.Generic.List<System.Guid> Statuses, byte ApplyType, string Title);
