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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void ParseHTML_Click(object sender, RoutedEventArgs e)
        {
            string url = urlTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(url))
            {
                MessageBox.Show("Please enter a valid URL.");
                return;
            }

            try
            {
                await SneakersParser.ParseAndWriteToTextFile(url);
                resultTextBox.Text = "Data has been successfully parsed and written to the text file.";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }

            try
            {
                var httpClient = new HttpClient();
                var html = await httpClient.GetStringAsync(url);
                var doc = new HtmlAgilityPack.HtmlDocument();
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
                    price = price.Replace(" ", "");
                    price = System.Web.HttpUtility.HtmlDecode(price);
                }

                // Size Parameters
                var size1 = "40";
                var size2 = "41";
                var size3 = "42";

                // Season
                var season = "Зима"; 

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

                // Displaying the result
                resultTextBox.Text = $"Product Name: {productName}\nBrand Name: {brandName}\nArticle: {article}\nPrice: {price}\nSize1: {size1}\nSize2: " +
                    $"{size2}\nSize3: {size3}\nSeason: {season}\nDescription: {description}\nGender: {propertyValues[0]}\nColor: {propertyValues[1]}" +
                    $"\nCountry: {propertyValues[2]}\nComposition: {propertyValues[3]}\n";

                resultTextBox.Text += "Image URLs:\n";
                for (int i = 0; i < imageUrls.Count; i++)
                {
                    resultTextBox.Text += $"Image {i + 1}: {imageUrls[i]}\n";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }
}