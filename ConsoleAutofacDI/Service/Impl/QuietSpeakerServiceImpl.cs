using System;
using System.Collections.Generic;
using System.Text;
using ConsoleAutofacDI.Model;

namespace ConsoleAutofacDI.Service.Impl
{
    class QuietSpeakerServiceImpl : ISpeakerService
    {
        public void PlayMusic(Speaker speaker)
        {
            Console.WriteLine("1.QUIET: Playing music, volume: " + speaker.Volume);
        }
    }
}
