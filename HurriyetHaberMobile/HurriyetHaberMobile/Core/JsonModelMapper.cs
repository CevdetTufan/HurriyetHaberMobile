using Newtonsoft.Json;
using System.Collections.Generic;

namespace HurriyetHaberMobile.Core
{
    public class JsonModelMapper<T> where T : class
    {
        public List<T> GetList(string json)
        {
            return JsonConvert.DeserializeObject<List<T>>(json);
        }

        public T GetItem(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
