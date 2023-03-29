// Angle.cs adds the Angle data type and the AngleUnit value.

namespace Cappuccino
{
    namespace Interpreters
    {
        namespace Languages
        {
            namespace USS
            {
                /// <summary>
                /// An Enum representation of all the unit types that an angle value supports.
                /// </summary>
                public enum AngleUnit
                {
                    /// <summary>
                    /// <see langword="MDN CSS:"/> Represents an angle in degrees. <br></br>
                    /// <i>One full rotation in degrees is {<b>360deg</b>}</i>.
                    /// </summary>
                    deg,

                    /// <summary>
                    /// <see langword="MDN CSS:"/> Represents an angle in <see href="https://en.wikipedia.org/wiki/Gradian">gradians</see>. <br></br>
                    /// <i>One full rotation in gradians is {<b>400grad</b>}</i>.
                    /// </summary>
                    grad,

                    /// <summary>
                    /// <see langword="MDN CSS:"/> Represents an angle in radians. <br></br>
                    /// <i>One full rotation in radians is {<b>2?rad</b>}</i>.
                    /// </summary>
                    rad,

                    /// <summary>
                    /// <see langword="MDN CSS:"/> Represents an angle in a number of turns. <br></br>
                    /// <i>One full rotation in a number of turns is {<b>1turn</b>}</i>.
                    /// </summary>
                    turn
                }   

                // The AngleUnit.Name and ToAngleUnit values are contained here, expressly because other enum behaviours and extensions are expressed here.
                /// <summary>
                /// This class defines any and every supported style rule constructor currently known.
                /// </summary>
                public static partial class Rules
                {
                    /// <summary>
                    /// Convert the provided AngleUnit enum value to it's string representation in USS. <br></br>
                    /// Defaults to "deg" if an invalid value is prvoided.
                    /// </summary>
                    /// <param name="value">The keyword to convert to a string.</param>
                    public static string Name(this AngleUnit value)
                    {
                        return value switch
                        {
                            AngleUnit.deg => "deg",
                            AngleUnit.grad => "grad",
                            AngleUnit.rad => "rad",
                            AngleUnit.turn => "turn",
                            _ => "deg"
                        };
                    }
                    /// <summary>
                    /// Convert the provided string into a AngleUnit enum value. <br></br>
                    /// Defaults to [AngleUnit.deg] if an invalid value is provided.
                    /// </summary>
                    /// <param name="valueAsName">The string value to convert.</param>
                    public static AngleUnit ToAngleUnit(string valueAsName)
                    {
                        return valueAsName switch
                        {
                            "deg" => AngleUnit.deg,
                            "grad" => AngleUnit.grad,
                            "rad" => AngleUnit.rad,
                            "turn" => AngleUnit.turn,
                            _ => AngleUnit.deg
                        };
                    }
                }

                /// <summary>
                /// A representation of an angle value for a USS style rule. <br></br>
                /// Can be in degrees, gradians, radians or turns.
                /// </summary>
                public class Angle 
                {
                    public string value;

                    /// <summary>
                    /// Create an Angle value
                    /// </summary>
                    /// <param name="unit">The unit type for the angle value.</param>
                    /// <param name="integer">The integer literal value for the angle.</param>
                    public Angle(AngleUnit unit, int integer)
                    {
                        value = integer.ToString() + unit.Name();
                    }

                    /// <summary>
                    /// Create an Angle value
                    /// </summary>
                    /// <param name="unit">The unit type for the angle value.</param>
                    /// <param name="floating">The floating point value for the angle.</param>
                    public Angle(AngleUnit unit, float floating)
                    {
                        value = floating.ToString() + unit.Name();
                    }

                    public override string ToString() => value;
                }
            }
        }
    }
}