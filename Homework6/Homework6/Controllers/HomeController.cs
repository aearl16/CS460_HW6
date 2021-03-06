﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Homework6.Models;
using System.Net;

namespace Homework6.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Global variables
        /// </summary>
        private AdventureWorks2014Entities db = new AdventureWorks2014Entities();
        private int PageSize = 4;

        /// <summary>
        /// Homepage
        /// </summary>
        /// <returns> Returns Index.cshtml view</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Queries Categories and displays subcategories based on query
        /// Defaulst to Bikes and Page 1
        /// </summary>
        /// <param name="category"></param>
        /// <param name="page"></param>
        /// <returns> View of subcategories </returns>
        [HttpGet]
        public ActionResult Categories(string category = "Bikes", int page = 1)
        {
            return View(db.ProductSubcategories
                        .Where(v => v.ProductCategory.Name.Contains(category))
                        .OrderBy(p => p.ProductCategoryID)
                        .Skip((page - 1) * PageSize)
                        .Take(PageSize));

        }

        /// <summary>
        /// Dispalys products based on Subcategory Queries
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="page"></param>
        /// <returns> View of Products based on ProductSubcategory ID</returns>
        [HttpGet]
        public ActionResult Products(int ID = 1, int page = 1)
        {
            return View(db.Products
                        .Where(catID => catID.ProductSubcategoryID == ID).ToList());

            //Tried Pagination
            /**
            return View(db.Products
                        .Where(catID => catID.ProductSubcategoryID == ID)
                        .OrderBy(pID => pID.ProductID)
                        .Skip((PageSize - 1) * PageSize)
                        .Take(PageSize));
            */
        }

        [HttpGet]
        public ActionResult ProductDetails(int? ID, int page = 1)
        {
            if(ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                return View(db.Products
                            .Where(p => p.ProductID == ID));
            }
        }

        /// <summary>
        /// Retrieves and gets the reivews based on ProductID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns> View of ProductReivews </returns>
        [HttpGet]
        public ActionResult Reviews(int? ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                return View(db.ProductReviews
                            .Where(p => p.ProductID == ID)
                            .OrderByDescending(d => d.ReviewDate).ToList());
            }
        }

        /// <summary>
        /// Get method for Create Reivew
        /// </summary>
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Creates and Posts a review
        /// </summary>
        /// <param name="review"></param>
        /// <returns> Redirect to the Index page whether or not a reviewis posted</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID, ReviewerName, ReviewDate, EmailAddress, Rating, Comments, ModifiedDate")] ProductReview review, int ID)
        {
            review.ProductID = ID;
            review.ReviewDate = DateTime.Now;
            review.ModifiedDate = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.ProductReviews.Add(review);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Index");
        }
    }
}