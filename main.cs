using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AudioMixer.SoundWaves;
using AudioMixer.WAVFileGenerator;
using GUI;

namespace AudioMixer
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            var gui = new GUI.WFGUI(); 
            Application.Run(gui);
            
        }

        
    }
}
