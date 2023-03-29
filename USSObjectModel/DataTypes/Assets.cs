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
                /// Create an asset path reference wrapped around the url() USS function. <br></br>
                /// Does not require quotation marks around the URL Path. <br></br><br></br>
                /// For all compatible url path definition styles, see <see href="https://docs.unity3d.com/2023.2/Documentation/Manual/UIE-USS-PropertyTypes.html">USS Property Types</see>
                /// </summary>
                public class URLAsset
                {
                    public string value;

                    public URLAsset(string assetPath)
                    {
                        value = $"url(\"{assetPath}\")";
                    }

                    /// <summary>
                    /// Return the url() USS function generated.
                    /// </summary>
                    public override string ToString() => value;
                }

                /// <summary>
                /// Create an asset path reference wrapped around the resource() USS function. <br></br>
                /// Does not require quotation marks around the Resource Path. <br></br><br></br>
                /// For all compatible resource path definition styles, see <see href="https://docs.unity3d.com/2023.2/Documentation/Manual/UIE-USS-PropertyTypes.html">USS Property Types</see>
                /// </summary>
                public class ResourceAsset
                {
                    public string value;

                    public ResourceAsset(string assetPath)
                    {
                        value = $"resource(\"{assetPath}\")";
                    }
                    
                    /// <summary>
                    /// Return the resource() USS function generated.
                    /// </summary>
                    public override string ToString() => value;
                }
            }
        }
    }
}