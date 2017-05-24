using System;
using System.Collections.Generic;
using System.Linq;
using Communication.IO.Tools;

namespace WindowsColourChangeController
{
    class SerialPacket
    {
        private static Byte startByte = 0xFF;
        public Byte type { get; private set; }
        // HACK: currently no support for multiple packets
        private Byte packetNum = 0x00;
        private UInt16 CRC;
        public Byte[] data { get; private set; }
        private CRCTool crcGen = new CRCTool();

        public SerialPacket(Byte typeIn, Byte[] dataIn)
        {
            crcGen.Init(CRCTool.CRCCode.CRC_CCITT);
            this.type = typeIn;
            this.data = dataIn;
        }
        public SerialPacket(Byte[] packetIn)
        {
            crcGen.Init(CRCTool.CRCCode.CRC_CCITT);
            // start 0
            this.type = packetIn[1];
            //packet num 2
            //take 3 and 4 for crc
            this.CRC = BitConverter.ToUInt16(packetIn,3);
            //4 + to data
            this.data = packetIn.Skip(4).Take((packetIn.Length - 4)).ToArray();
            UInt16 ourCRC = crcGen.CalcCRCITT(data);
            if(ourCRC != CRC)
            {
                Console.WriteLine("CRC ERROR:" + ourCRC + ":" + CRC);
            }
        }

        public Byte[] getBytes()
        {
            List<Byte> bytePacket = new List<Byte>();
            bytePacket.Add(startByte);
            bytePacket.Add(type);
            bytePacket.Add(packetNum);
            CRC = crcGen.CalcCRCITT(data);
            bytePacket.AddRange(BitConverter.GetBytes(CRC));
            bytePacket.AddRange(data);
            return bytePacket.ToArray();
        }

    }
}
