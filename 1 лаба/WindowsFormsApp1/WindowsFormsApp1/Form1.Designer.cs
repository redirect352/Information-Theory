namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.EncryptButton = new System.Windows.Forms.Button();
            this.DecryptButton = new System.Windows.Forms.Button();
            this.DecrText = new System.Windows.Forms.TextBox();
            this.EncrText = new System.Windows.Forms.TextBox();
            this.KeyNumb = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.KeyBox = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.KeyNumb)).BeginInit();
            this.SuspendLayout();
            // 
            // EncryptButton
            // 
            this.EncryptButton.Location = new System.Drawing.Point(362, 557);
            this.EncryptButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.EncryptButton.Name = "EncryptButton";
            this.EncryptButton.Size = new System.Drawing.Size(171, 78);
            this.EncryptButton.TabIndex = 0;
            this.EncryptButton.Text = "Зашифровать";
            this.EncryptButton.UseVisualStyleBackColor = true;
            this.EncryptButton.Click += new System.EventHandler(this.EncryptButton_Click);
            // 
            // DecryptButton
            // 
            this.DecryptButton.Location = new System.Drawing.Point(640, 557);
            this.DecryptButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DecryptButton.Name = "DecryptButton";
            this.DecryptButton.Size = new System.Drawing.Size(171, 78);
            this.DecryptButton.TabIndex = 3;
            this.DecryptButton.Text = "Расшифровать";
            this.DecryptButton.UseVisualStyleBackColor = true;
            this.DecryptButton.Click += new System.EventHandler(this.DecryptButton_Click);
            // 
            // DecrText
            // 
            this.DecrText.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DecrText.Location = new System.Drawing.Point(63, 37);
            this.DecrText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DecrText.Multiline = true;
            this.DecrText.Name = "DecrText";
            this.DecrText.Size = new System.Drawing.Size(468, 438);
            this.DecrText.TabIndex = 6;
            // 
            // EncrText
            // 
            this.EncrText.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EncrText.Location = new System.Drawing.Point(640, 37);
            this.EncrText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.EncrText.Multiline = true;
            this.EncrText.Name = "EncrText";
            this.EncrText.Size = new System.Drawing.Size(493, 438);
            this.EncrText.TabIndex = 7;
            this.EncrText.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // KeyNumb
            // 
            this.KeyNumb.Location = new System.Drawing.Point(978, 628);
            this.KeyNumb.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.KeyNumb.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.KeyNumb.Name = "KeyNumb";
            this.KeyNumb.Size = new System.Drawing.Size(180, 26);
            this.KeyNumb.TabIndex = 8;
            this.KeyNumb.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(904, 631);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Ключ";
            // 
            // KeyBox
            // 
            this.KeyBox.Location = new System.Drawing.Point(978, 626);
            this.KeyBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.KeyBox.Name = "KeyBox";
            this.KeyBox.Size = new System.Drawing.Size(178, 26);
            this.KeyBox.TabIndex = 11;
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.White;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Жд изгородь",
            "Табличный метод",
            "Виженера",
            "Поворачивающаяся решетка"});
            this.comboBox1.Location = new System.Drawing.Point(978, 557);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(178, 28);
            this.comboBox1.TabIndex = 12;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(904, 562);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "Метод";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 692);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.KeyBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.KeyNumb);
            this.Controls.Add(this.EncrText);
            this.Controls.Add(this.DecrText);
            this.Controls.Add(this.DecryptButton);
            this.Controls.Add(this.EncryptButton);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Shifrator";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.KeyNumb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button EncryptButton;
        private System.Windows.Forms.Button DecryptButton;
        private System.Windows.Forms.TextBox DecrText;
        private System.Windows.Forms.TextBox EncrText;
        private System.Windows.Forms.NumericUpDown KeyNumb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox KeyBox;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
    }
}

