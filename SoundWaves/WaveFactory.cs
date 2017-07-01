﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioMixer.SoundWaves
{
    public enum WaveTypes
    {
        SineWave,
        Square,
        Sawtooth,
        Triangle
    }

    public struct RepeatingWaveAttributes
    {
        public SampleRates WaveSampleRate;
        public double Runtime;
        public double TargetFrequency;

        public RepeatingWaveAttributes(SampleRates waveSampleRate, double runtime, double targetFrequency)
        {
            WaveSampleRate = waveSampleRate;
            Runtime = runtime;
            TargetFrequency = targetFrequency;
        }   
    }



    // Creates Various classical waves
    static class WaveFactory
    {
        static private WaveChunk MakeSineWave(RepeatingWaveAttributes waveAttributes)
        {
            WaveChunk wave = new WaveChunk(waveAttributes.WaveSampleRate, waveAttributes.Runtime);

            uint numSamples = wave.NumSamples;

            double t = (Math.PI * 2 * waveAttributes.TargetFrequency) / (uint) waveAttributes.WaveSampleRate;

            for (uint i = 0; i < numSamples; i++)
            {
                wave[i] = (float) Math.Sin(t * i);
            }

            return wave;
        }

        static private WaveChunk MakeSquareWave(RepeatingWaveAttributes waveAttributes)
        {
            WaveChunk wave = MakeSineWave(waveAttributes);
            uint nSamples = wave.NumSamples;
            for (uint i = 0; i < nSamples; i++)
                wave[i] = Math.Sign(wave[i]);

            return wave;

        }

        private static WaveChunk MakeSawtooth(RepeatingWaveAttributes waveAttr)
        {
            WaveChunk wave = new WaveChunk(waveAttr.WaveSampleRate, waveAttr.Runtime);
            uint numSamples = wave.NumSamples;

            var step = 1 / (double)waveAttr.WaveSampleRate * 2 * waveAttr.TargetFrequency;
            wave[0] = 0.0f;
            for(uint i=1 ; i < numSamples; i++)
            {
                var next = wave[i - 1] + (float) step;
                if (next > 1.0f)
                    wave[i] = -1.0f;
                else
                    wave[i] = next;
            }
            return wave;

        }

        private static WaveChunk MakeTriangle(RepeatingWaveAttributes waveAttr)
        {
            WaveChunk wave = new WaveChunk(waveAttr.WaveSampleRate, waveAttr.Runtime);
            uint numSamples = wave.NumSamples;

            float step = (float) (1 / (double)waveAttr.WaveSampleRate * 4 * waveAttr.TargetFrequency);
            wave[0] = 0.0f;
            for (uint i = 1; i < numSamples; i++)
            {
                var next = wave[i - 1] + step;
                if (Math.Abs(next) > 1.0f)
                    step = -step;
                
                wave[i] = wave[i - 1] + step;
            }
            return wave;

        }

        /// <summary>
        /// Creates basic audio waves
        /// </summary>
        /// <param name="waveType"></param>
        /// <param name="waveAttributes"></param>
        /// <returns></returns>
        static public WaveChunk MakeRepeatingWave(WaveTypes waveType, RepeatingWaveAttributes waveAttributes)
        {
            switch(waveType)
            {
                case WaveTypes.SineWave:
                    return MakeSineWave(waveAttributes);
                case WaveTypes.Square:
                    return MakeSquareWave(waveAttributes);
                case WaveTypes.Sawtooth:
                    return MakeSawtooth(waveAttributes);
                case WaveTypes.Triangle:
                    return MakeTriangle(waveAttributes);
                default:
                    throw new ArgumentException("Not a valid wave type");

            }
            
        }

        static private WaveChunk MakeWhiteNoise(RepeatingWaveAttributes waveAttr)
        {
            WaveChunk wave = new WaveChunk(waveAttr.WaveSampleRate, waveAttr.Runtime);
            uint numSamples = wave.NumSamples;

            Random random = new Random();

            for (uint i = 0; i < numSamples; i++)
            {
                wave[i] = (float) (2 * random.NextDouble() - 1);
            }

            return wave;
        }

        static public WaveChunk MakeNoise(RepeatingWaveAttributes waveAttributes)
        {
            return MakeWhiteNoise(waveAttributes);
        }

        
    }
}
