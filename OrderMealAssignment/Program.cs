using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMealAssignment
{
    internal class Program
    {
        class Meals
        {
            private string _mealType;
            private Dictionary<string, string> _parts = new Dictionary<string, string>();
            public Meals(string mealType)
            {
                this._mealType = mealType;
            }

            public string this[string key]
            {
                get { return _parts[key]; }
                set { _parts[key] = value; }
            }

            public void Show()
            {
                Console.WriteLine("--------------------------");
                Console.WriteLine("Meal type: {0}", _mealType);
                Console.WriteLine("Burger : {0} ", _parts["burger"]);
                Console.WriteLine("Drink : {0} ", _parts["shakes"]);
                Console.WriteLine("Deserts : {0} ", _parts["deserts"]);
                Console.WriteLine("Toys : {0} ", _parts["toys"]);
            }
        }
        abstract class MealBuilder
        {
            protected Meals meal;

            public Meals Meals { get { return meal; } }

            //Abstract build methods
            public abstract void BuildBurger();
            public abstract void BuildShakes();
            public abstract void BuildDeserts();
            public abstract void BuildToys();
        }

        class KidsMealBuilder : MealBuilder
        {
            public KidsMealBuilder()
            {
                meal = new Meals("Kids Meals");
            }

            public override void BuildBurger()
            {
                meal["burger"] = "cheese Burger";
            }

            public override void BuildShakes()
            {
                meal["shakes"] = "Chocolate Shake";
            }

            public override void BuildDeserts()
            {
                meal["deserts"] = "Donuts";
            }

            public override void BuildToys()
            {
                meal["toys"] = "Car";
            }
        }

        class ValuePackBuilder : MealBuilder
        {
            public ValuePackBuilder()
            {
                meal = new Meals("Value Pack");
            }

            public override void BuildBurger()
            {
                meal["burger"] = "Chicken Burger";
            }

            public override void BuildShakes()
            {
                meal["shakes"] = "Milk Shake";
            }

            public override void BuildDeserts()
            {
                meal["deserts"] = "Cool Cake";
            }

            public override void BuildToys()
            {
                meal["toys"] = "Bike";
            }
        }

        class AllinOneBuilder : MealBuilder
        {
            public AllinOneBuilder()
            {
                meal = new Meals("All in one Pack");
            }

            public override void BuildBurger()
            {
                meal["burger"] = "Double Ham and Chicken Burger";
            }

            public override void BuildShakes()
            {
                meal["shakes"] = "Cold Coffee and Strawberry Shake";
            }

            public override void BuildDeserts()
            {
                meal["deserts"] = "Donuts and brownies";
            }

            public override void BuildToys()
            {
                meal["toys"] = "Car and bike";
            }
        }

        class Order
        {
            public void Construct(MealBuilder mealBuilder)
            {
                mealBuilder.BuildBurger();
                mealBuilder.BuildShakes();
                mealBuilder.BuildDeserts();
                mealBuilder.BuildToys();
            }
        }
        static void Main(string[] args)
        {
            MealBuilder builder;

            Order order = new Order();

            builder = new KidsMealBuilder();
            order.Construct(builder);
            builder.Meals.Show();

            builder = new ValuePackBuilder();
            order.Construct(builder);
            builder.Meals.Show();

            builder = new AllinOneBuilder();
            order.Construct(builder);
            builder.Meals.Show();

            Console.ReadKey();
        }
    }
}
