global using System;
global using System.Threading.Tasks;
global using System.Collections.Generic;

// Used for Tuple-Based IPC calls and associated data transfers.
global using LociStatusInfoOLD = (
    System.Guid GUID,
    int IconID,
    string Title,
    string Description,
    byte Type,                      // loci StatusType enum, as a byte.
    string CustomVFXPath,           // What VFX to show on application.
    int Stacks,                     // Usually 1 when no stacks are used.
    long ExpireTicksUTC,            // Permanent if -1, referred to as 'NoExpire'
    string Applier,                 // Who applied the loci status. (Only relevant when updating active statuses)
    bool Dispelable,                // Can be dispelled by others.
    string Dispeller,               // When set, only this person can dispel your status.
    bool Permanent,                 // Referred to as 'Sticky' (Legacy)
    System.Guid StatusOnDispell,    // What new status is applied upon the this statuses expiration.
    bool ReapplyIncStacks,          // If stacks increase on reapplication.
    int StackIncCount,              // How many stacks get added on each reapplication.
    bool UseStacksOnDispelStatus    // If dispelling transfers stacks to the dispel-applied status.
);

global using LociStatusInfo = (
    int Version,
    System.Guid GUID,
    int IconID,
    string Title,
    string Description,
    string CustomVFXPath,       // What VFX to show on application.
    long ExpireTicks,           // Permanent if -1, referred to as 'NoExpire'
    SundouleiaAPI.StatusType Type, // Loci StatusType enum.
    int Stacks,                 // Usually 1 when no stacks are used.
    int StackSteps,             // How many stacks to add per reapplication.
    uint Modifiers,             // What can be customized, casted to uint from Modifiers (Dalamud IPC Rules)
    System.Guid ChainedStatus,  // What status is chained to this one.
    SundouleiaAPI.ChainTrigger ChainTrigger, // What triggers the chained status.
    string Applier,             // Who applied the status.
    string Dispeller,           // When set, only this person can dispel your loci status.
    bool Permanent              // Referred to as 'Sticky' (Legacy)
);

global using LociPresetInfo = (
    System.Guid GUID,
    System.Collections.Generic.List<System.Guid> Statuses,
    byte ApplicationType,
    string Title,
    string Description
);
