﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExtendableCheckLink.cs" company="">
//   Copyright 2013 Cyrille DUPUYDAUBY
//   //   Licensed under the Apache License, Version 2.0 (the "License");
//   //   you may not use this file except in compliance with the License.
//   //   You may obtain a copy of the License at
//   //       http://www.apache.org/licenses/LICENSE-2.0
//   //   Unless required by applicable law or agreed to in writing, software
//   //   distributed under the License is distributed on an "AS IS" BASIS,
//   //   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   //   See the License for the specific language governing permissions and
//   //   limitations under the License.
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace NFluent.Kernel
{
    /// <summary>
    /// Provides an specific implementation for IEnumerable fluent check. Required to implement IEnumerable fluent API.
    /// </summary>
    /// <typeparam name="T">
    /// Type managed by this extension.
    /// </typeparam>
    /// <typeparam name="TU">Type of the reference comparand.</typeparam>
    internal class ExtendableCheckLink<T, TU> : CheckLink<T>, IExtendableCheckLink<T, TU> where T: class, IMustImplementIForkableCheckWithoutDisplayingItsMethodsWithinIntelliSense
    {
        private readonly TU originalComparand;
        private readonly T previousCheck;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtendableCheckLink{T,U}"/> class. 
        /// </summary>
        /// <param name="previousCheck">
        /// The previous fluent check.
        /// </param>
        /// <param name="originalComparand">
        /// Comparand used for the first check.
        /// </param>
        public ExtendableCheckLink(T previousCheck, TU originalComparand) : base(previousCheck)
        {
            this.originalComparand = originalComparand;
            this.previousCheck = previousCheck;
        }

        /// <summary>
        /// Gets the initial list that was used in Contains.
        /// </summary>
        /// <value>
        /// Initial list that was used in Contains.
        /// </value>
        TU IExtendableCheckLink<T, TU>.OriginalComparand => this.originalComparand;

        T IExtendableCheckLink<T, TU>.AccessCheck => this.previousCheck;
    }
}