using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

using UnityEditor;
using UnityEditor.UIElements;

// This script builds "UI.Horizontal" into Cappuccino.Core.UI. - UI.Horizontal is entirely optional.
// If you prefer to not have to separate the contents of your Editor into multiple methods, use GUILayout.BeginHorizontal() and GUILayout.EndHorizontal()

namespace Cappuccino
{
    namespace Core
    {
        /// <summary>
        /// A static class for Diagnostics and Erorr handling methods. <br></br>
        /// <b><see langword="Notice:"/></b> Unlike other classes in Cappuccino, this class is vital for erorr handling and should not be removed.
        /// </summary>
        public static partial class Diag
        {
            /// <summary>
            /// Alert the developer that a violation has occured when trying to draw a UI Element with Cappucicno. <br></br>
            /// <b><see langword="Cappuccino:"/></b> Uses LogWarning to prevent any hard errors from appearing in console.
            /// </summary>
            /// <param name="context"> The message to display as the context for which method's execution requirements were violated.</param>
            public static void Violation(string context)
            {
                if (context == null)
                {
                    Violation("Violation of Diag.Violation(string context) -> no context message for violation.");
                    return;
                }

                // Get the entire list of methods that have been called up to this point. 
                System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace(true);

                // Get the method that was before the one triggering this violation.
                // We use GetFrame(2) as the hierarchy is:
                //      0 - this method (last added to the stack, first out)
                //      1 - the method invoking this method (second out)
                //      2 - the method we want to warn for by default, assuming this triggers error 1 (third out)
                System.Diagnostics.StackFrame invoker = stackTrace.GetFrame(2);

                Debug.LogWarning($"[Cappuccino] {context} \n" +
                    $"Called from: {invoker.GetMethod()} at Line {invoker.GetFileLineNumber()}\n\n" +
                    $"Script: {invoker.GetFileName()}\n");
            }

            /// <summary>
            /// Alert the developer that a violation has occured when trying to draw a UI Element with Cappucicno. <br></br>
            /// <b><see langword="Cappuccino:"/></b> Uses LogWarning to prevent any hard errors from appearing in console.
            /// </summary>
            /// <param name="context"> The message to display as the context for which method's execution requirements were violated.</param>
            /// <param name="diagnosticsFrame"> Which method to mark up as the one to be warned. <br></br> 0 is the current method and every increment is the previous method in the chain.</param>
            public static void Violation(string context, int diagnosticsFrame)
            {
                if (context == null)
                {
                    Violation("Violation of Diag.Violation(string context, int diagnosticsFrame) -> no context message for violation.");
                    return;
                }

                if (diagnosticsFrame < 0)
                {
                    Violation("Violation of Diag.Violation(string context, int diagnosticsFrame) -> diagnosticsFrame is less than 0.");
                    return;
                }

                // Get the entire list of methods that have been called up to this point. 
                System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace(true);

                // perform a safeguard action that accounts for an overflow where diagnosticsFrame is greater than stackTrace.FrameCount.
                diagnosticsFrame = diagnosticsFrame % stackTrace.FrameCount;

                // Get the method at the provided StackFrame within the StackTrace.
                System.Diagnostics.StackFrame invoker = stackTrace.GetFrame(diagnosticsFrame);

                Debug.LogWarning($"[Cappuccino] {context} \n" +
                    $"Called from: {invoker.GetMethod()} at Line {invoker.GetFileLineNumber()}\n\n" +
                    $"Script: {invoker.GetFileName()}\n");
            }
        }
    }
}
