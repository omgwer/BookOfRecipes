﻿namespace Domain
{
    public class Tag
    {
        public int Id { get; set; }  //dbContext
        public string Name { get; set; } = string.Empty;
        public int RecipeId { get; set; }
    }
}
