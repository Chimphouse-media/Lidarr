using System.Collections.Generic;
using System.Linq;
using Lidarr.Http.REST;
using NzbDrone.Common.Serializer;
using NzbDrone.Core.CustomFilters;

namespace Lidarr.Api.V1.CustomFilters
{
    public class CustomFilterResource : RestResource
    {
        public string Type { get; set; }
        public string Label { get; set; }
        public List<dynamic> Filters { get; set; }
    }

    public static class CustomFilterResourceMapper
    {
        public static CustomFilterResource ToResource(this CustomFilter model)
        {
            if (model == null)
            {
                return null;
            }

            return new CustomFilterResource
            {
                Id = model.Id,
                Type = model.Type,
                Label = model.Label,
                Filters = Json.Deserialize<List<dynamic>>(model.Filters)
            };
        }

        public static CustomFilter ToModel(this CustomFilterResource resource)
        {
            if (resource == null)
            {
                return null;
            }

            return new CustomFilter
            {
                Id = resource.Id,
                Type = resource.Type,
                Label = resource.Label,
                Filters = Json.ToJson(resource.Filters)
            };
        }

        public static List<CustomFilterResource> ToResource(this IEnumerable<CustomFilter> filters)
        {
            return filters.Select(ToResource).ToList();
        }
    }
}
