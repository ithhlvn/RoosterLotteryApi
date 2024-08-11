using System.ComponentModel;

namespace RoosterLotteryApi.Models
{
    public enum Gender : byte
    {
        [Description("Nam")]
        Male = 1,
        [Description("Nữ")]
        Female = 2,
        [Description("Chưa xác định")]
        Unspecified = 3
    }

    public enum SlotEnum:byte
    {
        [Description("All")]
        SlotAll = 0,
        [Description("Slot1")]
        Slot1 = 1,
        [Description("Slot2")]
        Slot2 = 2,
        [Description("Slot3")]
        Slot3 = 3,
        [Description("Slot4")]
        Slot4 = 4,
        [Description("Slot5")]
        Slot5 = 5,
        [Description("Slot6")]
        Slot6 = 6,
        [Description("Slot7")]
        Slot7 = 7,
        [Description("Slot8")]
        Slot8 = 8,
        [Description("Slot9")]
        Slot9 = 9,
        [Description("Slot10")]
        Slot10 = 10,
        [Description("Slot11")]
        Slot11 = 11,
        [Description("Slot12")]
        Slot12 = 12,
        [Description("Slot13")]
        Slot13 = 13,
        [Description("Slot14")]
        Slot14 = 14,
        [Description("Slot15")]
        Slot15 = 15,
        [Description("Slot16")]
        Slot16 = 16,
        [Description("Slot17")]
        Slot17 = 17,
        [Description("Slot18")]
        Slot18 = 18,
        [Description("Slot19")]
        Slot19 = 19,
        [Description("Slot20")]
        Slot20 = 20,
        [Description("Slot21")]
        Slot21 = 21,
        [Description("Slot22")]
        Slot22 = 22,
        [Description("Slot23")]
        Slot23 = 23,
        [Description("Slot24")]
        Slot24 = 24,
    }
}
