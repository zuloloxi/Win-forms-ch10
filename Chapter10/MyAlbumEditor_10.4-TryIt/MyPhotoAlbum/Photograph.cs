using System;
using System.Drawing;
using System.IO;

namespace Manning.MyPhotoAlbum
{
	/// <summary>
	/// The Photograph class represents a single photo and its properties.
	/// </summary>
	public class Photograph : IDisposable
	{
		private static Bitmap _invalidImageBitmap = null;

		private string _fileName;
		private Bitmap _bitmap;
		private string _caption;
		private DateTime _dateTaken;
		private string _photographer;
		private string _notes;

		public delegate Photograph ReadDelegate(StreamReader sr);
			
		public Photograph(string fileName)
		{
			_fileName = fileName;
			_bitmap = null;
			_caption = Path.GetFileNameWithoutExtension(_fileName);
			_dateTaken = DateTime.Now;
			_photographer = "unknown";
			_notes = "no notes provided";
		}

		public void Dispose()
		{
			if (_bitmap != null && _bitmap != InvalidPhotoImage)
			{
				_bitmap.Dispose();
			}

			_bitmap = null;
		}

		public string FileName
		{
			get { return _fileName; }
		}

		public Bitmap Image
		{
			get
			{
				if (_bitmap == null)
				{
					try
					{
						_bitmap = new Bitmap(_fileName);
					}
					catch
					{
						_bitmap = InvalidPhotoImage;
					}
				}

				return _bitmap;
			}
		}

		public static Bitmap InvalidPhotoImage
		{
			get 
			{
				if (_invalidImageBitmap == null)
				{
					// Create the "bad photo" bitmap
					Bitmap bm = new Bitmap(100, 100);
					Graphics g = Graphics.FromImage(bm);
					g.Clear(Color.WhiteSmoke);

					// Draw a red X
					Pen p = new Pen(Color.Red, 5);
					g.DrawLine(p, 0, 0, 100, 100);
					g.DrawLine(p, 100, 0, 0, 100);

					_invalidImageBitmap = bm;
				}

				return _invalidImageBitmap;
			}
		}

		public bool IsImageValid
		{
			get
			{
				return (_bitmap != InvalidPhotoImage);
			}
		}

		// Object class overrides
		public override bool Equals(object obj)
		{
			if (obj is Photograph)
			{
				Photograph p = (Photograph)obj;

				return (_fileName.ToLower().Equals(p.FileName.ToLower()));
			}

			return false;
		}

		public override int GetHashCode()
		{
			return this.FileName.GetHashCode();
		}

		public override string ToString()
		{
			return this.FileName;
		}

		// Other members
		public Rectangle ScaleToFit(Rectangle targetArea)
		{
			Rectangle result = new Rectangle(targetArea.Location, targetArea.Size);

			// Determine best fit: width or height
			if (result.Height * Image.Width > result.Width * Image.Height)
			{
				// Final width should match target, determine and center height
				result.Height = result.Width * Image.Height / Image.Width;
				result.Y += (targetArea.Height - result.Height) / 2;
			}
			else
			{
				// Final height should match target, determine and center width
				result.Width = result.Height * Image.Width / Image.Height;
				result.X += (targetArea.Width - result.Width) / 2;
			}

			return result;
		}

		public string Caption
		{
			get { return _caption; }
			set
			{
				if (value == null || value.Length == 0)
				{
					_caption = Path.
						GetFileNameWithoutExtension(_fileName);
				}
				else 
				{
					_caption = value;
				}
			}
		}

		public DateTime DateTaken
		{
			get { return _dateTaken; }
			set { _dateTaken = value; }
		}

		public string Photographer
		{
			get { return _photographer; }
			set { _photographer = value; }
		}

		public string Notes
		{
			get { return _notes; }
			set { _notes = value; }
		}

		public void Write(StreamWriter sw)
		{
			// First write the file and caption.
			sw.WriteLine(this.FileName);
			sw.WriteLine(this.Caption);

			// Write the date and photographer
			sw.WriteLine(this.DateTaken.Ticks);
			sw.WriteLine(this.Photographer);

			// Finally, write any notes
			sw.WriteLine(this.Notes.Length);
			sw.Write(this.Notes.ToCharArray());
			sw.WriteLine();
		}

		static public Photograph ReadVersion66(StreamReader sr)
		{
			String name = sr.ReadLine();
			if (name != null)
				return new Photograph(name);
			else
				return null;
		}

		static public Photograph ReadVersion83(StreamReader sr)
		{
			String name = sr.ReadLine();
			if (name == null)
				return null;

			Photograph p = new Photograph(name);
			p.Caption = sr.ReadLine();
			return p;
		}

		static public Photograph ReadVersion92(StreamReader sr)
		{
			// Use ReadVer83 for file and caption
			Photograph p = ReadVersion83(sr);
			if (p == null)
				return null;

			// Read date (may throw FormatException)
			string data = sr.ReadLine();
			long ticks = Convert.ToInt64(data);
			p.DateTaken = new DateTime(ticks);

			// Read the photographer
			p.Photographer = sr.ReadLine();

			// Read the notes size
			data = sr.ReadLine();
			int len = Convert.ToInt32(data);

			// Read the actual notes characters
			char[] notesArray = new char[len];
			sr.Read(notesArray, 0, len);
			p.Notes = new string(notesArray);
			sr.ReadLine();

			return p;
		}

		// end of Photograph class
	}
}