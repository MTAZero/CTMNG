using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.Control;

namespace EXON.Main.Module
{
    public static class ControlExtensions
    {
        public static IEnumerable<Control> All(this ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                foreach (Control grandChild in control.Controls.All())
                    yield return grandChild;

                yield return control;
            }
        }

        public static bool Have<T>(this T obj, params T[] args)
        {
            return args.Contains(obj);
        }

        public static bool In<T>(this T t, params T[] values)
        {
            foreach (T value in values)
            {
                if (t.Equals(value))
                {
                    return true;
                }
            }
            return false;
        }
       
    }
}