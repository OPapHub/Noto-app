using System.Data;

namespace Noto
{
    public partial class NoteForm : Form
    {
        private readonly NotoDBContext _db;
        private DataTable dataTable;
        private Note currentNote;
        private Color whiteBackColor = Color.WhiteSmoke;
        private Color whiteTextBoxColor = Color.White;
        private Color blackBackColor = Color.FromArgb(40, 40, 40);
        private Color blackTextBoxColor = Color.FromArgb(32, 32, 32);


        public NoteForm()
        {
            InitializeComponent();
            _db = new NotoDBContext();
        }

        //Form load handler
        private void NoteForm_Load(object sender, EventArgs e)
        {
            DarkMode(true);
            var notes = getNotes();

            //Configuration of the note table
            dataTable = new DataTable();
            dataTable.Columns.Add("Id", typeof(int));
            dataTable.Columns.Add("Title", typeof(string));

            foreach (var note in notes)
            {
                dataTable.Rows.Add(note.Id, note.Name);
            }

            PagesTable.DataSource = dataTable;
            PagesTable.Columns["Id"].Visible = false;

            PagesTable.Columns["Title"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            PagesTable.Columns["Title"].FillWeight = 100;

            //Setting the main note on load
            currentNote = notes[0];
            loadNote();
            PagesTable.CurrentCell = PagesTable.Rows[0].Cells[1];
        }

        //Form closing handler
        private void NoteForm_Close(object sender, FormClosingEventArgs e)
        {
            //saving last used note on closing
            saveNote();
        }

        //New note button handler
        private void newNote_Click(object sender, EventArgs e)
        {
            //Saving current note
            saveNote();

            currentNote = new Note();

            currentNote.Name = "Untitled" + untitledCount().ToString();
            var newId = updateNotes(currentNote);

            dataTable.Rows.Add(newId, currentNote.Name);
            PagesTable[1, dataTable.Rows.Count - 1].Selected = true;
            loadNote();
        }

        //Delete button method
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            //Checking whether the note is the main note which can`t be deleted
            if (currentNote.Id == 1)
            {
                MessageBox.Show("Sorry but you can not delete this note");
                return;
            }

            //Asking user if he wants to delete the note
            DialogResult result = MessageBox.Show("Are you sure you want to delete this note?", "Delete Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.Cancel)
            {
                return;
            }

            //Cell index of current note
            int selectedIndex = PagesTable.SelectedCells[0].RowIndex;

            //Select main note
            PagesTable[1, 0].Selected = true;

            //Remove row from table
            dataTable.Rows.RemoveAt(selectedIndex);

            //Delete note from database
            DeleteNote(currentNote);

            //Retrieving main note from database
            currentNote = getNote(1);

            //Load main note
            loadNote();

            PagesTable.Refresh();
        }

        //Select cell in table event
        private void PagesTableCellClickEventHandler(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Check if a valid row index was clicked
            if (e.RowIndex >= 0 && e.RowIndex < PagesTable.RowCount)
            {
                int id = Convert.ToInt32(PagesTable.Rows[e.RowIndex].Cells["Id"].Value);

                //Updating note in a database
                currentNote.Name = titleTextBox.Text;
                currentNote.Content = noteTextBox.Text;

                updateNotes(currentNote);

                //Loading selected note
                currentNote = getNote(id);
                loadNote();

            }
        }

        //Title change handler
        private void TitleTextChangeHandler(object sender, EventArgs e)
        {
            //Changing name of the note in the table
            if (PagesTable.CurrentCell != null)
            {
                dataTable.Rows[PagesTable.CurrentCell.RowIndex]["Title"] = titleTextBox.Text;
                PagesTable.Refresh();
            }

        }

        private void DarkMode(bool darkMode)
        {
            if (darkMode)
            {
                titleTextBox.BackColor = blackTextBoxColor;
                titleTextBox.ForeColor = Color.White;
                noteTextBox.BackColor = blackTextBoxColor;
                noteTextBox.ForeColor = Color.White;
                PagesTable.BackgroundColor = blackBackColor;
                PagesTable.DefaultCellStyle.BackColor = blackBackColor;
                PagesTable.DefaultCellStyle.ForeColor = Color.White;
                newNote.BackColor = blackBackColor;
                DeleteBtn.BackColor = blackBackColor;
                this.BackColor = blackBackColor;
            }
            else
            {
                titleTextBox.BackColor = whiteTextBoxColor;
                titleTextBox.ForeColor = Color.Black;
                noteTextBox.BackColor = whiteTextBoxColor;
                noteTextBox.ForeColor = Color.Black;
                PagesTable.BackgroundColor = whiteBackColor;
                PagesTable.DefaultCellStyle.BackColor = whiteBackColor;
                PagesTable.DefaultCellStyle.ForeColor = Color.Black;
                newNote.BackColor = whiteBackColor;
                DeleteBtn.BackColor = whiteBackColor;
                this.BackColor = whiteBackColor;
            }
        }

        //Save note in database
        private void saveNote()
        {
            var note = _db.Notes.FirstOrDefault(x => x.Id == currentNote.Id);

            note.Name = titleTextBox.Text;
            note.Content = noteTextBox.Text;

            updateNotes(note);

        }

        //Load note in textBox and TitleBox
        private void loadNote()
        {
            titleTextBox.Text = currentNote.Name;
            noteTextBox.Text = currentNote.Content;
        }

        //Method for retrieving the last Untitled note number
        private int untitledCount()
        {
            var lastUnt = _db.Notes
                .Where(x => x.Name.StartsWith("Untitled"))
                .OrderByDescending(x => x.Id)
                .FirstOrDefault()?.Name;
            if (lastUnt != null)
            {
                return lastUnt[lastUnt.Length - 2] + 1;
            }
            else
            {
                return 1;
            }
        }

        //Get all data from database method
        private List<Note> getNotes()
        {
            return _db.Notes.ToList();
        }

        private Note getNote(int id)
        {
            return _db.Notes.FirstOrDefault(x => x.Id == id);
        }
        //Delete data in database method
        private void DeleteNote(Note note)
        {
            _db.Notes.Remove(note);
        }

        //Update data in database method
        private int updateNotes(Note note)
        {

            var unote = _db.Update(note);
            _db.SaveChanges();
            return note.Id;
        }

        private void DarkModeToggleButton_CheckedChanged(object sender, EventArgs e)
        {
            if (DarkModeToggleButton.Checked)
            {
                DarkMode(true);
            }
            else
            {
                DarkMode(false);
            }
        }
    }
}