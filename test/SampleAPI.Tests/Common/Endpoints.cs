using System;
using System.Collections.Generic;
using System.Text;

namespace SampleAPI.Tests.Common
{
    static class Endpoints
    {
        //user
        public const string USERS = "/api/users";

        public const string GETUSER = "/api/users/ByUsername";

        public const string VALIDATE = "/api/users/ValidateCredentiales";

        //MedicalAppointment
        public const string MEDICALAPPOINTMENTS = "/api/MedicalAppointments";
        public const string BYUSERNAME = "/api/users/ByUsername";
    }
}
