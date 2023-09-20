namespace MdiApplication
{
    partial class ChildForm
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
            components = new System.ComponentModel.Container();
            ChildTextBox = new RichTextBox();
            menuStrip1 = new MenuStrip();
            FormatMenuItem = new ToolStripMenuItem();
            ToggleMenuItem = new ToolStripMenuItem();
            ChildWindowMenu = new MenuStrip();
            editMenuItem = new ToolStripMenuItem();
            cutMenuItem = new ToolStripMenuItem();
            copyMenuItem = new ToolStripMenuItem();
            pasteMenuItem = new ToolStripMenuItem();
            selectAllMenuItem = new ToolStripMenuItem();
            deleteMenuItem = new ToolStripMenuItem();
            contextMenuStrip1 = new ContextMenuStrip(components);
            cutContextMenuItem = new ToolStripMenuItem();
            copyContextMenuItem = new ToolStripMenuItem();
            pasteContextMenuItem = new ToolStripMenuItem();
            selectAllContextMenuItem = new ToolStripMenuItem();
            deleteContextMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            ChildWindowMenu.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // ChildTextBox
            // 
            ChildTextBox.ContextMenuStrip = contextMenuStrip1;
            ChildTextBox.Dock = DockStyle.Fill;
            ChildTextBox.Location = new Point(0, 48);
            ChildTextBox.Name = "ChildTextBox";
            ChildTextBox.Size = new Size(800, 402);
            ChildTextBox.TabIndex = 0;
            ChildTextBox.Text = "";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { FormatMenuItem });
            menuStrip1.Location = new Point(0, 24);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // FormatMenuItem
            // 
            FormatMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ToggleMenuItem });
            FormatMenuItem.MergeAction = MergeAction.Insert;
            FormatMenuItem.MergeIndex = 1;
            FormatMenuItem.Name = "FormatMenuItem";
            FormatMenuItem.Size = new Size(57, 20);
            FormatMenuItem.Text = "&Format";
            // 
            // ToggleMenuItem
            // 
            ToggleMenuItem.Name = "ToggleMenuItem";
            ToggleMenuItem.Size = new Size(174, 22);
            ToggleMenuItem.Text = "&Toggle Foreground";
            ToggleMenuItem.Click += ToggleMenuItem_Click;
            // 
            // ChildWindowMenu
            // 
            ChildWindowMenu.Items.AddRange(new ToolStripItem[] { editMenuItem });
            ChildWindowMenu.Location = new Point(0, 0);
            ChildWindowMenu.Name = "ChildWindowMenu";
            ChildWindowMenu.Size = new Size(800, 24);
            ChildWindowMenu.TabIndex = 2;
            ChildWindowMenu.Text = "menuStrip2";
            // 
            // editMenuItem
            // 
            editMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cutMenuItem, copyMenuItem, pasteMenuItem, selectAllMenuItem, deleteMenuItem });
            editMenuItem.Name = "editMenuItem";
            editMenuItem.Size = new Size(39, 20);
            editMenuItem.Text = "&Edit";
            // 
            // cutMenuItem
            // 
            cutMenuItem.Name = "cutMenuItem";
            cutMenuItem.Size = new Size(122, 22);
            cutMenuItem.Text = "Cut";
            cutMenuItem.Click += cutMenuItem_Click;
            // 
            // copyMenuItem
            // 
            copyMenuItem.Name = "copyMenuItem";
            copyMenuItem.Size = new Size(122, 22);
            copyMenuItem.Text = "Copy";
            copyMenuItem.Click += copyMenuItem_Click;
            // 
            // pasteMenuItem
            // 
            pasteMenuItem.Name = "pasteMenuItem";
            pasteMenuItem.Size = new Size(122, 22);
            pasteMenuItem.Text = "Paste";
            pasteMenuItem.Click += pasteMenuItem_Click;
            // 
            // selectAllMenuItem
            // 
            selectAllMenuItem.Name = "selectAllMenuItem";
            selectAllMenuItem.Size = new Size(122, 22);
            selectAllMenuItem.Text = "Select All";
            selectAllMenuItem.Click += selectAllMenuItem_Click;
            // 
            // deleteMenuItem
            // 
            deleteMenuItem.Name = "deleteMenuItem";
            deleteMenuItem.Size = new Size(122, 22);
            deleteMenuItem.Text = "Delete";
            deleteMenuItem.Click += deleteMenuItem_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { cutContextMenuItem, copyContextMenuItem, pasteContextMenuItem, selectAllContextMenuItem, deleteContextMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(123, 114);
            // 
            // cutContextMenuItem
            // 
            cutContextMenuItem.Name = "cutContextMenuItem";
            cutContextMenuItem.Size = new Size(122, 22);
            cutContextMenuItem.Text = "Cut";
            cutContextMenuItem.Click += cutContextMenuItem_Click;
            // 
            // copyContextMenuItem
            // 
            copyContextMenuItem.Name = "copyContextMenuItem";
            copyContextMenuItem.Size = new Size(122, 22);
            copyContextMenuItem.Text = "Copy";
            copyContextMenuItem.Click += copyContextMenuItem_Click;
            // 
            // pasteContextMenuItem
            // 
            pasteContextMenuItem.Name = "pasteContextMenuItem";
            pasteContextMenuItem.Size = new Size(122, 22);
            pasteContextMenuItem.Text = "Paste";
            pasteContextMenuItem.Click += pasteContextMenuItem_Click;
            // 
            // selectAllContextMenuItem
            // 
            selectAllContextMenuItem.Name = "selectAllContextMenuItem";
            selectAllContextMenuItem.Size = new Size(122, 22);
            selectAllContextMenuItem.Text = "Select All";
            selectAllContextMenuItem.Click += selectAllContextMenuItem_Click;
            // 
            // deleteContextMenuItem
            // 
            deleteContextMenuItem.Name = "deleteContextMenuItem";
            deleteContextMenuItem.Size = new Size(122, 22);
            deleteContextMenuItem.Text = "Delete";
            deleteContextMenuItem.Click += deleteContextMenuItem_Click;
            // 
            // ChildForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ChildTextBox);
            Controls.Add(menuStrip1);
            Controls.Add(ChildWindowMenu);
            MainMenuStrip = menuStrip1;
            Name = "ChildForm";
            Text = "ChildForm";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ChildWindowMenu.ResumeLayout(false);
            ChildWindowMenu.PerformLayout();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox ChildTextBox;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem FormatMenuItem;
        private ToolStripMenuItem ToggleMenuItem;
        private MenuStrip ChildWindowMenu;
        private ToolStripMenuItem editMenuItem;
        private ToolStripMenuItem cutMenuItem;
        private ToolStripMenuItem copyMenuItem;
        private ToolStripMenuItem pasteMenuItem;
        private ToolStripMenuItem selectAllMenuItem;
        private ToolStripMenuItem deleteMenuItem;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem cutContextMenuItem;
        private ToolStripMenuItem copyContextMenuItem;
        private ToolStripMenuItem pasteContextMenuItem;
        private ToolStripMenuItem selectAllContextMenuItem;
        private ToolStripMenuItem deleteContextMenuItem;
    }
}