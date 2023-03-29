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
                /// All known property types as of UnityEngine 2023.1 - following documentation for USS Properties. <br></br>
                /// <see href="https://docs.unity3d.com/2023.1/Documentation/Manual/UIE-USS-Properties-Reference.html">Unity - Manual: USS Properties Reference</see>
                /// </summary>
                public enum RuleType
                {
                    /// <summary>
                    /// <b><see langword="[DEPRECATED], [ADVANCED]"/></b><br></br>
                    /// The USSProperty will be translated directly - assumed as a natively supported property type. <br></br>
                    /// If a USS Property type is available but isn't included into the USS Object Model, this is provided alongside a constructor that takes two string values for you to construct the rule.
                    /// </summary>
                    // Trying to provide leeway for unsupported keywords in the future is very hard and it would only be possible to "safely" let a developer to directly write two string values (the style rule name and the style rule value).
                    NativeProperty = -1,

                    /// <summary>
                    /// The USSProperty will be translated as a variable with a custom name.
                    /// </summary>
                    Variable = 0,

                    /// <summary>
                    /// The USSProperty will be translated as [align-content].
                    /// </summary>
                    alignContent,

                    /// <summary>
                    /// The USSProperty will be translated as [align-items].
                    /// </summary>
                    alignItems,

                    /// <summary>
                    /// The USSProperty will be translated as [align-self].
                    /// </summary>
                    alignSelf,

                    /// <summary>
                    /// The USSProperty will be translated as [all].
                    /// </summary>
                    all,

                    /// <summary>
                    /// The USSProperty will be translated as [background-color].
                    /// </summary>
                    backgroundColor,

                    /// <summary>
                    /// The USSProperty will be translated as [background-image].
                    /// </summary>
                    backgroundImage,

                    #if UNITY_2022_2_OR_NEWER
                    /// <summary>
                    /// The USSProperty will be translated as [background-position].
                    /// </summary>
                    backgroundPosition,

                    /// <summary>
                    /// The USSProperty will be translated as [background-position-x].
                    /// </summary>
                    backgroundPositionX,

                    /// <summary>
                    /// The USSProperty will be translated as [background-position-y].
                    /// </summary>
                    backgroundPositionY,

                    /// <summary>
                    /// The USSProperty will be translated as [background-repeat].
                    /// </summary>
                    backgroundRepeat,

                    /// <summary>
                    /// The USSProperty will be translated as [background-size].
                    /// </summary>
                    backgroundSize,
                    #endif

                    /// <summary>
                    /// The USSProperty will be translated as [border-bottom-color].
                    /// </summary>
                    borderBottomColor,

                    /// <summary>
                    /// The USSProperty will be translated as [border-bottom-left-radius].
                    /// </summary>
                    borderBottomLeftRadius,

                    /// <summary>
                    /// The USSProperty will be translated as [border-bottom-right-radius].
                    /// </summary>
                    borderBottomRightRadius,

                    /// <summary>
                    /// The USSProperty will be translated as [border-bottom-width].
                    /// </summary>
                    borderBottomWidth,

                    /// <summary>
                    /// The USSProperty will be translated as [border-color].
                    /// </summary>
                    borderColor,

                    /// <summary>
                    /// The USSProperty will be translated as [border-left-color].
                    /// </summary>
                    borderLeftColor,

                    /// <summary>
                    /// The USSProperty will be translated as [border-left-width].
                    /// </summary>
                    borderLeftWidth,

                    /// <summary>
                    /// The USSProperty will be translated as [border-radius].
                    /// </summary>
                    borderRadius,

                    /// <summary>
                    /// The USSProperty will be translated as [border-right-color].
                    /// </summary>
                    borderRightColor,

                    /// <summary>
                    /// The USSProperty will be translated as [border-right-width].
                    /// </summary>
                    borderRightWidth,

                    /// <summary>
                    /// The USSProperty will be translated as [border-top-color].
                    /// </summary>
                    borderTopColor,

                    /// <summary>
                    /// The USSProperty will be translated as [border-top-left-radius].
                    /// </summary>
                    borderTopLeftRadius,

                    /// <summary>
                    /// The USSProperty will be translated as [border-top-right-radius].
                    /// </summary>
                    borderTopRightRadius,

                    /// <summary>
                    /// The USSProperty will be translated as [border-top-width].
                    /// </summary>
                    borderTopWidth,

                    /// <summary>
                    /// The USSProperty will be translated as [border-width].
                    /// </summary>
                    borderWidth,

                    /// <summary>
                    /// The USSProperty will be translated as [bottom].
                    /// </summary>
                    bottom,

                    /// <summary>
                    /// The USSProperty will be translated as [color].
                    /// </summary>
                    color,

                    /// <summary>
                    /// The USSProperty will be translated as [cursor].
                    /// </summary>
                    cursor,

                    /// <summary>
                    /// The USSProperty will be translated as [display].
                    /// </summary>
                    display,

                    /// <summary>
                    /// The USSProperty will be translated as [flex].
                    /// </summary>
                    flex,

                    /// <summary>
                    /// The USSProperty will be translated as [flex-basis].
                    /// </summary>
                    flexBasis,

                    /// <summary>
                    /// The USSProperty will be translated as [flex-direction].
                    /// </summary>
                    flexDirection,

                    /// <summary>
                    /// The USSProperty will be translated as [flex-grow].
                    /// </summary>
                    flexGrow,

                    /// <summary>
                    /// The USSProperty will be translated as [flex-shrink].
                    /// </summary>
                    flexShrink,

                    /// <summary>
                    /// The USSProperty will be translated as [flex-wrap].
                    /// </summary>
                    flexWrap,

                    /// <summary>
                    /// The USSProperty will be translated as [font-size].
                    /// </summary>
                    fontSize,

                    /// <summary>
                    /// The USSProperty will be translated as [height].
                    /// </summary>
                    height,

                    /// <summary>
                    /// The USSProperty will be translated as [justify-content].
                    /// </summary>
                    justifyContent,

                    /// <summary>
                    /// The USSProperty will be translated as [left].
                    /// </summary>
                    left,

                    /// <summary>
                    /// The USSProperty will be translated as [letter-spacing].
                    /// </summary>
                    letterSpacing,

                    /// <summary>
                    /// The USSProperty will be translated as [margin].
                    /// </summary>
                    margin,

                    /// <summary>
                    /// The USSProperty will be translated as [margin-bottom].
                    /// </summary>
                    marginBottom,

                    /// <summary>
                    /// The USSProperty will be translated as [margin-left].
                    /// </summary>
                    marginLeft,

                    /// <summary>
                    /// The USSProperty will be translated as [margin-right].
                    /// </summary>
                    marginRight,

                    /// <summary>
                    /// The USSProperty will be translated as [margin-top].
                    /// </summary>
                    marginTop,

                    /// <summary>
                    /// The USSProperty will be translated as [max-height].
                    /// </summary>
                    maxHeight,

                    /// <summary>
                    /// The USSProperty will be translated as [max-width].
                    /// </summary>
                    maxWidth,

                    /// <summary>
                    /// The USSProperty will be translated as [max-height].
                    /// </summary>
                    minHeight,

                    /// <summary>
                    /// The USSProperty will be translated as [minWidth].
                    /// </summary>
                    minWidth,

                    /// <summary>
                    /// The USSProperty will be translated as [opacity].
                    /// </summary>
                    opacity,

                    /// <summary>
                    /// The USSProperty will be translated as [overflow].
                    /// </summary>
                    overflow,

                    /// <summary>
                    /// The USSProperty will be translated as [padding].
                    /// </summary>
                    padding,

                    /// <summary>
                    /// The USSProperty will be translated as [padding-bottom].
                    /// </summary>
                    paddingBottom,

                    /// <summary>
                    /// The USSProperty will be translated as [padding-left].
                    /// </summary>
                    paddingLeft,

                    /// <summary>
                    /// The USSProperty will be translated as [padding-right].
                    /// </summary>
                    paddingRight,

                    /// <summary>
                    /// The USSProperty will be translated as [padding-top].
                    /// </summary>
                    paddingTop,

                    /// <summary>
                    /// The USSProperty will be translated as [position].
                    /// </summary>
                    position,

                    /// <summary>
                    /// The USSProperty will be translated as [right].
                    /// </summary>
                    right,

                    /// <summary>
                    /// The USSProperty will be translated as [rotate].
                    /// </summary>
                    rotate,

                    /// <summary>
                    /// The USSProperty will be translated as [scale].
                    /// </summary>
                    scale,

                    /// <summary>
                    /// The USSProperty will be translated as [text-overflow].
                    /// </summary>
                    textOverflow,

                    /// <summary>
                    /// The USSProperty will be translated as [text-shadow].
                    /// </summary>
                    textShadow,

                    /// <summary>
                    /// The USSProperty will be translated as [top].
                    /// </summary>
                    top,

                    /// <summary>
                    /// The USSProperty will be translated as [transform-origin].
                    /// </summary>
                    transformOrigin,

                    /// <summary>
                    /// The USSProperty will be translated as [transition].
                    /// </summary>
                    transition,

                    /// <summary>
                    /// The USSProperty will be translated as [transition-delay].
                    /// </summary>
                    transitionDelay,

                    /// <summary>
                    /// The USSProperty will be translated as [transition-duration].
                    /// </summary>
                    transitionDuration,

                    /// <summary>
                    /// The USSProperty will be translated as [transition-property].
                    /// </summary>
                    transitionProperty,

                    /// <summary>
                    /// The USSProperty will be translated as [transition-timing-function].
                    /// </summary>
                    transitionTimingFunction,

                    /// <summary>
                    /// The USSProperty will be translated as [translate].
                    /// </summary>
                    translate,

                    /// <summary>
                    /// The USSProperty will be translated as [-unity-background-image-tint-color].
                    /// </summary>
                    unityBackgroundImageTintColor,

                    /// <summary>
                    /// The USSProperty will be translated as [-unity-background-scale-mode].
                    /// </summary>
                    unityBackgroundScaleMode,

                    /// <summary>
                    /// The USSProperty will be translated as [-unity-font].
                    /// </summary>
                    unityFont,

                    /// <summary>
                    /// The USSProperty will be translated as [-unity-font-definition].
                    /// </summary>
                    unityFontDefinition,

                    /// <summary>
                    /// The USSProperty will be translated as [-unity-font-style].
                    /// </summary>
                    unityFontStyle,

                    /// <summary>
                    /// The USSProperty will be translated as [-unity-overflow-clip-box].
                    /// </summary>
                    unityOverflowClipBox,

                    /// <summary>
                    /// The USSProperty will be translated as [-unity-paragraph-spacing].
                    /// </summary>
                    unityParagraphSpacing,

                    /// <summary>
                    /// The USSProperty will be translated as [-unity-slice-bottom].
                    /// </summary>
                    unitySliceBottom,

                    /// <summary>
                    /// The USSProperty will be translated as [-unity-slice-left].
                    /// </summary>
                    unitySliceLeft,

                    /// <summary>
                    /// The USSProperty will be translated as [-unity-slice-right].
                    /// </summary>
                    unitySliceRight,

                    /// <summary>
                    /// The USSProperty will be translated as [-unity-slice-scale].
                    /// </summary>
                    unitySliceScale,

                    /// <summary>
                    /// The USSProperty will be translated as [-unity-slice-top].
                    /// </summary>
                    unitySliceTop,

                    /// <summary>
                    /// The USSProperty will be translated as [-unity-text-align].
                    /// </summary>
                    unityTextAlign,

                    /// <summary>
                    /// The USSProperty will be translated as [-unity-text-outline].
                    /// </summary>
                    unityTextOutline,

                    /// <summary>
                    /// The USSProperty will be translated as [-unity-text-outline-color].
                    /// </summary>
                    unityTextOutlineColor,

                    /// <summary>
                    /// The USSProperty will be translated as [-unity-text-outline-width].
                    /// </summary>
                    unityTextOutlineWidth,

                    /// <summary>
                    /// The USSProperty will be translated as [-unity-text-overflow-position].
                    /// </summary>
                    unityTextOverflowPosition,

                    /// <summary>
                    /// The USSProperty will be translated as [visibility].
                    /// </summary>
                    visibility,

                    /// <summary>
                    /// The USSProperty will be translated as [white-space].
                    /// </summary>
                    whiteSpace,

                    /// <summary>
                    /// The USSProperty will be translated as [width].
                    /// </summary>
                    width,

                    /// <summary>
                    /// The USSProperty will be translated as [word-spacing].
                    /// </summary>
                    wordSpacing
                }

                public static class RuleTyping
                {
                    /// <summary>
                    /// Convert the rule type to a string name. <br></br><br></br>
                    /// <see langword="Notice:"/> Does not convert NativeProperty or Variable RuleTypes. <br></br> 
                    /// For such behaviour, see: <see cref="ToRuleName(RuleType, string)"/>
                    /// </summary>
                    /// <param name="type">The type </param>
                    /// <returns></returns>
                    public static string ToRuleName(RuleType type)
                    {
                        switch (type)
                        {
                            default:
                                Diag.Violation("The property type passed through for string conversion as the propertyName is invalid.");
                                return "";

                            case RuleType.alignContent:
                                return "align-content";

                            case RuleType.alignItems:
                                return "align-items";

                            case RuleType.alignSelf:
                                return "align-self";

                            case RuleType.all:
                                return "all";

                            case RuleType.backgroundColor:
                                return "background-color";

                            case RuleType.backgroundImage:
                                return "background-image";

                            #if UNITY_2022_2_OR_NEWER
                            case RuleType.backgroundPosition:
                                return "background-position";

                            case RuleType.backgroundPositionX:
                                return "background-position-x";

                            case RuleType.backgroundPositionY:
                                return "background-position-y";

                            case RuleType.backgroundRepeat:
                                return "background-repeat";

                            case RuleType.backgroundSize:
                                return "background-size";
                            #endif

                            case RuleType.borderBottomColor:
                                return "border-bottom-color";

                            case RuleType.borderBottomLeftRadius:
                                return "border-bottom-left-radius";

                            case RuleType.borderBottomRightRadius:
                                return "border-bottom-right-radius";

                            case RuleType.borderBottomWidth:
                                return "border-bottom-width";

                            case RuleType.borderColor:
                                return "border-color";

                            case RuleType.borderLeftColor:
                                return "border-left-color";

                            case RuleType.borderLeftWidth:
                                return "border-left-width";

                            case RuleType.borderRadius:
                                return "border-radius";

                            case RuleType.borderRightColor:
                                return "border-right-color";

                            case RuleType.borderRightWidth:
                                return "border-right-width";

                            case RuleType.borderTopColor:
                                return "border-top-color";

                            case RuleType.borderTopLeftRadius:
                                return "border-top-left-radius";

                            case RuleType.borderTopRightRadius:
                                return "border-top-right-radius";

                            case RuleType.borderTopWidth:
                                return "border-top-width";

                            case RuleType.borderWidth:
                                return "border-width";

                            case RuleType.bottom:
                                return "bottom";

                            case RuleType.color:
                                return "color";

                            case RuleType.cursor:
                                return "cursor";

                            case RuleType.display:
                                return "display";

                            case RuleType.flex:
                                return "flex";

                            case RuleType.flexBasis:
                                return "flex-basis";

                            case RuleType.flexDirection:
                                return "flex-direction";

                            case RuleType.flexGrow:
                                return "flex-grow";

                            case RuleType.flexShrink:
                                return "flex-shrink";

                            case RuleType.flexWrap:
                                return "flex-wrap";

                            case RuleType.fontSize:
                                return "font-size";

                            case RuleType.height:
                                return "height";

                            case RuleType.justifyContent:
                                return "justify-content";

                            case RuleType.left:
                                return "left";

                            case RuleType.letterSpacing:
                                return "letter-spacing";

                            case RuleType.margin:
                                return "margin";

                            case RuleType.marginBottom:
                                return "margin-bottom";

                            case RuleType.marginLeft:
                                return "margin-left";

                            case RuleType.marginRight:
                                return "margin-right";

                            case RuleType.marginTop:
                                return "margin-top";

                            case RuleType.maxHeight:
                                return "max-height";

                            case RuleType.maxWidth:
                                return "max-width";

                            case RuleType.minHeight:
                                return "min-height";

                            case RuleType.minWidth:
                                return "min-width";

                            case RuleType.opacity:
                                return "opacity";

                            case RuleType.overflow:
                                return "overflow";

                            case RuleType.padding:
                                return "padding";

                            case RuleType.paddingBottom:
                                return "padding-bottom";

                            case RuleType.paddingLeft:
                                return "padding-left";

                            case RuleType.paddingRight:
                                return "padding-right";

                            case RuleType.paddingTop:
                                return "padding-top";

                            case RuleType.position:
                                return "position";

                            case RuleType.right:
                                return "right";

                            case RuleType.rotate:
                                return "rotate";

                            case RuleType.scale:
                                return "scale";

                            case RuleType.textOverflow:
                                return "text-overflow";

                            case RuleType.textShadow:
                                return "text-shadow";

                            case RuleType.top:
                                return "top";

                            case RuleType.transformOrigin:
                                return "transform-origin";

                            case RuleType.transition:
                                return "transition";

                            case RuleType.transitionDelay:
                                return "transition-delay";

                            case RuleType.transitionDuration:
                                return "transition-duration";

                            case RuleType.transitionProperty:
                                return "transition-property";

                            case RuleType.transitionTimingFunction:
                                return "transition-timing-function";

                            case RuleType.translate:
                                return "translate";

                            case RuleType.unityBackgroundImageTintColor:
                                return "-unity-background-image-tint-color";

                            case RuleType.unityBackgroundScaleMode:
                                return "-unity-background-scale-mode";

                            case RuleType.unityFont:
                                return "-unity-font";

                            case RuleType.unityFontDefinition:
                                return "-unity-font-definition";

                            case RuleType.unityFontStyle:
                                return "-unity-font-style";

                            case RuleType.unityOverflowClipBox:
                                return "-unity-overflow-clip-box";

                            case RuleType.unityParagraphSpacing:
                                return "-unity-paragraph-spacing";

                            case RuleType.unitySliceBottom:
                                return "-unity-slice-bottom";

                            case RuleType.unitySliceLeft:
                                return "-unity-slice-left";

                            case RuleType.unitySliceRight:
                                return "-unity-slice-right";

                            case RuleType.unitySliceScale:
                                return "-unity-slice-scale";

                            case RuleType.unitySliceTop:
                                return "-unity-slice-top";

                            case RuleType.unityTextAlign:
                                return "-unity-text-align";

                            case RuleType.unityTextOutline:
                                return "-unity-text-outline";

                            case RuleType.unityTextOutlineColor:
                                return "-unity-text-outline-color";

                            case RuleType.unityTextOutlineWidth:
                                return "-unity-text-outline-width";

                            case RuleType.unityTextOverflowPosition:
                                return "-unity-text-overflow-position";

                            case RuleType.visibility:
                                return "visibility";

                            case RuleType.whiteSpace:
                                return "white-space";

                            case RuleType.width:
                                return "width";

                            case RuleType.wordSpacing:
                                return "word-spacing";
                        }
                    }

                    public static string ToRuleName(RuleType type, string ruleName)
                    {
                        switch (type)
                        {
                            default:
                                Diag.Violation("The property type passed through for string conversion is invalid.");
                                return ruleName;

                            // assumes the developer already knows USS and knows a feature not yet supported in Cappuccinos C# to USS converter.
                            case RuleType.NativeProperty:
                                return ruleName;

                            case RuleType.Variable:
                                return "--" + ruleName;

                            case RuleType.alignContent:
                                return "align-content";

                            case RuleType.alignItems:
                                return "align-items";

                            case RuleType.alignSelf:
                                return "align-self";

                            case RuleType.all:
                                return "all";

                            case RuleType.backgroundColor:
                                return "background-color";

                            case RuleType.backgroundImage:
                                return "background-image";

                            #if UNITY_2022_2_OR_NEWER
                            case RuleType.backgroundPosition:
                                return "background-position";

                            case RuleType.backgroundPositionX:
                                return "background-position-x";

                            case RuleType.backgroundPositionY:
                                return "background-position-y";

                            case RuleType.backgroundRepeat:
                                return "background-repeat";

                            case RuleType.backgroundSize:
                                return "background-size";
                            #endif

                            case RuleType.borderBottomColor:
                                return "border-bottom-color";

                            case RuleType.borderBottomLeftRadius:
                                return "border-bottom-left-radius";

                            case RuleType.borderBottomRightRadius:
                                return "border-bottom-right-radius";

                            case RuleType.borderBottomWidth:
                                return "border-bottom-width";

                            case RuleType.borderColor:
                                return "border-color";

                            case RuleType.borderLeftColor:
                                return "border-left-color";

                            case RuleType.borderLeftWidth:
                                return "border-left-width";

                            case RuleType.borderRadius:
                                return "border-radius";

                            case RuleType.borderRightColor:
                                return "border-right-color";

                            case RuleType.borderRightWidth:
                                return "border-right-width";

                            case RuleType.borderTopColor:
                                return "border-top-color";

                            case RuleType.borderTopLeftRadius:
                                return "border-top-left-radius";

                            case RuleType.borderTopRightRadius:
                                return "border-top-right-radius";

                            case RuleType.borderTopWidth:
                                return "border-top-width";

                            case RuleType.borderWidth:
                                return "border-width";

                            case RuleType.bottom:
                                return "bottom";

                            case RuleType.color:
                                return "color";

                            case RuleType.cursor:
                                return "cursor";

                            case RuleType.display:
                                return "display";

                            case RuleType.flex:
                                return "flex";

                            case RuleType.flexBasis:
                                return "flex-basis";

                            case RuleType.flexDirection:
                                return "flex-direction";

                            case RuleType.flexGrow:
                                return "flex-grow";

                            case RuleType.flexShrink:
                                return "flex-shrink";

                            case RuleType.flexWrap:
                                return "flex-wrap";

                            case RuleType.fontSize:
                                return "font-size";

                            case RuleType.height:
                                return "height";

                            case RuleType.justifyContent:
                                return "justify-content";

                            case RuleType.left:
                                return "left";

                            case RuleType.letterSpacing:
                                return "letter-spacing";

                            case RuleType.margin:
                                return "margin";

                            case RuleType.marginBottom:
                                return "margin-bottom";

                            case RuleType.marginLeft:
                                return "margin-left";

                            case RuleType.marginRight:
                                return "margin-right";

                            case RuleType.marginTop:
                                return "margin-top";

                            case RuleType.maxHeight:
                                return "max-height";

                            case RuleType.maxWidth:
                                return "max-width";

                            case RuleType.minHeight:
                                return "min-height";

                            case RuleType.minWidth:
                                return "min-width";

                            case RuleType.opacity:
                                return "opacity";

                            case RuleType.overflow:
                                return "overflow";

                            case RuleType.padding:
                                return "padding";

                            case RuleType.paddingBottom:
                                return "padding-bottom";

                            case RuleType.paddingLeft:
                                return "padding-left";

                            case RuleType.paddingRight:
                                return "padding-right";

                            case RuleType.paddingTop:
                                return "padding-top";

                            case RuleType.position:
                                return "position";

                            case RuleType.right:
                                return "right";

                            case RuleType.rotate:
                                return "rotate";

                            case RuleType.scale:
                                return "scale";

                            case RuleType.textOverflow:
                                return "text-overflow";

                            case RuleType.textShadow:
                                return "text-shadow";

                            case RuleType.top:
                                return "top";

                            case RuleType.transformOrigin:
                                return "transform-origin";

                            case RuleType.transition:
                                return "transition";

                            case RuleType.transitionDelay:
                                return "transition-delay";

                            case RuleType.transitionDuration:
                                return "transition-duration";

                            case RuleType.transitionProperty:
                                return "transition-property";

                            case RuleType.transitionTimingFunction:
                                return "transition-timing-function";

                            case RuleType.translate:
                                return "translate";

                            case RuleType.unityBackgroundImageTintColor:
                                return "-unity-background-image-tint-color";

                            case RuleType.unityBackgroundScaleMode:
                                return "-unity-background-scale-mode";

                            case RuleType.unityFont:
                                return "-unity-font";

                            case RuleType.unityFontDefinition:
                                return "-unity-font-definition";

                            case RuleType.unityFontStyle:
                                return "-unity-font-style";

                            case RuleType.unityOverflowClipBox:
                                return "-unity-overflow-clip-box";

                            case RuleType.unityParagraphSpacing:
                                return "-unity-paragraph-spacing";

                            case RuleType.unitySliceBottom:
                                return "-unity-slice-bottom";

                            case RuleType.unitySliceLeft:
                                return "-unity-slice-left";

                            case RuleType.unitySliceRight:
                                return "-unity-slice-right";

                            case RuleType.unitySliceScale:
                                return "-unity-slice-scale";

                            case RuleType.unitySliceTop:
                                return "-unity-slice-top";

                            case RuleType.unityTextAlign:
                                return "-unity-text-align";

                            case RuleType.unityTextOutline:
                                return "-unity-text-outline";

                            case RuleType.unityTextOutlineColor:
                                return "-unity-text-outline-color";

                            case RuleType.unityTextOutlineWidth:
                                return "-unity-text-outline-width";

                            case RuleType.unityTextOverflowPosition:
                                return "-unity-text-overflow-position";

                            case RuleType.visibility:
                                return "visibility";

                            case RuleType.whiteSpace:
                                return "white-space";

                            case RuleType.width:
                                return "width";

                            case RuleType.wordSpacing:
                                return "word-spacing";
                        }
                    }

                    /// <summary>
                    /// Determine the Rule Type for the provided style rule definition.
                    /// </summary>
                    /// <param name="definition"></param>
                    /// <returns></returns>
                    public static RuleType ToRuleType(string definition)
                    {
                        return definition switch
                        {
                            "align-content" => RuleType.alignContent,
                            "align-items" => RuleType.alignItems,
                            "all" => RuleType.all,
                            "background-color" => RuleType.backgroundColor,
                            "background-image" => RuleType.backgroundImage,
                            #if UNITY_2022_2_OR_NEWER
                            "background-position" => RuleType.backgroundPosition,
                            "background-position-x" => RuleType.backgroundPositionX,
                            "background-position-y" => RuleType.backgroundPositionY,
                            "background-repeat" => RuleType.backgroundRepeat,
                            "background-size" => RuleType.backgroundSize,
                            #endif
                            "border-bottom-color" => RuleType.borderBottomColor,
                            "border-bottom-left-radius" => RuleType.borderBottomLeftRadius,
                            "border-bottom-right-radius" => RuleType.borderBottomRightRadius,
                            "border-bottom-width" => RuleType.borderBottomWidth,
                            "border-color" => RuleType.borderColor,
                            "border-left-color" => RuleType.borderLeftColor,
                            "border-left-width" => RuleType.borderLeftWidth,
                            "border-radius" => RuleType.borderRadius,
                            "border-right-color" => RuleType.borderRightColor,
                            "border-right-width" => RuleType.borderRightWidth,
                            "border-top-color" => RuleType.borderTopColor,
                            "border-top-left-radius" => RuleType.borderTopLeftRadius,
                            "border-top-right-radius" => RuleType.borderTopRightRadius,
                            "border-top-width" => RuleType.borderTopWidth,
                            "border-width" => RuleType.borderWidth,
                            "bottom" => RuleType.bottom,
                            "color" => RuleType.color,
                            "cusror" => RuleType.cursor,
                            "display" => RuleType.display,
                            "flex" => RuleType.flex,
                            "flex-basis" => RuleType.flexBasis,
                            "flex-direction" => RuleType.flexDirection,
                            "flex-grow" => RuleType.flexGrow,
                            "flex-shrink" => RuleType.flexShrink,
                            "flex-wrap" => RuleType.flexWrap,
                            "font-size" => RuleType.fontSize,
                            "height" => RuleType.height,
                            "justify-content" => RuleType.justifyContent,
                            "left" => RuleType.left,
                            "letter-spacing" => RuleType.letterSpacing,
                            "margin" => RuleType.margin,
                            "margin-bottom" => RuleType.marginBottom,
                            "margin-left" => RuleType.marginLeft,
                            "margin-right" => RuleType.marginRight,
                            "margin-top" => RuleType.marginTop,
                            "max-height" => RuleType.maxHeight,
                            "max-width" => RuleType.maxWidth,
                            "min-height" => RuleType.minHeight,
                            "min-width" => RuleType.minWidth,
                            "opacity" => RuleType.opacity,
                            "overflow" => RuleType.overflow,
                            "padding" => RuleType.padding,
                            "padding-bottom" => RuleType.paddingBottom,
                            "padding-left" => RuleType.paddingLeft,
                            "padding-right" => RuleType.paddingRight,
                            "padding-top" => RuleType.paddingTop,
                            "position" => RuleType.position,
                            "right" => RuleType.right,
                            "rotate" => RuleType.rotate,
                            "scale" => RuleType.scale,
                            "text-overflow" => RuleType.textOverflow,
                            "text-shadow" => RuleType.textShadow,
                            "top" => RuleType.top,
                            "transform-origin" => RuleType.transformOrigin,
                            "transition" => RuleType.transition,
                            "transition-delay" => RuleType.transitionDelay,
                            "transition-duration" => RuleType.transitionDuration,
                            "transition-property" => RuleType.transitionProperty,
                            "transition-timing-function" => RuleType.transitionTimingFunction,
                            "translate" => RuleType.translate,
                            "-unity-background-image-tint-color" => RuleType.unityBackgroundImageTintColor,
                            "-unity-background-scale-mode" => RuleType.unityBackgroundScaleMode,
                            "-unity-font" => RuleType.unityFont,
                            "-unity-font-definition" => RuleType.unityFontDefinition,
                            "-unity-font-style" => RuleType.unityFontStyle,
                            "-unity-overflow-clip-box" => RuleType.unityOverflowClipBox,
                            "-unity-paragraph-spacing" => RuleType.unityParagraphSpacing,
                            "-unity-slice-bottom" => RuleType.unitySliceBottom,
                            "-unity-slice-left" => RuleType.unitySliceLeft,
                            "-unity-slice-right" => RuleType.unitySliceRight,
                            "-unity-slice-scale" => RuleType.unitySliceScale,
                            "-unity-slice-top" => RuleType.unitySliceTop,
                            "-unity-text-align" => RuleType.unityTextAlign,
                            "-unity-text-outline" => RuleType.unityTextOutline,
                            "-unity-text-outline-color" => RuleType.unityTextOutlineColor,
                            "-unity-text-outline-width" => RuleType.unityTextOutlineWidth,
                            "-unity-text-overflow-position" => RuleType.unityTextOverflowPosition,
                            "visiblity" => RuleType.visibility,
                            "white-space" => RuleType.whiteSpace,
                            "width" => RuleType.width,
                            "word-spacing" => RuleType.wordSpacing,
                            _ => definition.StartsWith("--") ? RuleType.Variable : RuleType.NativeProperty
                        };
                    }
                }
            }
        }
    }
}