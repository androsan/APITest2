using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace CS_webapp.Models
{
	public class SeznamUporabnikov
	{
		[Key]
		public Guid ID_SeznamUporabnikov { get; set; }

		[Required]
		[DisplayName("Ime")]
		[MaxLength(15)]
		public string Ime { get; set; }

		[DisplayName("Priimek")]
		
		public string Priimek { get; set; }

		[DisplayName("E-mail")]
		public string Email { get; set; }

		public bool OnMailingList { get; set; }
	}

}