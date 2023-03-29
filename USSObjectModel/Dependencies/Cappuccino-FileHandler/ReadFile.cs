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

// This script contains the ReadFile methods.
// For the ReadFile methods, see [FileHandler > ReadFile.cs]

namespace Cappuccino
{
    namespace Interpreters
    {
        // For anyone who wants to recreate some of the elements here:

        //      Directory Creation Reference - https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/file-system/how-to-create-a-file-or-folder

        //      File Reading & Handling Reference  - https://learn.microsoft.com/en-us/dotnet/api/system.io.file?view=net-7.0
        //                                         - https://learn.microsoft.com/en-us/dotnet/api/system.io.streamreader?view=net-7.0

        /// <summary>
        /// A static class that handles file reading, writing and everything in between.
        /// </summary>
        public static partial class FileHandler
        {
            /// <summary>
            /// Read the file at the provided asset path.
            /// </summary>
            /// <param name="filePath">The asset path of the file relative to the Assets folder. <br></br>
            /// <see langword="Notice:"/> You don't need to explicitly state "Assets/" at the start of the path, this is taken care of already.</param>
            /// <param name="fileData">The text within the file to use.</param>
            /// <param name="fileName">The name of the file, minus the filetype.</param>
            /// <returns></returns>
            public static bool ReadFile(string filePath, out List<string> fileData, out string fileName)
            {
                fileData = new List<string>();
                fileName = default;

                // Prevent a file that's null from being read from.
                if (filePath == null || filePath.Length < 1)
                {
                    Diag.FatalViolation("FilePath is incomplete or expects the FileHandler to read a folder directory.");
                    return false;
                }

                // As the string likely starts with "Assets/" in this case and dir doesn't get suffixed with the forward-slash,
                // we can suffix everything past the Assets keyword to the directory to get a string that is parsable.
                if (filePath.StartsWith("Assets"))
                {
                    filePath = filePath.Substring("Assets".Length);
                }

                // We convert the targeted asset path to a list of "path blocks".
                // The path blocks are strings concatenated onto each other procedurally and tested one by one to see which directories exist and which don't.
                string[] pathBlocks = filePath.Split('/');
                fileName = pathBlocks[pathBlocks.Length - 1];
                fileName = fileName.Substring(0, fileName.IndexOf('.'));

                // The current directory that we're checking to see if it exists.
                string targetDirectory = dir;

                // Iterate through all the directories, starting with the first one specified in the asset path. Try-catch any non-existant directories.
                int i = 0;
                foreach (string block in pathBlocks)
                {
                    i++;
                    targetDirectory = targetDirectory + "/" + block;

                    if (i < pathBlocks.Length - 1)
                    {
                        if (!Directory.Exists(targetDirectory))
                        {
                            Diag.FatalViolation($"Attempted to find a file in a directory that doesn't exist. Attempted Directory Find:\n{targetDirectory}\n");
                            return false;
                        }
                    }
                }

                // If the file doesn't exist, exit out immediately. The file can't be found or read.
                if (!File.Exists(targetDirectory))
                {
                    Diag.FatalViolation("Attempted to find a file that doesn't exist.");
                    return false;
                }

                // Create a StreamReader and output all lines, similarly to how we write lines.
                // Output all lines.
                using (StreamReader filereader = File.OpenText(targetDirectory))
                {
                    string line;

                    while((line = filereader.ReadLine()) != null)
                    {
                        fileData.Add(line);
                    }
                }

                return true;
            }
        }
    }
}