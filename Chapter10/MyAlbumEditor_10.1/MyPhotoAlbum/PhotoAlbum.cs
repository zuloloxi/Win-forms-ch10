using System;
using System.Collections;
using System.IO;
using System.Windows.Forms;

namespace Manning
{
	namespace MyPhotoAlbum
	{
		/// <summary>
		/// The PhotoAlbum class represents a collection of Photographs.
		/// </summary>
		public class PhotoAlbum : CollectionBase, IDisposable
		{
			private string _fileName = null;
			private string _title;
			private string _password;

			public enum DisplayValEnum 
			{
				FileName, Caption, Date
			};
			private DisplayValEnum _displayOption = DisplayValEnum.Caption;

			public PhotoAlbum()
			{
				// Nothing to do
			}

			public void Dispose()
			{
				foreach (Photograph photo in this)
				{
					photo.Dispose();
				}
			}

			// Default directory implementation
			static private string _defaultDir = null;
			static private bool _initializeDir = true;

			static private void InitDefaultDir()
			{
				if (_defaultDir == null)
				{
					if (DateTime.Now < new DateTime(2002, 1, 1))
					{
						// For building the book's graphics
						_defaultDir = @"C:\My Documents";
					}
					else
					{
						// actual code from book
						_defaultDir = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
					}
					_defaultDir += @"\Albums";
				}

				Directory.CreateDirectory(_defaultDir);
			}

			static public string DefaultDir
			{
				get
				{
					if (_initializeDir)
					{
						InitDefaultDir();
						_initializeDir = false;
					}
					return _defaultDir;
				}
				set
				{
					_defaultDir = value;
					_initializeDir = true;
				}
			}

			// Implementation of ICollection interface
			public virtual bool IsSynchronized
			{
				get { return false; }
			}

			public virtual object SyncRoot
			{
				get { return List.SyncRoot; }
			}

			public virtual void CopyTo(Photograph[] array, int index)
			{
				List.CopyTo(array, index);
			}

			// Implementation of the ILIst interface
			public virtual bool IsFixedSize
			{
				get { return false; }
			}
			
			public virtual bool IsReadOnly
			{
				get { return false; }
			}

			public virtual Photograph this[int index]
			{
				get { return (Photograph)(List[index]); }
				set { List[index] = value; }
			}

			public virtual int Add(Photograph photo)
			{
				return List.Add(photo);
			}

			public virtual bool Contains(Photograph photo)
			{
				return List.Contains(photo);
			}

			public virtual int IndexOf(Photograph photo)
			{
				return List.IndexOf(photo);
			}
			
			public virtual void Insert(int index, Photograph photo)
			{
				List.Insert(index, photo);
			}

			public virtual void Remove(Photograph photo)
			{
				List.Remove(photo);
			}

			/// <summary>
			/// Tracks the current index position when displaying the album.
			/// </summary>
			private int _currentPos = 0;

			public int CurrentPosition
			{
				get { return _currentPos; }

				set
				{
					if (value <= 0)
					{
						_currentPos = 0;
					}
					else if (value >= this.Count)
					{
						_currentPos = this.Count - 1;
					}
					else
					{
						_currentPos = value;
					}
				}
			}

			protected override void OnClear()
			{
				_currentPos = 0;
				_fileName = null;
				_title = null;
				_password = null;
				_displayOption = DisplayValEnum.Caption;

				this.Dispose();
				base.OnClear();
			}

			public Photograph CurrentPhoto
			{
				get
				{
					if (this.Count == 0)
						return null;

					return this[CurrentPosition];
				}
			}

			public bool CurrentNext()
			{
				if (CurrentPosition+1 < this.Count)
				{
					CurrentPosition ++;
					return true;
				}

				return false;
			}

			public bool CurrentPrev()
			{
				if (CurrentPosition > 0)
				{
					CurrentPosition --;
					return true;
				}

				return false;
			}

			protected override void OnRemoveComplete(int index, object val)
			{
				CurrentPosition = _currentPos;
				base.OnRemoveComplete(index, val);
			}

			// Other class members
			public string FileName
			{
				get { return _fileName; }
				set { _fileName = value; }
			}

			private const int _CurrentVersion = 93;

			public void Save(string fileName)
			{
				FileStream fs = new FileStream(fileName,
					FileMode.Create,
					FileAccess.ReadWrite);

				StreamWriter sw = new StreamWriter(fs);

				try
				{
					sw.WriteLine(_CurrentVersion.ToString());

					// Save album properties
					sw.WriteLine(_title);
					sw.WriteLine(_password);
					sw.WriteLine(Convert.ToString((int)_displayOption));

					// Store each photo separately
					foreach (Photograph photo in this)
					{
						photo.Write(sw);
					}

					this._fileName = fileName;
				}

				finally
				{
					sw.Close();
					fs.Close();
				}
			}

			public void Save()
			{
				// Assumes FileName is not null
				Save(this.FileName);
			}

			public void Open(string fileName)
			{
				FileStream fs = new FileStream(fileName,
					FileMode.Open,
					FileAccess.Read);

				StreamReader sr = new StreamReader(fs);

				int version;

				try
				{
					version = Int32.Parse(sr.ReadLine());
				}
				catch
				{
					version = 0;
				}

				try
				{
					// Initialize as a new album
					Clear();
					this._fileName = fileName;
					ReadAlbumData(sr, version);

					// Check for password
					if (_password != null && _password.Length > 0)
					{
						using (PasswordDlg dlg = new PasswordDlg())
						{
							dlg.Text = String.Format("Opening album {0}", Path.GetFileName(_fileName));
							if ((dlg.ShowDialog() == DialogResult.OK) && (dlg.Password != _password))
							{
								throw new ApplicationException("Invalid password provided");
							}
						}
					}

					Photograph.ReadDelegate ReadPhoto;
					switch (version)
					{
						case 66:
							ReadPhoto = new Photograph.ReadDelegate(Photograph.ReadVersion66);
							break;

						case 83:
							ReadPhoto = new Photograph.ReadDelegate(Photograph.ReadVersion83);
							break;

						case 92:
						case 93:
							ReadPhoto = new Photograph.ReadDelegate(Photograph.ReadVersion92);
							break;

						default:
							// Unknown version or bad file.
							throw (new IOException
								("Unrecognized album file format"));
					}

					// Read in each photograph in the album
					Photograph p = ReadPhoto (sr);
					while (p != null)
					{
						this.Add(p);
						p = ReadPhoto (sr);
					}
				}
				finally
				{
					sr.Close();
					fs.Close();
				}
			}

			public string Title
			{
				get { return _title; }
				set { _title = value; }
			}

			public string Password
			{
				get { return _password; }
				set { _password = value; }
			}

			public DisplayValEnum DisplayOption
			{
				get { return _displayOption; }
				set { _displayOption = value; }
			}

			protected void ReadAlbumData(StreamReader sr, int version)
			{
				// Initialize settings to defaults
				_title = null;
				_password = null;
				_displayOption = DisplayValEnum.Caption;

				if (version >= 93) 
				{
					// Read album-specific data
					_title = sr.ReadLine();
					_password = sr.ReadLine();
					_displayOption = (DisplayValEnum) Convert.ToInt32(sr.ReadLine());
				}

				// Initialize title if none provided
				if (_title == null || _title.Length == 0) 
				{
					_title = Path.GetFileNameWithoutExtension(_fileName);
				}
			}

			public string GetDisplayText(Photograph photo)
			{
				switch (this._displayOption)
				{
					case DisplayValEnum.Caption:
					default:
						return photo.Caption;

					case DisplayValEnum.Date:
						return photo.DateTaken.ToString("g");

					case DisplayValEnum.FileName:
						return Path.GetFileName(photo.FileName);
				}
			}

			public string CurrentDisplayText
			{
				get { return GetDisplayText(CurrentPhoto); }
			}

			// end of PhotoAlbum class
		}
	}
}
