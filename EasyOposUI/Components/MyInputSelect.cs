using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace EasyOposUI.Components
{
    public class MyInputSelect<TValue> : InputSelect<TValue>
    {
        private ElementReference _element;
        private string _fieldClass;

        protected override void OnParametersSet()
        {
            
            var fieldClass = EditContext?.FieldCssClass(FieldIdentifier) ?? string.Empty;
            if(Element is not null)
            {
                if (fieldClass != _fieldClass || Element?.Id != _element.Id)
                {
                    _fieldClass = fieldClass;
                    _element = (ElementReference)Element;
                    base.OnParametersSet();
                }
            }
        }
    }
}
