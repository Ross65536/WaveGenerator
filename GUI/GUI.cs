
using AudioMixer.SoundWaves;
using AudioMixer.WAVFileGenerator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GUI
{


    public partial class WFGUI : Form
    {
        struct WaveItem
        {
            public string waveType;
            public string waveOperator;
            public double waveFrequency;

            public WaveItem(WaveItem currWaveItem)
            {
                waveType = currWaveItem.waveType;
                waveOperator = currWaveItem.waveOperator;
                waveFrequency = currWaveItem.waveFrequency;
            }
        }

        //consts
        const string DEFAULT_SAVE_DIR = @"..\..\..\WAVs";
        const string DEFAULT_FILE_NAME = @"music.wav";
        private const double DEFAULT_DURATION = 5.0;
        const double DEFAULT_WAVE_FREQUENCY = 500.0;
        SampleRate sampleRate;
        const int DEFAULT_COMBO_INDEX = 0;

        static readonly IList<string> WAVE_TYPE_COMBOS = new List<string> { "SineWave", "SquareWave", "SawTooth", "Triangle", "WhiteNoise" };
        static readonly IList<string> OPERATOR_COMBOS = new List<string> { "Add", "Sub","Mult Wave", "Div" };
        static readonly IDictionary<string, string> OPERATOR_SYMBOLS_MAP = new SortedDictionary<string, string>
        {
            { OPERATOR_COMBOS[0],"+" }, {OPERATOR_COMBOS[1],"-" }, {OPERATOR_COMBOS[2],"*" }, {OPERATOR_COMBOS[3],"/" }
        };
        static readonly IDictionary<string, WaveTypes> WAVE_TYPES_MAP = new SortedDictionary<string, WaveTypes>()
        {
          { WAVE_TYPE_COMBOS[0], WaveTypes.SineWave}, {WAVE_TYPE_COMBOS[1], WaveTypes.Square }, { WAVE_TYPE_COMBOS[2], WaveTypes.Sawtooth }
        , {WAVE_TYPE_COMBOS[3], WaveTypes.Triangle }, {WAVE_TYPE_COMBOS[4], WaveTypes.WhiteNoise }
        };
        

        //fields
        string savePath;
        System.Media.SoundPlayer player = new System.Media.SoundPlayer();
        double fileDuration;
        WaveItem currWaveItem;
        IList<WaveItem> waves;
        
        private SaveFileDialog SaveAudioFileDialog;

        public WFGUI()
        {
            InitializeComponent();

            this.SaveAudioFileDialog = new SaveFileDialog();
            currWaveItem = new WaveItem()
            {
                waveType = WAVE_TYPE_COMBOS[DEFAULT_COMBO_INDEX],
                waveOperator = OPERATOR_COMBOS[DEFAULT_COMBO_INDEX],
                waveFrequency = DEFAULT_WAVE_FREQUENCY
            };
            waves = new List<WaveItem>();

            InnitConstantsAndLabels();
            InnitWavesGUI();
        }

        private void InnitConstantsAndLabels()
        {
            savePath = DEFAULT_SAVE_DIR + "\\" + DEFAULT_FILE_NAME;
            fileDuration = DEFAULT_DURATION;
            sampleRate = SampleRate.F48kHz;

            //labels
            textBoxDuration.Text = fileDuration.ToString();
            textBoxWaveFrequency.Text = DEFAULT_WAVE_FREQUENCY.ToString();

            foreach (var value in Enum.GetValues(typeof(SampleRate)))
                sampleRatesCombo.Items.Add(value);

            sampleRatesCombo.SelectedIndex = DEFAULT_COMBO_INDEX;

        }

        private void InnitWavesGUI()
        {
            foreach (string type in WAVE_TYPE_COMBOS)
                this.comboWaveType.Items.Add(type);

            comboWaveType.SelectedIndex = DEFAULT_COMBO_INDEX;

            foreach (string op in OPERATOR_COMBOS)
                this.comboOperator.Items.Add(op);

            comboOperator.SelectedIndex = DEFAULT_COMBO_INDEX;

        }
        
        private void WFGUI_Load(object sender, EventArgs e)
        {

        }

        private bool checkSelectedWave()
        {
            if (waves.Count == 0)
            {
                this.labelBottomButtons.Text = "No wave selected!";
                return false;
            }
            
            this.labelBottomButtons.Text = "";
            return true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (!checkSelectedWave())
                return;
            
            SaveAudioFileDialog.OverwritePrompt = true;
            SaveAudioFileDialog.RestoreDirectory = true;
            SaveAudioFileDialog.FileName = DEFAULT_FILE_NAME;
            SaveAudioFileDialog.DefaultExt = ".wav";
            SaveAudioFileDialog.Filter = "WAV file (*.wav)|*.wav|All files (*.*)|*.*";
            SaveAudioFileDialog.InitialDirectory = Application.StartupPath;


            DialogResult result = SaveAudioFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                savePath = SaveAudioFileDialog.FileName;
                WaveChunk wave = this.ProcessWaves();
                WAVGenerator.CreateMonoWAVFile(savePath, sampleRate, wave);
                this.labelBottomButtons.Text = "Saved!";
            }
        }

        private WaveChunk ProcessWaves()
        {
            if (waves.Count == 0)
                return null;

            WaveAttributes attr = new WaveAttributes(sampleRate, fileDuration, -1);


            WaveChunk wave = makeWave(waves[0], attr);

            for (int i=1; i < waves.Count; i++)
            {
                var item = waves[i];
                var newWave = makeWave(item, attr);
                switch(item.waveOperator)
                {
                    case "Add":
                        wave += newWave;
                        break;
                    case "Sub":
                        wave -= newWave;
                        break;
                    case "Mult Wave":
                        wave *= newWave;
                        break;
                    case "Div":
                        wave /= newWave;
                        break;
                    default:
                        throw new Exception("Invalid wave operation");
                }
            }

            wave.LinearVolumeNormalize();
            return wave;

            WaveChunk makeWave(WaveItem item, WaveAttributes attr2)
            {
                attr2.TargetFrequency = item.waveFrequency;
                return WaveFactory.MakeWave(WAVE_TYPES_MAP[item.waveType], attr2);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!checkSelectedWave())
                return;
            
            WaveChunk wave = this.ProcessWaves();
            var writer = new BinaryWriter (new MemoryStream());
            WAVGenerator.WriteToStream(writer, sampleRate, wave);
            writer.Seek(0, SeekOrigin.Begin);
            player = new System.Media.SoundPlayer(writer.BaseStream);
            player.Play();
            writer.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            player.Stop();
        }
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                fileDuration = Convert.ToDouble(textBoxDuration.Text);
                labelDurationErrors.Text = "";
            }
            catch(FormatException)
            {
                fileDuration = DEFAULT_DURATION;
                labelDurationErrors.Text = "Invalid Value. Set to Default";
            }

            if (fileDuration > 60.0 * 10)
                labelDurationErrors.Text = "Warning, large file";
            else if (fileDuration <= 0.0)
            {
                fileDuration = DEFAULT_DURATION;
                labelDurationErrors.Text = "Value can't be 0 or negative. Set to default";
            }
        }
        
        //operator
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            currWaveItem.waveOperator = comboOperator.Text;
        }
        
        //wave type
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            currWaveItem.waveType = comboWaveType.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                currWaveItem.waveFrequency = Convert.ToDouble(textBoxWaveFrequency.Text);
                labelWaveErrors.Text = "";
            }
            catch (FormatException)
            {
                currWaveItem.waveFrequency = DEFAULT_WAVE_FREQUENCY;
                labelWaveErrors.Text = "Invalid Value. Set to Default";
            }

            if (currWaveItem.waveFrequency > 20000)
            {
                labelWaveErrors.Text = "Warning, Frequency above 20kHz";
            }
            else if (currWaveItem.waveFrequency <= 0.0)
            {
                currWaveItem.waveFrequency = DEFAULT_WAVE_FREQUENCY;
                labelWaveErrors.Text = "Value can't be 0 or negative. Set to default";
            }
        }

        private void buttonAddWave_Click(object sender, EventArgs e)
        {
            if (!OPERATOR_COMBOS.Contains(currWaveItem.waveOperator) || !WAVE_TYPE_COMBOS.Contains(currWaveItem.waveType))
                throw new ArgumentException("Inalid Wave Combo Arguemtns");

            waves.Add(new WaveItem(currWaveItem));
            this.updateWaveAlgebraText();
        }

        private void updateWaveAlgebraText()
        {
            textBoxWaveAlgebra.Text = "";
            if (waves.Count == 0)
                return;

            textBoxWaveAlgebra.Text = formatWave(waves[0]); //first wave doesnt have operator
            for(int i=1; i < waves.Count; i++)
            {
                var item = waves[i];
                textBoxWaveAlgebra.Text += " " + OPERATOR_SYMBOLS_MAP[item.waveOperator] + " " + formatWave(item);
            }

            return;

            string formatWave(WaveItem item)
            {
                string ret = item.waveType;
                if (!Regex.IsMatch(item.waveType, "noise|Noise"))
                    ret += "[" + item.waveFrequency.ToString() + "Hz]";

                return ret;
            }

        }
        

        private void buttonDeleteWave_Click(object sender, EventArgs e)
        {
            if(waves.Count != 0)
            waves.RemoveAt(waves.Count - 1);
            updateWaveAlgebraText();
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            waves.Clear();
            updateWaveAlgebraText();
        }
        

        private void sampleRatesCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            sampleRate = (SampleRate) sampleRatesCombo.SelectedItem;

        }
    }
}
