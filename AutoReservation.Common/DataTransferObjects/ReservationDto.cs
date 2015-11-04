using AutoReservation.Common.Extensions;
using AutoReservation.Common.DataTransferObjects.Core;
using System.Text;
using System.Runtime.Serialization;
using System;

namespace AutoReservation.Common.DataTransferObjects
{
    [DataContract]
    public class ReservationDto : DtoBase<ReservationDto>
    {

        private int reservationNr;
        private DateTime von;
        private DateTime bis;
        private AutoDto auto;
        private KundeDto kunde;

        [DataMember]
        public int ReservationNr
        {
            get { return reservationNr; }
            set
            {
                if(reservationNr != value)
                {
                    reservationNr = value;
                    this.OnPropertyChanged(p => p.reservationNr);
                }
            }
        }

        [DataMember]
        public DateTime Von
        {
            get { return von; }
            set
            {
                if(!von.Equals(value))
                {
                    von = value;
                    this.OnPropertyChanged(p => p.von);
                }
            }
        }

        [DataMember]
        public DateTime Bis
        {
            get { return bis; }
            set
            {
                if(!bis.Equals(value))
                {
                    bis = value;
                    this.OnPropertyChanged(p => p.bis);
                }
            }
        }

        [DataMember]
        public AutoDto Auto
        {
            get { return auto; }
            set
            {
                if(!auto.Equals(value))
                {
                    auto = value;
                    this.OnPropertyChanged(p => p.auto);
                }
            }
        }

        [DataMember]
        public KundeDto Kunde
        {
            get { return kunde; }
            set
            {
                if(!kunde.Equals(value))
                {
                    kunde = value;
                    this.OnPropertyChanged(p => p.kunde);
                }
            }
        }


        public override string Validate()
        {
            StringBuilder error = new StringBuilder();
            if (Von == DateTime.MinValue)
            {
                error.AppendLine("- Von-Datum ist nicht gesetzt.");
            }
            if (Bis == DateTime.MinValue)
            {
                error.AppendLine("- Bis-Datum ist nicht gesetzt.");
            }
            if (Von > Bis)
            {
                error.AppendLine("- Von-Datum ist grösser als Bis-Datum.");
            }
            if (Auto == null)
            {
                error.AppendLine("- Auto ist nicht zugewiesen.");
            }
            else
            {
                string autoError = Auto.Validate();
                if (!string.IsNullOrEmpty(autoError))
                {
                    error.AppendLine(autoError);
                }
            }
            if (Kunde == null)
            {
                error.AppendLine("- Kunde ist nicht zugewiesen.");
            }
            else
            {
                string kundeError = Kunde.Validate();
                if (!string.IsNullOrEmpty(kundeError))
                {
                    error.AppendLine(kundeError);
                }
            }


            if (error.Length == 0) { return null; }

            return error.ToString();
        }

        public override ReservationDto Clone()
        {
            return new ReservationDto
            {
                ReservationNr = ReservationNr,
                Von = Von,
                Bis = Bis,
                Auto = Auto.Clone(),
                Kunde = Kunde.Clone()
            };
        }

        public override string ToString()
        {
            return string.Format(
                "{0}; {1}; {2}; {3}; {4}",
                ReservationNr,
                Von,
                Bis,
                Auto,
                Kunde);
        }
    }
}
