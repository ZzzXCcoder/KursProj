﻿namespace KursProj.Dtos
{
    public class ShowCourseLessonsDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int Order {  get; set; }
    }
}
