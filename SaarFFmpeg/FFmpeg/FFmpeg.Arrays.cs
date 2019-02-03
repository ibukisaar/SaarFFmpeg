using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using Saar.FFmpeg.Structs;
using Saar.FFmpeg.CSharp;
using Saar.FFmpeg.Internal;
using Saar.FFmpeg.Delegates;

namespace Saar.FFmpeg.Support
{
    #pragma warning disable 169
    #pragma warning disable IDE1006 // 命名样式
    
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct double_arrayOfArray2
    {
        public const int Size = 2;
        public static readonly int ElementSize = sizeof(double_array399);
        public double_array399 _0, _1;
        
        public double_array399 this[int i]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { fixed (double_array399* p = &_0) return p[i]; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { fixed (double_array399* p = &_0) p[i] = value; }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Span<double_array399>(double_arrayOfArray2 @this) => new Span<double_array399>(Unsafe.AsPointer(ref @this._0), Size);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ReadOnlySpan<double_array399>(double_arrayOfArray2 @this) => new ReadOnlySpan<double_array399>(Unsafe.AsPointer(ref @this._0), Size);
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct short_array2
    {
        public const int Size = 2;
        public static readonly int ElementSize = sizeof(short);
        public fixed short _[2];
        
        public short this[int i]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _[i];
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => _[i] = value;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Span<short>(short_array2 @this) => new Span<short>(@this._, Size);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ReadOnlySpan<short>(short_array2 @this) => new ReadOnlySpan<short>(@this._, Size);
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct byte_ptrArray3
    {
        public const int Size = 3;
        public static readonly int ElementSize = sizeof(byte*);
        public byte* _0, _1, _2;
        
        public byte* this[int i]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { fixed (byte** p = &_0) return p[i]; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { fixed (byte** p = &_0) p[i] = value; }
        }
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct int_array3
    {
        public const int Size = 3;
        public static readonly int ElementSize = sizeof(int);
        public fixed int _[3];
        
        public int this[int i]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _[i];
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => _[i] = value;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Span<int>(int_array3 @this) => new Span<int>(@this._, Size);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ReadOnlySpan<int>(int_array3 @this) => new ReadOnlySpan<int>(@this._, Size);
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct short_arrayOfArray3
    {
        public const int Size = 3;
        public static readonly int ElementSize = sizeof(short_array2);
        public short_array2 _0, _1, _2;
        
        public short_array2 this[int i]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { fixed (short_array2* p = &_0) return p[i]; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { fixed (short_array2* p = &_0) p[i] = value; }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Span<short_array2>(short_arrayOfArray3 @this) => new Span<short_array2>(Unsafe.AsPointer(ref @this._0), Size);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ReadOnlySpan<short_array2>(short_arrayOfArray3 @this) => new ReadOnlySpan<short_array2>(Unsafe.AsPointer(ref @this._0), Size);
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct AVComponentDescriptor_array4
    {
        public const int Size = 4;
        public static readonly int ElementSize = sizeof(AVComponentDescriptor);
        public AVComponentDescriptor _0, _1, _2, _3;
        
        public AVComponentDescriptor this[int i]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { fixed (AVComponentDescriptor* p = &_0) return p[i]; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { fixed (AVComponentDescriptor* p = &_0) p[i] = value; }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Span<AVComponentDescriptor>(AVComponentDescriptor_array4 @this) => new Span<AVComponentDescriptor>(Unsafe.AsPointer(ref @this._0), Size);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ReadOnlySpan<AVComponentDescriptor>(AVComponentDescriptor_array4 @this) => new ReadOnlySpan<AVComponentDescriptor>(Unsafe.AsPointer(ref @this._0), Size);
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct byte_ptrArray4
    {
        public const int Size = 4;
        public static readonly int ElementSize = sizeof(byte*);
        public byte* _0, _1, _2, _3;
        
        public byte* this[int i]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { fixed (byte** p = &_0) return p[i]; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { fixed (byte** p = &_0) p[i] = value; }
        }
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct int_array4
    {
        public const int Size = 4;
        public static readonly int ElementSize = sizeof(int);
        public fixed int _[4];
        
        public int this[int i]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _[i];
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => _[i] = value;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Span<int>(int_array4 @this) => new Span<int>(@this._, Size);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ReadOnlySpan<int>(int_array4 @this) => new ReadOnlySpan<int>(@this._, Size);
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct long_array4
    {
        public const int Size = 4;
        public static readonly int ElementSize = sizeof(long);
        public fixed long _[4];
        
        public long this[int i]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _[i];
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => _[i] = value;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Span<long>(long_array4 @this) => new Span<long>(@this._, Size);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ReadOnlySpan<long>(long_array4 @this) => new ReadOnlySpan<long>(@this._, Size);
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct int_array5
    {
        public const int Size = 5;
        public static readonly int ElementSize = sizeof(int);
        public fixed int _[5];
        
        public int this[int i]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _[i];
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => _[i] = value;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Span<int>(int_array5 @this) => new Span<int>(@this._, Size);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ReadOnlySpan<int>(int_array5 @this) => new ReadOnlySpan<int>(@this._, Size);
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct AVBufferRef_ptrArray8
    {
        public const int Size = 8;
        public static readonly int ElementSize = sizeof(AVBufferRef*);
        public AVBufferRef* _0, _1, _2, _3, _4, _5, _6, _7;
        
        public AVBufferRef* this[int i]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { fixed (AVBufferRef** p = &_0) return p[i]; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { fixed (AVBufferRef** p = &_0) p[i] = value; }
        }
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct byte_array8
    {
        public const int Size = 8;
        public static readonly int ElementSize = sizeof(byte);
        public fixed byte _[8];
        
        public byte this[int i]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _[i];
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => _[i] = value;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Span<byte>(byte_array8 @this) => new Span<byte>(@this._, Size);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ReadOnlySpan<byte>(byte_array8 @this) => new ReadOnlySpan<byte>(@this._, Size);
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct byte_ptrArray8
    {
        public const int Size = 8;
        public static readonly int ElementSize = sizeof(byte*);
        public byte* _0, _1, _2, _3, _4, _5, _6, _7;
        
        public byte* this[int i]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { fixed (byte** p = &_0) return p[i]; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { fixed (byte** p = &_0) p[i] = value; }
        }
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct int_array8
    {
        public const int Size = 8;
        public static readonly int ElementSize = sizeof(int);
        public fixed int _[8];
        
        public int this[int i]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _[i];
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => _[i] = value;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Span<int>(int_array8 @this) => new Span<int>(@this._, Size);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ReadOnlySpan<int>(int_array8 @this) => new ReadOnlySpan<int>(@this._, Size);
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct ulong_array8
    {
        public const int Size = 8;
        public static readonly int ElementSize = sizeof(ulong);
        public fixed ulong _[8];
        
        public ulong this[int i]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _[i];
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => _[i] = value;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Span<ulong>(ulong_array8 @this) => new Span<ulong>(@this._, Size);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ReadOnlySpan<ulong>(ulong_array8 @this) => new ReadOnlySpan<ulong>(@this._, Size);
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct byte_array17
    {
        public const int Size = 17;
        public static readonly int ElementSize = sizeof(byte);
        public fixed byte _[17];
        
        public byte this[int i]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _[i];
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => _[i] = value;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Span<byte>(byte_array17 @this) => new Span<byte>(@this._, Size);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ReadOnlySpan<byte>(byte_array17 @this) => new ReadOnlySpan<byte>(@this._, Size);
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct long_array17
    {
        public const int Size = 17;
        public static readonly int ElementSize = sizeof(long);
        public fixed long _[17];
        
        public long this[int i]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _[i];
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => _[i] = value;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Span<long>(long_array17 @this) => new Span<long>(@this._, Size);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ReadOnlySpan<long>(long_array17 @this) => new ReadOnlySpan<long>(@this._, Size);
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct double_array399
    {
        public const int Size = 399;
        public static readonly int ElementSize = sizeof(double);
        public fixed double _[399];
        
        public double this[int i]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _[i];
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => _[i] = value;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Span<double>(double_array399 @this) => new Span<double>(@this._, Size);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ReadOnlySpan<double>(double_array399 @this) => new ReadOnlySpan<double>(@this._, Size);
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct byte_array1024
    {
        public const int Size = 1024;
        public static readonly int ElementSize = sizeof(byte);
        public fixed byte _[1024];
        
        public byte this[int i]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _[i];
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => _[i] = value;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Span<byte>(byte_array1024 @this) => new Span<byte>(@this._, Size);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ReadOnlySpan<byte>(byte_array1024 @this) => new ReadOnlySpan<byte>(@this._, Size);
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct byte_array61440
    {
        public const int Size = 61440;
        public static readonly int ElementSize = sizeof(byte);
        public fixed byte _[61440];
        
        public byte this[int i]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _[i];
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => _[i] = value;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Span<byte>(byte_array61440 @this) => new Span<byte>(@this._, Size);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ReadOnlySpan<byte>(byte_array61440 @this) => new ReadOnlySpan<byte>(@this._, Size);
    }
    
    #pragma warning restore IDE1006 // 命名样式
}
