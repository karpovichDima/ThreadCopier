using System;
using ConsoleAutofacDI.Controller;
using ConsoleAutofacDI.IoC;
using ConsoleAutofacDI.IoC.Impl;
using ConsoleAutofacDI.Service;
using ConsoleAutofacDI.Service.Impl;

namespace ConsoleAutofacDI
{
    class Program
    {
        static void Main(string[] args)
        {
            AbstractContainer.AbsContainer = UnityInit.GetInstance();
            RegistrationDependency();

            var screenController = new ScreenController();
            screenController.ShowMessage();
            var speakerController = new SpeakerController();
            speakerController.PlayMusic();
            var threadController = new ThreadController();
            threadController.CreateThreeTask();

            Console.ReadKey();
        }

        static void RegistrationDependency()
        {
            AbstractContainer.AbsContainer.RegistrationDependency<IScreenService, BlackScreenServiceImpl>();
            AbstractContainer.AbsContainer.RegistrationDependency<ISpeakerService, LoudSpeakerServiceImpl>();
            AbstractContainer.AbsContainer.RegistrationDependency<IThreadService, ThreadServiceImpl>();
        }
    }
}