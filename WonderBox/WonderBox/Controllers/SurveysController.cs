using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WonderBox.Models;

namespace WonderBox.Controllers
{
    public class SurveysController : Controller
    {
        private MasterBoxDBContext db = new MasterBoxDBContext();
        Random GiftChances = new Random();
        People people = new People();

        public int Answer1;
        public int Answer2;
        public int Answer3;
        public int Answer4;
        public int Answer5;
        public int Answer6;
        public string SumOfAnswers;
        public List<Item> ListOfGifts;
        

        // GET: Surveys
        public ActionResult Index()
        {
            return View(db.Surveys.ToList());
        }

        public ActionResult ProfileView()
        {
            return View(db.People);
        }

        // GET: Surveys/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Survey survey = db.Surveys.Find(id);
            if (survey == null)
            {
                return HttpNotFound();
            }
            return View(survey);
        }

        // GET: Surveys/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Surveys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Question1,Question2,Question3,Question4,Question5,Question6")] Survey survey)
        {
            if (ModelState.IsValid)
            {
                db.Surveys.Add(survey);
                db.SaveChanges();
                MatchSubscription(survey.ID);
                BoxAlgorithm();
                ItemSixToBox();
                ItemOneToBox();
                ItemTwoToBox();
                ItemThreeToBox();
                ItemForthToBox();
                ItemFifthToBox();
                return RedirectToAction("Index");
                
            }

            return View(people);
        }

        // GET: Surveys/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Survey survey = db.Surveys.Find(id);
            if (survey == null)
            {
                return HttpNotFound();
            }
            return View(survey);
        }
        
        // POST: Surveys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Question1,Question2,Question3,Question4,Question5,Question6")] Survey survey)
        {
            if (ModelState.IsValid)
            {
                db.Entry(survey).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(survey);
        }

        // GET: Surveys/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Survey survey = db.Surveys.Find(id);
            if (survey == null)
            {
                return HttpNotFound();
            }
            return View(survey);
        }

        // POST: Surveys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Survey survey = db.Surveys.Find(id);
            db.Surveys.Remove(survey);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public void MatchSubscription(int id)
        {
            Survey survey = db.Surveys.Find(id);
            this.Answer1 = Int32.Parse(survey.Question1);
            this.Answer2 = Int32.Parse(survey.Question2);
            this.Answer3 = Int32.Parse(survey.Question3);
            this.Answer4 = Int32.Parse(survey.Question4);
            this.Answer5 = Int32.Parse(survey.Question5);
            this.Answer6 = Int32.Parse(survey.Question6);
            
        }

        public void BoxAlgorithm()
        {
            int sum = this.Answer1 + this.Answer2 + this.Answer3 + this.Answer4 + this.Answer5 + Answer6;
            this.SumOfAnswers = sum.ToString();
        }

        public void decrementItemsFromDB(string paramString)
        {
            string stringToCompare = paramString;
            var query = db.Items.Where(ru => ru.Name == stringToCompare).Single();
            int GGQuantitiy = query.Quantity;
            query.Quantity--;
            db.SaveChanges();
        }


        public void ItemSixToBox()
        {
            char sixthItem = this.SumOfAnswers[0];
            if (sixthItem == '3')
            {
                decrementItemsFromDB("Fireball");

            }
            else if (sixthItem == '4')
            {
                decrementItemsFromDB("Gray Goose");
            }
            else if (sixthItem == '5')
            {
                decrementItemsFromDB("Everclear");
            }
        }

        public void ItemOneToBox()
        {
            char firstItem = this.SumOfAnswers[1];
            if (firstItem == '1')
            {
               int randomInt = GiftChances.Next(0, 100);
                if (randomInt >= 50)
                {
                    decrementItemsFromDB("Olive Garden Gift Card");
                }
                else
                {
                    decrementItemsFromDB("Texas Roadhouse Gift Card");
                }
            }
            else if (firstItem == '2')
            {
                 decrementItemsFromDB("Starbucks Gift Card");
            }
        }

        public void ItemTwoToBox()
        {
            char secoundItem = this.SumOfAnswers[2];
            if (secoundItem == '5')
            {
                int randomInt = GiftChances.Next(0, 100);
                if (randomInt >= 50)
                {
                    decrementItemsFromDB("PredAlien - ActionFigure");
                }
                else
                {
                    decrementItemsFromDB("The Marionette - ActionFigure");
                }
            }
            else if (secoundItem == '4')
            {
                {
                    int randomInt = GiftChances.Next(0, 100);
                    if (randomInt >= 50)
                    {
                        decrementItemsFromDB("The Notebook - Blu-ray");
                    }
                    else
                    {
                        decrementItemsFromDB("Requiem for a Dream - Blu-ray");
                    }
                }
            }
        }

        public void ItemThreeToBox()
        {
            char thirdItem = this.SumOfAnswers[3];
            if (thirdItem == '9')
            {
                decrementItemsFromDB("Skrillex - Bangarang");
                decrementItemsFromDB("The Living Tombstone");
            }
            else if (thirdItem == '7')
            {
                decrementItemsFromDB("Linkin Park - Meteora");
            }
            else if (thirdItem == '5')
            {
                decrementItemsFromDB("Apocolptica - Cult");
            }
            else if (thirdItem == '3')
            {
                decrementItemsFromDB("Parov Stelar - Coco");
            }
        }

        public void ItemForthToBox()
        {
            char forthItem = SumOfAnswers[4];
            if(forthItem == '8')
            {
                decrementItemsFromDB("PlayStation Plus Membership");
            }
            else if (forthItem == '6')
            {
                decrementItemsFromDB("Xbox Live Membership");
            }
            else if (forthItem == '4')
            {
                decrementItemsFromDB("Steam Gift Card");
            }
        }

        public void ItemFifthToBox()
        {
            char fifthItem = SumOfAnswers[5];
            if (fifthItem == '6')
            {
                decrementItemsFromDB("Flash - Season 1");
            }

            else if (fifthItem == '5')
            {
                decrementItemsFromDB("Venom - Hoodie");
            }
        }
    }
}
