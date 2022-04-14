using System.Collections.Generic;
using UnityEngine;

namespace Adobe.Substance.Input.Description
{
    [System.Serializable]
    public class SubstanceInputDescription
    {
        public string Identifier;

        public string Label;

        public string GuiGroup;

        public string GuiDescription;

        public string GuiVisibleIf;

        public int Index;

        public SubstanceValueType Type;

        public SubstanceWidgetType WidgetType;

        public bool IsNumerical()
        {
            return Type == SubstanceValueType.Float ||
                   Type == SubstanceValueType.Float2 ||
                   Type == SubstanceValueType.Float3 ||
                   Type == SubstanceValueType.Float4 ||
                   Type == SubstanceValueType.Int ||
                   Type == SubstanceValueType.Int2 ||
                   Type == SubstanceValueType.Int3 ||
                   Type == SubstanceValueType.Int4;
        }
    }
}