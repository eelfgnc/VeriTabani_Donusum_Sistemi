namespace VTYS
{
    partial class ConverterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConverterForm));
            this.serverNameTextBox = new System.Windows.Forms.TextBox();
            this.serverNameLabel = new System.Windows.Forms.Label();
            this.destinationTextBox = new System.Windows.Forms.TextBox();
            this.destinationButton = new System.Windows.Forms.Button();
            this.convertButton = new System.Windows.Forms.Button();
            this.databaseNameLabel = new System.Windows.Forms.Label();
            this.databaseNameTextBox = new System.Windows.Forms.TextBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.destinationLabel = new System.Windows.Forms.Label();
            this.showpasswordButton = new System.Windows.Forms.Button();
            this.sourceLabel = new System.Windows.Forms.Label();
            this.sourceTextBox = new System.Windows.Forms.TextBox();
            this.sourceButton = new System.Windows.Forms.Button();
            this.sqlServerAuthenticationRadioButton = new System.Windows.Forms.RadioButton();
            this.windowsAuthenticationRadioButton = new System.Windows.Forms.RadioButton();
            this.optionComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // serverNameTextBox
            // 
            this.serverNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverNameTextBox.ForeColor = System.Drawing.Color.Black;
            this.serverNameTextBox.Location = new System.Drawing.Point(75, 80);
            this.serverNameTextBox.Name = "serverNameTextBox";
            this.serverNameTextBox.Size = new System.Drawing.Size(275, 23);
            this.serverNameTextBox.TabIndex = 3;
            this.serverNameTextBox.TabStop = false;
            // 
            // serverNameLabel
            // 
            this.serverNameLabel.AutoSize = true;
            this.serverNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverNameLabel.ForeColor = System.Drawing.Color.White;
            this.serverNameLabel.Location = new System.Drawing.Point(75, 60);
            this.serverNameLabel.Name = "serverNameLabel";
            this.serverNameLabel.Size = new System.Drawing.Size(102, 17);
            this.serverNameLabel.TabIndex = 2;
            this.serverNameLabel.Text = "Server Name";
            // 
            // destinationTextBox
            // 
            this.destinationTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.destinationTextBox.ForeColor = System.Drawing.Color.Black;
            this.destinationTextBox.Location = new System.Drawing.Point(75, 385);
            this.destinationTextBox.Name = "destinationTextBox";
            this.destinationTextBox.Size = new System.Drawing.Size(275, 23);
            this.destinationTextBox.TabIndex = 17;
            this.destinationTextBox.TabStop = false;
            // 
            // destinationButton
            // 
            this.destinationButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.destinationButton.FlatAppearance.BorderSize = 0;
            this.destinationButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.destinationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.destinationButton.ForeColor = System.Drawing.Color.Black;
            this.destinationButton.Location = new System.Drawing.Point(365, 382);
            this.destinationButton.Name = "destinationButton";
            this.destinationButton.Size = new System.Drawing.Size(110, 29);
            this.destinationButton.TabIndex = 18;
            this.destinationButton.TabStop = false;
            this.destinationButton.Text = "DESTINATION";
            this.destinationButton.UseVisualStyleBackColor = false;
            this.destinationButton.Click += new System.EventHandler(this.destinationButton_Click);
            // 
            // convertButton
            // 
            this.convertButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(20)))));
            this.convertButton.FlatAppearance.BorderSize = 0;
            this.convertButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.convertButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.convertButton.ForeColor = System.Drawing.Color.White;
            this.convertButton.Location = new System.Drawing.Point(152, 433);
            this.convertButton.Name = "convertButton";
            this.convertButton.Size = new System.Drawing.Size(125, 35);
            this.convertButton.TabIndex = 19;
            this.convertButton.TabStop = false;
            this.convertButton.Text = "CONVERT";
            this.convertButton.UseVisualStyleBackColor = false;
            this.convertButton.Click += new System.EventHandler(this.convertButton_Click);
            // 
            // databaseNameLabel
            // 
            this.databaseNameLabel.AutoSize = true;
            this.databaseNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.databaseNameLabel.ForeColor = System.Drawing.Color.White;
            this.databaseNameLabel.Location = new System.Drawing.Point(75, 110);
            this.databaseNameLabel.Name = "databaseNameLabel";
            this.databaseNameLabel.Size = new System.Drawing.Size(123, 17);
            this.databaseNameLabel.TabIndex = 4;
            this.databaseNameLabel.Text = "Database Name";
            // 
            // databaseNameTextBox
            // 
            this.databaseNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.databaseNameTextBox.ForeColor = System.Drawing.Color.Black;
            this.databaseNameTextBox.Location = new System.Drawing.Point(75, 130);
            this.databaseNameTextBox.Name = "databaseNameTextBox";
            this.databaseNameTextBox.Size = new System.Drawing.Size(275, 23);
            this.databaseNameTextBox.TabIndex = 5;
            this.databaseNameTextBox.TabStop = false;
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameLabel.ForeColor = System.Drawing.Color.White;
            this.usernameLabel.Location = new System.Drawing.Point(75, 160);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(81, 17);
            this.usernameLabel.TabIndex = 6;
            this.usernameLabel.Text = "Username";
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Enabled = false;
            this.usernameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameTextBox.ForeColor = System.Drawing.Color.Black;
            this.usernameTextBox.Location = new System.Drawing.Point(75, 180);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(275, 23);
            this.usernameTextBox.TabIndex = 7;
            this.usernameTextBox.TabStop = false;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordLabel.ForeColor = System.Drawing.Color.White;
            this.passwordLabel.Location = new System.Drawing.Point(75, 210);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(77, 17);
            this.passwordLabel.TabIndex = 8;
            this.passwordLabel.Text = "Password";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Enabled = false;
            this.passwordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordTextBox.ForeColor = System.Drawing.Color.Black;
            this.passwordTextBox.Location = new System.Drawing.Point(75, 230);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(275, 23);
            this.passwordTextBox.TabIndex = 9;
            this.passwordTextBox.TabStop = false;
            this.passwordTextBox.UseSystemPasswordChar = true;
            // 
            // destinationLabel
            // 
            this.destinationLabel.AutoSize = true;
            this.destinationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.destinationLabel.ForeColor = System.Drawing.Color.White;
            this.destinationLabel.Location = new System.Drawing.Point(75, 365);
            this.destinationLabel.Name = "destinationLabel";
            this.destinationLabel.Size = new System.Drawing.Size(90, 17);
            this.destinationLabel.TabIndex = 16;
            this.destinationLabel.Text = "Destination";
            // 
            // showpasswordButton
            // 
            this.showpasswordButton.FlatAppearance.BorderSize = 0;
            this.showpasswordButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showpasswordButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showpasswordButton.Image = ((System.Drawing.Image)(resources.GetObject("showpasswordButton.Image")));
            this.showpasswordButton.Location = new System.Drawing.Point(365, 226);
            this.showpasswordButton.Name = "showpasswordButton";
            this.showpasswordButton.Size = new System.Drawing.Size(32, 31);
            this.showpasswordButton.TabIndex = 10;
            this.showpasswordButton.TabStop = false;
            this.showpasswordButton.UseVisualStyleBackColor = true;
            this.showpasswordButton.Click += new System.EventHandler(this.showpasswordButton_Click);
            // 
            // sourceLabel
            // 
            this.sourceLabel.AutoSize = true;
            this.sourceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sourceLabel.ForeColor = System.Drawing.Color.White;
            this.sourceLabel.Location = new System.Drawing.Point(75, 315);
            this.sourceLabel.Name = "sourceLabel";
            this.sourceLabel.Size = new System.Drawing.Size(59, 17);
            this.sourceLabel.TabIndex = 13;
            this.sourceLabel.Text = "Source";
            // 
            // sourceTextBox
            // 
            this.sourceTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sourceTextBox.ForeColor = System.Drawing.Color.Black;
            this.sourceTextBox.Location = new System.Drawing.Point(75, 335);
            this.sourceTextBox.Name = "sourceTextBox";
            this.sourceTextBox.Size = new System.Drawing.Size(275, 23);
            this.sourceTextBox.TabIndex = 14;
            this.sourceTextBox.TabStop = false;
            // 
            // sourceButton
            // 
            this.sourceButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.sourceButton.Location = new System.Drawing.Point(365, 332);
            this.sourceButton.Name = "sourceButton";
            this.sourceButton.Size = new System.Drawing.Size(110, 29);
            this.sourceButton.TabIndex = 15;
            this.sourceButton.TabStop = false;
            this.sourceButton.Text = "SOURCE";
            this.sourceButton.UseVisualStyleBackColor = true;
            this.sourceButton.Click += new System.EventHandler(this.sourceButton_Click);
            // 
            // sqlServerAuthenticationRadioButton
            // 
            this.sqlServerAuthenticationRadioButton.AutoSize = true;
            this.sqlServerAuthenticationRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sqlServerAuthenticationRadioButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.sqlServerAuthenticationRadioButton.Location = new System.Drawing.Point(252, 25);
            this.sqlServerAuthenticationRadioButton.Name = "sqlServerAuthenticationRadioButton";
            this.sqlServerAuthenticationRadioButton.Size = new System.Drawing.Size(219, 21);
            this.sqlServerAuthenticationRadioButton.TabIndex = 1;
            this.sqlServerAuthenticationRadioButton.Text = "SQL Server Authentication";
            this.sqlServerAuthenticationRadioButton.UseVisualStyleBackColor = true;
            // 
            // windowsAuthenticationRadioButton
            // 
            this.windowsAuthenticationRadioButton.AutoSize = true;
            this.windowsAuthenticationRadioButton.Checked = true;
            this.windowsAuthenticationRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.windowsAuthenticationRadioButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.windowsAuthenticationRadioButton.Location = new System.Drawing.Point(29, 25);
            this.windowsAuthenticationRadioButton.Name = "windowsAuthenticationRadioButton";
            this.windowsAuthenticationRadioButton.Size = new System.Drawing.Size(198, 21);
            this.windowsAuthenticationRadioButton.TabIndex = 0;
            this.windowsAuthenticationRadioButton.TabStop = true;
            this.windowsAuthenticationRadioButton.Text = "Windows Authentication";
            this.windowsAuthenticationRadioButton.UseVisualStyleBackColor = true;
            this.windowsAuthenticationRadioButton.CheckedChanged += new System.EventHandler(this.windowsAuthenticationRadioButton_CheckedChanged);
            // 
            // optionComboBox
            // 
            this.optionComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optionComboBox.FormattingEnabled = true;
            this.optionComboBox.Location = new System.Drawing.Point(75, 280);
            this.optionComboBox.Name = "optionComboBox";
            this.optionComboBox.Size = new System.Drawing.Size(275, 24);
            this.optionComboBox.TabIndex = 12;
            this.optionComboBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(75, 260);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "Options";
            // 
            // ConverterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(26)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(484, 489);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.optionComboBox);
            this.Controls.Add(this.sqlServerAuthenticationRadioButton);
            this.Controls.Add(this.windowsAuthenticationRadioButton);
            this.Controls.Add(this.sourceButton);
            this.Controls.Add(this.sourceLabel);
            this.Controls.Add(this.sourceTextBox);
            this.Controls.Add(this.showpasswordButton);
            this.Controls.Add(this.destinationLabel);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.databaseNameLabel);
            this.Controls.Add(this.databaseNameTextBox);
            this.Controls.Add(this.convertButton);
            this.Controls.Add(this.destinationButton);
            this.Controls.Add(this.destinationTextBox);
            this.Controls.Add(this.serverNameLabel);
            this.Controls.Add(this.serverNameTextBox);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ConverterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MsSQL to PostgreSQL Converter";
            this.Load += new System.EventHandler(this.ConverterForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox serverNameTextBox;
        private System.Windows.Forms.Label serverNameLabel;
        private System.Windows.Forms.TextBox destinationTextBox;
        private System.Windows.Forms.Button destinationButton;
        private System.Windows.Forms.Button convertButton;
        private System.Windows.Forms.Label databaseNameLabel;
        private System.Windows.Forms.TextBox databaseNameTextBox;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label destinationLabel;
        private System.Windows.Forms.Button showpasswordButton;
        private System.Windows.Forms.Label sourceLabel;
        private System.Windows.Forms.TextBox sourceTextBox;
        private System.Windows.Forms.Button sourceButton;
        private System.Windows.Forms.RadioButton sqlServerAuthenticationRadioButton;
        private System.Windows.Forms.RadioButton windowsAuthenticationRadioButton;
        private System.Windows.Forms.ComboBox optionComboBox;
        private System.Windows.Forms.Label label1;
    }
}

