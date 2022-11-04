/*
 * Notice:
 * This script was prepared by Chase Interactive Visuals, LLC, 
 * and is provided to FGCU for educational purposes only!
 * 
 * Class Summary:
 * Logging Manager to manage all log entries. 
 * 
 * As a static class, this does not need to have an active innstance in the unity scene to reference.
 */

using UnityEngine;

public static class LoggingManager
{
    // Controls if the DebuggingManager is active
    public static bool _debuggingOn = true;
    public static void LogToConsole(string log)
    {
        if (_debuggingOn)
        {
            Debug.Log(log);
        }
    }

    //This class is heavily extendable. 
}
