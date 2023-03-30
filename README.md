# Iroquois - USS Object Model
The Iroquois USS Object Model ("USSOM") is designed to allow developers the ability to create Unity Style Sheets from within C#. We believe that you should be able to follow the editor tutorials you want without having to step out of your comfort zone. 

Containing every style rule and every (safe) set of parameters that Unity Style Sheets, this model aims to be compliant to the USS Specification and, where necessary, the CSS3 specification that the import-export .NET library **ExCSS** abides by, which is used by Unity Technologies for importing USS files.

**Recommended IDE:** Visual Studio 2022 Community - All XML Documentation is designed in and compatible with this IDE.

**Engine Version:** Unity Engine 2021.3 or later.

**Notice:** The Iroquois USS Object Model is not validated to work during runtime (as part of games themselves). It is designed and focused on assisting the creation of Plugins and Editor Windows. Feel free to test and to modify at your own risk.

## Quick-Start with the USS Object Model
#### 1. Installing USS Object Model
Firstly, download the contents of the repository and Import the USSObjectModel folder into `Assets/Editor`. Any general directory is fine, as long the USSObjectModel folder is within an `Editor` Folder, to prevent compilation with runtime games in Unity Engine.

#### 2. Adding USS Object Model to a C# Script
With the files imported, go into the C# script you are looking to utilise the USSOM with and include the following namespace at the top:
```C#
using Cappuccino.Interpreters.Languages.USS;

// The namespace will change when the USS Object Model is fully complete and rigorously tested.
// This is a namespace for an in-development framework which is currently not public.
```

#### 3. Getting Started

USS Object Model follows the same general concept as USS. Creating a style sheet starts with defining a style sheet itself:
```C#
StyleSheet sheet = new StyleSheet("myStyleSheet"); 
    // Create a Unity Style Sheet named "myStyleSheet".
```
The next step is to define a **USS Selector** ("SimpleSelector", "ComplexSelector" or "SelectorList") and a **USS Property** ("StyleRule"). As a demonstration, we'll be adding some related to Unity's GraphView API (a common use-case):

```C#
// ...

StyleRule gridColor = Rules.Variable("--grid-background-color", new ColorRGBA(51, 51, 51, 0.4f));
    // Create a USS Variable that will provide a dark grey color to the Grid Background.

Selector gridBackground = SimpleSelector.Type("GridBackground", gridColor); 
    // Create a Type Selector called "GridBackground", which targets the object type for a GraphView window.
    // Specify the gridColor style rule within the USS Selector.
```


Now that there is a USS Selector and USS Property defined. The property can be added to the selector, followed by the selector being added to the StyleSheet. The final complete code should look like this: 

```C#
// ...

sheet.Add(gridBackground);          // Add the GridBackground type selector to the StyleSheet.
```

With the style sheet assembled using the USSOM, we can export it. The USSOM will already be set to saving within the `Assets` folder, so only subsequent directories are required. Additionally, the exporter will create any missing directories as a fail-safe.

```C#
sheet.Export("Editor/DemonstrationStyleSheets"); 
    // You can only write the file once. Overwriting is disabled and will error. 

sheet.Export("Editor/DemonstrationStyleSheets", true); 
    // You can write or overwrite the file. Providing "true" as the second parameter allows file overwriting.
```

Once the export has finished, the final style sheet should appear in `Assets/Editor/DemonstrationStyleSheets/` as "myStyleSheet.uss". Inside will be a clearly structured selector and definition, forming one "USS Rule": 

```css
GridBackground {
     --grid-background-color: rgba(51, 51, 51, 0.4);
}
```
***

#### Shortucts

There are times where what you're doing only uses one USS Selector and you don't want to go through the process of creating excess data just for quick styling options (and/or changes). There are a few tricks up the sleeve of USSOM that you can utilise to make the process of creation easier.


Selectors have `Export()` built into the class. Instead of exporting a style sheet directly, you can create a selector with some style rules and export it. The example from above using this method would instead be:

```C#
StyleRule gridColor = Rules.Variable("--grid-background-color", new ColorRGBA(51, 51, 51, 0.4f));
Selector gridBackground = SimpleSelector.Type("GridBackground", gridColor); 

gridBackground.Export("myStyleSheet", "Editor/DemonstrationStyleSheets", true)
    // You need to provide a style sheet name first as Selectors do not have a "name", except for simple selectors.

```

Another shortcut is the abiltiy to concatenate StyleRule objects inside a Selector constructor. This isn't explicitly recommended if the selector you are trying to define is a complex selector or selector list. As the USSOM uses `params` arguements for Selectors and StyleRules, it is possible to define multiple at once. Here are some examples:


```C#
// Multiple Rules inside a Selector.

Selector gridBackground = SimpleSelector.Type("GridBackground",
    Rules.Variable("grid-background-color", new ColorHex(0x2B, 0x2B, 0x2B)),
    Rules.Variable("line-color", new ColorRGBA(51, 51, 51, 0.4f))
    ); 
```

```C#
// Multiple Selectors inside a Complex Selector.

ComplexSelector cs = ComplexSelector.Descendant(
    new SimpleSelector[]
    {
        SimpleSelector.Type("GridBackground"),
        SimpleSelector.Class("tempClassName")
    },
    Rules.Variable("grid-background-color", new ColorHex(0x2B, 0x2B, 0x2B)),
    Rules.Variable("line-color", new ColorRGBA(51, 51, 51, 0.4f))
    );
```
***

### Where are all the Properties?

They're all in and ready for your use, *even ones exclusive to Unity Engine 2022.2 or later*. If you want to generally know how to create a property, they're within the `Rules` class, which defines all 92 built-in USS Properties (as of 2022.2), as well as 2 extra for variables and native properties. Each property constructor translates almost directly from the original format of the property using Camel Case and removing hyphens (due to C#). 

E.G. 
`background-image` becomes `BackgroundImage()` and `border-bottom-left-radius` becomes `BorderBottomLeftRadius()`

**USS Properties that use keywords as parameters have custom enumerators for the keywords they support.** This was an excessive, exhaustive and long-winded approach for property constructors, however it wasn't without merit. It would have taken longer to have written every single keyword that USS and CSS support and create restrictions for which keywords each property would accept, possibly leading to long chains of "||" checks within an if-else statement, which wasn't worthwhile. Taking this approach assured me  that whatever a developer would give as a keyword *was correct, as per the specifications*. Additionally, any keywords that had hyphens in them required custom extension methods called `Name()` to restore the hyphen during the export process.

**USS Properties that can take multiple sets of the same** ***n*** **constructors have custom objects.** Some properties can take multiple lists of values, separated by a comma for each list in the chain. An example being `transition`, which can take two to four parameters for a single animated transition ***or*** one or more `TransitionValue` objects, which represent the construction of one `transition` as part of a comma-separated list of animated transitions in a `transition` property.

**USS Properties that can take <color> values have four constructors for each type you can use.** As the *<color>* data type is split into `ColorHex`, `ColorRGB`, `ColorRGBA` and `ColorKeyword`, it is necessary to require all four variations to provide complete compatibility.

Some exceptions are made and highlighted later on in **Changes from CSS/USS** as they are tricky properties to translate into C# almost one-to-one.
## Selectors
One of the major elements within CSS Rules is the selector, for which there are a handful of types. In USS, there are four main types that exist and there is a hierarchy for them based on what the CSS and USS specifications have outlined. The overall hierarchy is as follows:

| C# Type | Level | Abstract | Constructible | Containable | Compatible Selectors |
| ---- | ---: | ---: | ---: | ---: | --- |
| **Selector** | 0 | Yes | No | No | None |
| **Pseudoclass** | 1 | No | No | Simple Selectors Only | None
| **SimpleSelector** | 2 | No | Yes | Yes |  Pseudoclass |
| **ComplexSelector** | 3 | No | Yes | Yes | SimpleSelector |
| **SelectorList** | 4 | No | Yes | No | SimpleSelector, ComplexSelector |

```
Constructible - Can the selector be constructed with a name or list of other selectors?
Containable - Whether or not the selector can be contained by other selectors with a higher level.
Compatible Selectors - The other selectors that the selector can contain specifically.
```
***

**Selectors**

The base class that any and all Selectors derive from, containing a majority of the core functions which all inheriting selectors derive from or override with unique methods. These cannot be constructed and serve as a general container which you can store various selectors in.

***
**Pseudoclasses**

| Constructor | Definition |
| :--- | :--- |
| new Pseudoclass() | Create a new pseudoclass object of the provided pseudoclass type. Direct constructor. |
| Pseudoclass.Hover() | Create a pseudoclass for the `:hover` pseudo-class type. |
| Pseudoclass.Active() | Create a pseudoclass for the `:active` pseudo-class type. |
| Pseudoclass.Inactive() | Create a pseudoclass for the `:inactive` pseudo-class type. |
| Pseudoclass.Focus() | Create a pseudoclass for the `:focus` pseudo-class type. |
| Pseudoclass.Selected() | Create a pseudoclass for the `:selected` pseudo-class type. |
| Pseudoclass.Disabled() | Create a pseudoclass for the `:disabled` pseudo-class type. |
| Pseudoclass.Enabled() | Create a pseudoclass for the `:enabled` pseudo-class type. |
| Pseudoclass.Checked() | Create a pseudoclass for the `:checked` pseudo-class type. |

Although technically simple selectors, pseudoclasses cannot be created or customized and they can only be given to Simple Selectors. They are in essence definitions for the "state" of a visual element which restrict whether or not a Selector can match with that element. If a Simple Selector is suffixed with one or more pseudoclasses (with the exception of *:root*), the selector will only match with the Visual Element(s) that are in the state specified. 

For example, if a button is in an interface and a pseudoclass of `:hover` is applied to a selector that targets the button from within a .uss file, the declarations that are contained within the selector will only apply if the mouse is hovering over the button.

***
**Simple Selectors**

These selectors have been introduced above and they have five unique constructors for five unique types of selector. The last of which is unique to the USS Object Model in that it is a Pseudoclass rather than a native Simple Selector.

| Constructor | Definition |
| :--- | :--- |
| SimpleSelector.Type() | Create a Type Selector which matches elements based on their element type in a UXML tag. |
| SimpleSelector.Name() | Create a Name Selector which matches elements based on their name in a UXML tag, prefixed with [ # ]. |
| SimpleSelector.Class() | Create a Class Selector which matches elements based on their assigned class in a UXML tag. Prefixed with [ . ]. |
| SimpleSelector.Universal() | Create a Universal Selector that matches any element. |
| SimpleSelector.Root() | Create a Root Selector, which matches the highest element in a visual tree in UXML. |

***Notice:*** If you wish to use a simple selector within a complex selector or selector list, you use the constructor that only takes in a name parameter. These constructors are supplied for simplified bulk adding and are not valid for creating a selector to add StyleRule objects to. If you attempt to use a selector with StyleRule objects, the StyleRule objects will be ingnored as part of the Complex Selector or Selector List and only the ones directly attached to the Complex Selector or Selector List will be exported.

***
**Complex Selectors** 

Unlike simple selectors, complex selectors cannot be assigned names and can only consist of simple selectors and style rules. There are three complex selectors:

| Constructor | Definition |
| :--- | :--- |
| ComplexSelector.Descendant() | Create a Descendant Selector which matches elements that descendant to another element. |
| ComplexSelector.Child() | Create a Child Selector which matches elements which are the child of another element. |
| ComplexSelector.Multiple() | Create a Multiple Selector which matches elements that match all Simple Selectors within. |

***Notice:*** If you wish to use a complex selector within a selector list, you have to use the constructor that only takes in Simple Selectors. These constructors are supplied for simplified bulk-adding and are not valid for creating a selector to add StyleRule objects to. If you attempt to use a selector with StyleRule objects, the StyleRule objects will be ingnored as part of the Selector List and only the ones directly attached to the Selector List will be exported.
***

**Selector List**

A selector list is a list of Simple Selectors and Complex Selectors that share the same set of declarations (aka "Style Rule") and each selector is separated with a comma. This type of Selector is useful for having declarations which affect multiple elements at once, if they are compatible with the declarations.

Only one constructor exists for a Selector List:

| Constructor | Definition |
| :--- | :--- |
| new SelectorList() | Create a SelectorList for a comma-separated list of selectors that share the same declarations. ("StyleRule")|

Selector Lists in the USSOM also have an additional ability. You can join USSOM Selector Lists together using `SelectorList.Join()` (a static method), passing in any number of other selector lists and receiving the resulting SelectorList object.
***
## Changes from CSS/USS
The USSOM cannot share all of the names and terminology that the main language has due to conflicts with C# and/or Unity Engine. Additionally some names were changed due to multiple values. For clarity's sake, these changes were made to the USS nomenclature:

***
#### Main Changes
| New Name | Old Name | Change Reason
| ---- | ---- | ---- |
| StyleRule | Property | Class Conflicts with some object types in Unity Engine and other packages.

A **StyleRule** in the USS Object Model is a *Declaration*. A declaration consists of a property and a value within a USS selector that follows this structure; `property-name: value;`.

For those versed in CSS/USS, this is an *improperly used* term. To avoid having multiple objects being prefixed with "USS" and causing a different issue, the choice was made to improperly apply the nomenclature as it still reflects the concept at hand and is only accessible to scripts that include the namespace denoted in **Using the USS Object Model**. 
***

#### Selector Changes
An additional selector is provided with the main four types of **Simple Selectors**. The additional type is SimpleSelector.Root(), which denotes the highest-level visual element. The choice to separate this from the general pseudo-classes is due to the nature that it refers to a Visual Element rather than a state of an element. (e.g. *:hover* for the mouse cursor being over the visual element)
***

#### Data Type Changes
| New Data Type | Old Data Type | Change Reason 
| ---- | ---- | ---- |
| ColorHex | `<Color>` | Color consists of several value types. ColorHex is for hexadecimal **(#RRGGBB)** values. |
| ColorRGB | `<Color>` | Color consists of several value types. ColorRGB is for **rgb(0-255, 0-255, 0-255)** values. |
| ColorRGBA | `<Color>` | Color consists of several value types. ColorRGBA is for **rgba(0-255, 0-255, 0-255, 0.0-1.0)** values. |
| ColorKeyword | `<Color>` | Color consists of several value types. ColorKeyword is for Keywords representing a color. |
| Duration | `<Time>` | UnityEngine.Time conflict. Duration is used as <Time> is a value provided for a duration of time. |

***
#### USS Property Changes
Finally, the C# Method Constructors for some USS Properties were changed between the conversion from Native USS to USS Object Model. These changes were for ease of access. These properties are the ones in the USS Properties Reference prefixed with `-unity`.

| USS Object Model Constructor | USS Property Name |    
| ---- | ---- |
| BackgroundImageTintColor(...) | -unity-background-image-tint-color: ... ; |
| BackgroundScaleMode(...) | -unity-background-scale-mode: ... ; |
| UnityFont(...) | -unity-font: ... ; |
| UnityFontDefinition(...) | -unity-font-definition: ... ; |
| UnityFontStyle(...) | -unity-font-style: ... ; |
| OverflowClipBox(...) | -unity-overflow-clip-box: ... ; |
| ParagraphSpacing(...) | -unity-paragraph-spacing: ... ; |
| SliceBottom(...) | -unity-slice-bottom: ... ; |
| SliceLeft(...) | -unity-slice-left: ... ; |
| SliceRight(...) | -unity-slice-right: ... ; |
| SliceScale(...) | -unity-slice-scale: ... ; |
| SliceTop(...) | -unity-slice-top: ... ; |
| TextAlign(...) | -unity-text-align: ... ; |
| TextOutline(...) | -unity-text-outline: ... ; |
| TextOutlineColor(...) | -unity-text-outline-color: ... ; |
| TextOutlineWidth(...) | -unity-text-outline-width: ... ; |
| TextOverflowPosition(...) | -unity-text-overflow-position: ... ; |

## Reading the Source Code
Some of you might want to fork your own (or write your own) USS Interpreter which use an object-oriented approach. For this, USSOM is already heavily commented and documented within the source code. Not only that but a clear file structure has been presented as necessary for your benefit, based almost entirely on Unity's own USS Properties pages.

The file defining **StyleSheet** is in the highest level folder of the source code: `.../USSObjectModel/StyleSheet.cs`

The files defining **Selector Classes** are found within the Selectors folder: `.../USSObjectModel/Selectors/`

The files defining **Data Types** are found within the DataTypes folder: `.../USSObjectModel/DataTypes/`

The files defining **Enumerators*** are found within the Enums folder: `.../USSObjectModel/Enums/`

The files defining **USS Properties ("StyleRule" constructors)*** are found within the StyleRule folder: `.../USSObjectModel/StyleRule/Constructors/`

The dependencies of the Iroquois USS Object Model are found within the Dependencies Folder: `.../USSObjectModel/Dependencies/`.
***
**Finding USS Properties**

Each set of USS Property constructors follow the organization of Unity Technologies' page ***USS Common Properties***. Every property listed on that page is in a folder labelled exactly the same as the section they are in.

Properties not found in the USS Common Properties are in the following folders:
| USS Property | File Path | Version Restriction |
| :--- | :--- | :--- |
| background-position | `.../StyleRule/Constructors/BackgroundImage/BackgroundPosition.cs` | Unity Engine 2022.2+ |
| background-position-x | `.../StyleRule/Constructors/BackgroundImage/BackgroundPositionX.cs` | Unity Engine 2022.2+ |
| background-position-y | `.../StyleRule/Constructors/BackgroundImage/BackgroundPositionY.cs` | Unity Engine 2022.2+ |
| background-repeat | `.../StyleRule/Constructors/BackgroundImage/BackgroundRepeat.cs` | Unity Engine 2022.2+ |
| background-size | `.../StyleRule/Constructors/BackgroundImage/BackgroundSize.cs` | Unity Engine 2022.2+ |
| border-bottom-color | `.../StyleRule/Constructors/Borders/BorderBottomColor.cs` | Any |
| border-left-color  | `.../StyleRule/Constructors/Borders/BorderLeftColor.cs` | Any|
| border-right-color  | `.../StyleRule/Constructors/Borders/BorderRightColor.cs` | Any |
| border-top-color  | `.../StyleRule/Constructors/Borders/BorderTopColor.cs` | Any |
| letter-spacing | `.../StyleRule/Constructors/TextProperties/LetterSpacing.cs` | Any |
| text-overflow | `.../StyleRule/Constructors/TextProperties/TextOverflow.cs` | Any |
| text-shadow | `.../StyleRule/Constructors/TextProperties/TextShadow.cs` | Any |
| word-spacing | `.../StyleRule/Constructors/TextProperties/WordSpacing.cs` | Any |
| rotate | `.../StyleRule/Constructors/Transform/Rotate.cs` | Any |
| scale | `.../StyleRule/Constructors/Transform/Scale.cs` | Any |
| transform-origin | `.../StyleRule/Constructors/Transform/TransformOrigin.cs` | Any |
| translate | `.../StyleRule/Constructors/Transform/Translate.cs` | Any |
| transition | `.../StyleRule/Constructors/Transition/Transition.cs` | Any |
| transition-delay | `.../StyleRule/Constructors/Transition/TransitionDelay.cs` | Any |
| transition-duration | `.../StyleRule/Constructors/Transition/TransitionDuration.cs` | Any |
| transition-property | `.../StyleRule/Constructors/Transition/TransitionProperty.cs` | Any |
| transition-timing-function | `.../StyleRule/Constructors/Transition/TransitionTimingFunction.cs` | Any |


Properties marked with "Any" compatibility refer to any version that has a recent version of USS included:
```
    Unity Engine 2018.1+: Partially Incompatible(?)    - Not Recommended
    Unity Engine 2019.1+: Partially Incompatible(?)    - Not Recommended
    Unity Engine 2020.1+: Partially Incompatible(?)    - Not Tested
    Unity Engine 2021.1+: Comatible                    - (2021.3 Recommended)
    Unity Engine 2022.1+: Compatible                   - (2022.2 Known)
    Unity Engine 2023.1+: Compatbile                   - Not Tested
```

***
*Not all Enumerators are stored within the Enums folder. A majority of the property-specific enumerators are kept with the relavent property found within the script that stores the constructor. Others are stored separately in `.../StyleRule/Constructors/_Global/` or within the folder containing the constructor's script.
## Limitations
At the time of writing, the USSOM only supports *Creating and Exporting* style sheets as a ".uss" file into a specified directory within your Unity Project's assets folder.

Some Style Rules provided are not available in some versions of Unity Engine, being accessible only to Unity Engine 2022.2 or newer.
    
## Credits
The Iroquois USS Object Model has been created by Alexander Gilbertson. This repository contains the contents of a major element, alongside minor elements, of a larger package currently in-development as part of University Coursework (to be released at a later date). This repository has been allowed to release early by course leaders.
    
Iroquois USS Object Model makes heavy use of the following resources:
    
    https://docs.unity3d.com/2023.1/Documentation/Manual/UIE-USS-SupportedProperties.html
    https://docs.unity3d.com/2023.1/Documentation/Manual/UIE-USS-Properties-Reference.html
    https://developer.mozilla.org/en-US/docs/Web/CSS
    https://css-tricks.com/snippets/css/a-guide-to-flexbox/
    https://www.w3.org/TR/2018/REC-selectors-3-20181106/#attribute-selectors
    https://www.w3.org/TR/selectors-4/
