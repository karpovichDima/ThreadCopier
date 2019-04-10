using ConsoleAutofacDI.IoC;
using ConsoleAutofacDI.Service;

namespace ConsoleAutofacDI.Controller
{
    public class SpeakerController
    {
        internal ISpeakerService SpeakerService { get; set; }

        public SpeakerController()
        {
            SpeakerService = AbstractContainer.AbsContainer.Resolve<ISpeakerService>();
        }
    }
}