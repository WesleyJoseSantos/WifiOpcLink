using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WifiOpcLink
{
    [JsonObject(MemberSerialization.OptIn)]
    public class OpcItem : Component
    {
        [JsonProperty]
        [Category("OPC Item")]
        [Description("OPC Id of this opc item.")]
        public string Id { get; set; }

        [JsonProperty]
        [Category("OPC Item")]
        [Description("Tag name of this opc item.")]
        public string Tag { get; set; }

        [JsonProperty]
        [Category("OPC Item")]
        [Description("Value of this opc item.")]
        public object Value { get; set; }
    }

    public class Tag
    {
        [JsonProperty]
        [Category("Tag Property")]
        [Description("Tag name.")]
        public string Name { get; set; }

        [JsonProperty]
        [Category("Tag Property")]
        [Description("Tag value.")]
        public object Value { get; set; }
    }
}
