using System.IO;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

using UnityEditor;
using UnityEditor.UIElements;

using Cappuccino.Core;

// A File Read/Write system for any C#<->Lang interpreter.
//          !! Used by the Iroquois Interpreters.
//          !! Core component of Cappuccino

// This script contains the WriteFile methods.
// For the ReadFile methods, see [FileHandler > ReadFile.cs]

namespace Cappuccino
{
    namespace Interpreters
    {
        // For anyone who wants to recreate some of the elements here:

        //      Directory Creation Reference - https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/file-system/how-to-create-a-file-or-folder

        //      File Creation & Handling Reference - https://learn.microsoft.com/en-us/dotnet/api/system.io.file?view=net-7.0
        //                                         - https://learn.microsoft.com/en-us/dotnet/api/system.io.file.createtext?view=net-7.0#system-io-file-createtext(system-string)


        /// <summary>
        /// A static class that handles file reading, writing and everything in between.
        /// </summary>
        public static partial class FileHandler
        {
            /// <summary>
            /// <see langword="Cappuccino:"> The full Project Directory (when accessed through UnityEngine's Editor). <br></br>
            /// <see langword="Unity:"/> Redirects to Application.dataPath.
            /// </summary>
            public static string dir = Application.dataPath;

            /// <summary>
            /// Write the provided formatted file data to a file with the provided file extension. <br></br>
            /// The resulting file will be saved at: .../Assets/assetPath.
            /// </summary>
            /// <param name="formattedFileData">The data to write to a file with.</param>
            /// <param name="fileName">The name of the file to create, if it doesn't exist.</param>
            /// <param name="fileExtension">The file's extension.</param>
            /// <param name="assetPath">The directory of the file to look for, if it doesn't exist.</param>
            /// <returns></returns>
            public static bool WriteFile(in List<string> formattedFileData, string fileName, string fileExtension, string assetPath)
            {
                // Prevent null formatted file data from being used.
                if (formattedFileData == null || formattedFileData.Count < 1)
                {
                    Diag.Violation("There are no lines to write to the file. File Write cancelled prematurely.");
                    return false;
                }

                // Filter out any empty spaces (if possible) to avoid a blank file.
                if (fileName.Replace(" ", "").Length < 1)
                {
                    Diag.Violation("There is no file name provided. You cannot write files with blank names. File Write cancelled prematurely.");
                    return false;
                }

                // Prevent processing time from being wasted if the file extension isn't started with ".".
                if (!fileExtension.StartsWith('.'))
                {
                    Diag.Violation("The file format you have specified is not valid as it doesn't start with '.'. File Write cancelled prematurely.");
                    return false;
                }

                bool isAssetPathNull = false;

                // Warn the developer of the issues of writing directly into the assets folder.
                if (assetPath == null || assetPath.Replace(" ", "").Length < 1)
                {
                    Diag.Violation("The file is set to be created in the Assets folder. This is not advised.");
                    isAssetPathNull = true;
                }

                // We convert the targeted asset path to a list of "path blocks".
                // The path blocks are strings concatenated onto each other procedurally and tested one by one to see which directories exist and which don't.
                string[] pathBlocks = assetPath.Split('/');

                // The current directory that we're checking to see if it exists.
                string targetDirectory = dir;

                // If there is an assetpath, parse all directories.
                if (!isAssetPathNull)
                {
                    // Iterate through all the directories, starting with the first one specified in the asset path.
                    // Try-catch any non-existant directories and create them.
                    foreach (string block in pathBlocks)
                    {
                        // Assemble the current directory we're now testing from the path blocks.
                        targetDirectory = targetDirectory + "/" + block;

                        // If the directory didn't exist - create it.
                        // Notify the developer of their error with a warning.
                        if (!Directory.Exists(targetDirectory))
                        {
                            Diag.Violation("Attempted to specify a directory that didn't exist. This violation has been caught the directory has been created.");
                            Directory.CreateDirectory(targetDirectory);
                        }

                        // Exists test - Debug.Log(currentDirectoryToTest + " exists?\n" + Directory.Exists(currentDirectoryToTest));
                    }
                }

                // Assemble the final directory for the file name.
                targetDirectory = targetDirectory + "/" + fileName + fileExtension;

                // Check if the file currently exists.
                //  -   If the file doesn't currently exist, proceed to creating (and writing) the file.
                //  -   Otherwise, abort early. This method variation has overwrite-protection measures.
                if (!File.Exists(targetDirectory))
                {
                    // Write all lines to a new file at the specified directory.
                    //  - Found out about this C# ability for the using keyword.
                    //  - See File.CreateText() and File class reference docs at the top.
                    using (StreamWriter filewriter = File.CreateText(targetDirectory))
                    {
                        foreach (string line in formattedFileData)
                        {
                            filewriter.WriteLine(line);
                        }
                    }
                }
                else
                {
                    Diag.Violation("This variation of the method WriteFile does not overwrite files. To turn off overwrite protection, suffix a true value after assetPath.");
                    return false;
                }

                return true;
            }

            /// <summary>
            /// Write the provided formatted file data to a file with the provided file extension. <br></br>
            /// The resulting file will be saved at: .../Assets/assetPath.
            /// </summary>
            /// <param name="formattedFileData">The data to write to a file with.</param>
            /// <param name="fileName">The name of the file to create, if it doesn't exist.</param>
            /// <param name="fileExtension">The file's extension.</param>
            /// <param name="assetPath">The directory of the file to look for, if it doesn't exist.</param>
            /// <param name="disableOverwriteProtection">Whether or not writing to an existing file is disabled.</param>
            /// <returns></returns>
            public static bool WriteFile(in List<string> formattedFileData, string fileName, string fileExtension, string assetPath, bool disableOverwriteProtection)
            {
                // Prevent null formatted file data from being used.
                if (formattedFileData == null || formattedFileData.Count < 1)
                {
                    Diag.Violation("There are no lines to write to the file. File Write cancelled prematurely.");
                    return false;
                }

                // Filter out any empty spaces (if possible) to avoid a blank file.
                if (fileName.Replace(" ", "").Length < 1)
                {
                    Diag.Violation("There is no file name provided. You cannot write files with blank names. File Write cancelled prematurely.");
                    return false;
                }

                // Prevent processing time from being wasted if the file extension isn't started with ".".
                if (!fileExtension.StartsWith('.'))
                {
                    Diag.Violation("The file format you have specified is not valid as it doesn't start with '.'. File Write cancelled prematurely.");
                    return false;
                }

                bool isAssetPathNull = false;

                // Warn the developer of the issues of writing directly into the assets folder.
                if (assetPath == null || assetPath.Replace(" ", "").Length < 1)
                {
                    Diag.Violation("The file is set to be created in the Assets folder. This is not advised.");
                    isAssetPathNull = true;
                }

                // We convert the targeted asset path to a list of "path blocks".
                // The path blocks are strings concatenated onto each other procedurally and tested one by one to see which directories exist and which don't.
                string[] pathBlocks = assetPath.Split('/');

                // The current directory that we're checking to see if it exists.
                string targetDirectory = dir;

                // If there is an assetpath, parse all directories.
                if (!isAssetPathNull)
                {
                    // Iterate through all the directories, starting with the first one specified in the asset path.
                    // Try-catch any non-existant directories and create them.
                    foreach (string block in pathBlocks)
                    {
                        // Assemble the current directory we're now testing from the path blocks.
                        targetDirectory = targetDirectory + "/" + block;

                        // If the directory didn't exist - create it.
                        // Notify the developer of their error with a warning.
                        if (!Directory.Exists(targetDirectory))
                        {
                            Diag.Violation("Attempted to specify a directory that didn't exist. This violation has been caught the directory has been created.");
                            Directory.CreateDirectory(targetDirectory);
                        }

                        // Exists test - Debug.Log(currentDirectoryToTest + " exists?\n" + Directory.Exists(currentDirectoryToTest));
                    }
                }

                // Assemble the final directory for the file name.
                targetDirectory = targetDirectory + "/" + fileName + fileExtension;

                // Check if the file currently exists.
                //  -   If the file doesn't currently exist, proceed to creating (and writing) the file.
                //  -   Otherwise, abort early. This method variation has overwrite-protection measures.
                if (!File.Exists(targetDirectory))
                {
                    // Write all lines to a new file at the specified directory.
                    //  - Found out about this C# ability for the using keyword.
                    //  - See File.CreateText() and File class reference docs at the top.
                    using (StreamWriter filewriter = File.CreateText(targetDirectory))
                    {
                        foreach (string line in formattedFileData)
                        {
                            filewriter.WriteLine(line);
                        }
                    }
                }
                else
                {
                    if (!disableOverwriteProtection)
                    {
                        Diag.Violation("DisableOverwriteProtection is still enabled. To turn it off, set the last parameter (a boolean) to true.");
                        return false;
                    }
                    else
                    {
                        // Overwrite the file at the directory and write all lines to it.
                        using (StreamWriter filewriter = File.CreateText(targetDirectory))
                        {
                            foreach (string line in formattedFileData)
                            {
                                filewriter.WriteLine(line);
                            }
                        }
                    }
                }

                return true;
            }
        }
    }
}   