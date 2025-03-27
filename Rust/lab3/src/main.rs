// Function to check if a given price is even
fn is_price_even(price: u32) -> bool {
    price % 2 == 0
}

// Function to calculate the discount based on the price
fn calculate_discount(price: u32) -> u32 {
    // Define a constant for the discount applied to even and odd prices
    const EVEN_DISCOUNT: u32 = 10;
    const ODD_DISCOUNT: u32 = 3;

    // If the price is less than 10 and even, or less than 3 and odd, no discount is applied
    if price < 10 && is_price_even(price) || price < 3 && !is_price_even(price) {
        return 0;
    }

    // If the price is even, subtract 10 as the discount
    if is_price_even(price) {
        price - EVEN_DISCOUNT
    } else {
        // If the price is odd, subtract 3 as the discount
        price - ODD_DISCOUNT
    }
}

fn main() {
    // Example price
    let price = 34;

    // Print the price after applying the discount
    println!("Price after discount: {}", calculate_discount(price));
}
