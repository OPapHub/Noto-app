namespace Noto
{
    partial class NoteForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NoteForm));
            PagesTable = new DataGridView();
            newNote = new Button();
            noteTextBox = new RichTextBox();
            titleTextBox = new TextBox();
            DeleteBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)PagesTable).BeginInit();
            SuspendLayout();
            // 
            // PagesTable
            // 
            PagesTable.AllowUserToAddRows = false;
            PagesTable.AllowUserToDeleteRows = false;
            PagesTable.AllowUserToResizeColumns = false;
            PagesTable.AllowUserToResizeRows = false;
            PagesTable.BackgroundColor = Color.WhiteSmoke;
            PagesTable.BorderStyle = BorderStyle.None;
            PagesTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            PagesTable.ColumnHeadersVisible = false;
            PagesTable.EditMode = DataGridViewEditMode.EditProgrammatically;
            PagesTable.GridColor = SystemColors.HighlightText;
            PagesTable.Location = new Point(5, 98);
            PagesTable.MultiSelect = false;
            PagesTable.Name = "PagesTable";
            PagesTable.ReadOnly = true;
            PagesTable.RowHeadersVisible = false;
            PagesTable.RowHeadersWidth = 62;
            PagesTable.RowTemplate.Height = 33;
            PagesTable.ScrollBars = ScrollBars.Vertical;
            PagesTable.Size = new Size(210, 345);
            PagesTable.TabIndex = 0;
            PagesTable.CellMouseClick += PagesTableCellClickEventHandler;
            // 
            // newNote
            // 
            newNote.BackColor = Color.WhiteSmoke;
            newNote.FlatAppearance.BorderColor = SystemColors.ControlLight;
            newNote.FlatAppearance.BorderSize = 0;
            newNote.FlatStyle = FlatStyle.Flat;
            newNote.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point);
            newNote.ForeColor = SystemColors.GrayText;
            newNote.Image = Properties.Resources.Add;
            newNote.ImageAlign = ContentAlignment.MiddleLeft;
            newNote.Location = new Point(5, 0);
            newNote.Name = "newNote";
            newNote.Size = new Size(210, 42);
            newNote.TabIndex = 1;
            newNote.Text = "New note";
            newNote.TextAlign = ContentAlignment.MiddleLeft;
            newNote.TextImageRelation = TextImageRelation.ImageBeforeText;
            newNote.UseVisualStyleBackColor = false;
            newNote.Click += newNote_Click;
            // 
            // noteTextBox
            // 
            noteTextBox.BackColor = SystemColors.ControlLightLight;
            noteTextBox.BorderStyle = BorderStyle.None;
            noteTextBox.Location = new Point(222, 50);
            noteTextBox.Margin = new Padding(0);
            noteTextBox.Name = "noteTextBox";
            noteTextBox.ScrollBars = RichTextBoxScrollBars.Vertical;
            noteTextBox.Size = new Size(578, 394);
            noteTextBox.TabIndex = 2;
            noteTextBox.Text = "";
            // 
            // titleTextBox
            // 
            titleTextBox.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            titleTextBox.Location = new Point(222, 0);
            titleTextBox.Name = "titleTextBox";
            titleTextBox.Size = new Size(578, 50);
            titleTextBox.TabIndex = 3;
            titleTextBox.TextChanged += TitleTextChangeHandler;
            // 
            // DeleteBtn
            // 
            DeleteBtn.BackColor = Color.WhiteSmoke;
            DeleteBtn.FlatAppearance.BorderColor = SystemColors.ControlLight;
            DeleteBtn.FlatAppearance.BorderSize = 0;
            DeleteBtn.FlatStyle = FlatStyle.Flat;
            DeleteBtn.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point);
            DeleteBtn.ForeColor = SystemColors.GrayText;
            DeleteBtn.Image = Properties.Resources.Trash;
            DeleteBtn.ImageAlign = ContentAlignment.MiddleLeft;
            DeleteBtn.Location = new Point(5, 50);
            DeleteBtn.Name = "DeleteBtn";
            DeleteBtn.Size = new Size(210, 42);
            DeleteBtn.TabIndex = 4;
            DeleteBtn.Text = "Delete";
            DeleteBtn.TextAlign = ContentAlignment.MiddleLeft;
            DeleteBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            DeleteBtn.UseVisualStyleBackColor = false;
            DeleteBtn.Click += DeleteBtn_Click;
            // 
            // NoteForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(800, 450);
            Controls.Add(DeleteBtn);
            Controls.Add(titleTextBox);
            Controls.Add(noteTextBox);
            Controls.Add(newNote);
            Controls.Add(PagesTable);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "NoteForm";
            Text = "Noto";
            FormClosing += NoteForm_Close;
            Load += NoteForm_Load;
            ((System.ComponentModel.ISupportInitialize)PagesTable).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button newNote;
        private RichTextBox noteTextBox;
        private TextBox titleTextBox;
        private DataGridView PagesTable;
        private Button DeleteBtn;
    }
}