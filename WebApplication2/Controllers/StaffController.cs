using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models.Entity6;
using System.Data.Entity;

namespace WebApplication2.Controllers
{
    public class StaffController : Controller
    {
        // GET: Staff
        public ActionResult ViewAllCategories()
        {
            using (var bwCtx = new WebApplication2.EF.AsmContext())
            {
                var books = bwCtx.CategoryofCourse
                                 .OrderBy(b => b.Id)
                                 .ToList();
                return View(books);
            }
        }
        // GET: Staff
        public ActionResult Index()
        {
            using (var bwCtx = new WebApplication2.EF.AsmContext())
            {
                var books = bwCtx.Trainees
                                 .OrderBy(b => b.Id)
                                 .ToList();
                return View(books);
            }
        }
        public ActionResult ViewAllCat()
        {
            return View();
        }
        [HttpGet]
        public ActionResult CreateTrainee()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateTrainee(Trainees newTrainee)
        {
            if (!ModelState.IsValid)
            {
                return View(newTrainee);
            }
            else
            {
                using (var bwCtx = new WebApplication2.EF.AsmContext())
                {
                    bwCtx.Trainees.Add(newTrainee);
                    bwCtx.SaveChanges();
                }

                TempData["message"] = $"Successfully insert a new book with Id: {newTrainee.Id}";
                return RedirectToAction("Index");
            }

        }
        [HttpGet]
        public ActionResult EditTrainee(int id)
        {
            using (var bwCtx = new WebApplication2.EF.AsmContext())
            {
                var book = bwCtx.Trainees.FirstOrDefault(b => b.Id == id);
                //ef method to select only one or null if not found

                if (book != null) // if a book is found, show edit view
                {
                    return View(book);
                }
                else // if no book is found, back to index
                {
                    return RedirectToAction("Index"); //redirect to action in the same controller
                }
            }
        }
        public ActionResult deleteTrainee(int id)
        {
            using (var bwCtx = new WebApplication2.EF.AsmContext())
            {
                var book = bwCtx.Trainees.FirstOrDefault(b => b.Id == id);
                if (book != null)
                {
                    bwCtx.Trainees.Remove(book);
                    bwCtx.SaveChanges();
                    TempData["message"] = $"Successfully delete book with Id: {book.Id}";
                }


                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public ActionResult EditTrainee(int id, Trainees newTrainee)
        {
            if (!ModelState.IsValid)
            {
                return View(newTrainee);
            }
            else
            {
                using (var bwCtx = new WebApplication2.EF.AsmContext())
                {
                    bwCtx.Entry<Trainees>(newTrainee).State
                        = System.Data.Entity.EntityState.Modified;

                    //add book to context and mark it as modified to do update, not insert

                    bwCtx.SaveChanges();
                }
                TempData["message"] = $"Successfully update book with Id: {newTrainee.Id}";
                return RedirectToAction("Index");
            }
        }
        //[HttpPost]
        //public ActionResult DeleteTrainee(int id)
        //{
        //    using (var bwCtx = new EF.FPTContext())
        //    {
        //        var book = bwCtx.Trainee.FirstOrDefault(b => b.Id == id);
        //        if (book != null) 
        //        {
        //            TempData["message"] = $"Successfully delete book with Id: {book.Id}";
        //            bwCtx.Trainee.Remove(book);
        //            bwCtx.SaveChanges();

        //        }


        //        return RedirectToAction("Index");
        //    }
        //}



        [HttpGet]
        public ActionResult CreateCategories()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCategories(CategoryofCourse newCategories)
        {
            if (!ModelState.IsValid)
            {
                return View(newCategories);
            }
            else
            {
                using (var bwCtx = new WebApplication2.EF.AsmContext())
                {
                    bwCtx.CategoryofCourse.Add(newCategories);
                    bwCtx.SaveChanges();
                }

                TempData["message"] = $"Successfully insert a new book with Id: {newCategories.Id}";
                return RedirectToAction("ViewAllCategories");
            }
        }
        [HttpGet]
        public ActionResult EditCategories(int id)
        {
            using (var bwCtx = new WebApplication2.EF.AsmContext())
            {
                var book = bwCtx.CategoryofCourse.FirstOrDefault(b => b.Id == id);
                //ef method to select only one or null if not found

                if (book != null) // if a book is found, show edit view
                {
                    return View(book);
                }
                else // if no book is found, back to index
                {
                    return RedirectToAction("ViewAllCategories"); //redirect to action in the same controller
                }
            }
        }
        [HttpPost]
        public ActionResult EditCategories(int id, CategoryofCourse newCategories)
        {
            if (!ModelState.IsValid)
            {
                return View(newCategories);
            }
            else
            {
                using (var bwCtx = new WebApplication2.EF.AsmContext())
                {
                    bwCtx.Entry<CategoryofCourse>(newCategories).State
                        = System.Data.Entity.EntityState.Modified;

                    //add book to context and mark it as modified to do update, not insert

                    bwCtx.SaveChanges();
                }
                TempData["message"] = $"Successfully update book with Id: {newCategories.Id}";
                return RedirectToAction("ViewAllCategories");
            }
        }

        public ActionResult DeleteCategories(int id)
        {
            using (var bwCtx = new WebApplication2.EF.AsmContext())
            {
                var book = bwCtx.CategoryofCourse.FirstOrDefault(b => b.Id == id);
                if (book != null)
                {
                    bwCtx.CategoryofCourse.Remove(book);
                    bwCtx.SaveChanges();
                    TempData["message"] = $"Successfully delete book with Id: {book.Id}";
                }


                return RedirectToAction("ViewAllCategories");
            }
        }
        public ActionResult ViewAllTrainer()
        {
            using (var bwCtx = new WebApplication2.EF.AsmContext())
            {
                var books = bwCtx.Trainner
                                 .OrderBy(b => b.Id)
                                 .ToList();
                return View(books);
            }
        }
        [HttpGet]
        public ActionResult CreateTrainer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateTrainer(Trainner newTrainer)
        {
            if (!ModelState.IsValid)
            {
                return View(newTrainer);
            }
            else
            {
                using (var bwCtx = new WebApplication2.EF.AsmContext())
                {
                    bwCtx.Trainner.Add(newTrainer);
                    bwCtx.SaveChanges();
                }

                TempData["message"] = $"Successfully insert a new book with Id: {newTrainer.Id}";
                return RedirectToAction("ViewAllTrainer");
            }
        }
        [HttpGet]
        public ActionResult EditTrainer(int id)
        {
            using (var bwCtx = new WebApplication2.EF.AsmContext())
            {
                var book = bwCtx.Trainner.FirstOrDefault(b => b.Id == id);
                //ef method to select only one or null if not found

                if (book != null) // if a book is found, show edit view
                {
                    return View(book);
                }
                else // if no book is found, back to index
                {
                    return RedirectToAction("ViewAllTrainer"); //redirect to action in the same controller
                }
            }
        }
        [HttpPost]
        public ActionResult EditTrainer(int id, Trainner newTrainer)
        {
            if (!ModelState.IsValid)
            {
                return View(newTrainer);
            }
            else
            {
                using (var bwCtx = new WebApplication2.EF.AsmContext())
                {
                    bwCtx.Entry<Trainner>(newTrainer).State
                        = System.Data.Entity.EntityState.Modified;
                    bwCtx.SaveChanges();
                }
                TempData["message"] = $"Successfully update book with Id: {newTrainer.Id}";
                return RedirectToAction("ViewAllTrainer");
            }
        }

        public ActionResult DeleteTrainer(int id)
        {
            using (var bwCtx = new WebApplication2.EF.AsmContext())
            {
                var book = bwCtx.Trainner.FirstOrDefault(b => b.Id == id);
                if (book != null)
                {
                    bwCtx.Trainner.Remove(book);
                    bwCtx.SaveChanges();
                    TempData["message"] = $"Successfully delete book with Id: {book.Id}";
                }


                return RedirectToAction("ViewAllTrainer");
            }
        }
        private void PrepareViewBagT()
        {
            using (var bwCtx = new WebApplication2.EF.AsmContext())
            {
                //ViewBag.Course = bwCtx.Course
                //                      .Select(p => new SelectListItem
                //                      {
                //                          Text = p.Name,
                //                          Value = p.Id.ToString()
                //                      })
                //                      .ToList();

                ViewBag.Trainer = bwCtx.Trainner.ToList();
            }
        }
        public ActionResult ViewAllCourse()
        {

            using (var bwCtx = new WebApplication2.EF.AsmContext())
            {
                var books = bwCtx.Course
                                 .OrderBy(b => b.Id)
                                 .ToList();
                return View(books);
            }

        }
        private void PrepareViewBagS()
        {
            using (var bwCtx = new WebApplication2.EF.AsmContext())
            {
                //ViewBag.Class = bwCtx.Course
                //                      .Select(p => new SelectListItem
                //                      {
                //                          Text = p.Name,
                //                          Value = p.Id.ToString()
                //                      })
                //                      .ToList();

                ViewBag.Trainee = bwCtx.Trainees.ToList();
            }
        }
        private List<SelectListItem> GetCategoryDropDown()
        {
            using (var bwCtx = new WebApplication2.EF.AsmContext())
            {
                var categories = bwCtx.CategoryofCourse
                                 .Select(p => new SelectListItem
                                 {
                                     Text = p.Name,
                                     Value = p.Id.ToString()
                                 }).ToList();
                return categories;
            }
        }
        private List<Trainner> LoadFormatsT(WebApplication2.EF.AsmContext bwCtx, string formatIds)
        {
            var selectedFIds = formatIds.Split(',')
                                        .Select(id => Int32.Parse(id))
                                        .ToArray();
            return bwCtx.Trainner.Where(f => selectedFIds.Contains(f.Id)).ToList();

        }
        private List<Trainees> LoadFormatsS(WebApplication2.EF.AsmContext bwCtx, string formatIds)
        {
            var selectedFIds = formatIds.Split(',')
                                        .Select(id => Int32.Parse(id))
                                        .ToArray();
            return bwCtx.Trainees.Where(f => selectedFIds.Contains(f.Id)).ToList();

        }
        [HttpGet]
        public ActionResult CreateCourse()
        {
            PrepareViewBagT();
            PrepareViewBagS();
            ViewBag.Categories = GetCategoryDropDown();
            return View();
        }
        [HttpPost]
        public ActionResult CreateCourse(Course newCourse, FormCollection fc, FormCollection fs)
        {
            ViewBag.Categories = GetCategoryDropDown();
            if (!ModelState.IsValid)
            {

                TempData["trainerIds"] = fc["trainerIds[]"];
                TempData["traineeIds"] = fs["traineeIds[]"];
                PrepareViewBagS();
                PrepareViewBagT();
                return View(newCourse);
            }
            else
            {
                using (var bwCtx = new WebApplication2.EF.AsmContext())
                {
                    newCourse.Trainer = LoadFormatsT(bwCtx, fc["trainerIds[]"]);
                    newCourse.Trainee = LoadFormatsS(bwCtx, fs["traineeIds[]"]);
                    bwCtx.Course.Add(newCourse);
                    bwCtx.SaveChanges();
                }

                TempData["message"] = $"Successfully insert a new book with Id: {newCourse.Id}";
                return RedirectToAction("ViewAllCourse");
            }
        }
        [HttpGet]
        public ActionResult EditCourse(int id)
        {
            using (var bwCtx = new WebApplication2.EF.AsmContext())
            {
                ViewBag.Categories = GetCategoryDropDown();
                var teacher = bwCtx.Course
                    .Include(b => b.Trainer)
                    .FirstOrDefault(b => b.Id == id);


                var student = bwCtx.Course
                    .Include(b => b.Trainee)
                    .FirstOrDefault(b => b.Id == id);

                if (teacher != null && student != null) // if a book is found, show edit view
                {
                    PrepareViewBagT();
                    PrepareViewBagS();
                    return View(teacher);
                }
                else // if no book is found, back to index
                {
                    return RedirectToAction("ViewAllCourse"); //redirect to action in the same controller
                }
            }
        }
        [HttpPost]
        public ActionResult EditCourse(int id, Course newCourse, FormCollection fc, FormCollection fs)
        {
            ViewBag.Categories = GetCategoryDropDown();
            if (!ModelState.IsValid)
            {
                TempData["trainerIds"] = fc["trainerIds[]"];
                TempData["traineeIds"] = fs["traineeIds[]"];
                PrepareViewBagS();
                PrepareViewBagT();
                return View(newCourse);
            }
            else
            {

                using (var bwCtx = new WebApplication2.EF.AsmContext())
                {
                    bwCtx.Entry<Course>(newCourse).State
                        = System.Data.Entity.EntityState.Modified;
                    bwCtx.Entry<Course>(newCourse).Collection(b => b.Trainer).Load();
                    bwCtx.Entry<Course>(newCourse).Collection(b => b.Trainee).Load();

                    newCourse.Trainer = LoadFormatsT(bwCtx, fc["trainerIds[]"]);
                    newCourse.Trainee = LoadFormatsS(bwCtx, fc["traineeIds[]"]);
                    //add book to context and mark it as modified to do update, not insert

                    bwCtx.SaveChanges();
                }
                TempData["message"] = $"Successfully update book with Id: {newCourse.Id}";

                return RedirectToAction("ViewAllCourse");
            }
        }
        [HttpPost]
        public ActionResult DeleteCourse(int id)
        {
            using (var bwCtx = new WebApplication2.EF.AsmContext())
            {
                var book = bwCtx.Course.FirstOrDefault(b => b.Id == id);
                if (book != null)
                {
                    bwCtx.Course.Remove(book);
                    bwCtx.SaveChanges();
                    TempData["message"] = $"Successfully delete book with Id: {book.Id}";
                }


                return RedirectToAction("ViewAllCourse");
            }
        }
    }
}