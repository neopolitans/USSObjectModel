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
                    /// An enum representation of all the animatable USS Properties that transition-property and transition can take. <br></br>
                    /// For the <i>full list</i> of USS Properties, see <see cref="RuleType">Rule Types</see>.
                    /// </summary>
                    public enum AnimatableProperty
                    {
                        /// <summary>
                        /// The USSProperty will be translated as [align-content]. <br></br>
                        /// <i>Animatability: Discrete.</i>
                        /// </summary>
                        alignContent,

                        /// <summary>
                        /// The USSProperty will be translated as [align-items]. <br></br>
                        /// <i>Animatability: Discrete.</i>
                        /// </summary>
                        alignItems,

                        /// <summary>
                        /// The USSProperty will be translated as [align-self]. <br></br>
                        /// <i>Animatability: Discrete.</i>
                        /// </summary>
                        alignSelf,

                        /// <summary>
                        /// The USSProperty will be translated as [all]. <br></br>
                        /// <i>Animatability: Fully Animatable.</i>
                        /// </summary>
                        all,

                        /// <summary>
                        /// The USSProperty will be translated as [background-color]. <br></br>
                        /// <i>Animatability: Fully Animatable.</i>
                        /// </summary>
                        backgroundColor,

                        /// <summary>
                        /// The USSProperty will be translated as [background-image]. <br></br>
                        /// <i>Animatability: Discrete.</i>
                        /// </summary>
                        backgroundImage,

                        #if UNITY_2022_2_OR_NEWER
                        /// <summary>
                        /// The USSProperty will be translated as [background-position]. <br></br>
                        /// <i>Animatability: Fully Animatable.</i>
                        /// </summary>
                        backgroundPosition,

                        /// <summary>
                        /// The USSProperty will be translated as [background-position-x]. <br></br>
                        /// <i>Animatability: Discrete.</i>
                        /// </summary>
                        backgroundPositionX,

                        /// <summary>
                        /// The USSProperty will be translated as [background-position-y]. <br></br>
                        /// <i>Animatability: Discrete.</i>
                        /// </summary>
                        backgroundPositionY,

                        /// <summary>
                        /// The USSProperty will be translated as [background-repeat]. <br></br>
                        /// <i>Animatability: Discrete.</i>
                        /// </summary>
                        backgroundRepeat,

                        /// <summary>
                        /// The USSProperty will be translated as [background-size]. <br></br>
                        /// <i>Animatability: Fully Animatable.</i>
                        /// </summary>
                        backgroundSize,
                        #endif

                        /// <summary>
                        /// The USSProperty will be translated as [border-bottom-color]. <br></br>
                        /// <i>Animatability: Fully Animatable.</i>
                        /// </summary>
                        borderBottomColor,

                        /// <summary>
                        /// The USSProperty will be translated as [border-bottom-left-radius]. <br></br>
                        /// <i>Animatability: Fully Animatable.</i>
                        /// </summary>
                        borderBottomLeftRadius,

                        /// <summary>
                        /// The USSProperty will be translated as [border-bottom-right-radius]. <br></br>
                        /// <i>Animatability: Fully Animatable.</i>
                        /// </summary>
                        borderBottomRightRadius,

                        /// <summary>
                        /// The USSProperty will be translated as [border-bottom-width]. <br></br>
                        /// <i>Animatability: Fully Animatable.</i>
                        /// </summary>
                        borderBottomWidth,

                        /// <summary>
                        /// The USSProperty will be translated as [border-color]. <br></br>
                        /// <i>Animatability: Fully Animatable.</i>
                        /// </summary>
                        borderColor,

                        /// <summary>
                        /// The USSProperty will be translated as [border-left-color]. <br></br>
                        /// <i>Animatability: Fully Animatable.</i>
                        /// </summary>
                        borderLeftColor,

                        /// <summary>
                        /// The USSProperty will be translated as [border-left-width]. <br></br>
                        /// <i>Animatability: Fully Animatable.</i>
                        /// </summary>
                        borderLeftWidth,

                        /// <summary>
                        /// The USSProperty will be translated as [border-radius]. <br></br>
                        /// <i>Animatability: Fully Animatable.</i>
                        /// </summary>
                        borderRadius,

                        /// <summary>
                        /// The USSProperty will be translated as [border-right-color]. <br></br>
                        /// <i>Animatability: Fully Animatable.</i>
                        /// </summary>
                        borderRightColor,

                        /// <summary>
                        /// The USSProperty will be translated as [border-right-width]. <br></br>
                        /// <i>Animatability: Fully Animatable.</i>
                        /// </summary>
                        borderRightWidth,

                        /// <summary>
                        /// The USSProperty will be translated as [border-top-color]. <br></br>
                        /// <i>Animatability: Fully Animatable.</i>
                        /// </summary>
                        borderTopColor,

                        /// <summary>
                        /// The USSProperty will be translated as [border-top-left-radius]. <br></br>
                        /// <i>Animatability: Fully Animatable.</i>
                        /// </summary>
                        borderTopLeftRadius,

                        /// <summary>
                        /// The USSProperty will be translated as [border-top-right-radius]. <br></br>
                        /// <i>Animatability: Fully Animatable.</i>
                        /// </summary>
                        borderTopRightRadius,

                        /// <summary>
                        /// The USSProperty will be translated as [border-top-width]. <br></br>
                        /// <i>Animatability: Fully Animatable.</i>
                        /// </summary>
                        borderTopWidth,

                        /// <summary>
                        /// The USSProperty will be translated as [border-width]. <br></br>
                        /// <i>Animatability: Fully Animatable.</i>
                        /// </summary>
                        borderWidth,

                        /// <summary>
                        /// The USSProperty will be translated as [bottom]. <br></br>
                        /// <i>Animatability: Fully Animatable.</i>
                        /// </summary>
                        bottom,

                        /// <summary>
                        /// The USSProperty will be translated as [color]. <br></br>
                        /// <i>Animatability: Fully Animatable.</i>
                        /// </summary>
                        color,

                        /// <summary>
                        /// The USSProperty will be translated as [display]. <br></br>
                        /// <i>Animatability: Discrete.</i>
                        /// </summary>
                        display,

                        /// <summary>
                        /// The USSProperty will be translated as [flex]. <br></br>
                        /// <i>Animatability: Fully Animatable.</i>
                        /// </summary>
                        flex,

                        /// <summary>
                        /// The USSProperty will be translated as [flex-basis]. <br></br>
                        /// <i>Animatability: Fully Animatable.</i>
                        /// </summary>
                        flexBasis,

                        /// <summary>
                        /// The USSProperty will be translated as [flex-direction].<br></br>
                        /// <i>Animatability: Discrete.</i>
                        /// </summary>
                        flexDirection,

                        /// <summary>
                        /// The USSProperty will be translated as [flex-grow]. <br></br>
                        /// <i>Animatability: Fully Animatable.</i>
                        /// </summary>
                        flexGrow,

                        /// <summary>
                        /// The USSProperty will be translated as [flex-shrink]. <br></br>
                        /// <i>Animatability: Fully Animatable.</i>
                        /// </summary>
                        flexShrink,

                        /// <summary>
                        /// The USSProperty will be translated as [flex-wrap].<br></br>
                        /// <i>Animatability: Discrete.</i>
                        /// </summary>
                        flexWrap,

                        /// <summary>
                        /// The USSProperty will be translated as [font-size]. <br></br>
                        /// <i>Animatability: Fully Animatable.</i>
                        /// </summary>
                        fontSize,

                        /// <summary>
                        /// The USSProperty will be translated as [height]. <br></br>
                        /// <i>Animatability: Fully Animatable.</i>
                        /// </summary>
                        height,

                        /// <summary>
                        /// The USSProperty will be translated as [justify-content].<br></br>
                        /// <i>Animatability: Discrete.</i>
                        /// </summary>
                        justifyContent,

                        /// <summary>
                        /// The USSProperty will be translated as [left]. <br></br>
                        /// <i>Animatability: Fully Animatable.</i>
                        /// </summary>
                        left,

                        /// <summary>
                        /// The USSProperty will be translated as [letter-spacing]. <br></br>
                        /// <i>Animatability: Fully Animatable.</i>
                        /// </summary>
                        letterSpacing,

                        /// <summary>
                        /// The USSProperty will be translated as [margin]. <br></br>
                        /// <i>Animatability: Fully Animatable.</i>
                        /// </summary>
                        margin,

                        /// <summary>
                        /// The USSProperty will be translated as [margin-bottom]. <br></br>
                        /// <i>Animatability: Fully Animatable.</i>
                        /// </summary>
                        marginBottom,

                        /// <summary>
                        /// The USSProperty will be translated as [margin-left]. <br></br>
                        /// <i>Animatability: Fully Animatable.</i>
                        /// </summary>
                        marginLeft,

                        /// <summary>
                        /// The USSProperty will be translated as [margin-right]. <br></br>
                        /// <i>Animatability: Fully Animatable.</i>
                        /// </summary>
                        marginRight,

                        /// <summary>
                        /// The USSProperty will be translated as [margin-top]. <br></br>
                        /// <i>Animatability: Fully Animatable.</i>
                        /// </summary>
                        marginTop,

                        /// <summary>
                        /// The USSProperty will be translated as [max-height]. <br></br>
                        /// <i>Animatability: Fully Animatable.</i>
                        /// </summary>
                        maxHeight,

                        /// <summary>
                        /// The USSProperty will be translated as [max-width]. <br></br>
                        /// <i>Animatability: Fully Animatable.</i>
                        /// </summary>
                        maxWidth,

                        /// <summary>
                        /// The USSProperty will be translated as [max-height]. <br></br>
                        /// <i>Animatability: Fully Animatable.</i>
                        /// </summary>
                        minHeight,

                        /// <summary>
                        /// The USSProperty will be translated as [minWidth]. <br></br>
                        /// <i>Animatability: Fully Animatable.</i>
                        /// </summary>
                        minWidth,

                        /// <summary>
                        /// The USSProperty will be translated as [opacity]. <br></br>
                        /// <i>Animatability: Fully Animatable.</i>
                        /// </summary>
                        opacity,

                        /// <summary>
                        /// The USSProperty will be translated as [overflow].<br></br>
                        /// <i>Animatability: Discrete.</i>
                        /// </summary>
                        overflow,

                        /// <summary>
                        /// The USSProperty will be translated as [padding]. <br></br>
                        /// <i>Animatability: Fully Animatable.</i>
                        /// </summary>
                        padding,

                        /// <summary>
                        /// The USSProperty will be translated as [padding-bottom]. <br></br>
                        /// <i>Animatability: Fully Animatable.</i>
                        /// </summary>
                        paddingBottom,

                        /// <summary>
                        /// The USSProperty will be translated as [padding-left]. <br></br>
                        /// <i>Animatability: Fully Animatable.</i>
                        /// </summary>
                        paddingLeft,

                        /// <summary>
                        /// The USSProperty will be translated as [padding-right]. <br></br>
                        /// <i>Animatability: Fully Animatable.</i>
                        /// </summary>
                        paddingRight,

                        /// <summary>
                        /// The USSProperty will be translated as [padding-top]. <br></br>
                        /// <i>Animatability: Fully Animatable.</i>
                        /// </summary>
                        paddingTop,

                        /// <summary>
                        /// The USSProperty will be translated as [position]. <br></br>
                        /// <i>Animatability: Discrete.</i>
                        /// </summary>
                        position,

                        /// <summary>
                        /// The USSProperty will be translated as [right]. <br></br>
                        /// <i>Animatability: Fully Animatable.</i>
                        /// </summary>
                        right,

                        /// <summary>
                        /// The USSProperty will be translated as [rotate]. <br></br>
                        /// <i>Animatability: Fully Animatable.</i>
                        /// </summary>
                        rotate,

                        /// <summary>
                        /// The USSProperty will be translated as [scale]. <br></br>
                        /// <i>Animatability: Fully Animatable.</i>
                        /// </summary>
                        scale,

                        /// <summary>
                        /// The USSProperty will be translated as [text-overflow]. <br></br>
                        /// <i>Animatability: Discrete.</i>
                        /// </summary>
                        textOverflow,

                        /// <summary>
                        /// The USSProperty will be translated as [text-shadow]. <br></br>
                        /// <i>Animatability: Fully Animatable.</i>
                        /// </summary>
                        textShadow,

                        /// <summary>
                        /// The USSProperty will be translated as [top]. <br></br>
                        /// <i>Animatability: Fully Animatable.</i>
                        /// </summary>
                        top,

                        /// <summary>
                        /// The USSProperty will be translated as [transform-origin]. <br></br>
                        /// <i>Animatability: Fully Animatable.</i>
                        /// </summary>
                        transformOrigin,

                        /// <summary>
                        /// The USSProperty will be translated as [translate]. <br></br>
                        /// <i>Animatability: Fully Animatable.</i>
                        /// </summary>
                        translate,

                        /// <summary>
                        /// The USSProperty will be translated as [-unity-background-image-tint-color]. <br></br>
                        /// <i>Animatability: Fully Animatable.</i>
                        /// </summary>
                        unityBackgroundImageTintColor,

                        /// <summary>
                        /// The USSProperty will be translated as [-unity-background-scale-mode]. <br></br>
                        /// <i>Animatability: Discrete.</i>
                        /// </summary>
                        unityBackgroundScaleMode,

                        /// <summary>
                        /// The USSProperty will be translated as [-unity-font]. <br></br>
                        /// <i>Animatability: Discrete.</i>
                        /// </summary>
                        unityFont,

                        /// <summary>
                        /// The USSProperty will be translated as [-unity-font-definition]. <br></br>
                        /// <i>Animatability: Discrete.</i>
                        /// </summary>
                        unityFontDefinition,

                        /// <summary>
                        /// The USSProperty will be translated as [-unity-font-style]. <br></br>
                        /// <i>Animatability: Discrete.</i>
                        /// </summary>
                        unityFontStyle,

                        /// <summary>
                        /// The USSProperty will be translated as [-unity-overflow-clip-box]. <br></br>
                        /// <i>Animatability: Discrete.</i>
                        /// </summary>
                        unityOverflowClipBox,

                        /// <summary>
                        /// The USSProperty will be translated as [-unity-paragraph-spacing].<br></br>
                        /// <i>Animatability: Fully Animatable.</i>
                        /// </summary>
                        unityParagraphSpacing,

                        /// <summary>
                        /// The USSProperty will be translated as [-unity-slice-bottom].<br></br>
                        /// <i>Animatability: Fully Animatable.</i>
                        /// </summary>
                        unitySliceBottom,

                        /// <summary>
                        /// The USSProperty will be translated as [-unity-slice-left].<br></br>
                        /// <i>Animatability: Fully Animatable.</i>
                        /// </summary>
                        unitySliceLeft,

                        /// <summary>
                        /// The USSProperty will be translated as [-unity-slice-right].<br></br>
                        /// <i>Animatability: Fully Animatable.</i>
                        /// </summary>
                        unitySliceRight,

                        /// <summary>
                        /// The USSProperty will be translated as [-unity-slice-scale].<br></br>
                        /// <i>Animatability: Fully Animatable.</i>
                        /// </summary>
                        unitySliceScale,

                        /// <summary>
                        /// The USSProperty will be translated as [-unity-slice-top].<br></br>
                        /// <i>Animatability: Fully Animatable.</i>
                        /// </summary>
                        unitySliceTop,

                        /// <summary>
                        /// The USSProperty will be translated as [-unity-text-align].<br></br>
                        /// <i>Animatability: Discrete.</i>
                        /// </summary>
                        unityTextAlign,

                        /// <summary>
                        /// The USSProperty will be translated as [-unity-text-outline].<br></br>
                        /// <i>Animatability: Fully Animatable.</i>
                        /// </summary>
                        unityTextOutline,

                        /// <summary>
                        /// The USSProperty will be translated as [-unity-text-outline-color].<br></br>
                        /// <i>Animatability: Fully Animatable.</i>
                        /// </summary>
                        unityTextOutlineColor,

                        /// <summary>
                        /// The USSProperty will be translated as [-unity-text-outline-width].<br></br>
                        /// <i>Animatability: Fully Animatable.</i>
                        /// </summary>
                        unityTextOutlineWidth,

                        /// <summary>
                        /// The USSProperty will be translated as [-unity-text-overflow-position].<br></br>
                        /// <i>Animatability: Discrete.</i>
                        /// </summary>
                        unityTextOverflowPosition,

                        /// <summary>
                        /// The USSProperty will be translated as [visibility].<br></br>
                        /// <i>Animatability: Discrete.</i>
                        /// </summary>
                        visibility,

                        /// <summary>
                        /// The USSProperty will be translated as [white-space].<br></br>
                        /// <i>Animatability: Discrete.</i>
                        /// </summary>
                        whiteSpace,

                        /// <summary>
                        /// The USSProperty will be translated as [width].<br></br>
                        /// <i>Animatability: Fully Animatable.</i>
                        /// </summary>
                        width,

                        /// <summary>
                        /// The USSProperty will be translated as [word-spacing].<br></br>
                        /// <i>Animatability: Fully Animatable.</i>
                        /// </summary>
                        wordSpacing
                    }

                    /// <summary>
                    /// Convert the provided JustifyContentValue enum value to it's string representation in USS. <br></br>
                    /// <b><see langword="Notice:"/> Does not default to any keyword, returns a blank value if an incorrect value is passed with a Diagnostics Violation warning in console.</b>
                    /// </summary>
                    /// <param name="value">The keyword to convert to a string.</param>
                    public static string Name(this AnimatableProperty value)
                    {
                        switch (value)
                        {
                            default:
                                Diag.Violation("The AnimatableProperty value for string conversionis invalid.");
                                return "";

                            case AnimatableProperty.alignContent:
                                return "align-content";

                            case AnimatableProperty.alignItems:
                                return "align-items";

                            case AnimatableProperty.alignSelf:
                                return "align-self";

                            case AnimatableProperty.all:
                                return "all";

                            case AnimatableProperty.backgroundColor:
                                return "background-color";

                            case AnimatableProperty.backgroundImage:
                                return "background-image";

                            #if UNITY_2022_2_OR_NEWER
                            case AnimatableProperty.backgroundPosition:
                                return "background-position";

                            case AnimatableProperty.backgroundPositionX:
                                return "background-position-x";

                            case AnimatableProperty.backgroundPositionY:
                                return "background-position-y";

                            case AnimatableProperty.backgroundRepeat:
                                return "background-repeat";

                            case AnimatableProperty.backgroundSize:
                                return "background-size";
                            #endif

                            case AnimatableProperty.borderBottomColor:
                                return "border-bottom-color";

                            case AnimatableProperty.borderBottomLeftRadius:
                                return "border-bottom-left-radius";

                            case AnimatableProperty.borderBottomRightRadius:
                                return "border-bottom-right-radius";

                            case AnimatableProperty.borderBottomWidth:
                                return "border-bottom-width";

                            case AnimatableProperty.borderColor:
                                return "border-color";

                            case AnimatableProperty.borderLeftColor:
                                return "border-left-color";

                            case AnimatableProperty.borderLeftWidth:
                                return "border-left-width";

                            case AnimatableProperty.borderRadius:
                                return "border-radius";

                            case AnimatableProperty.borderRightColor:
                                return "border-right-color";

                            case AnimatableProperty.borderRightWidth:
                                return "border-right-width";

                            case AnimatableProperty.borderTopColor:
                                return "border-top-color";

                            case AnimatableProperty.borderTopLeftRadius:
                                return "border-top-left-radius";

                            case AnimatableProperty.borderTopRightRadius:
                                return "border-top-right-radius";

                            case AnimatableProperty.borderTopWidth:
                                return "border-top-width";

                            case AnimatableProperty.borderWidth:
                                return "border-width";

                            case AnimatableProperty.bottom:
                                return "bottom";

                            case AnimatableProperty.color:
                                return "color";

                            case AnimatableProperty.display:
                                return "display";

                            case AnimatableProperty.flex:
                                return "flex";

                            case AnimatableProperty.flexBasis:
                                return "flex-basis";

                            case AnimatableProperty.flexDirection:
                                return "flex-direction";

                            case AnimatableProperty.flexGrow:
                                return "flex-grow";

                            case AnimatableProperty.flexShrink:
                                return "flex-shrink";

                            case AnimatableProperty.flexWrap:
                                return "flex-wrap";

                            case AnimatableProperty.fontSize:
                                return "font-size";

                            case AnimatableProperty.height:
                                return "height";

                            case AnimatableProperty.justifyContent:
                                return "justify-content";

                            case AnimatableProperty.left:
                                return "left";

                            case AnimatableProperty.letterSpacing:
                                return "letter-spacing";

                            case AnimatableProperty.margin:
                                return "margin";

                            case AnimatableProperty.marginBottom:
                                return "margin-bottom";

                            case AnimatableProperty.marginLeft:
                                return "margin-left";

                            case AnimatableProperty.marginRight:
                                return "margin-right";

                            case AnimatableProperty.marginTop:
                                return "margin-top";

                            case AnimatableProperty.maxHeight:
                                return "max-height";

                            case AnimatableProperty.maxWidth:
                                return "max-width";

                            case AnimatableProperty.minHeight:
                                return "min-height";

                            case AnimatableProperty.minWidth:
                                return "min-width";

                            case AnimatableProperty.opacity:
                                return "opacity";

                            case AnimatableProperty.overflow:
                                return "overflow";

                            case AnimatableProperty.padding:
                                return "padding";

                            case AnimatableProperty.paddingBottom:
                                return "padding-bottom";

                            case AnimatableProperty.paddingLeft:
                                return "padding-left";

                            case AnimatableProperty.paddingRight:
                                return "padding-right";

                            case AnimatableProperty.paddingTop:
                                return "padding-top";

                            case AnimatableProperty.position:
                                return "position";

                            case AnimatableProperty.right:
                                return "right";

                            case AnimatableProperty.rotate:
                                return "rotate";

                            case AnimatableProperty.scale:
                                return "scale";

                            case AnimatableProperty.textOverflow:
                                return "text-overflow";

                            case AnimatableProperty.textShadow:
                                return "text-shadow";

                            case AnimatableProperty.top:
                                return "top";

                            case AnimatableProperty.transformOrigin:
                                return "transform-origin";

                            case AnimatableProperty.translate:
                                return "translate";

                            case AnimatableProperty.unityBackgroundImageTintColor:
                                return "-unity-background-image-tint-color";

                            case AnimatableProperty.unityBackgroundScaleMode:
                                return "-unity-background-scale-mode";

                            case AnimatableProperty.unityFont:
                                return "-unity-font";

                            case AnimatableProperty.unityFontDefinition:
                                return "-unity-font-definition";

                            case AnimatableProperty.unityFontStyle:
                                return "-unity-font-style";

                            case AnimatableProperty.unityOverflowClipBox:
                                return "-unity-overflow-clip-box";

                            case AnimatableProperty.unityParagraphSpacing:
                                return "-unity-paragraph-spacing";

                            case AnimatableProperty.unitySliceBottom:
                                return "-unity-slice-bottom";

                            case AnimatableProperty.unitySliceLeft:
                                return "-unity-slice-left";

                            case AnimatableProperty.unitySliceRight:
                                return "-unity-slice-right";

                            case AnimatableProperty.unitySliceScale:
                                return "-unity-slice-scale";

                            case AnimatableProperty.unitySliceTop:
                                return "-unity-slice-top";

                            case AnimatableProperty.unityTextAlign:
                                return "-unity-text-align";

                            case AnimatableProperty.unityTextOutline:
                                return "-unity-text-outline";

                            case AnimatableProperty.unityTextOutlineColor:
                                return "-unity-text-outline-color";

                            case AnimatableProperty.unityTextOutlineWidth:
                                return "-unity-text-outline-width";

                            case AnimatableProperty.unityTextOverflowPosition:
                                return "-unity-text-overflow-position";

                            case AnimatableProperty.visibility:
                                return "visibility";

                            case AnimatableProperty.whiteSpace:
                                return "white-space";

                            case AnimatableProperty.width:
                                return "width";

                            case AnimatableProperty.wordSpacing:
                                return "word-spacing";
                        }
                    }

                    /// <summary>
                    /// Convert the provided string into a AnimatableProperty enum value. <br></br>
                    /// <b><see langword="Notice:"/> Does not default to any keyword. Will thrown an exception if an invalid value is provided.</b>
                    /// </summary>
                    /// <param name="valueAsName">The string value to convert.</param>
                    /// <exception cref="System.ArgumentException"></exception>
                    public static AnimatableProperty ToAnimatableProperty(string valueAsName)
                    {
                        return valueAsName switch
                        {
                            "align-content" => AnimatableProperty.alignContent,
                            "align-items" => AnimatableProperty.alignItems,
                            "all" => AnimatableProperty.all,
                            "background-color" => AnimatableProperty.backgroundColor,
                            "background-image" => AnimatableProperty.backgroundImage,
                            #if UNITY_2022_2_OR_NEWER
                            "background-position" => AnimatableProperty.backgroundPosition,
                            "background-position-x" => AnimatableProperty.backgroundPositionX,
                            "background-position-y" => AnimatableProperty.backgroundPositionY,
                            "background-repeat" => AnimatableProperty.backgroundRepeat,
                            "background-size" => AnimatableProperty.backgroundSize,
                            #endif
                            "border-bottom-color" => AnimatableProperty.borderBottomColor,
                            "border-bottom-left-radius" => AnimatableProperty.borderBottomLeftRadius,
                            "border-bottom-right-radius" => AnimatableProperty.borderBottomRightRadius,
                            "border-bottom-width" => AnimatableProperty.borderBottomWidth,
                            "border-color" => AnimatableProperty.borderColor,
                            "border-left-color" => AnimatableProperty.borderLeftColor,
                            "border-left-width" => AnimatableProperty.borderLeftWidth,
                            "border-radius" => AnimatableProperty.borderRadius,
                            "border-right-color" => AnimatableProperty.borderRightColor,
                            "border-right-width" => AnimatableProperty.borderRightWidth,
                            "border-top-color" => AnimatableProperty.borderTopColor,
                            "border-top-left-radius" => AnimatableProperty.borderTopLeftRadius,
                            "border-top-right-radius" => AnimatableProperty.borderTopRightRadius,
                            "border-top-width" => AnimatableProperty.borderTopWidth,
                            "border-width" => AnimatableProperty.borderWidth,
                            "bottom" => AnimatableProperty.bottom,
                            "color" => AnimatableProperty.color,
                            "display" => AnimatableProperty.display,
                            "flex" => AnimatableProperty.flex,
                            "flex-basis" => AnimatableProperty.flexBasis,
                            "flex-direction" => AnimatableProperty.flexDirection,
                            "flex-grow" => AnimatableProperty.flexGrow,
                            "flex-shrink" => AnimatableProperty.flexShrink,
                            "flex-wrap" => AnimatableProperty.flexWrap,
                            "font-size" => AnimatableProperty.fontSize,
                            "height" => AnimatableProperty.height,
                            "justify-content" => AnimatableProperty.justifyContent,
                            "left" => AnimatableProperty.left,
                            "letter-spacing" => AnimatableProperty.letterSpacing,
                            "margin" => AnimatableProperty.margin,
                            "margin-bottom" => AnimatableProperty.marginBottom,
                            "margin-left" => AnimatableProperty.marginLeft,
                            "margin-right" => AnimatableProperty.marginRight,
                            "margin-top" => AnimatableProperty.marginTop,
                            "max-height" => AnimatableProperty.maxHeight,
                            "max-width" => AnimatableProperty.maxWidth,
                            "min-height" => AnimatableProperty.minHeight,
                            "min-width" => AnimatableProperty.minWidth,
                            "opacity" => AnimatableProperty.opacity,
                            "overflow" => AnimatableProperty.overflow,
                            "padding" => AnimatableProperty.padding,
                            "padding-bottom" => AnimatableProperty.paddingBottom,
                            "padding-left" => AnimatableProperty.paddingLeft,
                            "padding-right" => AnimatableProperty.paddingRight,
                            "padding-top" => AnimatableProperty.paddingTop,
                            "position" => AnimatableProperty.position,
                            "right" => AnimatableProperty.right,
                            "rotate" => AnimatableProperty.rotate,
                            "scale" => AnimatableProperty.scale,
                            "text-overflow" => AnimatableProperty.textOverflow,
                            "text-shadow" => AnimatableProperty.textShadow,
                            "top" => AnimatableProperty.top,
                            "transform-origin" => AnimatableProperty.transformOrigin,
                            "translate" => AnimatableProperty.translate,
                            "-unity-background-image-tint-color" => AnimatableProperty.unityBackgroundImageTintColor,
                            "-unity-background-scale-mode" => AnimatableProperty.unityBackgroundScaleMode,
                            "-unity-font" => AnimatableProperty.unityFont,
                            "-unity-font-definition" => AnimatableProperty.unityFontDefinition,
                            "-unity-font-style" => AnimatableProperty.unityFontStyle,
                            "-unity-overflow-clip-box" => AnimatableProperty.unityOverflowClipBox,
                            "-unity-paragraph-spacing" => AnimatableProperty.unityParagraphSpacing,
                            "-unity-slice-bottom" => AnimatableProperty.unitySliceBottom,
                            "-unity-slice-left" => AnimatableProperty.unitySliceLeft,
                            "-unity-slice-right" => AnimatableProperty.unitySliceRight,
                            "-unity-slice-scale" => AnimatableProperty.unitySliceScale,
                            "-unity-slice-top" => AnimatableProperty.unitySliceTop,
                            "-unity-text-align" => AnimatableProperty.unityTextAlign,
                            "-unity-text-outline" => AnimatableProperty.unityTextOutline,
                            "-unity-text-outline-color" => AnimatableProperty.unityTextOutlineColor,
                            "-unity-text-outline-width" => AnimatableProperty.unityTextOutlineWidth,
                            "-unity-text-overflow-position" => AnimatableProperty.unityTextOverflowPosition,
                            "visiblity" => AnimatableProperty.visibility,
                            "white-space" => AnimatableProperty.whiteSpace,
                            "width" => AnimatableProperty.width,
                            "word-spacing" => AnimatableProperty.wordSpacing,
                            _ => throw new System.ArgumentException("The keyword you have tried to translate is either invalid or not supported in your version of Unity Engine.")
                        };
                    }
                }
            }
        }
    }
}