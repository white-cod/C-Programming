using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;

class Program
{
    static async Task Main(string[] args)
    {
        var httpClient = new HttpClient();
        var html = await httpClient.GetStringAsync("https://sneakerhead.ru/shoes/sneakers/dunk-low-fj5429-133/");
        var doc = new HtmlDocument();
        doc.LoadHtml(html);

        // Product Name
        var productNameNode = doc.DocumentNode.SelectSingleNode("//h1[@class='product__title']");
        var productName = productNameNode?.InnerText.Trim();

        // Brand Name
        string brandName = "";
        var brandNode = productNameNode.SelectSingleNode(".//a[@class='product__link']");
        if (brandNode != null)
        {
            brandName = brandNode.InnerText.Trim();
        }

        // Article
        var articleNode = doc.DocumentNode.SelectSingleNode("//span[@class='text-uppercase']");
        var article = articleNode?.InnerText.Trim();

        // Price
        var priceNode = doc.DocumentNode.SelectSingleNode("//span[@class='product__price-value']");
        var price = priceNode?.InnerText.Trim();
        if (price != null)
        {
            // Decode HTML entities
            price = System.Web.HttpUtility.HtmlDecode(price);
        }

        // Size Parameters
        var size1 = "40";
        var size2 = "41";
        var size3 = "42";

        // Season
        var season = "Лето";

        // Description
        var descriptionNode = doc.DocumentNode.SelectSingleNode("//div[@class='accordion__content-inner']");
        var description = descriptionNode?.InnerText.Trim();

        // Additional Properties
        var additionalProperties = doc.DocumentNode.SelectNodes("//span[@itemprop='value']");
        var propertyValues = new List<string>();

        if (additionalProperties != null)
        {
            foreach (var propertyNode in additionalProperties)
            {
                propertyValues.Add(propertyNode.InnerText.Trim());
            }
        }

        // Image URLs
        var imageUrls = new List<string>();
        var imageNodes = doc.DocumentNode.SelectNodes("//a[@class='product__images-link']");
        if (imageNodes != null)
        {
            foreach (var imageNode in imageNodes)
            {
                var imageUrlRelative = imageNode.GetAttributeValue("href", "");
                var imageUrlFull = "https://sneakerhead.ru" + imageUrlRelative;
                imageUrls.Add(imageUrlFull);
            }
        }

        // Output the extracted information
        Console.WriteLine($"Product Name: {productName}");
        Console.WriteLine($"Brand Name: {brandName}");
        Console.WriteLine($"Article: {article}");
        Console.WriteLine($"Price: {price}");
        Console.WriteLine($"Size1: {size1}");
        Console.WriteLine($"Size2: {size2}");
        Console.WriteLine($"Size3: {size3}");
        Console.WriteLine($"Season: {season}");
        Console.WriteLine($"Description: {description}");
        Console.WriteLine($"Gender: {propertyValues[0]}");
        Console.WriteLine($"Color: {propertyValues[1]}");
        Console.WriteLine($"Country: {propertyValues[2]}");
        Console.WriteLine($"Composition: {propertyValues[3]}");

        Console.WriteLine("Image URLs:");
        foreach (var imageUrl in imageUrls)
        {
            Console.WriteLine(imageUrl);
        }
    }
}