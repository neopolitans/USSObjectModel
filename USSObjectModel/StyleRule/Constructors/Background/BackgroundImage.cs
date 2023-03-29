using Cappuccino.Core;

namespace Cappuccino
{
    namespace Interpreters
    {
        namespace Languages
        {
            namespace USS
            {
                /// <summary>
                /// This class defines any and every supported style rule constructor currently known.
                /// </summary>
                public static partial class Rules
                {
                    /// <summary>
                    /// Create a Background-Image Style Rule with no value (uses the 'none' keyword).
                    /// </summary>
                    public static StyleRule BackgroundImage()
                    {
                        return new StyleRule(RuleType.backgroundImage, "none");
                    }

                    /// <summary>
                    /// Create a Background-Image Style Rule with a url() USS function.
                    /// </summary>
                    public static StyleRule BackgroundImage(URLAsset urlAsset)
                    {
                        return new StyleRule(RuleType.backgroundImage, urlAsset.value);
                    }

                    /// <summary>
                    /// Create a Background-Image Style Rule with a resource() USS function value.
                    /// </summary>
                    public static StyleRule BackgroundImage(ResourceAsset resourceAsset)
                    {
                        return new StyleRule(RuleType.backgroundImage, resourceAsset.value);
                    }
                }
            }
        }
    }
}