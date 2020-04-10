using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace DDDWithEF.Persistence
{
    public static class PropertyBuilderExtension
    {
        public static PropertyBuilder<T> HasJsonConversion<T>(this PropertyBuilder<T> propertyBuilder)
        {

            return propertyBuilder.HasConversion(v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<T>(v));
        }
    }
}
