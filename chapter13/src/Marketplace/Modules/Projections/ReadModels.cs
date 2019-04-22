using System;
using System.Collections.Generic;

namespace Marketplace.Modules.Projections
{
    public static class ReadModels
    {
        public class ClassifiedAdDetails
        {
            public string Id { get; set; }
            public string Title { get; set; }
            public decimal Price { get; set; }
            public string CurrencyCode { get; set; }
            public string Description { get; set; }
            public Guid SellerId { get; set; }
            public string SellersDisplayName { get; set; }
            public string SellersPhotoUrl { get; set; }
            public List<string> PhotoUrls { get; set; }
                = new List<string>();

            public static string GetDatabaseId(Guid id)
                => $"ClassifiedAdDetails/{id}";
        }

        public class UserDetails
        {
            public string Id { get; set; }
            public string DisplayName { get; set; }
            public string FullName { get; set; }
            public string PhotoUrl { get; set; }

            public static string GetDatabaseId(Guid id) => $"UserDetails/{id}";
        }

        public class MyClassifiedAds
        {
            public string Id { get; set; }
            public List<MyAd> MyAds { get; set; }

            public class MyAd
            {
                public Guid Id { get; set; }
                public string Title { get; set; }
                public decimal Price { get; set; }
                public string Description { get; set; }
                public string Status { get; set; }
                public List<string> PhotoUrls { get; set; }
                    = new List<string>();
            }

            public static string GetDatabaseId(Guid id)
                => $"MyClassifiedAds/{id}";
        }
    }
}