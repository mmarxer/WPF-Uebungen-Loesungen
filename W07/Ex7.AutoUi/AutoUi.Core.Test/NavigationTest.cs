using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoUi.Core.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoUi.Core.Test
{
    [TestClass]
    public class NavigationTest
    {
        [TestMethod]
        public void TopWindowIsCorrectlySet()
        {
            // 1. Arrange
            var navService = new TestMockNavigationService();
            var vm = new AutoListVm(navService);

            // 2. Act
            navService.Show(vm);
            var windowOnTopAfter = navService.ViewStack.Peek();

            vm.EditAuto();
            var windowOnTopAfterEditAuto = navService.ViewStack.Peek();

            // 3. Assert
            Assert.AreEqual("AutoListVm", windowOnTopAfter);
            Assert.AreEqual("AutoVm", windowOnTopAfterEditAuto);
        }
    }

}
