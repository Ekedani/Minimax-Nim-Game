namespace Minimax_Nim_Game
{
    partial class NimGameForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gameField = new System.Windows.Forms.DataGridView();
            this.restartButton = new System.Windows.Forms.Button();
            this.skipButton = new System.Windows.Forms.Button();
            this.gameControlBox = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.turnLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize) (this.gameField)).BeginInit();
            this.gameControlBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // gameField
            // 
            this.gameField.AllowUserToAddRows = false;
            this.gameField.AllowUserToDeleteRows = false;
            this.gameField.AllowUserToResizeColumns = false;
            this.gameField.AllowUserToResizeRows = false;
            this.gameField.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gameField.ColumnHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightGreen;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gameField.DefaultCellStyle = dataGridViewCellStyle1;
            this.gameField.GridColor = System.Drawing.SystemColors.AppWorkspace;
            this.gameField.Location = new System.Drawing.Point(12, 12);
            this.gameField.Name = "gameField";
            this.gameField.RowHeadersVisible = false;
            this.gameField.RowTemplate.Height = 40;
            this.gameField.Size = new System.Drawing.Size(400, 260);
            this.gameField.TabIndex = 0;
            this.gameField.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gameField_CellClick);
            // 
            // restartButton
            // 
            this.restartButton.Location = new System.Drawing.Point(7, 21);
            this.restartButton.Name = "restartButton";
            this.restartButton.Size = new System.Drawing.Size(102, 35);
            this.restartButton.TabIndex = 1;
            this.restartButton.Text = "Restart";
            this.restartButton.UseVisualStyleBackColor = true;
            this.restartButton.Click += new System.EventHandler(this.restartButton_Click);
            // 
            // skipButton
            // 
            this.skipButton.Location = new System.Drawing.Point(115, 21);
            this.skipButton.Name = "skipButton";
            this.skipButton.Size = new System.Drawing.Size(102, 35);
            this.skipButton.TabIndex = 2;
            this.skipButton.Text = "Skip turn";
            this.skipButton.UseVisualStyleBackColor = true;
            this.skipButton.Click += new System.EventHandler(this.skipButton_Click);
            // 
            // gameControlBox
            // 
            this.gameControlBox.Controls.Add(this.button1);
            this.gameControlBox.Controls.Add(this.skipButton);
            this.gameControlBox.Controls.Add(this.restartButton);
            this.gameControlBox.Location = new System.Drawing.Point(426, 107);
            this.gameControlBox.Name = "gameControlBox";
            this.gameControlBox.Size = new System.Drawing.Size(225, 108);
            this.gameControlBox.TabIndex = 3;
            this.gameControlBox.TabStop = false;
            this.gameControlBox.Text = "Game control";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(7, 62);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(210, 35);
            this.button1.TabIndex = 3;
            this.button1.Text = "Make a move!";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // turnLabel
            // 
            this.turnLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.turnLabel.Location = new System.Drawing.Point(426, 64);
            this.turnLabel.Name = "turnLabel";
            this.turnLabel.Size = new System.Drawing.Size(225, 40);
            this.turnLabel.TabIndex = 4;
            this.turnLabel.Text = "Your turn!";
            // 
            // NimGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 288);
            this.Controls.Add(this.turnLabel);
            this.Controls.Add(this.gameControlBox);
            this.Controls.Add(this.gameField);
            this.Name = "NimGameForm";
            this.Text = "Nim Game";
            ((System.ComponentModel.ISupportInitialize) (this.gameField)).EndInit();
            this.gameControlBox.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button button1;

        private System.Windows.Forms.Label turnLabel;
        private System.Windows.Forms.Button restartButton;
        private System.Windows.Forms.Button skipButton;
        private System.Windows.Forms.DataGridView gameField;
        private System.Windows.Forms.GroupBox gameControlBox;

        #endregion
    }
}