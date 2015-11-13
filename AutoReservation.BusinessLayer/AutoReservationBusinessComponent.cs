using AutoReservation.Dal;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace AutoReservation.BusinessLayer
{
    public class AutoReservationBusinessComponent
    {
        private AutoReservationEntities context;

        public AutoReservationBusinessComponent() 
        {
            context = new AutoReservationEntities();
        }

        /*
            Autos
        */

        public IList<Auto> GetAutos()
        {
            return context.Autos.AsNoTracking().ToList();
        }

        public Auto GetAuto(int id)
        {
            return context.Autos.AsNoTracking().SingleOrDefault(a => a.Id == id);
        }

        public void UpdateAuto(Auto original, Auto modified)
        {
            context.Autos.Attach(original);
            context.Entry(original).CurrentValues.SetValues(modified);

            try
            {
               context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                HandleDbConcurrencyException(context, original);
            }
            context.Entry(original).State = EntityState.Detached;

        }

        public void DeleteAuto(Auto auto)
        {
            context.Autos.Attach(auto);
            context.Autos.Remove(auto);
            context.SaveChanges();
            context.Entry(auto).State = EntityState.Detached;
        }

        public void AddAuto(Auto auto)
        {
            context.Autos.Add(auto);
            context.SaveChanges();

            context.Entry(auto).State = EntityState.Detached;
        }

        /*
            Kunde
        */

        public IList<Kunde> GetKunden()
        {
            return context.Kunden.AsNoTracking().ToList();
        }

        public Kunde GetKunde(int id)
        {
            return context.Kunden.AsNoTracking().SingleOrDefault(a => a.Id == id);
        }

        public void UpdateKunde(Kunde original, Kunde modified)
        {
            context.Kunden.Attach(original);
            context.Entry(original).CurrentValues.SetValues(modified);

            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                HandleDbConcurrencyException(context, original);
            }
            context.Entry(original).State = EntityState.Detached;

        }

        public void DeleteKunde(Kunde kunde)
        {
            context.Kunden.Attach(kunde);
            context.Kunden.Remove(kunde);
            context.SaveChanges();
            context.Entry(kunde).State = EntityState.Detached;
        }

        public void AddKunde(Kunde kunde)
        {
            context.Kunden.Add(kunde);
            context.SaveChanges();

            context.Entry(kunde).State = EntityState.Detached;
        }

        /*
            Reservation
        */

        public IList<Reservation> GetReservationen()
        {
            return context.Reservationen.AsNoTracking().ToList();
        }

        public Reservation GetReservation(int ResNr)
        {
            return context.Reservationen.AsNoTracking().SingleOrDefault(a => a.ReservationNr == ResNr);
        }

        public void UpdateReservation(Reservation original, Reservation modified)
        {
            context.Reservationen.Attach(original);
            context.Entry(original).CurrentValues.SetValues(modified);

            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                HandleDbConcurrencyException(context, original);
            }
            context.Entry(original).State = EntityState.Detached;

        }

        public void DeleteReservation(Reservation reservation)
        {
            context.Reservationen.Attach(reservation);
            context.Reservationen.Remove(reservation);
            context.SaveChanges();
            context.Entry(reservation).State = EntityState.Detached;
        }

        public void AddReservation(Reservation reservation)
        {
            context.Reservationen.Add(reservation);
            context.SaveChanges();

            context.Entry(reservation).State = EntityState.Detached;
        }


        private static void HandleDbConcurrencyException<T>(AutoReservationEntities context, T original) where T : class
        {
            var databaseValue = context.Entry(original).GetDatabaseValues();
            context.Entry(original).CurrentValues.SetValues(databaseValue);

            throw new LocalOptimisticConcurrencyException<T>(string.Format("Update {0}: Concurrency-Fehler", typeof(T).Name), original);
        }
    }
}