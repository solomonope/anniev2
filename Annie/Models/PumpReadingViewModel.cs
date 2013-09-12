using System;

namespace Annie.ViewModel
{
	public class PumpReadingViewModel
	{
		public string PumpReadingId
		{
			get;
			set;
		}
		public DateTime ReadingDate
		{
			get;
			set;
		}
		public double SalesRate
		{
			get;
			set;
		}
		public double StartOfBusiness
		{
			get;
			set;
		}
		public double CloseOfBusiness
		{
			get;
			set;
		}
		public double TotalVolumeSold
		{
			get
			{
				return CloseOfBusiness - StartOfBusiness;
			}

		}
		public string PumpId
		{
			get;
			set;
		}
	}
}

