using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Manning.MyPhotoAlbum
{
	/// <summary>
	/// Summary description for BaseEditDlg.
	/// </summary>
	public class BaseEditDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnReset;
		private System.Windows.Forms.Button btnCancel;
		protected System.Windows.Forms.Panel panel1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public BaseEditDlg()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
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
			this.btnOK = new System.Windows.Forms.Button();
			this.btnReset = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(16, 264);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 0;
			this.btnOK.Text = "&OK";
			// 
			// btnReset
			// 
			this.btnReset.Location = new System.Drawing.Point(108, 264);
			this.btnReset.Name = "btnReset";
			this.btnReset.TabIndex = 1;
			this.btnReset.Text = "&Reset";
			this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(200, 264);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "&Cancel";
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Location = new System.Drawing.Point(8, 8);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(280, 136);
			this.panel1.TabIndex = 3;
			// 
			// BaseEditDlg
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(294, 295);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.panel1,
																		  this.btnCancel,
																		  this.btnReset,
																		  this.btnOK});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "BaseEditDlg";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "BaseEditDlg";
			this.ResumeLayout(false);

		}
		#endregion

		private void btnReset_Click(object sender, System.EventArgs e)
		{
			ResetSettings();
		}

		protected virtual void ResetSettings()
		{
			// Subclasses override to reset form
		}

		protected virtual bool SaveSettings()
		{
			// Subclasses override to save form
			return true;
		}

		protected override void OnClosing(CancelEventArgs e)
		{
			if (!e.Cancel && (this.DialogResult == DialogResult.OK))
			{
				e.Cancel = ! SaveSettings();
			}

			base.OnClosing(e);
		}

	}
}
