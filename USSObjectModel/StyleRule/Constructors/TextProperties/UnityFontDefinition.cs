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
                    /// Create a Unity Font Definition Style Rule with a Resource USS Function value. <br></br><br></br>
                    /// <see langword="Cappuccino:"/> Not to be confused with UnityFont(aka -unity-font) style rule.
                    /// </summary>
                    /// <param name="resource">The ResourceAsset USS function to use.</param>
                    /// <returns></returns>
                    public static StyleRule UnityFontDefinition(ResourceAsset resource)
                    {
                        return new StyleRule(RuleType.unityFontDefinition, resource.value);
                    }

                    /// <summary>
                    /// Create a Unity Font Definition Style Rule with a URL USS Function value. <br></br><br></br>
                    /// <see langword="Cappuccino:"/> Not to be confused with UnityFont (aka -unity-font) style rule.
                    /// </summary>
                    /// <param name="url">The URL Asset USS function to use.</param>
                    /// <returns></returns>
                    public static StyleRule UnityFontDefinition(URLAsset url)
                    {
                        return new StyleRule(RuleType.unityFontDefinition, url.value);
                    }
                }
            }
        }
    }
}