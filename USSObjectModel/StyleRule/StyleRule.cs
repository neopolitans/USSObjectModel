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
                // The class was sealed. It is not *necessary* to be sealed and can be modified.

                /// <summary>
                /// A representation of a style rule that can be applied to a selector.
                /// </summary>
                public sealed class StyleRule
                {
                    public string name;

                    /// <summary>
                    /// The value of this USS Style Rule.
                    /// </summary>
                    public string value;

                    /// <summary>
                    /// The underlying style rule type.
                    /// </summary>
                    public RuleType ruleType;

                    /// <summary>
                    /// [internal] Whether or not the Style Rule is valid.
                    /// </summary>
                    private bool valid;

                    /// <summary>
                    /// Whether or not the Style Rule is valid. <br></br>
                    /// This cannot be externally modified.
                    /// </summary>
                    public bool Valid { get { return valid; } }

                    /// <summary>
                    /// Does this style rule have a value?
                    /// </summary>
                    public bool hasValue => value != null;

                    /// <summary>
                    /// Whether or not this USS Style Rule is a value.
                    /// </summary>
                    public bool isVariable => ruleType == RuleType.Variable;

                    // Constructors

                    /// <summary>
                    /// Create a Style Rule - Name is automatically defined through the rule type.
                    /// </summary>
                    /// <param name="value">The value of the style rule.</param>
                    /// <param name="ruleType">The type of the style rule.</param>
                    public StyleRule(RuleType ruleType, string value)
                    {
                        this.ruleType = ruleType;
                        this.name = RuleTyping.ToRuleName(ruleType);
                        this.value = value;
                        valid = true;
                    }

                    /// <summary>
                    /// Create a Style Rule.
                    /// </summary>
                    /// <param name="name">The name of the style rule.</param>
                    /// <param name="value">The value of the style rule.</param>
                    /// <param name="ruleType">The type of the style rule.</param>
                    public StyleRule(string name, string value, RuleType ruleType)
                    {
                        this.name = name;
                        this.value = value;
                        this.ruleType = ruleType;
                        valid = true;
                    }

                    /// <summary>
                    /// Create a Style Rule - Name is automatically defined through the rule type.
                    /// </summary>
                    /// <param name="value">The value of the style rule.</param>
                    /// <param name="ruleType">The type of the style rule.</param>
                    /// <param name="isValid">Whether or not the style rule has a valid value.</param>
                    public StyleRule(RuleType ruleType, string value, bool isValid)
                    {
                        this.ruleType = ruleType;
                        this.name = RuleTyping.ToRuleName(ruleType);
                        this.value = value;
                        valid = isValid;
                    }

                    /// <summary>
                    /// Create a Style Rule.
                    /// </summary>
                    /// <param name="name">The name of the style rule.</param>
                    /// <param name="value">The value of the style rule.</param>
                    /// <param name="ruleType">The type of the style rule.</param>
                    /// <param name="isValid">Whether or not the style rule has a valid value.</param>
                    public StyleRule(string name, string value, RuleType ruleType, bool isValid)
                    {
                        this.name = name;
                        this.value = value;
                        this.ruleType = ruleType;
                        valid = isValid;
                    }


                    // String Coversions

                    /// <summary>
                    /// Convert the style rule into a style rule that can be read by Unity's USS format.
                    /// </summary>
                    /// <returns><see langword="string"/> - a string that compiled the rule declaration and value as one readable line.</returns>
                    public override string ToString()
                    {
                        // Convert the property type to a string.
                        string str = RuleTyping.ToRuleName(ruleType, name);

                        // Append the underlying property value to the string, suffixed with a semicolon.
                        str = str + ": " + value + ";";

                        return str;
                    }

                    /// <summary>
                    /// Convert the style rule into a style rule that can be read by Unity's USS format.
                    /// </summary>
                    /// <param name="indentation">The amount of indents before the line to add.</param>
                    /// <returns><see langword="string"/> - a string that compiled the rule declaration and value as one readable line.</returns>
                    public string ToString(int indentation)
                    {
                        // Convert the property type to a string.
                        string str = RuleTyping.ToRuleName(ruleType, name);

                        // Append the underlying property value to the string, suffixed with a semicolon.
                        str = str + ": " + value.ToString() + ";";

                        // add indentation.
                        int i = indentation;
                        while (i > 0)
                        {
                            str = " " + str;
                            i--;
                        }

                        return str;
                    }
                }
            }
        }
    }
}