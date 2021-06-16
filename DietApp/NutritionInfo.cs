namespace DietApp
{
    public class NutritionInfo
    {
        private readonly double _totalCalories;
        private readonly string _foodname, _foodtype;
        private readonly double _calories, _fat, _protein, _carbohydrates, _carbs;

        public NutritionInfo(double totalCalories)
        {
            _totalCalories = totalCalories;
        } 
        public NutritionInfo(string foodname, string foodtype, double calories, double fat, double protein, double carbohydrates,
            double carbs)
        {
            _foodname = foodname;
            _foodtype = foodtype;
            _calories = calories;
            _fat = fat;
            _protein = protein;
            _carbohydrates = carbohydrates;
            _carbs = carbs;
        }
        
        // Getters
        public string GetFoodName() { return _foodname; }
        public string GetFoodType() { return _foodtype; }
        public double GetCalories() { return _calories; }
        public double GetFat() { return _fat; }
        public double GetProtein() { return _protein; }
        public double GetCarbohydrates() { return _carbohydrates; }
        public double GetCarbs() { return _carbs; }
        public double GetTotalCalories() { return _totalCalories; }
        
    }
}