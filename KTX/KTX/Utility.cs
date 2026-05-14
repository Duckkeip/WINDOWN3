using KTX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class Utility
    {
        static public Staff staff;
        static public bool IsOpeningForm(string formname)
        {
            foreach (Form f in Application.OpenForms)
                if (f.Name == formname)
                    return true;
            return false;
        }
    }
}
