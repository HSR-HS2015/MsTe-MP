using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoReservation.Common.Interfaces;
using System.ServiceModel;

namespace AutoReservation.Ui.Factory
{
    class RemoteDataAccessServiceFactory : IServiceFactory
    {
        public IAutoReservationService GetService()
        {
            ChannelFactory<IAutoReservationService> myChannelFactory = new ChannelFactory<IAutoReservationService>("AutoReservationService");

            // Create a channel.
            return myChannelFactory.CreateChannel();
        }
    }
}
