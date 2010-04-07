﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PersistentDictionaryTracing.cs" company="Microsoft Corporation">
//   Copyright (c) Microsoft Corporation.
// </copyright>
// <summary>
//   PersistentDictionary tracing code.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Microsoft.Isam.Esent.Collections.Generic
{
    using System;
    using System.Diagnostics;

    /// <content>
    /// PersistentDictionary tracing.
    /// </content>
    public partial class PersistentDictionary<TKey, TValue> where TKey : IComparable<TKey>
    {
        /// <summary>
        /// PersistentDictionary tracing.
        /// </summary>
        private readonly TraceSwitch traceSwitch = new TraceSwitch("PersistentDictionary", "PersistentDictionary");

        /// <summary>
        /// Gets the TraceSwitch for the dictionary.
        /// </summary>
        internal TraceSwitch TraceSwitch
        {
            get { return this.traceSwitch; }
        }

        /// <summary>
        /// Trace the results of examining a Where expression.
        /// </summary>
        /// <param name="range">The calculated range.</param>
        [Conditional("TRACE")]
        internal void TraceWhere(KeyRange<TKey> range)
        {
            Trace.WriteLineIf(this.traceSwitch.TraceVerbose, String.Format("WHERE: {0}", range));
        }
    }
}