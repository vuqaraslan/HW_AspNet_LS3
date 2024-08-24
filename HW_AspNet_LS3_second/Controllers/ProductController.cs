using HW_AspNet_LS3_second.Entities;
using HW_AspNet_LS3_second.Models;
using HW_AspNet_LS3_second.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace HW_AspNet_LS3_second.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        //List<Product> _allProducts = new List<Product>();
        public ProductController(IProductService productService)
        {
            _productService = productService;
            //_allProducts = new List<Product>();
            //GetAllProducts();
        }

        //public async Task GetAllProducts(string key = "")
        //{
        //    _allProducts = await _productService.GetAllByKeyAsync(key);
        //}

        // GET: StudentController
        public async Task<ActionResult> Index(string key = "")
        {
            //GetAllProducts(key);
            //var productListViewModel = new ProductListViewModel
            //{
            //    ProductList = _allProducts
            //};
            var allProducts = await _productService.GetAllByKeyAsync(key);
            var productListViewModel = new ProductListViewModel
            {
                ProductList = allProducts
            };
            return View(productListViewModel);
            //return Ok(result);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var allProducts = await _productService.GetAllByKeyAsync("");
            if (allProducts != null)
            {
                var productForUpdate = allProducts.SingleOrDefault(p => p.Id == id);
                if (productForUpdate != null)
                {
                    var updateProductViewModel = new UpdateProductViewMOdel
                    {
                        ProductUpdate = productForUpdate
                    };
                    return View(updateProductViewModel);
                }
                else
                {
                    return NotFound("Product could not find in database !");
                }
            }
            return Json("Product List is empty !");
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateProductViewMOdel updateProductVM)
        {
            var allProducts = await _productService.GetAllByKeyAsync("");
            var updatedProduct = allProducts.SingleOrDefault(p => p.Id == updateProductVM.ProductUpdate.Id);
            if (ModelState.IsValid)
            {
                if (updatedProduct != null)
                {
                    updatedProduct.Name = updateProductVM.ProductUpdate.Name;
                    updatedProduct.Price = updateProductVM.ProductUpdate.Price;
                    updatedProduct.Discount = updateProductVM.ProductUpdate.Discount;
                    updatedProduct.Description = updateProductVM.ProductUpdate.Description;
                    updatedProduct.ImagePath = updateProductVM.ProductUpdate.ImagePath;

                    var result = _productService.UpdateAsync(updatedProduct);
                    return RedirectToAction("Index");
                }
            }
            return View(updateProductVM);
        }

        // GET: StudentController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var allProducts = await _productService.GetAllByKeyAsync("");
            if (allProducts != null)
            {
                var productForDelete = allProducts.SingleOrDefault(p => p.Id == id);
                if (productForDelete != null)
                {
                    await _productService.DeleteAsync(productForDelete);
                }
                else
                {
                    return Json("Product is null !");
                }
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var addNewProductVM = new AddNewProductViewModel
            {
                NewProduct = new Product()
            };
            return View(addNewProductVM);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddNewProductViewModel newAddProduct)
        {
            if (ModelState.IsValid)
            {
                if (newAddProduct.NewProduct != null)
                {

                    await _productService.AddAsync(newAddProduct.NewProduct);
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(newAddProduct);
        }

        public async Task<IActionResult> GetProductByIdAsync(int id )
        {
            var product = await _productService.GetByIdAsync(id);
            if (product != null)
            {
                return Ok(product);
            }
            return NotFound("Not found !");
        }


        public async Task<IActionResult> GetProductByName(string name)
        {
            var product=await _productService.GetByNameAsync(name);
            if(product != null)
            {
                return Ok(product);
            }
            return NotFound("Not found !");
        }



        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
