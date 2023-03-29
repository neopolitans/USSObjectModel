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
                /// A base class for any selector under the USS standard.
                /// </summary>
                public abstract class Selector
                {
                    /// <summary>
                    /// The Style Rules that apply to the selector.
                    /// </summary>
                    public List<StyleRule> rules = new List<StyleRule>();

                    /// <summary>
                    /// Whether or not the Selector can contain style rules. Set to <see langword="true"/> by default.<br></br><br></br>
                    /// If the selector is on it's own, it can - otherwise it is a child of another selector then it cannot. <br></br> <i>
                    ///  - A simple selector cannot have rules if it is part of a complex selector. <br></br>
                    ///  - A complex selector cannot have rules if it is part of a selector list. </i>
                    /// </summary>
                    public bool canContainStyleRules = true;

                    /// <summary>
                    /// Whether or not a selector is a containable selector. <br></br>
                    /// As Simple Selectors and Complex selectors are the only containable selector types, this will be false for Pseudoclasses and Selector Lists.
                    /// </summary>
                    public bool isContainable = false;

                    /// <summary>
                    /// Whether or not a selector is a pseudoclass instead of a simple selector, complex selector or selector list.
                    /// </summary>
                    public bool isPseudoclass = false;

                    /// <summary>
                    /// Try Add a Style Rule to this Selector.
                    /// </summary>
                    /// <param name="rule"></param>
                    /// <returns></returns>
                    public bool Add(StyleRule rule)
                    {
                        if (!canContainStyleRules || rules.Contains(rule))
                        {
                            return false;
                        }
                        else
                        {
                            rules.Add(rule);
                            return true;
                        }
                    }

                    /// <summary>
                    /// Try Remove a style rule from this Selector.
                    /// </summary>
                    /// <param name="rule"></param>
                    /// <returns></returns>
                    public bool Remove(StyleRule rule)
                    {
                        if (!canContainStyleRules || !rules.Contains(rule))
                        {
                            return false;
                        }
                        else
                        {
                            rules.Remove(rule);
                            return true;
                        }
                    }

                    /// <summary>
                    /// Remove all properties from this style rule.
                    /// </summary>
                    /// <returns><see langword="boolean"/> - whether or not the operation carried out successfully.</returns>
                    public bool RemoveAll()
                    {
                        if (rules == null || rules.Count <= 0)
                        {
                            Diag.Violation("This USSElement does not contain any properties.");
                            return false;
                        }

                        rules.Clear();
                        return true;
                    }

                    /// <summary>
                    /// Try find a style rule within this pseudoclass.
                    /// </summary>
                    /// <param name="queryName">The name of the style rule to find.</param>
                    /// <param name="rule">The resulting style rule, if one is found.</param>
                    /// <returns>
                    /// <see langword="boolean"/> - whether or not the operation carried out successfully. <br></br>
                    /// <see langword="out StyleRule"/> - the property if the boolean returned true, or null.
                    /// </returns>
                    public bool Find(string queryName, out StyleRule rule)
                    {
                        rule = null;

                        foreach (StyleRule s in rules)
                        {
                            if (s.name == queryName)
                            {
                                rule = s;
                                return true;
                            }
                        }

                        return false;
                    }

                    /// <summary>
                    /// Get the selector definition. Defaults to object.ToString().
                    /// </summary>
                    /// <returns></returns>
                    public virtual string Name() => ToString();

                    /// <summary>
                    /// Translate the Selector into a text format that can be saved to a .uss file.
                    /// </summary>
                    /// <returns></returns>
                    public List<string> Translate()
                    {
                        List<string> text = new List<string>();

                        text.Add(Name() + " {");

                        foreach (StyleRule r in rules)
                        {
                            if (!r.Valid) { continue; } // Skip the current style rule in the iteration. It's been marked as invalid.
                            text.Add(r.ToString(5));
                        }

                        text.Add("}", "");

                        return text;
                    }

                    /// <summary>
                    /// Export the Selector as a Unity Style Sheet to the provided filepath.
                    /// </summary>
                    /// <param name="assetPath">The directory of the file to look for, if it doesn't exist.</param>
                    /// <returns></returns>
                    public bool Export(string sheetName, string assetPath)
                    {
                        bool success = FileHandler.WriteFile(Translate(), sheetName, ".uss", assetPath);
                        if (!success)
                        {
                            Diag.Violation($"{sheetName} failed to be written to file.");
                        }

                        return success;
                    }

                    /// <summary>
                    /// Export the Selector as a Unity Style Sheet to the provided filepath.
                    /// </summary>
                    /// <param name="assetPath">The directory of the file to look for, if it doesn't exist.</param>
                    /// <param name="overwriteExistingFile">Whether or not to overwrite the file if it exists.</param>
                    public bool Export(string sheetName, string assetPath, bool overwriteExistingFile)
                    {
                        bool success = FileHandler.WriteFile(Translate(), sheetName, ".uss", assetPath, overwriteExistingFile);
                        if (!success)
                        {
                            Diag.Violation($"{sheetName} failed to be written to file.");
                        }
                        return success;
                    }
                }
            }
        }
    }
}