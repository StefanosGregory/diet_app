namespace DietApp
{
    public class NutritionInfo
    {
        private readonly string _name, _type;
        private readonly double _calories, _fat, _protein, _carbohydrates, _carbs;

        //public 
        public NutritionInfo(string name, string type, double calories, double fat, double protein, double carbohydrates,
            double carbs)
        {
            _name = name;
            _type = type;
            _calories = calories;
            _fat = fat;
            _protein = protein;
            _carbohydrates = carbohydrates;
            _carbs = carbs;
        }
        
        // Getters
        public string getName() { return _name; }
        public string getType() { return _type; }
        public double getCalories() { return _calories; }
        public double getFat() { return _fat; }
        public double getProtein() { return _protein; }
        public double getCarbohydrates() { return _carbohydrates; }
        public double getCarbs() { return _carbs; }

        // Maybe method to calculate calories.
    }
}