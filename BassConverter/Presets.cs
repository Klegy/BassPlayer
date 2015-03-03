﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BassConverter
{
    [Serializable]
    public class Preset
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Extension { get; set; }
        public string CommandLine { get; set; }
    }

    internal interface IPresetControl
    {
        string InputPattern { get; set; }
        string GeneratePattern();
        void SetupFromTokens(Dictionary<string, string> Tokens);
    }

    internal class PresetManager: ObservableCollection<Preset>
    {
        public PresetManager() : base()
        {
            this.Add(new Preset 
            {
                Name = "Wav 16 bit, 2ch, 44100Khz",
                Description = "Converts input file(s) to CD Audio compatible wave\r\n 1 sec =  172.26 KiB",
                CommandLine = "ffmpeg.exe -i {input} {output}",
                Extension = "wav"
            });
        }
    }
}
