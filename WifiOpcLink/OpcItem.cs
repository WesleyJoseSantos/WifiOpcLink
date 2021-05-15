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
    public enum OpcItemStatus
    {
        Good,
        Bad
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class OpcItem : Component
    {
        [JsonProperty]
        [Category("OPC Information")]
        [Description("OPC Id of this opc item.")]
        public string Id { get; set; }

        [JsonProperty]
        [Category("OPC Information")]
        [Description("Value of this opc item.")]
        public object Value { get; set; }

        [Category("OPC Information")]
        [Description("Quality of this item.")]
        public OpcItemStatus Status { get; set; }

        [JsonProperty]
        [Category("Data Link Information")]
        [Description("Tag name of this opc item.")]
        public string Tag { get; set; }

        [JsonProperty]
        [Category("Data Link Options")]
        [Description("Reverse logic status of this opc item.")]
        public bool Reverse { get; set; }

        [JsonProperty]
        [Category("Data Link Options")]
        [Description("Get bit of this opc. -1 to use entire value.")]
        public int GetBit { get; set; }

        public OpcItem()
        {
            GetBit = -1;
        }
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
