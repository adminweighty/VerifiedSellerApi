﻿namespace VerifiedSeller.Shared.Entities.Database
{
    public class Products
    {
        public int productId { get; set; }
        public string productName { get; set; }
        public string productCode { get; set; }
        public int productCurrency { get; set; }
        public double productPrice { get; set; }
        public double productRetailPrice { get; set; }
        public string productPriceDescription { get; set; }
        public double productDiscount { get; set; }
        public string productBrand { get; set; }
        public DateTime productLastUpdated { get; set; }
        public DateTime productManufacturerDate { get; set; }
        public DateTime productExpiryDate { get; set; }
        public string productBarCode { get; set; }
        public double productUnit { get; set; }
        public double productWeight { get; set; }
        public double productHeight { get; set; }
        public double productHeightUnit { get; set; }
        public double productQuantity { get; set; }
        public string productColor { get; set; }
        public int sellerId { get; set; }
        public int categoryId { get; set; }
        public string featureImageUrl { get; set; }
        public string featureImageUrl_1 { get; set; }
        public string featureImageUrl_2 { get; set; }
        public string featureImageUrl_3 { get; set; }
        public string featureImageUrl_4 { get; set; }
        public string featureImageUrl_5 { get; set; }
        public int status { get; set; }

    }
}
