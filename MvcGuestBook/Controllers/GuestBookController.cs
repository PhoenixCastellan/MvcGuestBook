using MvcGuestBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Sql;
using System.Data.SqlClient;
using Dapper;
using System.Configuration;

namespace MvcGuestBook.Controllers
{
    /// <summary>
    /// 目前只是最简单的做了下，之前没有详细玩过mvc
    /// </summary>
    public class GuestBookController : Controller
    {
        // GET: GuestBook
        public ActionResult Index()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            try
            {
                using (System.Data.IDbConnection conn = new SqlConnection(connectionString))
                {

                    string insert = "SELECT * FROM dbo.MvcGuestBook";
                    conn.Open();
                    var data = conn.QueryMultiple(insert).Read<GuestBook>().ToList();
                    return View(data);
                }
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: GuestBook/Details/5
        public ActionResult Details(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            try
            {
                using (System.Data.IDbConnection conn = new SqlConnection(connectionString))
                {
                    string insert = "SELECT * FROM dbo.MvcGuestBook WHERE Id=@Id";
                    conn.Open();
                    var data = conn.QuerySingle<GuestBook>(insert, new { Id = id });
                    return View(data);
                }
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: GuestBook/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GuestBook/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            try
            {
                using (System.Data.IDbConnection conn = new SqlConnection(connectionString))
                {

                    string insert = "INSERT  INTO dbo.MvcGuestBook" +
                        " (Name, Email, Abstract)" +
                        " VALUES(@Name, @Email, @Abstract)";
                    conn.Open();
                    conn.Execute(insert,new GuestBook()
                    {
                        Name = collection.Get("Name"),
                        Abstract = collection.Get("Abstract"),
                        Email = collection.Get("Email")
                    });
                }
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: GuestBook/Edit/5
        public ActionResult Edit(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            try
            {
                using (System.Data.IDbConnection conn = new SqlConnection(connectionString))
                {

                    string insert = "SELECT * FROM dbo.MvcGuestBook WHERE Id=@Id";
                    conn.Open();
                    var data = conn.QuerySingle<GuestBook>(insert, new { Id = id });
                    return View(data);
                }
            }
            catch (Exception ex)
            {
                return View();
            }
            return View();
        }

        // POST: GuestBook/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            try
            {
                using (System.Data.IDbConnection conn = new SqlConnection(connectionString))
                {

                    string insert = "UPDATE  dbo.MvcGuestBook" +
                                    " SET Name = @Name," +
                                    "        Email = @Email," +
                                    "        Abstract = @Abstract" +
                                    " WHERE Id = @Id; ";
                    conn.Open();
                    conn.Execute(insert, new GuestBook()
                    {
                        Id = Convert.ToInt16( collection.Get("Id")),
                        Name = collection.Get("Name"),
                        Abstract = collection.Get("Abstract"),
                        Email = collection.Get("Email")
                    });
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: GuestBook/Delete/5
        public ActionResult Delete(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            try
            {
                using (System.Data.IDbConnection conn = new SqlConnection(connectionString))
                {

                    string insert = "DELETE FROM dbo.MvcGuestBook WHERE Id=@Id;";
                    conn.Open();
                    conn.Execute(insert, new
                    {
                        Id = id
                    });
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // POST: GuestBook/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
}
