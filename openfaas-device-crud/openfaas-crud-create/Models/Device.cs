using System;

namespace openfaas_crud_create.Models
{
    public class Device
    {
        public Guid DeviceID { get; set; }
        public string Name { get; set; }
    }
}