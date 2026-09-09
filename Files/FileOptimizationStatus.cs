namespace SundouleiaAPI.Files;

public enum FileOptimizationStatus
{
    /// <summary>
    ///   This file will never have a compressed state.
    /// </summary>
    NotCompressible = 0,

    /// <summary>
    ///   The compressed file is not present on the server, 
    ///   but is being processed and can retroactively check.
    /// </summary>
    /// <remarks>
    ///   If 425 is returned, the compression is not finished. <br/>
    ///   If 404 is returned, compression is no longer available.
    /// </remarks>
    Compressing = 1,

    /// <summary>
    ///   The compressed file can be downloaded from CompressedLink.
    /// </summary>
    Compressed = 2,
}