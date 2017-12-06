using Common;
using DogFightServer.Server;
using System;
using System.Collections.Generic;
using System.Text;

namespace DogFightServer.Controller
{
    abstract class BaseController
    {
        RequestCode requestCode = RequestCode.None;
        public RequestCode RequestCode { get { return requestCode; } }

        public virtual string DefaultHandle(string data,Client client,ServerEntry server) { return null; }
    }
}
