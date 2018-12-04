using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using ConsoleAutofacDI.Model;

namespace ConsoleAutofacDI.Service.Impl
{
    class LoudSpeakerServiceImpl : ISpeakerService
    {
        public void PlayMusic(Speaker speaker)
        {
            int musicVol = StartMusic().Result;
        }

        private async Task<int> StartMusic()
        {
            int vol = await Task.Run(() => Volume(4));
            Console.WriteLine("2.LOUD: Playing music, volume: " + vol);
            return vol;
        }

        private int Volume(int volume)
        {
            return volume;
        }
    }
}
