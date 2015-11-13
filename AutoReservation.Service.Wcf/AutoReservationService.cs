using System;
using System.Collections.Generic;
using System.Diagnostics;
using AutoReservation.Common.DataTransferObjects;
using AutoReservation.Common.Interfaces;
using AutoReservation.BusinessLayer;

namespace AutoReservation.Service.Wcf
{
    public class AutoReservationService : IAutoReservationService
    {
        private AutoReservationBusinessComponent component;

        private static void WriteActualMethod()
        {
            Console.WriteLine("Calling: " + new StackTrace().GetFrame(1).GetMethod().Name);
        }

        public AutoReservationService()
        {
            WriteActualMethod();
            component = new AutoReservationBusinessComponent();
        }

        public IList<AutoDto> Autos()
        {
            WriteActualMethod();
            return component.GetAutos().ConvertToDtos();
        }

        public AutoDto GetAuto(int id)
        {
            WriteActualMethod();
            return component.GetAuto(id).ConvertToDto();
        }

        public void InsertAuto(AutoDto auto)
        {
            WriteActualMethod();
            component.AddAuto(auto.ConvertToEntity());
        }

        public void UpdateAuto(AutoDto original, AutoDto modified )
        {
            WriteActualMethod();
            component.UupdateAuto(original.ConvertToEntity(), modified.ConvertToEntity());
        }

        public void DeleteAuto(AutoDto auto)
        {
            WriteActualMethod();
            component.DeleteAuto(auto.ConvertToEntity());
        }


        public IList<KundeDto> Kunden()
        {
            WriteActualMethod();
            return component.GetKunden().ConvertToDtos();
        }

        public KundeDto GetKunde(int id)
        {
            WriteActualMethod();
            return component.GetKunde(id).ConvertToDto();
        }

        public void InsertKunde(KundeDto kunde)
        {
            WriteActualMethod();
            component.AddKunde(kunde.ConvertToEntity());
        }


        public void UpdateKunde(KundeDto original, KundeDto modified )
        {
            WriteActualMethod();
            component.UpdateKunde(original.ConvertToEntity(), modified.ConvertToEntity());
        }

        public void DeleteKunde(KundeDto kunde)
        {
            WriteActualMethod();
            component.DeleteKunde(kunde.ConvertToEntity());
        }

        public IList<ReservationDto> Reservationen()
        {
            WriteActualMethod();
            return component.Reservationen().ConvertToDtos();
        }

        public ReservationDto GetReservation(int id)
        {
            WriteActualMethod();
            return component.GetReservation(id).ConvertToDto();
        }

        public void InsertReservation(ReservationDto reservation)
        {
            WriteActualMethod();
            component.AddReservation(reservation.ConvertToEntity());
        }

        public void UpdateReservation(ReservationDto original, ReservationDto modified )
        {
            WriteActualMethod();
            component.UpdateReservation(original.ConvertToEntity(), modified.ConvertToEntity());
        }

        public void DeleteReservation(ReservationDto reservation)
        {
            WriteActualMethod();
            component.DeleteReservation(reservation.ConvertToEntity());
        }

    }
}