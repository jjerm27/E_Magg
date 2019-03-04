using E_Mag.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace E_Mag.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        [AllowAnonymous]
        public ActionResult Index()
        {
            #region adding data in database

            //ApplicationUserManager userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));

            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            //// создаем роли
            //var role1 = new IdentityRole { Name = "admin" };
            //var role2 = new IdentityRole { Name = "user" };
            //var role3 = new IdentityRole { Name = "moder" };
            //var role4 = new IdentityRole { Name = "deputyAdmin" };

            //// добавляем роли в бд
            //roleManager.Create(role1);
            //roleManager.Create(role2);
            //roleManager.Create(role3);
            //roleManager.Create(role4);

            //// создаем пользователей
            //var admin = new ApplicationUser { Email = "admin@mail.ru", UserName = "admin@mail.ru" };
            //string password = "Qwerty";
            //var result = userManager.Create(admin, password);
            //if (result.Succeeded)
            //{
            //    userManager.AddToRole(admin.Id, role1.Name);
            //    userManager.AddToRole(admin.Id, role2.Name);
            //}

            //var user = new ApplicationUser { Email = "user1@mail.ru", UserName = "user1@mail.ru" };
            //result = userManager.Create(user, password);
            //if (result.Succeeded)
            //    userManager.AddToRole(user.Id, role2.Name);

            //user = new ApplicationUser { Email = "user2@mail.ru", UserName = "user2@mail.ru" };
            //result = userManager.Create(user, password);
            //if (result.Succeeded)
            //    userManager.AddToRole(user.Id, role2.Name);

            //Создаем категории
            //var cat = new Category { CategoryName = "Спортивная одежда" };
            //db.Categories.Add(cat);
            //cat = new Category { CategoryName = "Для мужчин" };
            //db.Categories.Add(cat);
            //cat = new Category { CategoryName = "Для женщин" };
            //db.Categories.Add(cat);
            //cat = new Category { CategoryName = "Для детей" };
            //db.Categories.Add(cat);
            //cat = new Category { CategoryName = "Мода" };
            //db.Categories.Add(cat);
            //cat = new Category { CategoryName = "Для дома" };
            //db.Categories.Add(cat);
            //cat = new Category { CategoryName = "Интерьер" };
            //db.Categories.Add(cat);
            //cat = new Category { CategoryName = "Одежда" };
            //db.Categories.Add(cat);
            //cat = new Category { CategoryName = "Сумки" };
            //db.Categories.Add(cat);
            //cat = new Category { CategoryName = "Обувь" };
            //db.Categories.Add(cat);
            //cat = new Category { CategoryName = "Футболки" };
            //db.Categories.Add(cat);
            //cat = new Category { CategoryName = "Футболки поло" };
            //db.Categories.Add(cat);
            //cat = new Category { CategoryName = "Блейзеры" };
            //db.Categories.Add(cat);
            //cat = new Category { CategoryName = "Солнцезащитные очки" };
            //db.Categories.Add(cat);
            //db.SaveChanges();

            //Создаем бренды
            //var br = new Brand { BrandName = "ACNE" };
            //db.Brands.Add(br);
            //br = new Brand { BrandName = "ALBIRO" };
            //db.Brands.Add(br);
            //br = new Brand { BrandName = "RONHILL" };
            //db.Brands.Add(br);
            //br = new Brand { BrandName = "ODDMOLLY" };
            //db.Brands.Add(br);
            //br = new Brand { BrandName = "BOUDESTIJN" };
            //db.Brands.Add(br);
            //br = new Brand { BrandName = "ADIDAS" };
            //db.Brands.Add(br);
            //br = new Brand { BrandName = "NIKE" };
            //db.Brands.Add(br);
            //br = new Brand { BrandName = "UNDER ARMOUR" };
            //db.Brands.Add(br);
            //br = new Brand { BrandName = "PUMA" };
            //db.Brands.Add(br);
            //br = new Brand { BrandName = "ASICS" };
            //db.Brands.Add(br);
            //br = new Brand { BrandName = "VALENTINO" };
            //db.Brands.Add(br);
            //br = new Brand { BrandName = "VERSACE" };
            //db.Brands.Add(br);
            //br = new Brand { BrandName = "FENDI" };
            //db.Brands.Add(br);
            //br = new Brand { BrandName = "GUESS" };
            //db.Brands.Add(br);
            //br = new Brand { BrandName = "DIOR" };
            //db.Brands.Add(br);
            //br = new Brand { BrandName = "ARMANI" };
            //db.Brands.Add(br);
            //br = new Brand { BrandName = "PRADA" };
            //db.Brands.Add(br);
            //br = new Brand { BrandName = "DOLCHE AND GABANA" };
            //db.Brands.Add(br);
            //br = new Brand { BrandName = "CHANELL" };
            //db.Brands.Add(br);
            //br = new Brand { BrandName = "GUCCI" };
            //db.Brands.Add(br);
            //db.SaveChanges();
            #endregion
           
            var cats = db.Categories.Take(10).ToList();
            if (cats != null)
                ViewBag.cats = cats;
            var brands = db.Brands.Take(7).ToList();
            if (brands != null)
                ViewBag.brands = brands;
            var products = db.Products.Take(6).ToList();           
            if (products != null)
                ViewBag.products = products;
            var category = db.Categories.Where(i => i.Products.Count > 0).Take(6).ToList();
            if (category != null)
                ViewBag.categoriList = category;                 
            return View();
        }

        public ActionResult Shop(int page = 1)
        {
            var cats = db.Categories.Take(10).ToList();
            if (cats != null)
                ViewBag.cats = cats;
            var brands = db.Brands.Take(7).ToList();
            if (brands != null)
                ViewBag.brands = brands;
            
            int pageSize = 12; // количество объектов на страницу
            IEnumerable<Product> ProductsPerPage = db.Products.OrderBy(p=>p.ProductName).Skip((page - 1) * pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = db.Products.Count() };
            PagedViewModel avm = new PagedViewModel { PageInfo = pageInfo, ProductsPaged = ProductsPerPage };  
            
            return View(avm);
        }

        [HttpPost]
        public void AddToCart(int? id)
        {
            var product = db.Products.Find(id);
            if(product!=null)
            {
                GetCart().AddItem(product, 1);                
            }  
            
        }

        [HttpPost]
        public string AddToCartPlus(int? id)
        {
            var product = db.Products.Find(id);
            if (product != null)
            {
                GetCart().AddItem(product, 1);
            }
            var quantity = GetCart().Lines.First(i => i.Product.ProductId == id);

            return quantity.Quantity + "|" + id+"|"+quantity.Product.Price;
        }

        [HttpPost]
        public string RemoveFromCart(int? id)
        {            
            var product = db.Products.Find(id);

            CartLine cartLine = null;
            string price = "", quantity = "";            

            if (product != null)
            {
                cartLine = GetCart().Lines.First(l => l.Product.ProductId == id);
                price = cartLine.Product.Price.ToString();
                quantity = cartLine.Quantity.ToString();
                GetCart().RemoveLine(product);
            }          
            return id + "|" + price + "|"+ quantity;
        }

        [HttpPost]
        public string RemoveFromCartMinus(int? id)
        {
            CartLine cartLine = null;

            var product = db.Products.Find(id);
            if (product != null)
            {               
                cartLine = GetCart().Lines.First(i => i.Product.ProductId == id);                
                if(cartLine != null)
                {
                    
                    if (cartLine.Quantity == 1)
                        return cartLine.Quantity + "|" + id + "|" + cartLine.Product.Price;
                    else
                    {
                        cartLine.Quantity--;
                    }                                                                                         
                }              
            }
            return cartLine.Quantity + "|" + id + "|" + cartLine.Product.Price;
        }


        public Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if(cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }

            return cart;                
        }

        [Authorize]
        public ActionResult ShowCart()
        {
            return View(GetCart().Lines);
        }

       
        [HttpPost]
        public ActionResult MakeTheOrder()
        {
            string UId = User.Identity.GetUserId();

            int publicId = 0;
            var publicOrderId = db.Orders.OrderByDescending(o=>o.OrderId).FirstOrDefault();

            if (publicOrderId == null)
                publicId = 1;
            else
            {
                publicId = publicOrderId.PublicOrderId;
                publicId++;
            }
                
            if (UId != null)
            {
                foreach (var line in GetCart().Lines)
                {
                    Order order = new Order { UserId = UId, OrderDate = DateTime.Now, ProductId = line.Product.ProductId, Quantity = line.Quantity, Price = line.Product.Price * line.Quantity, PublicOrderId = publicId };
                    db.Orders.Add(order);
                    
                }
                db.SaveChanges();
                GetCart().Clear();               
            }

            var script = "window.location ='" + Url.Action("ShowOrder", "Home") + "' ;";
            return JavaScript(script);
           
        }
       
        public ActionResult ShowOrder()
        {
            return View(db.Orders.OrderByDescending(o => o.OrderId).FirstOrDefault());
        }


        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}