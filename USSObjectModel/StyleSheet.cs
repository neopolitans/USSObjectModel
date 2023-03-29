using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

using UnityEditor;
using UnityEditor.UIElements;

using Cappuccino.Core;
using System.Linq;

namespace Cappuccino
{
    namespace Interpreters
    {
        namespace Languages
        {
            namespace USS
            {
                /// <summary>
                /// A representation of a Unity Style Sheet as an object.
                /// </summary>
                public class StyleSheet
                {
                    /// <summary>
                    /// The name of the style sehet;
                    /// </summary>
                    public string name;

                    /// <summary>
                    /// The selectors contained within this Unity Style Sheet.
                    /// </summary>
                    List<Selector> selectors = new List<Selector>();

                    /// <summary>
                    /// The file path of the imported style sheet, if it was imported.
                    /// </summary>
                    public readonly string filePath;

                    /// <summary>
                    /// Is the UnityStyleSheet directly imported from a .uss file?
                    /// </summary>
                    public bool isImported => filePath != null && filePath.Length > 0;

                    // Constructors
                    /// <summary>
                    /// Create a style sheet with no selectors.
                    /// </summary>
                    /// <param name="sheetName">The name of the style sheet that will be used on export.</param>
                    public StyleSheet(string sheetName)
                    {
                        name = sheetName;
                    }

                    /// <summary>
                    /// Create a style sheet containing the provided selectors.
                    /// </summary>
                    /// <param name="sheetName">The name of the style sheet that will be used on export.</param>
                    /// <param name="selectors">The selectors that will be placed into the style sheet.</param>
                    public StyleSheet(string sheetName, params Selector[] selectors)
                    {
                        name = sheetName;

                        foreach (Selector s in selectors)
                        {
                            // Skip any loose pseudoclasses.
                            if (s.isPseudoclass) { continue; }
                            this.selectors.Add(s);
                        }
                    }

                    /// <summary>
                    /// Add a selector to the Style Sheet. <br></br>
                    /// <see langword="Notice:"/> Pseudo-classes cannot be added.
                    /// </summary>
                    /// <param name="selector">The USS Selector to add to the style sheet.</param>
                    /// <returns><see langword="boolean"/> - true if successful, false otherwise.</returns>
                    public bool Add(Selector selector)
                    {
                        if (selector == null || selector.isPseudoclass || selectors.Contains(selector)) { return false; }
                        else
                        {
                            selectors.Add(selector);
                            return true;
                        }
                    }

                    /// <summary>
                    /// Remove a selector from the Style Sheet.
                    /// </summary>
                    /// <param name="selector">The USS Selector to add to the style sheet.</param>
                    /// <returns><see langword="boolean"/> - true if successful, false otherwise.</returns>
                    public bool Remove(Selector selector)
                    {
                        if (selector == null || !selectors.Contains(selector)) { return false; }
                        else
                        {
                            selectors.Remove(selector);
                            return true;
                        }
                    }

                    /// <summary>
                    /// Translate the style sheet into an exportable .uss format.
                    /// </summary>
                    /// <returns></returns>
                    public List<string> Translate()
                    {
                        List<string> text = new List<string>();

                        foreach (Selector s in selectors)
                        {
                            List<string> translation = s.Translate();

                            if (translation != null && translation.Count > 0)
                            {
                                foreach (string str in translation)
                                {
                                    text.Add(str);
                                }
                            }
                        }

                        return text;
                    }

                    /// <summary>
                    /// Export the Style Sheet to the provided filepath.
                    /// </summary>
                    /// <param name="assetPath">The directory of the file to look for, if it doesn't exist.</param>
                    /// <returns></returns>
                    public bool Export(string assetPath)
                    {
                        bool success = FileHandler.WriteFile(Translate(), name, ".uss", assetPath);
                        if (!success)
                        {
                            Diag.Violation($"{name} failed to be written to file.");
                        }

                        return success;
                    }

                    /// <summary>
                    /// Export the Style Sheet to the provided filepath.
                    /// </summary>
                    /// <param name="assetPath">The directory of the file to look for, if it doesn't exist.</param>
                    /// <param name="overwriteExistingFile">Whether or not to overwrite the file if it exists.</param>
                    public bool Export(string assetPath, bool overwriteExistingFile)
                    {
                        bool success = FileHandler.WriteFile(Translate(), name, ".uss", assetPath, overwriteExistingFile);
                        if (!success)
                        {
                            Diag.Violation($"{name} failed to be written to file.");
                        }
                        return success;
                    }

                }
            }
        }
    }
}