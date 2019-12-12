using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsciiArtGenerator.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AsciiArtGenerator.Test
{
    [TestClass]
    public class DialogServiceTest
    {
        [TestMethod]
        public void MissingFilenameGivesAnErrorMessage()
        {
            // 1. Arrange
            var dialogService = new MockDialogService();
            var vm = new AsciiGeneratorVm(dialogService);

            // 2. Act
            var messageCountBefore = dialogService.Errors.Count;
            vm.CalcCommand.Execute(null);
            var messageCountAfter = dialogService.Errors.Count;

            // Spasseshalber geben wir die Error (s)Message noch aus
            DumpErrorMessages(dialogService.Errors);

            // 3. Assert
            Assert.AreEqual(messageCountBefore + 1, messageCountAfter);
            Assert.IsNull(vm.Result);
        }

        public void DumpErrorMessages(List<MockErrorMessage> messages)
        {
            messages.ForEach(x => Console.WriteLine($"{x.Title}: {x.Message}"));
        }
    }
}
