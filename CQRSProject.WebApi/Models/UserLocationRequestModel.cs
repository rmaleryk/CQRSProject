using System;

namespace CQRSProject.WebApi.Models
{
    public class UserLocationRequestModel
    {
        public Guid UserId { get; set; }

        public double Latitude { get; set;  }

        public double Longitude { get; set; }

        public double Height { get; set; }
    }
}