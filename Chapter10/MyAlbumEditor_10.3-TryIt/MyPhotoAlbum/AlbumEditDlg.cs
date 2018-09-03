using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

using System.Windows.Forms;


namespace Manning.MyPhotoAlbum
{
	public class AlbumEditDlg : Manning.MyPhotoAlbum.BaseEditDlg
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtAlbumFile;
		private System.Windows.Forms.TextBox txtTitle;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label lblConfirmPwd;
		private System.Windows.Forms.TextBox txtAlbumPwd;
		private System.Windows.Forms.CheckBox cbtnPassword;
		private System.Windows.Forms.TextBox txtConfirmPwd;
		private System.Windows.Forms.RadioButton rbtnDate;
		private System.Windows.Forms.RadioButton rbtnCaption;
		private System.Windows.Forms.RadioButton rbtnFileName;
		private System.ComponentModel.IContainer components = null;

		public AlbumEditDlg(PhotoAlbum album)
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			// Initialize radio button tags
			this.rbtnCaption.Tag = (int) PhotoAlbum.DisplayValEnum.Caption;
			this.rbtnDate.Tag = (int) PhotoAlbum.DisplayValEnum.Date;
			this.rbtnFileName.Tag = (int) PhotoAlbum.DisplayValEnum.FileName;

			// Initialize the dialog settings
			_album = album;
			ResetSettings();
		}

		private PhotoAlbum _album;
		private PhotoAlbum.DisplayValEnum _selectedDisplayOption;

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

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtAlbumFile = new System.Windows.Forms.TextBox();
			this.txtTitle = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.rbtnDate = new System.Windows.Forms.RadioButton();
			this.rbtnCaption = new System.Windows.Forms.RadioButton();
			this.rbtnFileName = new System.Windows.Forms.RadioButton();
			this.cbtnPassword = new System.Windows.Forms.CheckBox();
			this.lblConfirmPwd = new System.Windows.Forms.Label();
			this.txtAlbumPwd = new System.Windows.Forms.TextBox();
			this.txtConfirmPwd = new System.Windows.Forms.TextBox();
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.txtTitle,
																				 this.txtAlbumFile,
																				 this.label2,
																				 this.label1});
			this.panel1.Size = new System.Drawing.Size(280, 80);
			this.panel1.Visible = true;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Album &File:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "&Title:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtAlbumFile
			// 
			this.txtAlbumFile.Location = new System.Drawing.Point(80, 14);
			this.txtAlbumFile.Name = "txtAlbumFile";
			this.txtAlbumFile.Size = new System.Drawing.Size(184, 20);
			this.txtAlbumFile.TabIndex = 1;
			this.txtAlbumFile.Text = "";
			// 
			// txtTitle
			// 
			this.txtTitle.Location = new System.Drawing.Point(80, 46);
			this.txtTitle.Name = "txtTitle";
			this.txtTitle.Size = new System.Drawing.Size(184, 20);
			this.txtTitle.TabIndex = 3;
			this.txtTitle.Text = "";
			this.txtTitle.TextChanged += new System.EventHandler(this.txtTitle_TextChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.rbtnDate,
																					this.rbtnCaption,
																					this.rbtnFileName});
			this.groupBox1.Location = new System.Drawing.Point(8, 96);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(280, 56);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Phot&o Display Text";
			// 
			// rbtnDate
			// 
			this.rbtnDate.Location = new System.Drawing.Point(200, 24);
			this.rbtnDate.Name = "rbtnDate";
			this.rbtnDate.Size = new System.Drawing.Size(60, 24);
			this.rbtnDate.TabIndex = 2;
			this.rbtnDate.Text = "&Date";
			this.rbtnDate.Click += new System.EventHandler(this.DisplayOption_Click);
			// 
			// rbtnCaption
			// 
			this.rbtnCaption.Location = new System.Drawing.Point(108, 24);
			this.rbtnCaption.Name = "rbtnCaption";
			this.rbtnCaption.Size = new System.Drawing.Size(68, 24);
			this.rbtnCaption.TabIndex = 1;
			this.rbtnCaption.Text = "C&aption";
			this.rbtnCaption.Click += new System.EventHandler(this.DisplayOption_Click);
			// 
			// rbtnFileName
			// 
			this.rbtnFileName.Location = new System.Drawing.Point(16, 24);
			this.rbtnFileName.Name = "rbtnFileName";
			this.rbtnFileName.Size = new System.Drawing.Size(80, 24);
			this.rbtnFileName.TabIndex = 0;
			this.rbtnFileName.Text = "File &name";
			this.rbtnFileName.Click += new System.EventHandler(this.DisplayOption_Click);
			// 
			// cbtnPassword
			// 
			this.cbtnPassword.Location = new System.Drawing.Point(24, 176);
			this.cbtnPassword.Name = "cbtnPassword";
			this.cbtnPassword.Size = new System.Drawing.Size(128, 24);
			this.cbtnPassword.TabIndex = 5;
			this.cbtnPassword.Text = "Require &Password:";
			this.cbtnPassword.CheckedChanged += new System.EventHandler(this.cbtnPassword_CheckedChanged);
			// 
			// lblConfirmPwd
			// 
			this.lblConfirmPwd.Enabled = false;
			this.lblConfirmPwd.Location = new System.Drawing.Point(40, 216);
			this.lblConfirmPwd.Name = "lblConfirmPwd";
			this.lblConfirmPwd.Size = new System.Drawing.Size(100, 16);
			this.lblConfirmPwd.TabIndex = 7;
			this.lblConfirmPwd.Text = "Confir&m Password:";
			this.lblConfirmPwd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtAlbumPwd
			// 
			this.txtAlbumPwd.Enabled = false;
			this.txtAlbumPwd.Location = new System.Drawing.Point(160, 176);
			this.txtAlbumPwd.Name = "txtAlbumPwd";
			this.txtAlbumPwd.PasswordChar = '*';
			this.txtAlbumPwd.Size = new System.Drawing.Size(112, 20);
			this.txtAlbumPwd.TabIndex = 6;
			this.txtAlbumPwd.Text = "textBox1";
			this.txtAlbumPwd.Validating += new System.ComponentModel.CancelEventHandler(this.txtAlbumPwd_Validating);
			// 
			// txtConfirmPwd
			// 
			this.txtConfirmPwd.Enabled = false;
			this.txtConfirmPwd.Location = new System.Drawing.Point(160, 214);
			this.txtConfirmPwd.Name = "txtConfirmPwd";
			this.txtConfirmPwd.PasswordChar = 'x';
			this.txtConfirmPwd.Size = new System.Drawing.Size(112, 20);
			this.txtConfirmPwd.TabIndex = 8;
			this.txtConfirmPwd.Text = "textBox2";
			// 
			// AlbumEditDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(296, 297);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.panel1,
																		  this.txtConfirmPwd,
																		  this.txtAlbumPwd,
																		  this.lblConfirmPwd,
																		  this.cbtnPassword,
																		  this.groupBox1});
			this.Name = "AlbumEditDlg";
			this.Text = "Album Properties";
			this.panel1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void DisplayOption_Click(object sender, System.EventArgs e)
		{
			RadioButton rb = sender as RadioButton;

			if (rb != null)
				this._selectedDisplayOption = (PhotoAlbum.DisplayValEnum)rb.Tag;
		}

		private void cbtnPassword_CheckedChanged(object sender, System.EventArgs e)
		{
			// Enable password controls as required.
			bool enable = cbtnPassword.Checked;
			txtAlbumPwd.Enabled = enable;
			lblConfirmPwd.Enabled = enable;
			txtConfirmPwd.Enabled = enable;

			if (enable)
			{
				// Assign focus to pwd text box
				txtAlbumPwd.Focus();
			}
		}

		private void txtAlbumPwd_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (txtAlbumPwd.TextLength == 0) 
			{
				MessageBox.Show(this, "The password for the album cannot be blank",
					"Invalid Password",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				e.Cancel = true;
			}
		}

		private bool ValidPasswords()
		{
			if ((cbtnPassword.Checked) && (txtConfirmPwd.Text != txtAlbumPwd.Text))
			{
				MessageBox.Show(this,
					"The password and confirm values do not match",
					"Password Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				return false;
			}

			return true;
		}

		protected override void ResetSettings()
		{
			// Set file name
			txtAlbumFile.Text = _album.FileName;

			// Set title, and use in title bar
			this.txtTitle.Text = _album.Title;
			this.Text = String.Format("{0} - Album Properties", txtTitle.Text);

			// Set display option values
			_selectedDisplayOption = _album.DisplayOption;
			switch (_selectedDisplayOption)
			{
				case PhotoAlbum.DisplayValEnum.Date:
					this.rbtnDate.Checked = true;
					break;

				case PhotoAlbum.DisplayValEnum.FileName:
					this.rbtnFileName.Checked = true;
					break;

				case PhotoAlbum.DisplayValEnum.Caption:
				default:
					this.rbtnCaption.Checked = true;
					break;
			}

			string pwd = _album.Password;
			cbtnPassword.Checked = (pwd != null && pwd.Length > 0);
			txtAlbumPwd.Text = pwd;
			txtConfirmPwd.Text = pwd;
		}

		protected override bool SaveSettings()
		{
			bool valid = ValidPasswords();

			if (valid)
			{
				_album.Title = txtTitle.Text;
				_album.DisplayOption = this._selectedDisplayOption;

				if (cbtnPassword.Checked) 
					_album.Password = txtAlbumPwd.Text;
				else
					_album.Password = null;
			}

			return valid;
		}

		private void txtTitle_TextChanged(object sender, System.EventArgs e)
		{
			this.Text = String.Format("{0} - Album Properties", txtTitle.Text);
		}

		// end of AlbumEditDlg
	}
}

