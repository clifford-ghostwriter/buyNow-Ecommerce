using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using buyNow.UTILITY.Interface;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;





namespace buyNow.UTILITY
{
	public static class ConvertExtension
	{

		public static ICollection<SelectListItem> ConvertToSelectList<T>(this IEnumerable<T> collection, int selectedValue) where T : IPrimaryProperties
		{
			return (from item in collection
					select new SelectListItem
					{
						Text = item.Name,
						Value = item.Id.ToString(),
						Selected = (item.Id == selectedValue)
					}).ToList();
		}
	}

	
}
