using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AudioMixer.SoundWaves;
using AudioMixer.WAVFileGenerator;

namespace AudioMixer
{
    class Program
    {
        static void Main(string[] args)
        {
            const string pathPrefix = @"..\..\..\WAVs";
            const string filePath = pathPrefix + @"\music.wav";
            const SampleRates sampleRate = SampleRates.F48kHz;

            RepeatingWaveAttributes attributes = new RepeatingWaveAttributes(sampleRate, 5.2, 800.0);

            WaveChunk wave1 = WaveFactory.MakeRepeatingWave(WaveTypes.SineWave,attributes);
            attributes.TargetFrequency = 300;
            WaveChunk wave2 = WaveFactory.MakeRepeatingWave(WaveTypes.SineWave, attributes);
            attributes.TargetFrequency = 0.5;
            WaveChunk wave3 = WaveFactory.MakeRepeatingWave(WaveTypes.SineWave, attributes);

            

            CreateWAVFile(pathPrefix + @"\music.wav", sampleRate, ((wave1 + wave2) * wave3).LinearVolumeNormalize());

        }

        private static void CreateWAVFile(string filePath, SampleRates sampleRate, WaveChunk wave)
        {
            WAVGenerator generator = WAVGenerator.Singleton.SetAudioProperties((uint)sampleRate, 1);
            var data = WaveChunk.Get16BitArray(wave);
            generator.SetMonoData(data);
            generator.SaveToFile(filePath);
        }
    }
}
