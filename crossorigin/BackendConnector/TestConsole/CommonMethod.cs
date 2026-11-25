using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    public class CommonMethod
    {
        public static T DeserializeFromJson<T>(string jsonString)
        {
            return Jil.JSON.Deserialize<T>(jsonString,
                                            new Jil.Options(
                                                    dateFormat: Jil.DateTimeFormat.MicrosoftStyleMillisecondsSinceUnixEpoch,
                                                    excludeNulls: true,
                                                    includeInherited: true));
        }
    }
}
