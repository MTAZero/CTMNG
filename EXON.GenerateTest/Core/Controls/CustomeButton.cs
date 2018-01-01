using EXON.GenerateTest.Core.Common;
using System.Drawing;
using System.Windows.Forms;

namespace EXON.GenerateTest.Core.Controls
{
    public partial class CustomeButton : Button
    {
        private static string[] ColourValues = new string[] {
        "C08040", "000080", "C0C000", "4080C0", "FF40FF", "00FFFF", "000000",
        "800000", "008000", "000080", "808000", "800080", "008080", "808080",
        "C00000", "00C000", "0000C0", "C0C000", "C000C0", "00C0C0", "C0C0C0",
        "400000", "004000", "000040", "404000", "400040", "004040", "404040",
        "200000", "002000", "000020", "202000", "200020", "002020", "202020",
        "600000", "006000", "000060", "606000", "600060", "006060", "606060",
        "A00000", "00A000", "0000A0", "A0A000", "A000A0", "00A0A0", "A0A0A0",
        "E00000", "00E000", "0000E0", "E0E000", "E000E0", "00E0E0", "E0E0E0",
        };

        public CustomeButton()
        {
            this.Dock = System.Windows.Forms.DockStyle.Top;
            this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.BackColor = System.Drawing.Color.Transparent;
            this.ForeColor = System.Drawing.Color.White;
            this.Size = new System.Drawing.Size(120, 45);
            this.AutoSize = true;

            this.TextChanged += CustomeButton_TextChanged;           
        }

        private void CustomeButton_TextChanged(object sender, System.EventArgs e)
        {
            AutoLoadImage();
        }

        private void AutoLoadColor(string color)
        {
            this.ForeColor = Color.Black;//System.Drawing.ColorTranslator.FromHtml("#" + color);           
            this.FlatAppearance.BorderSize = 0;
        }

        private void AutoLoadImage()
        {
            if (this.Text.ToLower().Contains(SubjectName.Math))
            {
                this.Image = global::EXON.GenerateTest.Properties.Resources.Math;
                AutoLoadColor(ColourValues[0]);
                return;
            }
            else if (this.Text.ToLower().Contains(SubjectName.Physical))
            {
                this.Image = global::EXON.GenerateTest.Properties.Resources.physics;
                AutoLoadColor(ColourValues[1]);
                return;
            }
            else if (this.Text.ToLower().Contains(SubjectName.Chemistry))
            {
                this.Image = global::EXON.GenerateTest.Properties.Resources.Chemistry;
                AutoLoadColor(ColourValues[2]);
                return;
            }
            else if (this.Text.ToLower().Contains(SubjectName.English))
            {
                this.Image = global::EXON.GenerateTest.Properties.Resources.Language;
                AutoLoadColor(ColourValues[3]);
                return;
            }
            else
            {
                this.Image = global::EXON.GenerateTest.Properties.Resources.Subject;
                AutoLoadColor(ColourValues[0]);
            }
        }
    }
}