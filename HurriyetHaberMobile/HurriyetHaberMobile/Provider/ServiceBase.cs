using System;
using System.Collections.Generic;
using System.Text;

namespace HurriyetHaberMobile.Provider
{
    public abstract class ServiceBase : IService
    {
        public abstract string Get(string address);
    }
}
