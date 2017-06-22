using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEProbs
{
    /// <summary>
    /// Hacky implementation (wrapper) to allow using BitArrays for implementing
    /// prime sieves (of Erastothenes) for larger numbers without resorting to segmenting.
    /// Implemented as a dictionary of BitArrays, keyed off of the first index each BitArray 
    /// can handle (multiples of Int32.MaxValue, since max size for BitArrays is an int)
    /// </summary>
    public sealed class LongBitArray
    {
        public const bool BITARRAY_DEFAULT_VAL = false;
        private SortedDictionary<long, BitArray> BitArrays { get; set; }

        public LongBitArray(long length, bool defaultValue = BITARRAY_DEFAULT_VAL)
        {
            BitArrays = new SortedDictionary<long, BitArray>();
            if (length < Int32.MaxValue)
            {                
                BitArrays.Add(0, new BitArray((int)length, defaultValue));
            }
            else
            {
                //figure out how many BitArrays we need. 
                long numFull = length / Int32.MaxValue;
                long lastKey = 0;
                for (long i = 0; i < numFull; i++)
                {
                    lastKey = Int32.MaxValue * i;
                    BitArrays.Add(lastKey, new BitArray(Int32.MaxValue, defaultValue));
                }
                int remainder = (int)(length % Int32.MaxValue);
                if (remainder > 0)
                {
                    lastKey += Int32.MaxValue;
                    BitArrays.Add(lastKey, new BitArray(remainder, defaultValue));
                }
            }
        }

        //public LongBitArray(BitArray ba, long desiredLength, bool defaultValue = BITARRAY_DEFAULT_VAL)
        //{}

        public bool this[long index]
        {
            get
            {
                (BitArray ba, int i) = LookupIndex(index);
                return ba[i];
            }
            set
            {
                (BitArray ba, int i) = LookupIndex(index);
                ba[i] = value;
            }
        }

        public long Length
        {
            get
            {
                return BitArrays.Values.Aggregate(0, (acc, ba) => acc + ba.Length);
            }
        }

        private (BitArray ba, int i) LookupIndex(long index)
        {
            long dictKey = BitArrays.Keys.First(k => index >= k);
            return (BitArrays[dictKey], (int)(index - dictKey));

        }
    }
}
