namespace ListView
{
    partial class Form1
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            listViewCatalog = new System.Windows.Forms.ListView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            подробныйВидToolStripMenuItem = new ToolStripMenuItem();
            крупныеЗначкиToolStripMenuItem = new ToolStripMenuItem();
            мелкиеЗначкиToolStripMenuItem = new ToolStripMenuItem();
            видСпискаToolStripMenuItem = new ToolStripMenuItem();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // listViewCatalog
            // 
            listViewCatalog.ContextMenuStrip = contextMenuStrip1;
            listViewCatalog.Dock = DockStyle.Fill;
            listViewCatalog.Location = new Point(0, 0);
            listViewCatalog.Name = "listViewCatalog";
            listViewCatalog.Size = new Size(800, 450);
            listViewCatalog.TabIndex = 0;
            listViewCatalog.UseCompatibleStateImageBehavior = false;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { подробныйВидToolStripMenuItem, крупныеЗначкиToolStripMenuItem, мелкиеЗначкиToolStripMenuItem, видСпискаToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(165, 92);
            contextMenuStrip1.ItemClicked += contextMenuStrip1_ItemClicked;
            // 
            // подробныйВидToolStripMenuItem
            // 
            подробныйВидToolStripMenuItem.Name = "подробныйВидToolStripMenuItem";
            подробныйВидToolStripMenuItem.Size = new Size(164, 22);
            подробныйВидToolStripMenuItem.Text = "Подробный вид";
            // 
            // крупныеЗначкиToolStripMenuItem
            // 
            крупныеЗначкиToolStripMenuItem.Name = "крупныеЗначкиToolStripMenuItem";
            крупныеЗначкиToolStripMenuItem.Size = new Size(164, 22);
            крупныеЗначкиToolStripMenuItem.Text = "Крупные значки";
            // 
            // мелкиеЗначкиToolStripMenuItem
            // 
            мелкиеЗначкиToolStripMenuItem.Name = "мелкиеЗначкиToolStripMenuItem";
            мелкиеЗначкиToolStripMenuItem.Size = new Size(164, 22);
            мелкиеЗначкиToolStripMenuItem.Text = "Мелкие значки";
            // 
            // видСпискаToolStripMenuItem
            // 
            видСпискаToolStripMenuItem.Name = "видСпискаToolStripMenuItem";
            видСпискаToolStripMenuItem.Size = new Size(164, 22);
            видСпискаToolStripMenuItem.Text = "Вид списка";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(listViewCatalog);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.ListView listViewCatalog;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem подробныйВидToolStripMenuItem;
        private ToolStripMenuItem крупныеЗначкиToolStripMenuItem;
        private ToolStripMenuItem мелкиеЗначкиToolStripMenuItem;
        private ToolStripMenuItem видСпискаToolStripMenuItem;
    }
}