﻿using AutoReservation.Common.DataTransferObjects;
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
            Assert.IsTrue(reservationen.Count > 0);
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
            Assert.AreEqual(Target.GetAuto(3).ToString(),Target.GetReservation(3).Auto.ToString());
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

            Assert.AreEqual(kunde.ToString(), inserted.Kunde.ToString());
            Assert.AreEqual(auto.ToString(), inserted.Auto.ToString());
            Assert.AreEqual(new DateTime(2001, 10, 10), inserted.Von);

        }

        [TestMethod]
        public void Test_UpdateAuto()
        {
            AutoDto auto = Target.GetAuto(2);

            auto.Marke = "Ferrari";
            auto.Tagestarif = 400;

            Target.UpdateAuto(Target.GetAuto(2), auto);
            Assert.AreEqual("Ferrari", Target.GetAuto(2).Marke);
            Assert.AreEqual(400, Target.GetAuto(2).Tagestarif);
        }

        [TestMethod]
        public void Test_UpdateKunde()
        {
            KundeDto kunde = Target.GetKunde(3);

            kunde.Vorname = "Jesus";
            kunde.Nachname = "Christus";
            kunde.Geburtsdatum = new DateTime(1900, 12, 24);

            Target.UpdateKunde(Target.GetKunde(3), kunde);

            Assert.AreEqual("Jesus", Target.GetKunde(3).Vorname);
            Assert.AreEqual("Christus", Target.GetKunde(3).Nachname);
            Assert.AreEqual(new DateTime(1900, 12, 24), Target.GetKunde(3).Geburtsdatum);
        }

        [TestMethod]
        public void Test_UpdateReservation()
        {
            ReservationDto res = Target.GetReservation(2);
            int kundeid = Target.Kunden().Count;
            int autoid = Target.Autos().Count;

            res.Kunde = Target.GetKunde(kundeid);
            res.Auto = Target.GetAuto(autoid);
            res.Von = new DateTime(1990, 12, 23);
            res.Bis = new DateTime(2100, 10, 23);

            Target.UpdateReservation(Target.GetReservation(2), res);

            Assert.AreEqual(Target.GetKunde(kundeid).ToString(), Target.GetReservation(2).Kunde.ToString());
            Assert.AreEqual(Target.GetAuto(autoid).ToString(), Target.GetReservation(2).Auto.ToString());
            Assert.AreEqual(new DateTime(1990, 12, 23), Target.GetReservation(2).Von);
            Assert.AreEqual(new DateTime(2100, 10, 23), Target.GetReservation(2).Bis);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void Test_UpdateAutoWithOptimisticConcurrency()
        {
            AutoDto modified = Target.GetAuto(2);
            modified.Marke = "Lada";
            modified.Tagestarif = 100;

            Target.UpdateAuto(modified, Target.GetAuto(2));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void Test_UpdateKundeWithOptimisticConcurrency()
        {
            KundeDto modified = Target.GetKunde(2);
            modified.Vorname = "Lina";
            modified.Nachname = "Nadelmann";

            Target.UpdateKunde(modified, Target.GetKunde(2));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void Test_UpdateReservationWithOptimisticConcurrency()
        {
            ReservationDto modified = Target.GetReservation(2);
            modified.Bis = new DateTime(12,12,1990);
            modified.Von = new DateTime(12,12,1978);

            Target.UpdateReservation(modified, Target.GetReservation(2));
        }

        [TestMethod]
        public void Test_DeleteKunde()
        {
            KundeDto kunde = Target.GetKunde(1);
            Target.DeleteKunde(kunde);

            Assert.IsNull(Target.GetKunde(1));
        }

        [TestMethod]
        public void Test_DeleteAuto()
        {
            AutoDto auto = Target.GetAuto(1);
            Target.DeleteAuto(auto);

            Assert.IsNull(Target.GetAuto(1));
        }

        [TestMethod]
        public void Test_DeleteReservation()
        {
            ReservationDto res = Target.GetReservation(1);
            Target.DeleteReservation(res);

            Assert.IsNull(Target.GetReservation(1));
        }
    }
}
