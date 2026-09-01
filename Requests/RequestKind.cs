namespace SundouleiaAPI.Requests;

public enum RequestKind
{
    /// <summary>
    ///   Transfers a sanction from the request sender to the reciever. <br/>
    ///   Can only be accepted on the player it was meant for.
    /// </summary>
    Transfer = 0,

    /// <summary>
    ///   Swaps the ownership of a sanction between the request sender and reciever. <br/>
    ///   Both must own a sanction for this to work correctly.
    /// </summary>
    ExchangeOwnership,
}