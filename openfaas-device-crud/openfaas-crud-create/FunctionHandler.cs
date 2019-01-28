using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using openfaas_crud_create.Models;

namespace Function
{
    public class FunctionHandler
    {
        public string Handle(string input)
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                string schemaJson = @"{
                    'type': 'object',
                    'properties': {
                        'id': {'type': ['string', 'null']},
                        'name': {'type':'string'}
                    },
                    'required': ['id', 'name'],
                    'additionalProperties': false
                }";

                JSchema schema = JSchema.Parse(schemaJson);

                JObject jdevice = JObject.Parse(input);

                IList<string> errorMessages;
                bool valid = jdevice.IsValid(schema, out errorMessages);

                if (valid == true)
                {
                    var device = jdevice.ToObject<Device>();
                }

                return valid.ToString();
            }
            else
            {
                throw new ArgumentNullException(nameof(input));
            }
        }
    }
}
