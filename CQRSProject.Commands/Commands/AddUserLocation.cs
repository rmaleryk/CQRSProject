using System;
using CQRSProject.Commands.Extensibility;

namespace CQRSProject.Commands.Commands
{
    public class AddUserLocation : ICommand
    {
        public Guid UserId { get; }

        public double Latitude { get; }

        public double Longitude { get; }

        public double Height { get; }

        public AddUserLocation(Guid userId, double latitude, double longitude, double height)
        {
            UserId = userId;
            Latitude = latitude;
            Longitude = longitude;
            Height = height;
        }
    }
}