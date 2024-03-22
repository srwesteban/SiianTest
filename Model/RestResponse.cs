using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiianTest.Model
{
    public class RestResponse
    {
        private int statusCode;
        private string responseData;

        public RestResponse(int statuscode, string responseData)
        {
            this.statusCode = statuscode;
            this.responseData = responseData;   
        }
        public int StatusCode
        {
            get { return statusCode; }
        }
        public string ResponseData
        {
            get { return responseData; }
        }

        public override string ToString()
        {
            return String.Format("StatusCode : {0}\n ResponseData : {1}", statusCode, responseData);
        }
    }
}
