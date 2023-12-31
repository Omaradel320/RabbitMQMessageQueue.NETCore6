﻿namespace RabbitMqProductAPI.Dtos;

public class ProductDto
{
    public int Id { get; set; }
    public string ProductName { get; set; }
    public string ProductDescription { get; set; }
    public double ProductPrice { get; set; }
    public int ProductStock { get; set; }
    public bool IsDeleted { get; set; }
}