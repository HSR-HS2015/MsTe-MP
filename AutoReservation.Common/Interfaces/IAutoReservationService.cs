﻿using System.Collections.Generic;
using System.ServiceModel;
using AutoReservation.Common.DataTransferObjects;

namespace AutoReservation.Common.Interfaces
{
    [ServiceContract]
    public interface IAutoReservationService
    {

        [OperationContract]
        IList<KundeDto> GetKunden();

        [OperationContract]
        KundeDto GetKunde(int id);

        [OperationContract]
        void InsertKunde(KundeDto kunde);

        [OperationContract]
        void UpdateKunde(KundeDto modified, KundeDto original);

        [OperationContract]
        void DeleteKunde(KundeDto kunde);



        [OperationContract]
        IList<AutoDto> GetAutos();

        [OperationContract]
        AutoDto GetAuto(int id);

        [OperationContract]
        void InsertAuto(AutoDto auto);

        [OperationContract]
        void UpdateAuto(AutoDto modified, AutoDto original);

        [OperationContract]
        void DeleteAuto(AutoDto auto);



        [OperationContract]
        IList<ReservationDto> GetReservations();

        [OperationContract]
        ReservationDto GetReservation(int id);

        [OperationContract]
        void InsertReservation(ReservationDto reservation);

        [OperationContract]
        void UpdateReservation(ReservationDto modified, ReservationDto original);

        [OperationContract]
        void DeleteReservation(ReservationDto reservation);
    }
}
