using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

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
		private System.Windows.Forms.Button btnOpen;
		private System.Windows.Forms.ListBox lstPhotos;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Button btnPhotoProp;
		private System.Windows.Forms.Button btnAlbumProp;
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
			this.btnAlbumProp = new System.Windows.Forms.Button();
			this.btnOpen = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.btnPhotoProp = new System.Windows.Forms.Button();
			this.lstPhotos = new System.Windows.Forms.ListBox();
			this.btnClose = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.btnAlbumProp,
																					this.btnOpen});
			this.groupBox1.Location = new System.Drawing.Point(8, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(380, 48);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "&Albums";
			// 
			// btnAlbumProp
			// 
			this.btnAlbumProp.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.btnAlbumProp.Location = new System.Drawing.Point(296, 16);
			this.btnAlbumProp.Name = "btnAlbumProp";
			this.btnAlbumProp.TabIndex = 1;
			this.btnAlbumProp.Text = "Propertie&s...";
			this.btnAlbumProp.Click += new System.EventHandler(this.btnAlbumProp_Click);
			// 
			// btnOpen
			// 
			this.btnOpen.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.btnOpen.Location = new System.Drawing.Point(212, 16);
			this.btnOpen.Name = "btnOpen";
			this.btnOpen.TabIndex = 0;
			this.btnOpen.Text = "&Open...";
			this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.groupBox2.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.btnPhotoProp,
																					this.lstPhotos});
			this.groupBox2.Location = new System.Drawing.Point(8, 72);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(380, 152);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "&Photographs";
			// 
			// btnPhotoProp
			// 
			this.btnPhotoProp.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.btnPhotoProp.Location = new System.Drawing.Point(296, 24);
			this.btnPhotoProp.Name = "btnPhotoProp";
			this.btnPhotoProp.TabIndex = 1;
			this.btnPhotoProp.Text = "Properti&es...";
			this.btnPhotoProp.Click += new System.EventHandler(this.btnPhotoProp_Click);
			// 
			// lstPhotos
			// 
			this.lstPhotos.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.lstPhotos.Location = new System.Drawing.Point(16, 24);
			this.lstPhotos.Name = "lstPhotos";
			this.lstPhotos.Size = new System.Drawing.Size(268, 121);
			this.lstPhotos.TabIndex = 0;
			this.lstPhotos.DoubleClick += new System.EventHandler(this.lstPhotos_DoubleClick);
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

		private void btnOpen_Click(object sender, System.EventArgs e)
		{
			CloseAlbum();

			using (OpenFileDialog dlg = new OpenFileDialog())
			{
				dlg.Title = "Open Album";
				dlg.Filter = "abm files (*.abm)|*.abm|All Files (*.*)|*.*";
				dlg.InitialDirectory = PhotoAlbum.DefaultDir;

				try
				{
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						_album.Open(dlg.FileName);
						this.Text = _album.FileName;
						UpdateList();
					}
				}
				catch (Exception)
				{
					MessageBox.Show("Unable to open album\n" + dlg.FileName,
						"Open Album Error",
						MessageBoxButtons.OK,
						MessageBoxIcon.Error);
				}
			}
		}

		protected void UpdateList()
		{
			lstPhotos.DisplayMember = "Caption";
			lstPhotos.DataSource = _album;
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


		// end of MyAlbumEditor
	}
}
