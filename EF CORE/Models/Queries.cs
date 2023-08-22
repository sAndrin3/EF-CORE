using System;
using System.Linq;
using System.Linq.Expressions;

namespace EF_CORE{
    public class Queries {
        private ApplicationDBContext context = new ApplicationDBContext();

        //inserting
        public void AddNewTour() {
            var newTour = new Tour(){
                description = "Vintage Riders",
                duration = "1 day",
                title = "Back in time",
                price = 1200
            };

            //Adding to a table
            context.Tours.Add(newTour);

            context.SaveChanges();

        }

        //Fetching
        public void fetchAllTours(){
            var tours = context.Tours.ToList();

            foreach (var tour in tours)
            {
              System.Console.WriteLine($"{tour.title}--{tour.description}--{tour.duration}");   
            }
        }

        // fetch one tour
        public void fetchOne( ){
            var tours = context.Tours.Where(t=>t.price>2000).ToList();
            foreach (var tour in tours)
            {
                System.Console.WriteLine($"{tour.title}--{tour.description}--{tour.duration}--{tour.price}");
            }
        
        }

        public void fetchAndOrder( ){
            var tours = context.Tours.Where(t=>t.price>2000).OrderByDescending(c=>c.duration).ThenByDescending(c=>c.price).ToList();
            foreach (var tour in tours)
            {
                System.Console.WriteLine($"{tour.title}--{tour.description}--{tour.duration}--{tour.price}");
            }
        }

         public void updateTours(int id ){
            Tour tour = (Tour) context.Tours.Find(id);
            if (tour != null)
            {
                tour.title = "Mazda fanatics";
                tour.description = "Zoom Zoom";
            }
            else
            {
                return;
            }
            

            context.SaveChanges();

            var tours = context.Tours.ToList();
            foreach (var tour1 in tours)
            {
                System.Console.WriteLine($"{tour1.title}--{tour1.description}--{tour1.duration}--{tour1.price}");
            }
        }
        public void deleteTours(int id){
            try
            {
                Tour tour = context.Tours.Find(id);

                if (tour != null)
                {
                    context.Tours.Remove(tour);
                    context.SaveChanges();

                    var tours = context.Tours.ToList();
                    foreach (var tour1 in tours)
                    {
                        System.Console.WriteLine($"{tour1.title}--{tour1.description}--{tour1.duration}--{tour1.price}");
                    }
                        var sum = context.Tours.Sum(x=>x.price);
            System.Console.WriteLine(sum);

            var count = context.Tours.Count();
            System.Console.WriteLine(count);
                }
                }catch(Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
            public void toursAnalytics() {
            var sum = context.Tours.Sum(x => x.price);
            System.Console.WriteLine(sum);

            var count = context.Tours.Count();
            System.Console.WriteLine(count);

            var average = context.Tours.Average(x => x.price);
            System.Console.WriteLine(average);

            // var count = context.Tours.Count();
            // System.Console.WriteLine(count);
        }
           
        }
    }
