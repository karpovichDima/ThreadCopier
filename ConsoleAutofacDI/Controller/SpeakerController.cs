using ConsoleAutofacDI.IoC;
using ConsoleAutofacDI.Model;
using ConsoleAutofacDI.Service.Impl;

namespace ConsoleAutofacDI.Controller
{

    class SpeakerController
    {
        internal ISpeakerService SpeakerService { get; set; }

        public SpeakerController()
        {
            SpeakerService = AbstractContainer.AbsContainer.Resolve<ISpeakerService>();
        }
        
        public void PlayMusic()
        {
            SpeakerService.PlayMusic(new Speaker { Volume = 79 });
        }
    }
    
    
}
