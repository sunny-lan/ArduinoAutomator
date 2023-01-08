using System.Runtime.InteropServices;

namespace ArduinoAutomator
{
    static class Util
    {

        public static byte[] Serialize<T>(this T v) where T : struct
        {
            // Get the byte size of a MyDataStruct structure if it is to be
            // marshaled to unmanaged memory.
            Int32 iSizeOMyDataStruct = Marshal.SizeOf<T>();
            // Allocate a byte array to contain the bytes of the unmanaged version
            // of the MyDataStruct structure.
            byte[] byteArrayMyDataStruct = new byte[iSizeOMyDataStruct];
            // Allocate a GCHandle to pin the byteArrayMyDataStruct array
            // in memory in order to obtain its pointer.
            GCHandle gch = GCHandle.Alloc(byteArrayMyDataStruct, GCHandleType.Pinned);
            // Obtain a pointer to the byteArrayMyDataStruct array in memory.
            IntPtr pbyteArrayMyDataStruct = gch.AddrOfPinnedObject();
            // Copy all bytes from the managed MyDataStruct structure into
            // the byte array.
            Marshal.StructureToPtr(v, pbyteArrayMyDataStruct, false);
            // Unpin the byteArrayMyDataStruct array in memory.
            gch.Free();
            // Return the byte array.
            // It contains the serialized bytes of the MyDataStruct structure.
            return byteArrayMyDataStruct;
        }
    }
}
