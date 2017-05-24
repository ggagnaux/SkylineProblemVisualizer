using System.ComponentModel;
using System.Windows.Forms;

namespace SkylineProblemVisualizer.UI
{
    class BindableToolStripMenuItem : ToolStripMenuItem, IBindableComponent
    {
        private BindingContext _bindingContext;
        private ControlBindingsCollection _dataBindings;

        [Browsable(false)]
        public BindingContext BindingContext
        {
            get
            {
                if (this._bindingContext == null)
                {
                    this._bindingContext = new BindingContext();
                }
                return this._bindingContext;
            }
            set
            {
                this._bindingContext = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ControlBindingsCollection DataBindings
        {
            get
            {
                if (this._dataBindings == null)
                {
                    this._dataBindings = new ControlBindingsCollection(this);
                }
                return this._dataBindings;
            }
        }
    }
}
