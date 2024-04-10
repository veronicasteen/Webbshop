using Webbshop.Models;

namespace Webbshop.Data
{
    public class SampleData
    {
        public static void Create(AppDbContext database)
        {
            // If there are no fake accounts, add some.
            string fakeIssuer = "https://example.com";
            if (!database.Accounts.Any(a => a.OpenIDIssuer == fakeIssuer))
            {
                database.Accounts.Add(new Account
                {
                    OpenIDIssuer = fakeIssuer,
                    OpenIDSubject = "1111111111",
                    Name = "Brad"
                });
                database.Accounts.Add(new Account
                {
                    OpenIDIssuer = fakeIssuer,
                    OpenIDSubject = "2222222222",
                    Name = "Angelina"
                });
                database.Accounts.Add(new Account
                {
                    OpenIDIssuer = fakeIssuer,
                    OpenIDSubject = "3333333333",
                    Name = "Will"
                });
            }

            if (!database.Products.Any())
            {
                database.Products.Add(new Product
                {
                    Name = "Smartphone X",
                    Description = "The latest model of our flagship smartphone series, featuring advanced technology and sleek design.",
                    Price = 999.99,
                    ImagePath = "smartphone_x.jpg",
                    Category = "Electronics"
                });

                database.Products.Add(new Product
                {
                    Name = "Wireless Headphones Pro",
                    Description = "High-quality wireless headphones with noise-cancellation technology for an immersive listening experience.",
                    Price = 149.99,
                    ImagePath = "wireless_headphones_pro.jpg",
                    Category = "Electronics"
                });

                database.Products.Add(new Product
                {
                    Name = "Organic Green Tea",
                    Description = "Premium organic green tea leaves sourced from sustainable farms, known for their refreshing taste and health benefits.",
                    Price = 9.99,
                    ImagePath = "organic_green_tea.jpg",
                    Category = "Health"

                });

                database.Products.Add(new Product
                {
                    Name = "Laptop Ultra",
                    Description = "Powerful laptop with cutting-edge specifications, perfect for work and entertainment.",
                    Price = 1299.99,
                    ImagePath = "laptop_ultra.jpg",
                    Category = "Electronics"
                });

                database.Products.Add(new Product
                {
                    Name = "Running Shoes Elite",
                    Description = "Top-of-the-line running shoes designed for maximum performance and comfort.",
                    Price = 89.99,
                    ImagePath = "running_shoes_elite.jpg",
                    Category = "Health"
                });

                database.Products.Add(new Product
                {
                    Name = "Wireless Charging Pad",
                    Description = "Convenient wireless charging pad compatible with a wide range of devices.",
                    Price = 29.99,
                    ImagePath = "wireless_charging_pad.jpg",
                    Category = "Electronics"
                });

                database.Products.Add(new Product
                {
                    Name = "Organic Dark Chocolate",
                    Description = "Indulge in the rich flavor of organic dark chocolate, made from premium cocoa beans.",
                    Price = 5.99,
                    ImagePath = "organic_dark_chocolate.jpg",
                    Category = "Food and beverage"
                });

                database.Products.Add(new Product
                {
                    Name = "Digital Camera Pro",
                    Description = "Professional-grade digital camera with advanced features for capturing stunning photographs and videos.",
                    Price = 799.99,
                    ImagePath = "digital_camera_pro.jpg",
                    Category = "Electronics"
                });

                database.Products.Add(new Product
                {
                    Name = "Yoga Mat Premium",
                    Description = "High-quality yoga mat designed for optimal grip and comfort during yoga practice.",
                    Price = 49.99,
                    ImagePath = "yoga_mat_premium.jpg",
                    Category = "Health"
                });

                database.Products.Add(new Product
                {
                    Name = "Stainless Steel Water Bottle",
                    Description = "Durable stainless steel water bottle, perfect for staying hydrated on the go.",
                    Price = 19.99,
                    ImagePath = "stainless_steel_water_bottle.jpg",
                    Category = "Outdoors"
                });

                database.Products.Add(new Product
                {
                    Name = "Bluetooth Speaker Portable",
                    Description = "Compact and portable Bluetooth speaker with impressive sound quality for music lovers.",
                    Price = 79.99,
                    ImagePath = "bluetooth_speaker_portable.jpg",
                    Category = "Electronics"
                });

                database.Products.Add(new Product
                {
                    Name = "Protein Powder",
                    Description = "High-quality protein powder to support muscle growth and recovery after workouts.",
                    Price = 29.99,
                    ImagePath = "protein_powder.jpg",
                    Category = "Health"
                });

                database.Products.Add(new Product
                {
                    Name = "Smart Watch Fitness Tracker",
                    Description = "Advanced smartwatch with fitness tracking features to monitor your daily activity and health goals.",
                    Price = 199.99,
                    ImagePath = "smart_watch_fitness_tracker.jpg",
                    Category = "Electronics"
                });

                database.Products.Add(new Product
                {
                    Name = "Soy Wax Scented Candles Set",
                    Description = "Set of soy wax scented candles in various fragrances to create a cozy atmosphere at home.",
                    Price = 39.99,
                    ImagePath = "scented_candles_set.jpg",
                    Category = "Indoors"
                });

                database.Products.Add(new Product
                {
                    Name = "Gaming Mouse RGB",
                    Description = "High-performance gaming mouse with customizable RGB lighting for an immersive gaming experience.",
                    Price = 49.99,
                    ImagePath = "gaming_mouse_rgb.jpg",
                    Category = "Electronics"
                });

                database.Products.Add(new Product
                {
                    Name = "Reusable Grocery Bag",
                    Description = "Reusable grocery bag made from eco-friendly materials to reduce plastic waste.",
                    Price = 14.99,
                    ImagePath = "grocery_bag.jpg",
                    Category = "Eco-friendly"
                });

                database.Products.Add(new Product
                {
                    Name = "HD LED TV",
                    Description = "Sleek and stylish HD LED TV with vibrant picture quality for an immersive viewing experience.",
                    Price = 699.99,
                    ImagePath = "hd_led_tv.jpg",
                    Category = "Electronics"
                });

                database.Products.Add(new Product
                {
                    Name = "Essential Oil Diffuser",
                    Description = "Aromatherapy essential oil diffuser to create a relaxing ambiance with soothing scents.",
                    Price = 34.99,
                    ImagePath = "essential_oil_diffuser.jpg",
                    Category = "Indoors"
                });

                database.Products.Add(new Product
                {
                    Name = "Electric Toothbrush Sonic",
                    Description = "Advanced electric toothbrush with sonic technology for superior plaque removal and gum care.",
                    Price = 59.99,
                    ImagePath = "electric_toothbrush_sonic.jpg",
                    Category = "Electronics"
                });

                database.Products.Add(new Product
                {
                    Name = "Camping Tent Waterproof",
                    Description = "Spacious camping tent with waterproof design, ideal for outdoor adventures in any weather.",
                    Price = 199.99,
                    ImagePath = "camping_tent_waterproof.jpg",
                    Category = "Outdoors"
                });

                database.Products.Add(new Product
                {
                    Name = "Desktop External Hard Drive",
                    Description = "High-capacity desktop external hard drive for reliable data storage and backup.",
                    Price = 129.99,
                    ImagePath = "external_hard_drive.jpg",
                    Category = "Electronics"
                });

                database.Products.Add(new Product
                {
                    Name = "Natural Bamboo Cutting Board",
                    Description = "Durable and eco-friendly cutting board made from natural bamboo for food preparation.",
                    Price = 24.99,
                    ImagePath = "bamboo_cutting_board.jpg",
                    Category = "Eco-friendly"
                });

                database.Products.Add(new Product
                {
                    Name = "Wireless Earbuds Active Noise Cancelling",
                    Description = "Wireless earbuds with active noise-cancelling technology for immersive audio experience.",
                    Price = 129.99,
                    ImagePath = "wireless_earbuds_active_noise_cancelling.jpg",
                    Category = "Electronics"
                });

                database.Products.Add(new Product
                {
                    Name = "Hydration Backpack",
                    Description = "Lightweight hydration backpack with a built-in water bladder, perfect for hiking and outdoor activities.",
                    Price = 39.99,
                    ImagePath = "hydration_backpack.jpg",
                    Category = "Outdoors"
                });

                database.Products.Add(new Product
                {
                    Name = "Air Purifier HEPA Filter",
                    Description = "High-efficiency air purifier with HEPA filter to remove allergens and pollutants from indoor air.",
                    Price = 149.99,
                    ImagePath = "air_purifier_hepa_filter.jpg",
                    Category = "Electronics"
                });
            }


            database.SaveChanges();
        }
    }
}
