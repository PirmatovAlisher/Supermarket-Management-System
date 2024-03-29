﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness;

public class Category
{
	public int CategoryId { get; set; }
	[Required]
	public string Name { get; set; }

	public string Description { get; set; }

	// Navigation property for EF Core
	public List<Product> Products { get; set; }
}
