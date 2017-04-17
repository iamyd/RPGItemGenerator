using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFBattle
{
    public class TextBoxStreamWriter : System.IO.TextWriter
    {
        private System.Windows.Controls.TextBox textbox;

        public TextBoxStreamWriter(System.Windows.Controls.TextBox t)
        {
            textbox = t;
        }
        public override Encoding Encoding
        {
            get { return System.Text.Encoding.UTF8; }
        }

        public override void Write(char value)
        {
            base.Write(value);
            textbox.Dispatcher.BeginInvoke(new Action(() =>
            {
                textbox.AppendText(value.ToString());
                textbox.ScrollToEnd();
            })
            ); // When character data is written, append it to the text box.
        }
    }
}