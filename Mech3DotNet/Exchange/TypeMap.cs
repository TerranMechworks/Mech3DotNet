namespace Mech3DotNet.Exchange
{
    public enum TypeMap
    {
        U8 = 10,
        U16 = 11,
        U32 = 12,
        I8 = 20,
        I16 = 21,
        I32 = 22,
        F32 = 30,
        BoolTrue = 40,
        BoolFalse = 41,
        None = 32,
        Some = 33,
        Str = 50,
        Bytes = 51,
        Seq = 60,
        Struct = 70,
        EnumUnit = 80,
        EnumNewType = 81,
    }

    public static class TypeMapExtensions
    {
        public static TypeMap FromInt(int value) => value switch
        {
            10 => TypeMap.U8,
            11 => TypeMap.U16,
            12 => TypeMap.U32,
            20 => TypeMap.I8,
            21 => TypeMap.I16,
            22 => TypeMap.I32,
            30 => TypeMap.F32,
            40 => TypeMap.BoolTrue,
            41 => TypeMap.BoolFalse,
            32 => TypeMap.None,
            33 => TypeMap.Some,
            50 => TypeMap.Str,
            51 => TypeMap.Bytes,
            60 => TypeMap.Seq,
            70 => TypeMap.Struct,
            80 => TypeMap.EnumUnit,
            81 => TypeMap.EnumNewType,
            _ => throw new System.ArgumentOutOfRangeException(),
        };

        public static int ToInt(this TypeMap type) => type switch
        {
            TypeMap.U8 => 10,
            TypeMap.U16 => 11,
            TypeMap.U32 => 12,
            TypeMap.I8 => 20,
            TypeMap.I16 => 21,
            TypeMap.I32 => 22,
            TypeMap.F32 => 30,
            TypeMap.BoolTrue => 40,
            TypeMap.BoolFalse => 41,
            TypeMap.None => 32,
            TypeMap.Some => 33,
            TypeMap.Str => 50,
            TypeMap.Bytes => 51,
            TypeMap.Seq => 60,
            TypeMap.Struct => 70,
            TypeMap.EnumUnit => 80,
            TypeMap.EnumNewType => 81,
            _ => throw new System.ArgumentOutOfRangeException(),
        };
    }
}
