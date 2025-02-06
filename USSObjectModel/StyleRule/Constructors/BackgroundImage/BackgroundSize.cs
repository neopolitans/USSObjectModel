#if UNITY_2022_2_OR_NEWER
using Cappuccino.Core;
using UnityEngine.UIElements;

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
                    /// An Enum representation of all the keywords that the background-size style rule's value can be assigned.
                    /// </summary>
                    public enum BackgroundSizeValue
                    {
                        cover,
                        contain
                    }

                    /// <summary>
                    /// Convert the provided BackgroundSizeValue enum value to it's string representation in USS. <br></br>
                    /// Defaults to "contain" if an invalid value is prvoided. <br></br><br></br>
                    /// <see langword="MDN CSS:"/> <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/background-size">background-size</see> places contain over cover in the order and uses contain in the demonstration. This is assumed as the default behaviour.
                    /// </summary>
                    /// <param name="value">The keyword to convert to a string.</param>
                    public static string Name(this BackgroundSizeValue value)
                    {
                        return value switch
                        {
                            BackgroundSizeValue.cover => "cover",
                            BackgroundSizeValue.contain => "contain",
                            _ => "contain"
                        };
                    }

                    /// <summary>
                    /// Convert the provided string into a BackgroundSizeValue enum value. <br></br>
                    /// Defaults to [BackgroundSizeValue.contain] if an invalid value is provided.<br></br><br></br>
                    /// <see langword="MDN CSS:"/> <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/background-size">background-size</see> places contain over cover in the order and uses contain in the demonstration. This is assumed as the default behaviour.
                    /// </summary>
                    /// <param name="valueAsName">The string value to convert.</param>
                    public static BackgroundSizeValue ToBackgroundSizeValue(string valueAsName)
                    {
                        return valueAsName switch
                        {
                            "cover" => BackgroundSizeValue.cover,
                            "contain" => BackgroundSizeValue.contain,
                            _ => BackgroundSizeValue.contain
                        };
                    }

                    /// <summary>
                    /// An object representing image size parameters for each image when there are multiple present. <br></br><br></br>
                    /// <see langword="Cappuccino:"/> This object is exclusively used for background-size, for dealing with multiple images. <br></br> 
                    /// It shares all the same constructors as background-size does, minus the params <see cref="ImageSize"/>[] variant.
                    /// </summary>
                    public class ImageSize
                    {
                        public string value;

                        /// <summary>
                        /// Create an ImageSize object with a keyword value.
                        /// </summary>
                        /// <param name="keyword">The USS keyword that will be applied to a background-size style rule.</param>
                        public ImageSize(BackgroundSizeValue keyword)
                        {
                            value = keyword.Name();
                        }

                        /// <summary>
                        /// Create an ImageSize object with a length value. <br></br><br></br>
                        /// <see langword="MDN CSS:"/> When one length value is provided, it will determine the width of the image. 
                        /// </summary>
                        /// <param name="width">The width of the image. Can be defined or auto.</param>
                        public ImageSize(Length width)
                        {
                            value = width.ToString();
                        }

                        /// <summary>
                        /// Create an ImageSize object with two length values. <br></br><br></br>
                        /// <see langword="MDN CSS:"/> When two length values are provided, the first value will determine the width of the image and the second will determine the height.
                        /// </summary>
                        /// <param name="width">The width of the image. Can be defined or auto.</param>
                        /// <param name="height">The height of the image. Can be defined or auto.</param>
                        public ImageSize(Length width, Length height)
                        {
                            value = $"{width} {height}";
                        }
                    }

                    /// <summary>
                    /// Create a Background-Size Style Rule with a keyword value.
                    /// </summary>
                    /// <param name="keyword">The USS keyword to be applied to Background Size. Restricted to only the compatible keywords.</param>
                    public static StyleRule BackgroundSize(BackgroundSizeValue keyword)
                    {
                        return new StyleRule(RuleType.backgroundSize, keyword.Name());
                    }

                    /// <summary>
                    /// Create a Background-Size Style Rule with a length value. <br></br><br></br>
                    /// <see langword="MDN CSS:"/> When one length value is provided, it will determine the width of the image. 
                    /// </summary>
                    /// <param name="width">The width of the image. Can be defined or auto.</param>
                    public static StyleRule BackgroundSize(Length width)
                    {   
                        return new StyleRule(RuleType.backgroundSize, width.ToString());
                    }

                    /// <summary>
                    /// Create a Background-Size Style Rule with two length values. <br></br><br></br>
                    /// <see langword="MDN CSS:"/> When two length values are provided, the first value will determine the width of the image and the second will determine the height.
                    /// </summary>
                    /// <param name="width">The width of the image. Can be defined or auto.</param>
                    /// <param name="height">The height of the image. Can be defined or auto.</param>
                    public static StyleRule BackgroundSize(Length width, Length height)
                    {
                        return new StyleRule(RuleType.backgroundSize, $"{width} {height}");
                    }

                    /// <summary>
                    /// Create a Background-Size Style Rule with one or more ImageSize objects. <br></br><br></br>
                    /// <see langword="Cappuccino:"/> An ImageSize object represents the construction of a background-size style rule with a keyword, length for width and/or length for value. <br></br>
                    /// Each string value of an ImageSize object is separated with a comma to affect multiple background images at once.
                    /// </summary>
                    /// <param name="allImageSizes">The ImageSize objects to concatenate into one style rule.</param>
                    /// <returns></returns>
                    public static StyleRule BackgroundSize(params ImageSize[] allImageSizes)
                    {
                        if (allImageSizes.Length > 0)
                        {
                            string value = "";
                            int i = 0;

                            foreach (ImageSize size in allImageSizes)
                            {
                                i++;
                                value = value + (i < allImageSizes.Length - 1 ? size.value + ", " : size.value);
                            }

                            return new StyleRule(RuleType.backgroundSize, value);
                        }
                        else
                        {
                            Diag.Violation("There are no ImageSize objects for this background-size rule. No style rule created.");
                            return null;
                        }
                    }
                }
            }
        }
    }
}
#endif