using System;
using System.IO;
using System.Collections.Generic;
class MainClass
{
    public static void Main(string[] args)
    {
     
        byte[] fileBytes = File.ReadAllBytes("D:/musicgameproject/tryBox/midifile/music01.mid");

        int count = 0;
        List<int> sysIndex = new List<int>();
        byte[] midiTempo = new byte[4];

        foreach (byte b in fileBytes)
        {
            if (b == 0xFF) 
            {
                sysIndex.Add(count);
            }
            count++;
        }

        foreach (int b in sysIndex)
        {
            if (fileBytes[b + 1] == 0x51)
            {
                if (fileBytes[b + 2] == 0x03)
                {
                    midiTempo[0] = fileBytes[b + 3];
                    midiTempo[1] = fileBytes[b + 4];
                    midiTempo[2] = fileBytes[b + 5];
                }
            } 
        }

        int num = midiTempo[0] << 16 | midiTempo[1] << 8 | midiTempo[2]; 
        float BPM = 60000000 / num;
        Console.WriteLine(BPM);
    }
}
