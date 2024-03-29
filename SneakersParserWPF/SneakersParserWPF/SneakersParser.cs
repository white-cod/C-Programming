using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using HtmlAgilityPack;
using System.Diagnostics;
using System.IO;

namespace SneakersParserWPF
{
    public static class SneakersParser
    {
        public static async Task ParseAndWriteToTextFile(string url)
        {
            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);
            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            string productName = ExtractProductName(doc);
            string brandName = ExtractBrandName(doc);
            string article = ExtractArticle(doc);
            string price = ExtractPrice(doc);
            string size1 = "40";
            string size2 = "41";
            string size3 = "42";
            string season = "Зима";
            string description = ExtractDescription(doc);
            List<string> propertyValues = ExtractPropertyValues(doc);
            List<string> imageUrls = ExtractImageUrls(doc);

            string insertQuery = GenerateInsertQuery(productName, brandName, article, price, size1, size2, size3, season, description, propertyValues, imageUrls);

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = System.IO.Path.Combine(desktopPath, "shoes_inserts.txt");

            using (StreamWriter writer = File.AppendText(filePath))
            {
                writer.WriteLine(insertQuery);
            }

            Console.WriteLine("Insert query has been written to shoes_inserts.txt file on the desktop.");
        }

        private static string ExtractProductName(HtmlDocument doc)
        {
            var productNameNode = doc.DocumentNode.SelectSingleNode("//h1[@class='product__title']");
            return productNameNode?.InnerText.Trim();
        }

        private static string ExtractBrandName(HtmlDocument doc)
        {
            var productNameNode = doc.DocumentNode.SelectSingleNode("//h1[@class='product__title']");
            string brandName = "";
            var brandNode = productNameNode.SelectSingleNode(".//a[@class='product__link']");
            return brandNode.InnerText.Trim();
        }

        private static string ExtractArticle(HtmlDocument doc)
        {
            var articleNode = doc.DocumentNode.SelectSingleNode("//span[@class='text-uppercase']");
            return articleNode?.InnerText.Trim();
        }

        private static string ExtractPrice(HtmlDocument doc)
        {
            var priceNode = doc.DocumentNode.SelectSingleNode("//span[@class='product__price-value']");
            if (priceNode != null)
            {
                var price = priceNode.InnerText.Trim();
                price = price.Replace("&nbsp;", " ");
                price = new string(price.Where(char.IsDigit).ToArray());
                return price;
            }
            return null;
        }

        private static string ExtractDescription(HtmlDocument doc)
        {
            var descriptionNode = doc.DocumentNode.SelectSingleNode("//div[@class='accordion__content-inner']");
            return descriptionNode?.InnerText.Trim();
        }

        private static List<string> ExtractPropertyValues(HtmlDocument doc)
        {
            List<string> propertyValues = new List<string>();

            var additionalProperties = doc.DocumentNode.SelectNodes("//span[@itemprop='value']");
            if (additionalProperties != null)
            {
                foreach (var propertyNode in additionalProperties)
                {
                    propertyValues.Add(propertyNode.InnerText.Trim());
                }

                return propertyValues;
            }
            else
            {
                return null;
            }
        }

        private static List<string> ExtractImageUrls(HtmlDocument doc)
        {
            List<string> imageUrls = new List<string>();

            var imageNodes = doc.DocumentNode.SelectNodes("//a[@class='product__images-link']");
            if (imageNodes != null)
            {
                foreach (var imageNode in imageNodes)
                {
                    var imageUrlRelative = imageNode.GetAttributeValue("href", "");
                    var imageUrlFull = "https://sneakerhead.ru" + imageUrlRelative;
                    imageUrls.Add(imageUrlFull);
                }

                return imageUrls;
            }
            else
            {
                return null;
            }
        }

        private static string GenerateInsertQuery(string productName, string brandName, string article, string price, string size1, string size2, string size3, string season, string description, List<string> propertyValues, List<string> imageUrls)
        {
            productName ??= "";
            brandName ??= "";
            article ??= "";
            price ??= "0";
            size1 ??= "";
            size2 ??= "";
            size3 ??= "";
            season ??= "";
            description ??= "";
            string gender = propertyValues?.Count > 0 ? propertyValues[0] : "";
            string color = propertyValues?.Count > 1 ? propertyValues[1] : "";
            string country = propertyValues?.Count > 2 ? propertyValues[2] : "";
            string composition = propertyValues?.Count > 3 ? propertyValues[3] : "";
            string[] imageColumns = new string[7];
            for (int i = 0; i < imageColumns.Length; i++)
            {
                if (i < imageUrls?.Count)
                {
                    imageColumns[i] = imageUrls[i];
                }
                else
                {
                    imageColumns[i] = "";
                }
            }

            string insertQuery = $"INSERT INTO shoes (product_name, brand_name, article, price, size1, size2, size3, season, description, gender, " +
                $"color, country, composition, image_url1, image_url2, image_url3, image_url4, image_url5, image_url6, image_url7) " +
                $"VALUES ('{productName}', '{brandName}', '{article}', '{price}', '{size1}', '{size2}', '{size3}', '{season}', '{description}'," +
                $" '{gender}', '{color}', '{country}', '{composition}', '{imageColumns[0]}', '{imageColumns[1]}', '{imageColumns[2]}', '{imageColumns[3]}', '{imageColumns[4]}', " +
                $"'{imageColumns[5]}', '{imageColumns[6]}');\n";

            return insertQuery;
        }

    }
}
