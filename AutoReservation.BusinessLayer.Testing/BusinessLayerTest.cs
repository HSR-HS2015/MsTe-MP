using AutoReservation.TestEnvironment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoReservation.Dal;
using System.Data.Entity.Core.Objects;
using System;

namespace AutoReservation.BusinessLayer.Testing
{
    [TestClass]
    public class BusinessLayerTest
    {
        private AutoReservationBusinessComponent target;
        private AutoReservationBusinessComponent Target
        {
            get
            {
                if (target == null)
                {
                    target = new AutoReservationBusinessComponent();
                }
                return target;
            }
        }


        [TestInitialize]
        public void InitializeTestData()
        {
            TestEnvironmentHelper.InitializeTestData();
        }
        
        [TestMethod]
        public void Test_UpdateAuto()
        {
            Auto modified = target.getAuto(1);
            modified.Marke = "Suzuki";
            modified.Tagestarif = 200;
            target.updateAuto(target.getAuto(1), modified);

            Assert.AreEqual("Suzuki", target.getAuto(1).Marke);
            Assert.AreEqual(200, target.getAuto(1).Tagestarif);
        }

        [TestMethod]
        public void Test_UpdateKunde()
        {
            Kunde modified = target.getKunde(1);
            modified.Nachname = "Müller";
            modified.Vorname = "Josef";
            target.updateKunde(target.getKunde(1), modified);
            Assert.AreEqual("Müller", target.getKunde(1).Nachname);
            Assert.AreEqual("Josef", target.getKunde(1).Vorname);
        }

        [TestMethod]
        public void Test_UpdateReservation()
        {
            Reservation modified = Target.getReservation(1);
            DateTime newDate = DateTime.Now;
            modified.Von = newDate;
            modified.Bis = newDate.AddHours(1);
            Target.updateReservation(Target.getReservation(1), modified);
            Assert.IsTrue(newDate.ToString("MM/dd/yy H:mm:ss").Equals(Target.getReservation(1).Von.ToString("MM/dd/yy H:mm:ss")));
        }
    }
}
