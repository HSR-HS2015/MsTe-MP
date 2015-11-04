using AutoReservation.Common.Extensions;
using AutoReservation.Common.DataTransferObjects.Core;
using System;
using System.Text;
using System.Runtime.Serialization;

namespace AutoReservation.Common.DataTransferObjects
{
    [DataContract]
    public class AutoDto : DtoBase<AutoDto>
    {
        private int id;
        private int basistarif;
        private string marke;
        private int tagestarif;
        private AutoKlasse autoKlasse;

        [DataMember]
        public int Id
        {
            get { return id; }
            set
            {
                if(id != value)
                {
                    id = value;
                    this.OnPropertyChanged(p => p.id);
                }
            }
        }

        [DataMember]
        public int Basistarif
        {
            get { return basistarif; }
            set
            {
                if(basistarif != value)
                {
                    basistarif = value;
                    this.OnPropertyChanged(p => p.basistarif);
                }
            }
        }


        [DataMember]
        public string Marke
        {
            get { return marke; }
            set
            {
                if(marke != value)
                {
                    marke = value;
                    this.OnPropertyChanged(p => p.marke);
                }
            }
        }

        [DataMember]
        public int Tagestarif
        {
            get { return tagestarif; }
            set
            {
                if(tagestarif != value)
                {
                    tagestarif = value;
                    this.OnPropertyChanged(p => p.tagestarif);
                }
            }
        }

        [DataMember]
        public AutoKlasse AutoKlasse
        {
            get { return autoKlasse; }
            set
            {
                if(!autoKlasse.Equals(value))
                {
                    autoKlasse = value;
                    this.OnPropertyChanged(p => p.AutoKlasse);
                }
                    
            }
        }

        public override string Validate()
        {
            StringBuilder error = new StringBuilder();
            if (string.IsNullOrEmpty(marke))
            {
                error.AppendLine("- Marke ist nicht gesetzt.");
            }
            if (tagestarif <= 0)
            {
                error.AppendLine("- Tagestarif muss grösser als 0 sein.");
            }
            if (AutoKlasse == AutoKlasse.Luxusklasse && basistarif <= 0)
            {
                error.AppendLine("- Basistarif eines Luxusautos muss grösser als 0 sein.");
            }

            if (error.Length == 0) { return null; }

            return error.ToString();
        }

        public override AutoDto Clone()
        {
            return new AutoDto
            {
                Id = Id,
                Marke = Marke,
                Tagestarif = Tagestarif,
                AutoKlasse = AutoKlasse,
                Basistarif = Basistarif
            };
        }

        public override string ToString()
        {
            return string.Format(
                "{0}; {1}; {2}; {3}; {4}",
                Id,
                Marke,
                Tagestarif,
                Basistarif,
                AutoKlasse);
        }
       
    }
}
