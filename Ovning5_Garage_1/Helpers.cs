namespace Ovning5_Garage_1
{
    public static class Helpers
    {
        public static bool MatchesProperties<T>(T obj, Dictionary<string, object> properties)
        {
            return properties.All(property =>
            {
                var propInfo = obj?.GetType().GetProperty(property.Key);
                return propInfo != null &&
                       propInfo.GetValue(obj) != null &&
                       PropertyValueMatches(
                           propInfo.GetValue(obj)!,
                           property.Value,
                           StringComparison.OrdinalIgnoreCase);
            });
        }

        public static bool PropertyValueMatches(object propValue, object otherPropValue, StringComparison comparsion)
        {
            if (propValue is string stringValue && otherPropValue is string otherStringValue)
            {
                return stringValue.Equals(otherStringValue, comparsion);
            }
            return propValue.Equals(otherPropValue);
        }
    }
}
