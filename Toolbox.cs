using System;

namespace BEncoding.NET {

    public static class Toolbox {

        /// <summary>
        /// Checks to see if the contents of two byte arrays are equal
        /// </summary>
        /// <param name="array1">The first array</param>
        /// <param name="array2">The second array</param>
        /// <returns>True if the arrays are equal, false if they aren't</returns>
        public static bool ByteMatch(byte[] array1, byte[] array2) {
            if(array1 == null)
                throw new ArgumentNullException("array1");
            if(array2 == null)
                throw new ArgumentNullException("array2");

            if(array1.Length != array2.Length)
                return false;

            return ByteMatch(array1, 0, array2, 0, array1.Length);
        }

        /// <summary>
        /// Checks to see if the contents of two byte arrays are equal
        /// </summary>
        /// <param name="array1">The first array</param>
        /// <param name="array2">The second array</param>
        /// <param name="offset1">The starting index for the first array</param>
        /// <param name="offset2">The starting index for the second array</param>
        /// <param name="count">The number of bytes to check</param>
        /// <returns></returns>
        public static bool ByteMatch(byte[] array1, int offset1, byte[] array2, int offset2, int count) {
            if(array1 == null)
                throw new ArgumentNullException("array1");
            if(array2 == null)
                throw new ArgumentNullException("array2");

            // If either of the arrays is too small, they're not equal
            if((array1.Length - offset1) < count || (array2.Length - offset2) < count)
                return false;

            // Check if any elements are unequal
            for(int i = 0; i < count; i++)
                if(array1[offset1 + i] != array2[offset2 + i])
                    return false;

            return true;
        }
    }
}
