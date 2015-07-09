namespace MusicHotkeys
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btDone = new System.Windows.Forms.Button();
            this.cbHotkeys = new System.Windows.Forms.CheckBox();
            this.cbName = new System.Windows.Forms.CheckBox();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itemOpenSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.itemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.btFont = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.notifyMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // btDone
            // 
            this.btDone.Location = new System.Drawing.Point(190, 69);
            this.btDone.Name = "btDone";
            this.btDone.Size = new System.Drawing.Size(84, 23);
            this.btDone.TabIndex = 0;
            this.btDone.Text = "Готово";
            this.btDone.UseVisualStyleBackColor = true;
            this.btDone.Click += new System.EventHandler(this.btDone_Click);
            // 
            // cbHotkeys
            // 
            this.cbHotkeys.AutoSize = true;
            this.cbHotkeys.Checked = true;
            this.cbHotkeys.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbHotkeys.Location = new System.Drawing.Point(12, 12);
            this.cbHotkeys.Name = "cbHotkeys";
            this.cbHotkeys.Size = new System.Drawing.Size(269, 17);
            this.cbHotkeys.TabIndex = 1;
            this.cbHotkeys.Text = "Включить управление мультимедиа клавишами";
            this.cbHotkeys.UseVisualStyleBackColor = true;
            this.cbHotkeys.CheckedChanged += new System.EventHandler(this.cbHotkeys_CheckedChanged);
            // 
            // cbName
            // 
            this.cbName.AutoSize = true;
            this.cbName.Checked = true;
            this.cbName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbName.Location = new System.Drawing.Point(12, 35);
            this.cbName.Name = "cbName";
            this.cbName.Size = new System.Drawing.Size(172, 17);
            this.cbName.TabIndex = 2;
            this.cbName.Text = "Показывать название трека";
            this.cbName.UseVisualStyleBackColor = true;
            this.cbName.CheckedChanged += new System.EventHandler(this.cbName_CheckedChanged);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.notifyMenu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Music Hotkeys";
            this.notifyIcon.BalloonTipClicked += new System.EventHandler(this.notifyIcon_BalloonTipClicked);
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // notifyMenu
            // 
            this.notifyMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemOpenSettings,
            this.itemExit});
            this.notifyMenu.Name = "notifyMenu";
            this.notifyMenu.Size = new System.Drawing.Size(187, 48);
            // 
            // itemOpenSettings
            // 
            this.itemOpenSettings.Name = "itemOpenSettings";
            this.itemOpenSettings.Size = new System.Drawing.Size(186, 22);
            this.itemOpenSettings.Text = "Открыть настройки";
            this.itemOpenSettings.Click += new System.EventHandler(this.itemOpenSettings_Click);
            // 
            // itemExit
            // 
            this.itemExit.Name = "itemExit";
            this.itemExit.Size = new System.Drawing.Size(186, 22);
            this.itemExit.Text = "Закрыть программу";
            this.itemExit.Click += new System.EventHandler(this.itemExit_Click);
            // 
            // btFont
            // 
            this.btFont.Location = new System.Drawing.Point(190, 32);
            this.btFont.Name = "btFont";
            this.btFont.Size = new System.Drawing.Size(84, 23);
            this.btFont.TabIndex = 3;
            this.btFont.Text = "Шрифт";
            this.btFont.UseVisualStyleBackColor = true;
            this.btFont.Click += new System.EventHandler(this.btFont_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(9, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 39);
            this.label1.TabIndex = 4;
            this.label1.Text = "Название показывается для\r\nподдерживаемых сайтов\r\nсверху по центру экрана";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 104);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btFont);
            this.Controls.Add(this.cbName);
            this.Controls.Add(this.cbHotkeys);
            this.Controls.Add(this.btDone);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Music Hotkeys";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsForm_FormClosing);
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.notifyMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btDone;
        private System.Windows.Forms.CheckBox cbHotkeys;
        private System.Windows.Forms.CheckBox cbName;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip notifyMenu;
        private System.Windows.Forms.ToolStripMenuItem itemOpenSettings;
        private System.Windows.Forms.ToolStripMenuItem itemExit;
        private System.Windows.Forms.Button btFont;
        private System.Windows.Forms.Label label1;
    }
}

