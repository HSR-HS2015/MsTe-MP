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
            Auto modified = Target.GetAuto(1);
            modified.Marke = "Suzuki";
            modified.Tagestarif = 200;
            Target.UupdateAuto(Target.GetAuto(1), modified);

            Assert.AreEqual("Suzuki", Target.GetAuto(1).Marke);
            Assert.AreEqual(200, Target.GetAuto(1).Tagestarif);
        }

        [TestMethod]
        public void Test_UpdateKunde()
        {
            Kunde modified = Target.GetKunde(1);
            modified.Nachname = "Müller";
            modified.Vorname = "Josef";
            Target.UpdateKunde(Target.GetKunde(1), modified);
            Assert.AreEqual("Müller", Target.GetKunde(1).Nachname);
            Assert.AreEqual("Josef", Target.GetKunde(1).Vorname);
        }

        [TestMethod]
        public void Test_UpdateReservation()
        {
            Reservation modified = Target.GetReservation(1);
            DateTime newDate = DateTime.Now;
            modified.Von = newDate;
            modified.Bis = newDate.AddHours(1);
            Target.UpdateReservation(Target.GetReservation(1), modified);
            Assert.IsTrue(newDate.ToString("MM/dd/yy H:mm:ss").Equals(Target.GetReservation(1).Von.ToString("MM/dd/yy H:mm:ss")));
        }
    }
}
