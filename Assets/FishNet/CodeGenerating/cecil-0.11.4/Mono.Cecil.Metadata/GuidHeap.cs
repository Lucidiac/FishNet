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

namespace MonoFN.Cecil.Metadata
{
    internal sealed class GuidHeap : Heap
    {
        public GuidHeap(byte[] data) : base(data) { }

        public Guid Read(uint index)
        {
            const int guid_size = 16;

            if (index == 0 || index - 1 + guid_size > data.Length)
                return new();

            var buffer = new byte [guid_size];

            Buffer.BlockCopy(data, (int)((index - 1) * guid_size), buffer, 0, guid_size);

            return new(buffer);
        }
    }
}