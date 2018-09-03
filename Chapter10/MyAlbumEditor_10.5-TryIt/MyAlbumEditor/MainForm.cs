using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Reflection;

using Manning.MyPhotoAlbum;

namespace MyAlbumEditor
{
	/// <summary>
	/// Summary description for MainForm.
	/// </summary>
	public class MainForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ListBox lstPhotos;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Button btnPhotoProp;
		private System.Windows.Forms.Button btnAlbumProp;
		private System.Windows.Forms.Button btnMoveUp;
		private System.Windows.Forms.Button btnMoveDown;
		private System.Windows.Forms.Button btnRemove;
		private System.Windows.Forms.ComboBox cmbxAlbums;
		private System.Windows.Forms.ContextMenu ctxtPhotoList;
		private System.Windows.Forms.MenuItem menuThumbs;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuFileName;
		private System.Windows.Forms.MenuItem menuCaption;
		private System.Windows.Forms.MenuItem menuPhotographer;
		private System.Windows.Forms.MenuItem menuDefault;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public MainForm()
		{
			// Required for Windows Form Designer support
			InitializeComponent();

			// Other initialization
		}

		private PhotoAlbum _album;
		private bool _bAlbumChanged = false;

		private static Rectangle _drawRect = new Rectangle(0,0,45,45);
		private static SolidBrush _textBrush = new SolidBrush(SystemColors.WindowText);

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cmbxAlbums = new System.Windows.Forms.ComboBox();
			this.btnAlbumProp = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.btnRemove = new System.Windows.Forms.Button();
			this.btnMoveDown = new System.Windows.Forms.Button();
			this.btnMoveUp = new System.Windows.Forms.Button();
			this.lstPhotos = new System.Windows.Forms.ListBox();
			this.ctxtPhotoList = new System.Windows.Forms.ContextMenu();
			this.menuThumbs = new System.Windows.Forms.MenuItem();
			this.btnPhotoProp = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuFileName = new System.Windows.Forms.MenuItem();
			this.menuCaption = new System.Windows.Forms.MenuItem();
			this.menuPhotographer = new System.Windows.Forms.MenuItem();
			this.menuDefault = new System.Windows.Forms.MenuItem();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.cmbxAlbums,
																					this.btnAlbumProp});
			this.groupBox1.Location = new System.Drawing.Point(8, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(380, 48);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "&Albums";
			// 
			// cmbxAlbums
			// 
			this.cmbxAlbums.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.cmbxAlbums.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbxAlbums.Location = new System.Drawing.Point(16, 16);
			this.cmbxAlbums.Name = "cmbxAlbums";
			this.cmbxAlbums.Size = new System.Drawing.Size(268, 21);
			this.cmbxAlbums.Sorted = true;
			this.cmbxAlbums.TabIndex = 2;
			this.cmbxAlbums.SelectedIndexChanged += new System.EventHandler(this.cmbxAlbums_SelectedIndexChanged);
			// 
			// btnAlbumProp
			// 
			this.btnAlbumProp.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.btnAlbumProp.Enabled = false;
			this.btnAlbumProp.Location = new System.Drawing.Point(296, 16);
			this.btnAlbumProp.Name = "btnAlbumProp";
			this.btnAlbumProp.TabIndex = 1;
			this.btnAlbumProp.Text = "Propertie&s";
			this.btnAlbumProp.Click += new System.EventHandler(this.btnAlbumProp_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.groupBox2.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.btnRemove,
																					this.btnMoveDown,
																					this.btnMoveUp,
																					this.lstPhotos,
																					this.btnPhotoProp});
			this.groupBox2.Location = new System.Drawing.Point(8, 72);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(380, 160);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "&Photographs";
			// 
			// btnRemove
			// 
			this.btnRemove.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.btnRemove.Enabled = false;
			this.btnRemove.Location = new System.Drawing.Point(296, 88);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.TabIndex = 4;
			this.btnRemove.Text = "&Remove";
			this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
			// 
			// btnMoveDown
			// 
			this.btnMoveDown.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.btnMoveDown.Enabled = false;
			this.btnMoveDown.Location = new System.Drawing.Point(296, 56);
			this.btnMoveDown.Name = "btnMoveDown";
			this.btnMoveDown.TabIndex = 3;
			this.btnMoveDown.Text = "Move &Down";
			this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
			// 
			// btnMoveUp
			// 
			this.btnMoveUp.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.btnMoveUp.Enabled = false;
			this.btnMoveUp.Location = new System.Drawing.Point(296, 24);
			this.btnMoveUp.Name = "btnMoveUp";
			this.btnMoveUp.TabIndex = 2;
			this.btnMoveUp.Text = "Move &Up";
			this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
			// 
			// lstPhotos
			// 
			this.lstPhotos.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.lstPhotos.ContextMenu = this.ctxtPhotoList;
			this.lstPhotos.Location = new System.Drawing.Point(16, 24);
			this.lstPhotos.Name = "lstPhotos";
			this.lstPhotos.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.lstPhotos.Size = new System.Drawing.Size(268, 121);
			this.lstPhotos.TabIndex = 0;
			this.lstPhotos.DoubleClick += new System.EventHandler(this.lstPhotos_DoubleClick);
			this.lstPhotos.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.lstPhotos_MeasureItem);
			this.lstPhotos.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstPhotos_DrawItem);
			this.lstPhotos.SelectedIndexChanged += new System.EventHandler(this.lstPhotos_SelectedIndexChanged);
			// 
			// ctxtPhotoList
			// 
			this.ctxtPhotoList.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						  this.menuThumbs,
																						  this.menuItem1});
			// 
			// menuThumbs
			// 
			this.menuThumbs.Index = 0;
			this.menuThumbs.Text = "&Thumbnails";
			this.menuThumbs.Click += new System.EventHandler(this.menuThumbs_Click);
			// 
			// btnPhotoProp
			// 
			this.btnPhotoProp.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.btnPhotoProp.Enabled = false;
			this.btnPhotoProp.Location = new System.Drawing.Point(296, 120);
			this.btnPhotoProp.Name = "btnPhotoProp";
			this.btnPhotoProp.TabIndex = 1;
			this.btnPhotoProp.Text = "Properti&es";
			this.btnPhotoProp.Click += new System.EventHandler(this.btnPhotoProp_Click);
			// 
			// btnClose
			// 
			this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnClose.Location = new System.Drawing.Point(159, 240);
			this.btnClose.Name = "btnClose";
			this.btnClose.TabIndex = 2;
			this.btnClose.Text = "&Close";
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 1;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuDefault,
																					  this.menuFileName,
																					  this.menuCaption,
																					  this.menuPhotographer});
			this.menuItem1.Text = "&Display As";
			// 
			// menuFileName
			// 
			this.menuFileName.Index = 1;
			this.menuFileName.Text = "&File name";
			this.menuFileName.Click += new System.EventHandler(this.menuFileName_Click);
			// 
			// menuCaption
			// 
			this.menuCaption.Index = 2;
			this.menuCaption.Text = "&Caption";
			this.menuCaption.Click += new System.EventHandler(this.menuCaption_Click);
			// 
			// menuPhotographer
			// 
			this.menuPhotographer.Index = 3;
			this.menuPhotographer.Text = "&Photographer";
			this.menuPhotographer.Click += new System.EventHandler(this.menuPhotographer_Click);
			// 
			// menuDefault
			// 
			this.menuDefault.Index = 0;
			this.menuDefault.Text = "&Default";
			this.menuDefault.Click += new System.EventHandler(this.menuDefault_Click);
			// 
			// MainForm
			// 
			this.AcceptButton = this.btnClose;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(392, 273);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btnClose,
																		  this.groupBox2,
																		  this.groupBox1});
			this.Name = "MainForm";
			this.Text = "MyAlbumEditor";
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new MainForm());
		}

		protected override void OnLoad(EventArgs e)
		{
			// Initialize the album
			_album = new PhotoAlbum();

			// Initialize the combo box
			cmbxAlbums.DataSource = Directory.GetFiles(PhotoAlbum.DefaultDir, "*.abm");

			base.OnLoad(e);
		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		private void CloseAlbum()
		{
			if (_bAlbumChanged)
			{
				_bAlbumChanged = false;

				DialogResult result = MessageBox.Show("Do you want to save your changes to "
					+ _album.FileName + '?',
					"Save Changes?",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Question);

				if (result == DialogResult.Yes) 
				{
					_album.Save();
				}
			}

			_album.Clear();
		}

		protected override void OnClosing(CancelEventArgs e)
		{
			CloseAlbum();
		}

		private void OpenAlbum(string fileName)
		{
			CloseAlbum();

			// Open the given album file
			_album.Open(fileName);
			this.Text = _album.FileName;

			UpdateList();
		}

		protected void UpdateList()
		{
			lstPhotos.BeginUpdate();
			lstPhotos.Items.Clear();
			foreach (Photograph photo in _album)
			{
				lstPhotos.Items.Add(photo);
			}
			lstPhotos.EndUpdate();
		}

		private void btnAlbumProp_Click(object sender, System.EventArgs e)
		{
			using (AlbumEditDlg dlg = new AlbumEditDlg(_album))
			{
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					_bAlbumChanged = true;
					UpdateList();
				}
			}
		}

		private void btnPhotoProp_Click(object sender, System.EventArgs e)
		{
			if (_album.Count == 0)
				return;

			if (lstPhotos.SelectedIndex >= 0)
			{
				_album.CurrentPosition = lstPhotos.SelectedIndex;
			}

			using (PhotoEditDlg dlg = new PhotoEditDlg(_album))
			{
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					_bAlbumChanged = true;
					UpdateList();
				}
			}

		}

		private void lstPhotos_DoubleClick(object sender, System.EventArgs e)
		{
			btnPhotoProp.PerformClick();
		}

		private void lstPhotos_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			int numSelected = lstPhotos.SelectedIndices.Count;
			bool someSelected = (numSelected > 0);

			btnMoveUp.Enabled = (someSelected && !lstPhotos.GetSelected(0));
			btnMoveDown.Enabled = (someSelected && (!lstPhotos.GetSelected(lstPhotos.Items.Count - 1)));
			btnRemove.Enabled = someSelected;

			btnPhotoProp.Enabled = (numSelected == 1);
		}

		private void btnMoveUp_Click(object sender, System.EventArgs e)
		{
			ListBox.SelectedIndexCollection indices = lstPhotos.SelectedIndices;
			int[] newSelects = new int[indices.Count];

			// Move the selected items up
			for (int i = 0; i < indices.Count; i++)
			{
				int index = indices[i];
				_album.MoveBefore(index);
				newSelects[i] = index - 1;
			}

			_bAlbumChanged = true;
			UpdateList();

			// Reset the selections.
			lstPhotos.ClearSelected();
			foreach (int x in newSelects)
			{
				lstPhotos.SetSelected(x, true);
			}
		}

		private void btnMoveDown_Click(object sender, System.EventArgs e)
		{
			ListBox.SelectedIndexCollection indices = lstPhotos.SelectedIndices;
			int[] newSelects = new int[indices.Count];

			// Move the selected items down
			for (int i = indices.Count - 1; i >= 0; i--)
			{
				int index = indices[i];
				_album.MoveAfter(index);
				newSelects[i] = index + 1;
			}

			_bAlbumChanged = true;
			UpdateList();

			// Reset the selections.
			lstPhotos.ClearSelected();
			foreach (int x in newSelects)
			{
				lstPhotos.SetSelected(x, true);
			}
		}

		private void btnRemove_Click(object sender, System.EventArgs e)
		{
			string msg;
			int n = lstPhotos.SelectedItems.Count;

			if (n == 1)
				msg = "Do your really want to remove the selected photo?";
			else
				msg = String.Format("Do you really want to remove the {0} selected photos?", n);

			DialogResult result = MessageBox.Show(msg, "Remove Photos?",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question);

			if (result == DialogResult.Yes)
			{
				ListBox.SelectedIndexCollection indices = lstPhotos.SelectedIndices;
				for (int i = indices.Count - 1; i >= 0; i--)
				{
					_album.RemoveAt(indices[i]);
				}

				_bAlbumChanged = true;
				UpdateList();
			}
		}

		private void cmbxAlbums_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string albumPath = cmbxAlbums.SelectedItem.ToString();

			if (albumPath == _album.FileName)
				return;

			try 
			{
				CloseAlbum();
				OpenAlbum(albumPath);
				btnAlbumProp.Enabled = true;
				lstPhotos.BackColor = SystemColors.Window;
			}
			catch (Exception)
			{
				// Unable to open album
				this.Text = "Unable to open selected album";
				lstPhotos.Items.Clear();
				lstPhotos.BackColor = SystemColors.Control;
				btnAlbumProp.Enabled = false;
			}
		}

		private void menuThumbs_Click(object sender, System.EventArgs e)
		{
			menuThumbs.Checked = ! menuThumbs.Checked;

			if (menuThumbs.Checked)
			{
				lstPhotos.DrawMode = DrawMode.OwnerDrawVariable;
			}
			else
			{
				lstPhotos.DrawMode = DrawMode.Normal;
				lstPhotos.ItemHeight = lstPhotos.Font.Height + 2;
			}
		}

		private void lstPhotos_MeasureItem(object sender, System.Windows.Forms.MeasureItemEventArgs e)
		{
			Photograph p = _album[e.Index];
			Rectangle scaledRect = p.ScaleToFit(_drawRect);
			e.ItemHeight = Math.Max(scaledRect.Height, lstPhotos.Font.Height) + 2;
			e.ItemWidth = scaledRect.Width + 2 + (int)e.Graphics.MeasureString(p.Caption, lstPhotos.Font).Width;
		}

		private void lstPhotos_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
		{
			Graphics g = e.Graphics;
			Photograph p = _album[e.Index];

			Rectangle scaledRect = p.ScaleToFit(_drawRect);
			Rectangle imageRect = e.Bounds;
			imageRect.Y += 1;
			imageRect.Height = scaledRect.Height;
			imageRect.X += 2;
			imageRect.Width = scaledRect.Width;

			g.DrawImage(p.Thumbnail, imageRect);
			g.DrawRectangle(Pens.Black, imageRect);

			Rectangle textRect = new Rectangle(
				imageRect.Right + 2,
				imageRect.Y + ((imageRect.Height - e.Font.Height) / 2),
				e.Bounds.Width - imageRect.Width - 4,
				e.Font.Height);

			if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
			{
				_textBrush.Color = SystemColors.Highlight;
				g.FillRectangle(_textBrush, textRect);
				_textBrush.Color = SystemColors.HighlightText;
			}
			else
			{
				_textBrush.Color = SystemColors.Window;
				g.FillRectangle(_textBrush, textRect);
				_textBrush.Color = SystemColors.WindowText;
			}

			// Note that DisplayMember can be null here, causing pi to be null
			PropertyInfo pi = typeof(Photograph).GetProperty(lstPhotos.DisplayMember);
			if (pi != null)
			{
				object propValue = pi.GetValue(p, null);
				g.DrawString(propValue.ToString(), e.Font, _textBrush, textRect);
			}
			else
				g.DrawString(p.ToString(), e.Font, _textBrush, textRect);
		}


		private void menuDefault_Click(object sender, System.EventArgs e)
		{
			lstPhotos.DisplayMember = "ToString";
			UpdateList();
		}

		private void menuFileName_Click(object sender, System.EventArgs e)
		{
			lstPhotos.DisplayMember = "Filename";
			UpdateList();
		}

		private void menuCaption_Click(object sender, System.EventArgs e)
		{
			lstPhotos.DisplayMember = "Caption";
			UpdateList();
		}

		private void menuPhotographer_Click(object sender, System.EventArgs e)
		{
			lstPhotos.DisplayMember = "Photographer";
			UpdateList();
		}

		// end of MyAlbumEditor
	}
}
