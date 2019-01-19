using System;
using System.Text;
using Newtonsoft.Json;

namespace Function
{
    public class FunctionHandler
    {
        public void Handle(string input) {
            int value = DateTime.Now.Year;
            if (!string.IsNullOrWhiteSpace(input))
            {
                dynamic jsonResponse = JsonConvert.DeserializeObject(input);
                if (jsonResponse.value != null)
                {
                    value = (int) jsonResponse.value;
                }
            }
        }
    }
}
