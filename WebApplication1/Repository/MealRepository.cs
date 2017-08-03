﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;
using WebApplication1.Infrastructure;
using WebApplication1.DAL;
using System.Data.Entity;

namespace WebApplication1.Repository
{
    public class MealRepository : RepositoryBase<Meal>, IMealRepository 
    {
        public MealRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public Meal GetMealById(string name)
        {
            var meal = this.DbContext.Meals.Where(m => m.Name == name).FirstOrDefault();
            return meal;
        }

        public void AttachFoodToMeal(int mealId, int foodId)
        {
            var meal = this.DbContext.Meals.Find(mealId);
            var food = this.DbContext.Foods.Find(foodId);

            meal.Foods.Add(food);

        }




        
    }

    public interface IMealRepository : IRepository<Meal>
    {
        Meal GetMealById(string name);
    }
}