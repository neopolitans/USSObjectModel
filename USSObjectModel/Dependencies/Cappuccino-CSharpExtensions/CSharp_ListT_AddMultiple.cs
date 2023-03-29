using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Cappuccino
{
    /// <summary>
    /// <see langword="Cappuccino:"/> A class containing various extension methods for C# types internally. <br></br>
    /// <b><see langword="Notice:"/> <i>Not for runtime use.</i></b> 
    /// </summary>
    public static partial class CSharp
    { 
        /// <summary>
        /// Add multiple elements of the same type to the list.
        /// </summary>
        /// <typeparam name="T">The list and element type.</typeparam>
        /// <param name="list">The list to add to.</param>
        /// <param name="elements">The elements to add.</param>
        public static void Add<T>(this List<T> list, params T[] elements)
        {
            foreach (T element in elements)
            {
                list.Add(element);
            }
        }
    }
}