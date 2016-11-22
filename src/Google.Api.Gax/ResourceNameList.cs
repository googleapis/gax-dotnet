/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Google.Api.Gax
{
    /// <summary>
    /// A list of resource names of a specific type, that delegates all operations to an
    /// underlying list of string-based resource names.
    /// </summary>
    /// <typeparam name="TName">The type of the resource name contained in this list.</typeparam>
    public sealed class ResourceNameList<TName> : IList<TName> where TName : class, IResourceName
    {
        private readonly IList<String> _underlyingList;
        private readonly Func<TName, string> _nameToString;
        private readonly Func<string, TName> _stringToName;

        /// <summary>
        /// Constructs a <see cref="ResourceNameList{TName}"/> from an underlying string-based list
        /// and a resource name parser.
        /// </summary>
        /// <param name="underlyingList"></param>
        /// <param name="stringToName"></param>
        public ResourceNameList(IList<string> underlyingList, Func<string, TName> stringToName)
        {
            _underlyingList = underlyingList;
            _nameToString = name => GaxPreconditions.CheckNotNull(name, nameof(name)).ToString();
            _stringToName = str => stringToName(GaxPreconditions.CheckNotNull(str, nameof(str)));
        }

        /// <inheritdoc />
        public int Count => _underlyingList.Count;

        /// <inheritdoc />
        public bool IsReadOnly => _underlyingList.IsReadOnly;

        /// <inheritdoc />
        public TName this[int index]
        {
            get { return _stringToName(_underlyingList[index]); }
            set { _underlyingList[index] = _nameToString(value); }
        }

        /// <inheritdoc />
        public void Add(TName item) => _underlyingList.Add(_nameToString(item));

        /// <inheritdoc />
        public void Clear() => _underlyingList.Clear();

        /// <inheritdoc />
        public bool Contains(TName item) => _underlyingList.Contains(_nameToString(item));

        /// <inheritdoc />
        public void CopyTo(TName[] array, int arrayIndex)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));
            if (arrayIndex < 0) throw new ArgumentOutOfRangeException(nameof(arrayIndex), "Must be >= 0");
            if (Count > array.Length - arrayIndex) throw new ArgumentException("Copy operation must not exceed the array space available.");
            for (int i = 0; i < Count; i++)
            {
                array[arrayIndex + i] = _stringToName(_underlyingList[i]);
            }
        }

        /// <inheritdoc />
        public IEnumerator<TName> GetEnumerator() => _underlyingList.Select(_stringToName).GetEnumerator();

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        public int IndexOf(TName item) => _underlyingList.IndexOf(_nameToString(item));

        /// <inheritdoc />
        public void Insert(int index, TName item) => _underlyingList.Insert(index, _nameToString(item));

        /// <inheritdoc />
        public bool Remove(TName item) => _underlyingList.Remove(_nameToString(item));

        /// <inheritdoc />
        public void RemoveAt(int index) => _underlyingList.RemoveAt(index);
    }
}
