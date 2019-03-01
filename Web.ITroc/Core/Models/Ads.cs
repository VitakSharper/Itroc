using System;
using System.Collections.Generic;

namespace Web.ITroc.Core.Models
{
	public class Ads
	{
		public int Id { get; set; }

		public string AdTitle { get; set; }

		public string AdDescription { get; set; }

		public DateTime AdCreate { get; set; }

		public bool Poubelle { get; set; }

		public string AdAdresse { get; set; }

		public int CategoryId { get; set; }
		public Category Category { get; set; }

		public int? CodePostalId { get; set; }
		public Codepostal Codepostal { get; set; }

		public string UserId { get; set; }
		public ApplicationUser User { get; set; }

		public IList<Image> Images { get; set; }
	}
}