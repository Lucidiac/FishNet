//
// Author:
//   Jb Evain (jbevain@gmail.com)
//
// Copyright (c) 2008 - 2015 Jb Evain
// Copyright (c) 2008 - 2011 Novell, Inc.
//
// Licensed under the MIT/X11 license.
// 

using System;

namespace MonoFN
{
    internal static class Disposable
    {
        public static Disposable<T> Owned<T>(T value) where T : class, IDisposable
        {
            return new(value, owned: true);
        }

        public static Disposable<T> NotOwned<T>(T value) where T : class, IDisposable
        {
            return new(value, owned: false);
        }
    }

    internal struct Disposable<T> : IDisposable where T : class, IDisposable
    {
        internal readonly T value;
        private readonly bool owned;

        public Disposable(T value, bool owned)
        {
            this.value = value;
            this.owned = owned;
        }

        public void Dispose()
        {
            if (value != null && owned)
                value.Dispose();
        }
    }
}