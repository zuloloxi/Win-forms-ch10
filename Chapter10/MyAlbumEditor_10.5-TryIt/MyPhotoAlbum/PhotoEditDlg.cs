using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

using System.Windows.Forms;


namespace Manning.MyPhotoAlbum
{
	public class PhotoEditDlg : Manning.MyPhotoAlbum.BaseEditDlg
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtPhotoFile;
		private System.Windows.Forms.TextBox txtCaption;
		private System.Windows.Forms.TextBox txtDate;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtNotes;
		private System.Windows.Forms.ComboBox cmbxPhotographer;
		private System.ComponentModel.IContainer components = null;

		public PhotoEditDlg(PhotoAlbum album)
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			// Initialize the dialog settings
			_album = album;
			ResetSettings();
		}

		private PhotoAlbum _album;

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
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txtPhotoFile = new System.Windows.Forms.TextBox();
			this.txtCaption = new System.Windows.Forms.TextBox();
			this.txtDate = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtNotes = new System.Windows.Forms.TextBox();
			this.cmbxPhotographer = new System.Windows.Forms.ComboBox();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.cmbxPhotographer,
																				 this.txtDate,
																				 this.txtCaption,
																				 this.txtPhotoFile,
																				 this.label4,
																				 this.label3,
																				 this.label2,
																				 this.label1});
			this.panel1.Visible = true;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Photo &File:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 39);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 14);
			this.label2.TabIndex = 2;
			this.label2.Text = "Cap&tion:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 68);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(80, 20);
			this.label3.TabIndex = 4;
			this.label3.Text = "&Date Taken:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 103);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(80, 18);
			this.label4.TabIndex = 6;
			this.label4.Text = "&Photographer:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtPhotoFile
			// 
			this.txtPhotoFile.Location = new System.Drawing.Point(104, 6);
			this.txtPhotoFile.Name = "txtPhotoFile";
			this.txtPhotoFile.ReadOnly = true;
			this.txtPhotoFile.Size = new System.Drawing.Size(160, 20);
			this.txtPhotoFile.TabIndex = 1;
			this.txtPhotoFile.Text = "";
			// 
			// txtCaption
			// 
			this.txtCaption.Location = new System.Drawing.Point(104, 36);
			this.txtCaption.Name = "txtCaption";
			this.txtCaption.Size = new System.Drawing.Size(160, 20);
			this.txtCaption.TabIndex = 3;
			this.txtCaption.Text = "";
			this.txtCaption.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCaption_KeyPress);
			this.txtCaption.TextChanged += new System.EventHandler(this.txtCaption_TextChanged);
			// 
			// txtDate
			// 
			this.txtDate.Location = new System.Drawing.Point(104, 68);
			this.txtDate.Name = "txtDate";
			this.txtDate.Size = new System.Drawing.Size(160, 20);
			this.txtDate.TabIndex = 5;
			this.txtDate.Text = "";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(8, 160);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(37, 13);
			this.label5.TabIndex = 4;
			this.label5.Text = "&Notes:";
			// 
			// txtNotes
			// 
			this.txtNotes.AcceptsReturn = true;
			this.txtNotes.Location = new System.Drawing.Point(16, 176);
			this.txtNotes.Multiline = true;
			this.txtNotes.Name = "txtNotes";
			this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtNotes.Size = new System.Drawing.Size(264, 72);
			this.txtNotes.TabIndex = 5;
			this.txtNotes.Text = "";
			// 
			// cmbxPhotographer
			// 
			this.cmbxPhotographer.Location = new System.Drawing.Point(104, 104);
			this.cmbxPhotographer.MaxDropDownItems = 4;
			this.cmbxPhotographer.Name = "cmbxPhotographer";
			this.cmbxPhotographer.Size = new System.Drawing.Size(160, 21);
			this.cmbxPhotographer.Sorted = true;
			this.cmbxPhotographer.TabIndex = 7;
			this.cmbxPhotographer.Validated += new System.EventHandler(this.cmbxPhotographer_Validated);
			this.cmbxPhotographer.TextChanged += new System.EventHandler(this.cmbxPhotographer_TextChanged);
			// 
			// PhotoEditDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(296, 297);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.panel1,
																		  this.label5,
																		  this.txtNotes});
			this.Name = "PhotoEditDlg";
			this.Text = "Photo Properties";
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		protected override void ResetSettings()
		{
			// Initialize the ComboBox settings
			if (cmbxPhotographer.Items.Count == 0)
			{
				// Create the list of photographers
				cmbxPhotographer.BeginUpdate();
				cmbxPhotographer.Items.Clear();
				cmbxPhotographer.Items.Add("unknown");

				foreach (Photograph ph in _album)
				{
					if (ph.Photographer != null && !cmbxPhotographer.Items.Contains(ph.Photographer))
					{
						cmbxPhotographer.Items.Add(ph.Photographer);
					}
				}
				cmbxPhotographer.EndUpdate();
			}

			Photograph p = _album.CurrentPhoto;

			if (p != null) 
			{
				txtPhotoFile.Text = p.FileName;
				txtCaption.Text = p.Caption;
				txtDate.Text = p.DateTaken.ToString();
				cmbxPhotographer.SelectedItem = p.Photographer;
				txtNotes.Text = p.Notes;
			}
		}

		protected override bool SaveSettings()
		{
			Photograph photo = _album.CurrentPhoto;

			if (photo != null)
			{
				photo.Caption = txtCaption.Text;
				// Ignore txtDate setting for now
				photo.Photographer = cmbxPhotographer.Text;
				photo.Notes = txtNotes.Text;
			}

			return true;
		}

		private void txtCaption_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			char c = e.KeyChar;

			e.Handled = !(Char.IsLetterOrDigit(c) || Char.IsWhiteSpace(c) || Char.IsControl(c));
		}

		private void txtCaption_TextChanged(object sender, System.EventArgs e)
		{		
			this.Text = String.Format("{0} - Photo Properties", txtCaption.Text);
		}

		private void cmbxPhotographer_Validated(object sender, System.EventArgs e)
		{
			string pg = cmbxPhotographer.Text;

			if (!cmbxPhotographer.Items.Contains(pg))
			{
				_album.CurrentPhoto.Photographer = pg;
				cmbxPhotographer.Items.Add(pg);
			}
			cmbxPhotographer.SelectedItem = pg;
		}

		private void cmbxPhotographer_TextChanged(object sender, System.EventArgs e)
		{
			string text = cmbxPhotographer.Text;
			int index = cmbxPhotographer.FindString(text);

			if (index >= 0)
			{
				// Found a match
				string newText = cmbxPhotographer.Items[index].ToString();
				cmbxPhotographer.Text = newText;

				cmbxPhotographer.SelectionStart = text.Length;
				cmbxPhotographer.SelectionLength = newText.Length - text.Length;
			}
		}

		// end of PhotoEditDlg
	}
}

