// This function takes an integer as input and returns its square
fn square_num(num: i32) -> i32 {
    num * num // Multiply the number by itself
}

fn main() {
    // Declare a variable `num` and assign it the value 3
    let num: i32 = 3;

    // Call the `square_num` function to calculate the square of `num`
    let num_squared: i32 = square_num(num);

    // Print the result to the console
    println!("The number {} squared is {}", num, num_squared);
}
