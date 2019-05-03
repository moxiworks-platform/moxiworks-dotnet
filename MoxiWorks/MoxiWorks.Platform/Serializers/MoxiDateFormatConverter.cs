using Newtonsoft.Json.Converters;

namespace MoxiWorks.Platform.Serializers
{
    internal class MoxiDateFormatConverter : IsoDateTimeConverter
    {
        public MoxiDateFormatConverter(string format)
        {
            DateTimeFormat = format;
        }
    }
}