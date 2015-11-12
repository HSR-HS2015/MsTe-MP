using System;
using System.Collections.Generic;
using System.Diagnostics;
using AutoReservation.Common.DataTransferObjects;
using AutoReservation.Common.Interfaces;

namespace AutoReservation.Service.Wcf
{
    public class AutoReservationService : IAutoReservationService
    {

        private static void WriteActualMethod()
        {
            Console.WriteLine("Calling: " + new StackTrace().GetFrame(1).GetMethod().Name);
        }

        public IList<AutoDto> Autos()
        {
            throw new NotImplementedException();
        }

        public void DeleteAuto(AutoDto auto)
        {
            throw new NotImplementedException();
        }

        public void DeleteKunde(KundeDto kunde)
        {
            throw new NotImplementedException();
        }

        public void DeleteReservation(ReservationDto reservation)
        {
            throw new NotImplementedException();
        }

        public AutoDto GetAuto(int id)
        {
            throw new NotImplementedException();
        }

        public IList<AutoDto> GetAutos()
        {
            throw new NotImplementedException();
        }

        public KundeDto GetKunde(int id)
        {
            throw new NotImplementedException();
        }

        public IList<KundeDto> GetKunden()
        {
            throw new NotImplementedException();
        }

        public ReservationDto GetReservation(int id)
        {
            throw new NotImplementedException();
        }

        public IList<ReservationDto> GetReservations()
        {
            throw new NotImplementedException();
        }

        public void InsertAuto(AutoDto auto)
        {
            throw new NotImplementedException();
        }

        public void InsertKunde(KundeDto kunde)
        {
            throw new NotImplementedException();
        }

        public void InsertReservation(ReservationDto reservation)
        {
            throw new NotImplementedException();
        }

        public IList<KundeDto> Kunden()
        {
            throw new NotImplementedException();
        }

        public IList<ReservationDto> Reservationen()
        {
            throw new NotImplementedException();
        }

        public void UpdateAuto(AutoDto modified, AutoDto original)
        {
            throw new NotImplementedException();
        }

        public void UpdateKunde(KundeDto modified, KundeDto original)
        {
            throw new NotImplementedException();
        }

        public void UpdateReservation(ReservationDto modified, ReservationDto original)
        {
            throw new NotImplementedException();
        }
    }
}