using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BananaPour.Project;

internal class ProjectLocalConfigBucketEventGraph
{
    private List<string> _pins = [];
    [JsonInclude]
    internal List<string> NodePins
    {
        get { return _pins; }
        set { _pins = value; }
    }
};