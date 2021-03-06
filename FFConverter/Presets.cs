﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FFConverter
{
    [Serializable]
    public class Preset
    {
        /// <summary>
        /// Preset name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Preset Description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Output Extension
        /// </summary>
        public string Extension { get; set; }
        /// <summary>
        /// Preset command line
        /// </summary>
        public string CommandLine { get; set; }
    }

    internal interface IPresetControl
    {
        string InputPattern { get; set; }
        string GeneratePattern();
        void SetupFromTokens(Dictionary<string, string> Tokens);
    }

    /// <summary>
    /// Preset management class
    /// </summary>
    internal class PresetManager: ObservableCollection<Preset>
    {
        public PresetManager() : base()
        {
            this.Add(new Preset
            {
                Name = "Wav",
                Description = "Converts input file(s) to wav, as it is. No additional processing is involved",
                CommandLine = "ffmpeg.exe -i {input} {output} {extension}",
                Extension = "wav"
            });
            this.Add(new Preset 
            {
                Name = "Wav 16 bit, 2ch, 44100Khz",
                Description = "Converts input file(s) to CD Audio compatible wave\r\n 1 sec =  172.26 KiB",
                CommandLine = "ffmpeg.exe -i {input} -ac 2 -ar 44100 -sample_fmt s16 {output}",
                Extension = "wav"
            });
            this.Add(new Preset
            {
                Name = "Extract Audio track from video",
                Description = "Extracts Audio track from video to wav file  to CD Audio compatible wave",
                CommandLine = "ffmpeg -i {input} -vn -ac 2 -ar 44100 -sample_fmt s16 {output}",
                Extension = "wav"
            });
            this.Add(new Preset
            {
                Name = "Extract Audio track from MP4",
                Description = "Extracts Audio track from mp4 video to an m4a file.",
                CommandLine = "ffmpeg -i {input} -vn -acodec copy {output}",
                Extension = "m4a"
            });
            this.Add(new Preset
            {
                Name = "FLAC",
                Description = "Convert Audio to Free Losless Audio Codec (FLAC) format",
                CommandLine = "ffmpeg -i {input} -vn -acodec flac -aq {slider text=\"Compression (Higher = Smaller file):\" min=\"1\" max=\"8\" step=\"1\" val=\"3\"} {output}", 
                Extension = "flac"
            });
            this.Add(new Preset
            {
                Name = "ALAC",
                Description = "Convert Audio to Apple Losless Audio Codec (ALAC) format",
                CommandLine = "ffmpeg -i {input} -vn -acodec alac {output}",
                Extension = "m4a"
            });
            this.Add(new Preset
            {
                Name = "WavPack",
                Description = "Convert Audio to WavPack Losless Audio Codec (WV) format",
                CommandLine = "ffmpeg -i {input} -vn -acodec wavpack {output}",
                Extension = "wv"
            });
            this.Add(new Preset
            {
                Name = "M4A Quality mode",
                Description = "Convert Audio to M4A/AAC based on Quality",
                CommandLine = "ffmpeg -i {input} -vn -f wav - faac.exe -q {slider text=\"Quality Level:\" min=\"1\" max=\"500\" val=\"500\" step=\"1\"} -o {output} -",
                Extension = "m4a"
            });
            this.Add(new Preset
            {
                Name = "M4A Bitrate mode",
                Description = "Convert Audio to M4A/AAC based on an average bitrate",
                CommandLine = "ffmpeg -i {input} -vn -f wav - faac.exe -b {slider text=\"Bitrate:\" min=\"8\" stops=\"8;16;32;40;48;56;64;80;96;112;128;160;192;224;256;320\" val=\"256\"} -o {output} -",
                Extension = "m4a"
            });
            this.Add(new Preset
            {
                Name = "MP3 CBR",
                Description = "Mp3 format with Constant bitrate",
                CommandLine = "ffmpeg -i {input} -vn -acodec mp3 -b:a {slider text=\"Bitrate:\" min=\"8\" stops=\"8;16;32;40;48;56;64;80;96;112;128;160;192;224;256;320\" val=\"192\" unit=\"k\"} {output}",
                Extension = "mp3"
            });
            this.Add(new Preset
            {
                Name = "MP3 VBR",
                Description = "Mp3 format with Variable bitrate",
                CommandLine = "ffmpeg -i {input} -vn -acodec mp3 -q:a {slider text=\"Quality Level:\" min=\"1\" max=\"9\" val=\"7\" step=\"1\"} {output}",
                Extension = "mp3"
            });
            this.Add(new Preset
            {
                Name = "AC3",
                Description = "Dolby Digital AC3 Format",
                CommandLine = "ffmpeg -i {input} -vn -acodec ac3 -b:a {slider text=\"Bitrate:\" min=\"8\" stops=\"8;16;32;40;48;56;64;80;96;112;128;160;192;224;256;384;448\" val=\"384\" unit=\"k\"} {output} -drc_scale {slider text=\"DRC (Dynamic Range Compression) Level:\" min=\"0.1\" max=\"2\" val=\"0.9\" step=\"0.1\"}",
                Extension = "ac3"
            });
            this.Add(new Preset
            {
                Name = "AC3, DVD compatible",
                Description = "Dolby Digital AC3 Format, DVD compatible, with resampling to 48Khz",
                CommandLine = "ffmpeg -i {input} -vn -acodec ac3 -b:a {slider text=\"Bitrate:\" min=\"8\" stops=\"8;16;32;40;48;56;64;80;96;112;128;160;192;224;256;384;448\" val=\"384\" unit=\"k\"} {output} -drc_scale {slider text=\"DRC (Dynamic Range Compression) Level:\" min=\"0.1\" max=\"2\" val=\"0.9\" step=\"0.1\"}",
                Extension = "ac3"
            });
        }
    }
}
