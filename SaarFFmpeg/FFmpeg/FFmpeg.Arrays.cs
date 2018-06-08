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
        public static readonly int ElementSize = Marshal.SizeOf<double_array399>();
        double_array399 _0, _1;
        
        public ref double_array399 this[int i]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => ref Unsafe.AsRef<double_array399>(Unsafe.AsPointer(ref _0));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Span<double_array399>(double_arrayOfArray2 @this) => new Span<double_array399>(Unsafe.AsPointer(ref @this._0), Size);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ReadOnlySpan<double_array399>(double_arrayOfArray2 @this) => new ReadOnlySpan<double_array399>(Unsafe.AsPointer(ref @this._0), Size);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ref double_array399 GetPinnableReference() => ref this[0];
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct short_array2
    {
        public const int Size = 2;
        public static readonly int ElementSize = sizeof(short);
        fixed short _[2];
        
        public ref short this[int i]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => ref this._[i];
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Span<short>(short_array2 @this) => new Span<short>(@this._, Size);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ReadOnlySpan<short>(short_array2 @this) => new ReadOnlySpan<short>(@this._, Size);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ref short GetPinnableReference() => ref this[0];
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct byte_ptrArray3
    {
        public const int Size = 3;
        public static readonly int ElementSize = sizeof(byte*);
        byte* _0, _1, _2;
        
        public ref byte* this[uint i]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { fixed (byte** p = &_0) return ref *(p + i); }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ref byte* GetPinnableReference() => ref this[0];
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct int_array3
    {
        public const int Size = 3;
        public static readonly int ElementSize = sizeof(int);
        fixed int _[3];
        
        public ref int this[int i]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => ref this._[i];
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Span<int>(int_array3 @this) => new Span<int>(@this._, Size);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ReadOnlySpan<int>(int_array3 @this) => new ReadOnlySpan<int>(@this._, Size);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ref int GetPinnableReference() => ref this[0];
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct short_arrayOfArray3
    {
        public const int Size = 3;
        public static readonly int ElementSize = Marshal.SizeOf<short_array2>();
        short_array2 _0, _1, _2;
        
        public ref short_array2 this[int i]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => ref Unsafe.AsRef<short_array2>(Unsafe.AsPointer(ref _0));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Span<short_array2>(short_arrayOfArray3 @this) => new Span<short_array2>(Unsafe.AsPointer(ref @this._0), Size);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ReadOnlySpan<short_array2>(short_arrayOfArray3 @this) => new ReadOnlySpan<short_array2>(Unsafe.AsPointer(ref @this._0), Size);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ref short_array2 GetPinnableReference() => ref this[0];
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct AVComponentDescriptor_array4
    {
        public const int Size = 4;
        public static readonly int ElementSize = Marshal.SizeOf<AVComponentDescriptor>();
        AVComponentDescriptor _0, _1, _2, _3;
        
        public ref AVComponentDescriptor this[int i]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => ref Unsafe.AsRef<AVComponentDescriptor>(Unsafe.AsPointer(ref _0));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Span<AVComponentDescriptor>(AVComponentDescriptor_array4 @this) => new Span<AVComponentDescriptor>(Unsafe.AsPointer(ref @this._0), Size);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ReadOnlySpan<AVComponentDescriptor>(AVComponentDescriptor_array4 @this) => new ReadOnlySpan<AVComponentDescriptor>(Unsafe.AsPointer(ref @this._0), Size);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ref AVComponentDescriptor GetPinnableReference() => ref this[0];
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct byte_ptrArray4
    {
        public const int Size = 4;
        public static readonly int ElementSize = sizeof(byte*);
        byte* _0, _1, _2, _3;
        
        public ref byte* this[uint i]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { fixed (byte** p = &_0) return ref *(p + i); }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ref byte* GetPinnableReference() => ref this[0];
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct int_array4
    {
        public const int Size = 4;
        public static readonly int ElementSize = sizeof(int);
        fixed int _[4];
        
        public ref int this[int i]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => ref this._[i];
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Span<int>(int_array4 @this) => new Span<int>(@this._, Size);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ReadOnlySpan<int>(int_array4 @this) => new ReadOnlySpan<int>(@this._, Size);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ref int GetPinnableReference() => ref this[0];
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct long_array4
    {
        public const int Size = 4;
        public static readonly int ElementSize = sizeof(long);
        fixed long _[4];
        
        public ref long this[int i]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => ref this._[i];
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Span<long>(long_array4 @this) => new Span<long>(@this._, Size);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ReadOnlySpan<long>(long_array4 @this) => new ReadOnlySpan<long>(@this._, Size);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ref long GetPinnableReference() => ref this[0];
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct int_array5
    {
        public const int Size = 5;
        public static readonly int ElementSize = sizeof(int);
        fixed int _[5];
        
        public ref int this[int i]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => ref this._[i];
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Span<int>(int_array5 @this) => new Span<int>(@this._, Size);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ReadOnlySpan<int>(int_array5 @this) => new ReadOnlySpan<int>(@this._, Size);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ref int GetPinnableReference() => ref this[0];
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct AVBufferRef_ptrArray8
    {
        public const int Size = 8;
        public static readonly int ElementSize = sizeof(AVBufferRef*);
        AVBufferRef* _0, _1, _2, _3, _4, _5, _6, _7;
        
        public ref AVBufferRef* this[uint i]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { fixed (AVBufferRef** p = &_0) return ref *(p + i); }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ref AVBufferRef* GetPinnableReference() => ref this[0];
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct byte_array8
    {
        public const int Size = 8;
        public static readonly int ElementSize = sizeof(byte);
        fixed byte _[8];
        
        public ref byte this[int i]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => ref this._[i];
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Span<byte>(byte_array8 @this) => new Span<byte>(@this._, Size);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ReadOnlySpan<byte>(byte_array8 @this) => new ReadOnlySpan<byte>(@this._, Size);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ref byte GetPinnableReference() => ref this[0];
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct byte_ptrArray8
    {
        public const int Size = 8;
        public static readonly int ElementSize = sizeof(byte*);
        byte* _0, _1, _2, _3, _4, _5, _6, _7;
        
        public ref byte* this[uint i]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { fixed (byte** p = &_0) return ref *(p + i); }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ref byte* GetPinnableReference() => ref this[0];
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct int_array8
    {
        public const int Size = 8;
        public static readonly int ElementSize = sizeof(int);
        fixed int _[8];
        
        public ref int this[int i]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => ref this._[i];
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Span<int>(int_array8 @this) => new Span<int>(@this._, Size);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ReadOnlySpan<int>(int_array8 @this) => new ReadOnlySpan<int>(@this._, Size);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ref int GetPinnableReference() => ref this[0];
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct ulong_array8
    {
        public const int Size = 8;
        public static readonly int ElementSize = sizeof(ulong);
        fixed ulong _[8];
        
        public ref ulong this[int i]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => ref this._[i];
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Span<ulong>(ulong_array8 @this) => new Span<ulong>(@this._, Size);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ReadOnlySpan<ulong>(ulong_array8 @this) => new ReadOnlySpan<ulong>(@this._, Size);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ref ulong GetPinnableReference() => ref this[0];
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct byte_array17
    {
        public const int Size = 17;
        public static readonly int ElementSize = sizeof(byte);
        fixed byte _[17];
        
        public ref byte this[int i]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => ref this._[i];
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Span<byte>(byte_array17 @this) => new Span<byte>(@this._, Size);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ReadOnlySpan<byte>(byte_array17 @this) => new ReadOnlySpan<byte>(@this._, Size);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ref byte GetPinnableReference() => ref this[0];
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct long_array17
    {
        public const int Size = 17;
        public static readonly int ElementSize = sizeof(long);
        fixed long _[17];
        
        public ref long this[int i]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => ref this._[i];
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Span<long>(long_array17 @this) => new Span<long>(@this._, Size);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ReadOnlySpan<long>(long_array17 @this) => new ReadOnlySpan<long>(@this._, Size);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ref long GetPinnableReference() => ref this[0];
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct double_array399
    {
        public const int Size = 399;
        public static readonly int ElementSize = sizeof(double);
        fixed double _[399];
        
        public ref double this[int i]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => ref this._[i];
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Span<double>(double_array399 @this) => new Span<double>(@this._, Size);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ReadOnlySpan<double>(double_array399 @this) => new ReadOnlySpan<double>(@this._, Size);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ref double GetPinnableReference() => ref this[0];
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct byte_array1024
    {
        public const int Size = 1024;
        public static readonly int ElementSize = sizeof(byte);
        fixed byte _[1024];
        
        public ref byte this[int i]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => ref this._[i];
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Span<byte>(byte_array1024 @this) => new Span<byte>(@this._, Size);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ReadOnlySpan<byte>(byte_array1024 @this) => new ReadOnlySpan<byte>(@this._, Size);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ref byte GetPinnableReference() => ref this[0];
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct byte_array61440
    {
        public const int Size = 61440;
        public static readonly int ElementSize = sizeof(byte);
        fixed byte _[61440];
        
        public ref byte this[int i]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => ref this._[i];
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Span<byte>(byte_array61440 @this) => new Span<byte>(@this._, Size);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ReadOnlySpan<byte>(byte_array61440 @this) => new ReadOnlySpan<byte>(@this._, Size);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ref byte GetPinnableReference() => ref this[0];
    }
    
    #pragma warning restore IDE1006 // 命名样式
}
