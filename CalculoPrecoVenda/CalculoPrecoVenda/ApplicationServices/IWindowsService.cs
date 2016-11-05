using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculoPrecoVenda.ApplicationServices
{
    public interface IWindowsService
    {
        void PutFocusOnForm();
        void ConfirmSabe();
        void ConfirmDelete();
        void CloseWindow();
        void UpdateBindings();

    }
}
