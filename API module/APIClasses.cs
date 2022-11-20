using System;


namespace CS_webapp.Models.API
{
	public class VhodniPodatki
	{
		/// <summary>
		/// Enolièni identifikator uporabnika.
		/// </summary>
		public Guid ID_SeznamUporabnikov { get; set; }

		/// <summary>
		/// Ime uporabnika.
		/// </summary>
		public string Ime { get; set; }

		/// <summary>
		/// Priimek uporabnika.
		/// </summary>
		public string Priimek { get; set; }

		/// <summary>
		/// Elektronski naslov uporabnika.
		/// </summary>
		public string Email { get; set; }

		/// <summary>
		/// Boolean: uporabnika JE/NI na mailning listi. 
		/// </summary>
		public bool OnMailingList { get; set; }
	}


	public class IzhodniPodatki
	{
		/// <summary>
		/// Ime uporabnika.
		/// </summary>
		public string Ime { get; set; }

		/// <summary>
		/// Priimek uporabnika.
		/// </summary>
		public string Priimek { get; set; }

		/// <summary>
		/// Elektronski naslov uporabnika.
		/// </summary>
		public string Email { get; set; }
	}

	public class FindByName
    {
		/// <summary>
		/// Ime uporabnika.
		/// </summary>
		public string Ime { get; set; }
	}

}