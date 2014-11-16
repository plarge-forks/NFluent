﻿// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="DecimalSignedCheckExtensions.cs" company="">
// //   Copyright 2013 Thomas PIERRAIN
// //   Licensed under the Apache License, Version 2.0 (the "License");
// //   you may not use this file except in compliance with the License.
// //   You may obtain a copy of the License at
// //       http://www.apache.org/licenses/LICENSE-2.0
// //   Unless required by applicable law or agreed to in writing, software
// //   distributed under the License is distributed on an "AS IS" BASIS,
// //   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// //   See the License for the specific language governing permissions and
// //   limitations under the License.
// // </copyright>
// // --------------------------------------------------------------------------------------------------------------------
namespace NFluent
{
    using System;

    /// <summary>
    /// Provides check methods to be executed on an <see cref="decimal"/> value that is considered as a signed number.
    /// </summary>
    public static class DecimalSignedCheckExtensions
    {
        #pragma warning disable 169

        //// ---------------------- WARNING ----------------------
        //// AUTO-GENERATED FILE WHICH SHOULD NOT BE MODIFIED!
        //// To change this class, change the one that is used
        //// as the golden source/model for this autogeneration
        //// (i.e. the one dedicated to the integer values).
        //// -----------------------------------------------------

        // Since this class is the model/template for the generation of all the other signed numbers related CheckExtensions classes, don't forget to re-generate all the other classes every time you change this one. To do that, just save the ..\T4\NumberFluentAssertionGenerator.tt file within Visual Studio 2012. This will trigger the T4 code generation process.

        /// <summary>
        /// Checks that the actual value is strictly positive.
        /// </summary>
        /// <param name="check">The fluent check to be extended.</param>
        /// <returns>
        /// A check link.
        /// </returns>
        /// <exception cref="FluentCheckException">The value is not strictly positive.</exception>
        [Obsolete("Use IsGreaterThanZero instead.")]
        public static ICheckLink<ICheck<decimal>> IsPositive(this ICheck<decimal> check)
        {
            var numberCheckStrategy = new NumberCheck<decimal>(check);
            return numberCheckStrategy.IsGreaterThanZero();
        }

        /// <summary>
        /// Checks that the actual value is greater than zero.
        /// </summary>
        /// <param name="check">The fluent check to be extended.</param>
        /// <returns>
        /// A check link.
        /// </returns>
        /// <exception cref="FluentCheckException">The value is not greater than zero.</exception>
        public static ICheckLink<ICheck<decimal>> IsGreaterThanZero(this ICheck<decimal> check)
        {
            var numberCheckStrategy = new NumberCheck<decimal>(check);
            return numberCheckStrategy.IsGreaterThanZero();
        }

        /// <summary>
        /// Checks that the actual value is strictly negative.
        /// </summary>
        /// <param name="check">The fluent check to be extended.</param>
        /// <returns>
        /// A check link.
        /// </returns>
        /// <exception cref="FluentCheckException">The value is not strictly positive.</exception>
        [Obsolete("Use IsLessThanZero instead.")]
        public static ICheckLink<ICheck<decimal>> IsNegative(this ICheck<decimal> check)
        {
            var numberCheckStrategy = new NumberCheck<decimal>(check);
            return numberCheckStrategy.IsNegative();
        }

        /// <summary>
        /// Checks that the actual value is less than zero.
        /// </summary>
        /// <param name="check">The fluent check to be extended.</param>
        /// <returns>
        /// A check link.
        /// </returns>
        /// <exception cref="FluentCheckException">The value is not less than zero.</exception>
        public static ICheckLink<ICheck<decimal>> IsLessThanZero(this ICheck<decimal> check)
        {
            var numberCheckStrategy = new NumberCheck<decimal>(check);
            return numberCheckStrategy.IsNegative();
        }
    }
}
