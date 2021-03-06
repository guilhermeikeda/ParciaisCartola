﻿namespace ParciaisCartola.Models.Requests
{
    public class RequestGloboLogin
    {
        public Payload payload { get; set; }
        public string captcha = "";

        public RequestGloboLogin(string email, string password)
        {
            this.payload = new Payload() { email = email, password = password, serviceId = 438 };
        }

        public class Payload
        {
            public string email { get; set; }
            public string password { get; set; }
            public int serviceId { get; set; }
        }
    }
}