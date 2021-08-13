using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC.Infrastructure
{
    public class ApiPaths
    {
        public static class Event
        {
            public static string GetAllTypes(string baseUri) //baseUri =http://localhost:7006/api/catalog
            {
                return $"{baseUri}GetByType";
            }
            public static string GetAllLocations(string baseUri)
            {
                return $"{baseUri}GetByLocation";
            }
            public static string GetAllEvents(string baseUri, int page, int take, int? type, int? location)
            {
                var filterQs = string.Empty;
                if (type.HasValue || location.HasValue)
                {
                    var typeQs = (type.HasValue) ? type.Value.ToString() : "null";
                    var locationQs = (location.HasValue) ? location.Value.ToString() : "null";
                    filterQs = $"/type/{typeQs}/ location/ {locationQs}";
                }
                return $"{baseUri}items{filterQs}?pageIndex={page}&pageSize={take}";
            }
        }
    }
}
