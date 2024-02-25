using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory;

public class CategoryInMemoryRepository : ICategoryRepository
{
	private List<Category> categories;

	public CategoryInMemoryRepository()
	{

		// Add some default Categories.
		categories = new List<Category>()
		{
			new() {CategoryId = 1, Name = "Fruits", Description="Healthy and juicy fruits"},
			new() {CategoryId = 2, Name = "Vegetables", Description="Fresh and rich for vitamins"},
			new() {CategoryId = 3, Name = "Meet", Description="Halal and fatty meet"}
		};
	}

	public void AddCategory(Category category)
	{
		//if (categories.Contains(category)) return;
		if (categories.Any(x => x.Name.Equals(category.Name, StringComparison.OrdinalIgnoreCase))) return;

		if (categories != null && categories.Count > 0)
		{
			var maxId = categories.Max(x => x.CategoryId);
			category.CategoryId = maxId + 1;
		}
		else
		{
			category.CategoryId = 1;
		}

		categories.Add(category);
	}

	public void DeleteCategory(int categoryId)
	{
		var category = GetCategoryById(categoryId);
		if (category != null)
		{
			categories.Remove(category);
		}
	}

	public IEnumerable<Category> GetCategories()
	{
		return categories;
	}

	public Category GetCategoryById(int categoryId)
	{
		var category = categories.FirstOrDefault(x => x.CategoryId == categoryId);
		return category ?? new();
	}

	public void UpdateCategory(Category category)
	{
		var categoryToUpdate = GetCategoryById(category.CategoryId);
		if (categoryToUpdate != null)
		{
			categoryToUpdate.Name = category.Name;
			categoryToUpdate.Description = category.Description;
		}
	}
}
