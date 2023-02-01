using Newtonsoft.Json;

namespace Utility.Helpers
{
    public static class SerializationHelper
    {
        public static string Serialize(object obj)
        {
            try
            {
                return JsonConvert.SerializeObject(obj);
            }
            catch (Exception e)
            {
                if (e.Message.ToLower().Replace(" ", "").Contains("selfreferencingloopdetected"))
                {
                    try
                    {
                        return JsonConvert.SerializeObject(obj,
                             new JsonSerializerSettings
                             {
                                 ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                             });
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }

            return string.Empty;
        }
        public static T? Deserialize<T>(string rawinput)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(rawinput))
                    return default;

                return JsonConvert.DeserializeObject<T>(rawinput);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
