﻿namespace RabbitMqProductAPI.Dtos;

public class AddProductDto
{
    public string ProductName { get; set; } = null!;
    public string? ProductDescription { get; set; }
    public double ProductPrice { get; set; }
    public int ProductStock { get; set; }
}