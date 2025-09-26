namespace SundouleiaAPI.Hub;

/// <summary>
///     All Error Codes for SundouleiaAPI calls.
/// </summary>
public enum SundouleiaApiEc
{
    /// <summary> Indicates a successful interaction. </summary>
    Success = 0,

    /// <summary> Network Connection not established or was terminated. </summary>
    NetworkError = 1,

    /// <summary> The passed in object was not the desired datatype. </summary>
    IncorrectDataType = 2,

    /// <summary> The passed in data was null or invalid. </summary>
    NullData = 3,

    /// <summary> The Recipient was not who it should be. </summary>
    InvalidRecipient = 4,

    /// <summary> Blocked by sender or recipient. </summary>
    RecipientBlocked = 5,

    /// <summary> The Method is not yet fully implemented. </summary>
    NotYetImplemented = 6,

    /// <summary> Attempted to interact with self, but the method is for interaction with others </summary>
    CannotInteractWithSelf = 7,

    /// <summary> Tried to interact with another using a method intended for self-use only. </summary>
    CanOnlyInteractWithSelf = 8,

    /// <summary> Tried to use a feature that your account reputation prevents access to. </summary>
    RestrictedByReputation = 9,

    // ----- Client Vanity Specific Errors -----

    /// <summary> The provided image file is not in PNG format. </summary>
    InvalidImageFormat,

    /// <summary> The provided image file is larger than 256x256. </summary>
    InvalidImageSize,

    /// <summary> Reporting someone you already have an active report on. </summary>
    AlreadyReported,

    /// <summary> The reported user does not even have a profile yet. </summary>
    ProfileNotFound,


    // ----- Interaction Specific Errors -----

    /// <summary> Cant send Request to someone already paired. </summary>
    AlreadyPaired,

    /// <summary> A Request for the recipient was already made by the sender. </summary>
    RequestExists,

    /// <summary> Cannot cancel a request that no longer exists. </summary>
    RequestNotFound,

    /// <summary> Not paired with the intended recipient. </summary>
    NotPaired,

    /// <summary> The incorrect updateKind was used for the call made. </summary>
    BadUpdateKind,

    // ------ Radar Specific Errors -----
    NotInZone,
}
