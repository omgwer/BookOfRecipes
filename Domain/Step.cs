﻿namespace Domain
{
    public class Step
    {
        public int Id { get; set; } // dbContext
        public int RecipeId { get; set; } // dbContext
        public int Order { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
