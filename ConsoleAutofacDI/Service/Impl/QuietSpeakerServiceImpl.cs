using System;
using ConsoleAutofacDI.Model;

namespace ConsoleAutofacDI.Service.Impl
{
    public class QuietSpeakerServiceImpl : ISpeakerService
    {
        public void PlayMusic(Speaker speaker)
        {
            Console.WriteLine("1.QUIET: Playing music, volume: " + speaker.Volume);
        }
    }
}