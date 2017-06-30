using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WAVgenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"..\..\..\music.wav";
            WaveGenerator wave = new WaveGenerator(WaveExampleType.ExampleSineWave);
            wave.Save(filePath);

            //SoundPlayer player = new SoundPlayer(filePath);
            //player.Play();
        }
    }
}
