﻿using DoQuocHuy0352.Context;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

public class ProductController : Controller
{
    private WebsiteEcomEntities1 _context = new WebsiteEcomEntities1();

    public ActionResult Index()
    {
        var listProduct = _context.Products.ToList();
        return View(listProduct);
    }


    public ActionResult ProductDetail(int id)
    {
        var product = _context.Products.FirstOrDefault(p => p.Id == id);
        if (product == null)
        {
            return HttpNotFound();
        }
        return View(product);
    }

    public async Task<ActionResult> ProductsByCategory(int categoryId)
    {
        var products = await _context.Products
            .Where(p => p.CategoryId == categoryId)
            .ToListAsync();

        ViewBag.CategoryId = categoryId;
        return View(products);
    }
}
