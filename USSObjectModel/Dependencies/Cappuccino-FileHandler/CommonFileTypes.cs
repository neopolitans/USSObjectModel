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

// This script contains some common file-type writing methods so that you don't have to mess around with the file handler.
namespace Cappuccino
{
    namespace Interpreters
    {
        /// <summary>
        /// A static class that handles file reading, writing and everything in between.
        /// </summary>
        public static partial class FileHandler
        {
            /// <summary>
            /// Export the file data as a text file to the provided filepath.
            /// </summary>
            /// <param name="fileData">The file data (as a list of strings) to write to a file.</param>
            /// <param name="fileName">The name of the file itself.</param>
            /// <param name="assetPath">The directory of the file to look for, if it doesn't exist.</param>
            public static bool ToText(List<string> fileData, string fileName, string assetPath)
            {
                return WriteFile(fileData, fileName, ".txt", assetPath, false);
            }

            /// <summary>
            /// Export the file data as a text file to the provided filepath.
            /// </summary>
            /// <param name="fileData">The file data (as a list of strings) to write to a file.</param>
            /// <param name="fileName">The name of the file itself.</param>
            /// <param name="assetPath">The directory of the file to look for, if it doesn't exist.</param>
            /// <param name="overwriteExistingFile">Whether or not to overwrite the file if it exists.</param>
            public static bool ToText(List<string> fileData, string fileName, string assetPath, bool overwriteExistingFile)
            {
                return WriteFile(fileData, fileName, ".txt", assetPath, overwriteExistingFile);
            }
        }
    }
}