using System.IO;
using System.Text;
using System;

using SampleRates = AudioMixer.SoundWaves.SampleRates;

namespace AudioMixer.WAVFileGenerator
{
    public class WAVGenerator
    {
        // Header, Format, Data chunks
        private WaveHeader header;
        private WaveFormatChunk format;
        private WaveDataChunk data;

        private static WAVGenerator singleton = null;

        private WAVGenerator()
        {
            // Init chunks
            header = new WaveHeader();
            format = new WaveFormatChunk();
            data = new WaveDataChunk();
        }

        public static WAVGenerator Singleton
        {
            get
            {
                if (singleton == null)
                    singleton = new WAVGenerator();

                return singleton;
            }
        }

        public WAVGenerator SetAudioProperties(uint sampleRate, ushort nChannels)
        {
            CheckValidSampleRate(sampleRate);

            format.SetProperties(nChannels, sampleRate, sizeof(short) * 8); //TODO

            return this;
        }

        private static void CheckValidSampleRate(uint sampleRate)
        {
            bool isSampleRateValid = Enum.IsDefined(typeof(SampleRates), sampleRate);
            if (!isSampleRateValid)
                throw new ArgumentException("Sample Rate Invalid.");
        }

        public void SaveToFile(string filePath)
        {
            FileStream fileStream = new FileStream(filePath, FileMode.Create);
            
            BinaryWriter writer = new BinaryWriter(fileStream, Encoding.ASCII);
            header.WriteToFile(writer);
            format.WriteToFile(writer);
            data.WriteToFile(writer);

            writer.Seek(4, SeekOrigin.Begin);
            uint filesize = (uint)writer.BaseStream.Length;
            writer.Write(filesize - 8);

            // Clean up
            writer.Close();
            fileStream.Close();
        }

        public void SetMonoData(short[] monoData)
        {
            data.DataArray = monoData;
        }
    }
}
