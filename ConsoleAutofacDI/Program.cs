using System;
using ConsoleAutofacDI.Controller;
using ConsoleAutofacDI.IoC;
using ConsoleAutofacDI.IoC.Impl;
using ConsoleAutofacDI.Service;
using ConsoleAutofacDI.Service.Impl;

namespace ConsoleAutofacDI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            AbstractContainer.AbsContainer = UnityInit.GetInstance();
            RegistrationDependency();

            /*var screenController = new ScreenController();
            screenController.ShowMessage();
            var speakerController = new SpeakerController();
            speakerController.PlayMusic();*/

            var threadController = new ThreadController();
            threadController.StartCopyingFiles();

            Console.ReadKey();
        }

        public static void RegistrationDependency()
        {
            AbstractContainer.AbsContainer.RegistrationDependency<IScreenService, BlackScreenServiceImpl>();
            AbstractContainer.AbsContainer.RegistrationDependency<IThreadService, ThreadServiceImpl>();
            AbstractContainer.AbsContainer.RegistrationDependency<ISpeakerService, LoudSpeakerServiceImpl>();
            AbstractContainer.AbsContainer.RegistrationDependency<ITestThreadService, TestTestThreadServiceImpl>();
        }
    }
}