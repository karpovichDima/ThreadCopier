using System;
using System.Collections.Generic;
using System.Text;
using ConsoleAutofacDI.Model;

namespace ConsoleAutofacDI.Service.Impl
{
    class LoudSpeakerServiceImpl : ISpeakerService
    {
        public void PlayMusic(Speaker speaker)
        {
            Console.WriteLine("2.LOUD: Playing music, volume: " + speaker.Volume);
        }
    }
}
