using System;
using System.Windows.Forms;
using Backend;

namespace Frontend.Windows
{
    public partial class Form1 : Form
    {
        private string _expression = string.Empty;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var text = btn.Text;

            if (text == "Clear")
            {
                _expression = string.Empty;
                _display.Text = string.Empty;
            }
            else if (text == "Delete")
            {
                if (_expression.Length > 0)
                {
                    _expression = _expression.Substring(0, _expression.Length - 1);
                    _display.Text = _expression;
                }
            }
            else if (text == "=")
            {
                try
                {
                    if (!string.IsNullOrWhiteSpace(_expression))
                    {
                        var result = ExpressionEvaluator.Evalute(_expression);
                        
                        // Display the full operation and keep the result for chained calculations
                        _display.Text = $"{_expression}={result}";
                        _expression = result.ToString(System.Globalization.CultureInfo.InvariantCulture);
                    }
                }
                catch (Exception)
                {
                    _display.Text = "Error";
                    _expression = string.Empty;
                }
            }
            else
            {
                _expression += text;
                _display.Text = _expression;
            }
        }
    }
}
