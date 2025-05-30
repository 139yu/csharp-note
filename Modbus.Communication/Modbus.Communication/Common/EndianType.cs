namespace Modbus.Communication.Common
{
    public enum EndianType
    {
        AB,
        BA,
        ABCD,
        CDAB,
        BADC,
        DCBA,
        ABCDEFGH,
        GHEFCDAB,
        BADCFEHG,
        HGFEDCBA
    }
}