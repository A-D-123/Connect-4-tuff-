namespace Connect_4
{
    partial class Menu
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
            playWithAI = new Button();
            playWithPlayer = new Button();
            SuspendLayout();
            // 
            // playWithAI
            // 
            playWithAI.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            playWithAI.Location = new Point(65, 102);
            playWithAI.Name = "playWithAI";
            playWithAI.Size = new Size(332, 243);
            playWithAI.TabIndex = 0;
            playWithAI.Text = "Play With AI";
            playWithAI.UseVisualStyleBackColor = true;
            playWithAI.Click += playWithAI_Click;
            // 
            // playWithPlayer
            // 
            playWithPlayer.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            playWithPlayer.Location = new Point(403, 102);
            playWithPlayer.Name = "playWithPlayer";
            playWithPlayer.Size = new Size(332, 243);
            playWithPlayer.TabIndex = 1;
            playWithPlayer.Text = "Play Against Other Player";
            playWithPlayer.UseVisualStyleBackColor = true;
            playWithPlayer.Click += playWithPlayer_Click;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            ClientSize = new Size(800, 450);
            Controls.Add(playWithPlayer);
            Controls.Add(playWithAI);
            Name = "Menu";
            Text = "Menu";
            Load += Menu_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button playWithAI;
        private Button playWithPlayer;
    }
}