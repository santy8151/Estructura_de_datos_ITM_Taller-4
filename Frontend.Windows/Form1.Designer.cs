namespace Frontend.Windows
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 450);
            this.Text = "Functions Evaluator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.Black;
            
            // Build layout
            var table = new System.Windows.Forms.TableLayoutPanel();
            table.ColumnCount = 7;
            table.RowCount = 5;
            table.Dock = System.Windows.Forms.DockStyle.Fill;
            table.Padding = new System.Windows.Forms.Padding(10);
            
            for (int i = 0; i < 7; i++) table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f / 7f));
            for (int i = 0; i < 5; i++) table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20f));

            this.Controls.Add(table);

            // TextBox
            _display = new System.Windows.Forms.TextBox();
            _display.Dock = System.Windows.Forms.DockStyle.Fill;
            _display.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            _display.BackColor = System.Drawing.Color.Green;
            _display.ForeColor = System.Drawing.Color.White;
            _display.ReadOnly = true;
            _display.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            _display.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            
            table.Controls.Add(_display, 0, 0);
            table.SetColumnSpan(_display, 7);

            // Add buttons helper
            void AddBtn(string text, int col, int row, int colSpan, System.Drawing.Color backColor, System.Drawing.Color foreColor)
            {
                var btn = new System.Windows.Forms.Button();
                btn.Text = text;
                btn.Dock = System.Windows.Forms.DockStyle.Fill;
                btn.Margin = new System.Windows.Forms.Padding(5);
                btn.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
                btn.BackColor = backColor;
                btn.ForeColor = foreColor;
                btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                btn.Click += Button_Click;
                table.Controls.Add(btn, col, row);
                if (colSpan > 1) table.SetColumnSpan(btn, colSpan);
            }

            var white = System.Drawing.Color.White;
            var black = System.Drawing.Color.Black;
            var orange = System.Drawing.Color.DarkOrange;

            // Row 1
            AddBtn("7", 0, 1, 1, white, black);
            AddBtn("8", 1, 1, 1, white, black);
            AddBtn("9", 2, 1, 1, white, black);
            AddBtn("(", 3, 1, 1, orange, black);
            AddBtn(")", 4, 1, 1, orange, black);
            AddBtn("Delete", 5, 1, 2, orange, black);

            // Row 2
            AddBtn("4", 0, 2, 1, white, black);
            AddBtn("5", 1, 2, 1, white, black);
            AddBtn("6", 2, 2, 1, white, black);
            AddBtn("*", 3, 2, 1, orange, black);
            AddBtn("/", 4, 2, 1, orange, black);
            AddBtn("Clear", 5, 2, 2, orange, black);

            // Row 3
            AddBtn("1", 0, 3, 1, white, black);
            AddBtn("2", 1, 3, 1, white, black);
            AddBtn("3", 2, 3, 1, white, black);
            AddBtn("+", 3, 3, 1, orange, black);
            AddBtn("-", 4, 3, 1, orange, black);
            AddBtn("^", 5, 3, 2, orange, black);

            // Row 4
            AddBtn("0", 0, 4, 2, white, black);
            AddBtn(".", 2, 4, 1, white, black);
            AddBtn("=", 3, 4, 4, orange, black);
        }
        
        private System.Windows.Forms.TextBox _display;
    }
}
