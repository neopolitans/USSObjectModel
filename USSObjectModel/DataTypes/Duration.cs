namespace Cappuccino
{
    namespace Interpreters
    {
        namespace Languages
        {
            namespace USS
            {
                /// <summary>
                /// A representation of a <b>time duration</b> value for a USS style rule. <br></br><br></br> 
                /// CSS data type: <i>&lt;time&gt;</i> <br></br> 
                /// Changed to prevent conflicts with <see cref="UnityEngine.Time"/>.
                /// </summary>
                public class Duration
                {
                    public float value;
                    public readonly bool isMilliseconds;

                    /// <summary>
                    /// Create a time duration value for a USS style rule. <br></br>
                    /// </summary>
                    /// <param name="value">The duration of time, in seconds.</param>
                    public Duration(float value)
                    {
                        this.value = value;
                    }

                    /// <summary>
                    /// Create a time duration value for a USS style rule. <br></br>
                    /// </summary>
                    /// <param name="value">The duration of time, in seconds or milliseconds.</param>
                    /// <param name="isMilliseconds">Whether or not the time is in milliseconds.</param>
                    public Duration(float value, bool isMilliseconds)
                    {
                        this.value = value;
                        this.isMilliseconds = isMilliseconds;
                    }

                    /// <summary>
                    /// Create a time duration value for a USS style rule. <br></br>
                    /// </summary>
                    /// <param name="value">The duration of time, in seconds.</param>
                    public Duration(int value)
                    {
                        this.value = value;
                    }

                    /// <summary>
                    /// Create a time duration value for a USS style rule. <br></br>
                    /// </summary>
                    /// <param name="value">The duration of time, in seconds or milliseconds.</param>
                    /// <param name="isMilliseconds">Whether or not the time is in milliseconds.</param>
                    public Duration(int value, bool isMilliseconds)
                    {
                        this.value = value;
                        this.isMilliseconds = isMilliseconds;
                    }

                    /// <summary>
                    /// Convert the Duration value to a Milliseconds value. <br></br>
                    /// If the value is a seconds value, it is multiplied by 1000. (source: <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/time">MDN CSS: &lt;time&gt;</see>)
                    /// </summary>
                    public float ToMS()
                    {
                        return (isMilliseconds ? value : value * 1000f);
                    }

                    /// <summary>
                    /// Convert the Duration value to a Seconds value. <br></br>
                    /// If the value is a milliseconds value, it is divided by 1000. (source: <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/time">MDN CSS: &lt;time&gt;</see>)
                    /// </summary>
                    public float ToS()
                    {
                        return (!isMilliseconds ? value : value / 1000f); 
                    }

                    /// <summary>
                    /// Convert the Duration value to a string for a style rule.
                    /// </summary>
                    public override string ToString()
                    {
                        return value.ToString() + (isMilliseconds ? "ms" : "s");
                    }
                }
            }
        }
    }
}