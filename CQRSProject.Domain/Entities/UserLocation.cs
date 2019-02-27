using System;

namespace CQRSProject.Core.Entities
{
    public class UserLocation
    {
        public Guid Id { get; }

        public Guid UserId { get; }

        public DateTime Date { get; }

        public double Latitude { get; }

        public double Longitude { get; }

        public double Height { get; }

        public UserLocation(Guid id, Guid userId, DateTime date, double latitude, double longitude, double height)
        {
            Id = id;
            UserId = userId;
            Date = date;
            Latitude = latitude;
            Longitude = longitude;
            Height = height;
        }
    }
}