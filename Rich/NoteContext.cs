using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Rich
{
	class NoteContext:DbContext
	{
		/// <summary>
		/// Контекст Данних
		/// </summary>

		public NoteContext()
			:base("Context")
		{

		}

		public DbSet<Note> Notes { get; set; }

	}
}
