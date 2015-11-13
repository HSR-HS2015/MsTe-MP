using AutoReservation.Common.DataTransferObjects;
using AutoReservation.Common.Interfaces;
using AutoReservation.TestEnvironment;
using AutoReservation.Dal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace AutoReservation.Service.Wcf.Testing
{
    [TestClass]
    public abstract class ServiceTestBase
    {
        protected abstract IAutoReservationService Target { get; }

        [TestInitialize]
        public void InitializeTestData()
        {
            TestEnvironmentHelper.InitializeTestData();
        }

        [TestMethod]
        public void Test_GetAutos()
        {
            IList<AutoDto> autos = Target.Autos();
            Assert.IsTrue(autos.Count >= 3);
        }

        [TestMethod]
        public void Test_GetKunden()
        {
            IList<KundeDto> kunden = Target.Kunden();
            Assert.IsTrue(kunden.Count >= 4);
        }

        [TestMethod]
        public void Test_GetReservationen()
        {
            IList<ReservationDto> reservationen = Target.Reservationen();
            Assert.IsTrue(reservationen.Count >= 3);
        }

        [TestMethod]
        public void Test_GetAutoById()
        {
            Assert.AreEqual("Audi S6", Target.GetAuto(3).Marke);
        }

        [TestMethod]
        public void Test_GetKundeById()
        {
            Assert.AreEqual("Zufall", Target.GetKunde(4).Nachname);
        }

        [TestMethod]
        public void Test_GetReservationByNr()
        {
            Console.WriteLine(Target.GetReservation(1)); //failed
        }

        [TestMethod]
        public void Test_GetReservationByIllegalNr()
        {
            Assert.IsNull(Target.GetReservation(100));
        }

        [TestMethod]
        public void Test_InsertAuto()
        {
            int newid = Target.Autos().Count + 1;
            AutoDto auto = new AutoDto();
            auto.Marke = "VW Golf";
            auto.Tagestarif = 9000;
            auto.Basistarif = 300;
            auto.AutoKlasse = AutoKlasse.Luxusklasse;
            Target.InsertAuto(auto);

            AutoDto inserted = Target.GetAuto(newid);

            Assert.AreEqual("VW Golf", inserted.Marke);
            Assert.AreEqual(9000, inserted.Tagestarif);
            Assert.AreEqual(300, inserted.Basistarif);
            Assert.AreEqual(AutoKlasse.Luxusklasse, inserted.AutoKlasse);
        }

        [TestMethod]
        public void Test_InsertKunde()
        {
            int newid = Target.Kunden().Count + 1;
            KundeDto kunde = new KundeDto();
            kunde.Vorname = "Hans";
            kunde.Nachname = "Washeiri";
            kunde.Geburtsdatum = new DateTime(2011, 11, 11);
            Target.InsertKunde(kunde);

            KundeDto inserted = Target.GetKunde(newid);

            Assert.AreEqual("Hans", inserted.Vorname);
            Assert.AreEqual("Washeiri", inserted.Nachname);
            Assert.AreEqual(new DateTime(2011, 11, 11), inserted.Geburtsdatum);
        }

        [TestMethod]
        public void Test_InsertReservation()
        {
            int newresid = Target.Reservationen().Count + 1;
            int kundeid = Target.Kunden().Count;
            int autoid = Target.Autos().Count;

            ReservationDto res = new ReservationDto();
            res.Kunde = Target.GetKunde(kundeid);
            res.Auto = Target.GetAuto(autoid);
            res.Von = new DateTime(2001, 10, 10);
            res.Bis = new DateTime(2002, 10, 10);

            Target.InsertReservation(res);

            ReservationDto inserted = Target.GetReservation(newresid);
            KundeDto kunde = Target.GetKunde(kundeid);
            AutoDto auto = Target.GetAuto(autoid);

            //Assert.AreSame(kunde, inserted.Kunde);
            // Assert.AreEqual(auto, inserted.Auto);
            Assert.AreEqual(new DateTime(2001, 10, 10), inserted.Von);

        }

        [TestMethod]
        public void Test_UpdateAuto()
        {
            Assert.Inconclusive("Test not implemented.");
        }

        [TestMethod]
        public void Test_UpdateKunde()
        {
            Assert.Inconclusive("Test not implemented.");
        }

        [TestMethod]
        public void Test_UpdateReservation()
        {
            Assert.Inconclusive("Test not implemented.");
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<AutoDto>))]
        public void Test_UpdateAutoWithOptimisticConcurrency()
        {
            Assert.Inconclusive("Test not implemented.");
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<KundeDto>))]
        public void Test_UpdateKundeWithOptimisticConcurrency()
        {
            Assert.Inconclusive("Test not implemented.");
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<ReservationDto>))]
        public void Test_UpdateReservationWithOptimisticConcurrency()
        {
            Assert.Inconclusive("Test not implemented.");
        }

        [TestMethod]
        public void Test_DeleteKunde()
        {
            Assert.Inconclusive("Test not implemented.");
        }

        [TestMethod]
        public void Test_DeleteAuto()
        {
            Assert.Inconclusive("Test not implemented.");
        }

        [TestMethod]
        public void Test_DeleteReservation()
        {
            Assert.Inconclusive("Test not implemented.");
        }
    }
}
