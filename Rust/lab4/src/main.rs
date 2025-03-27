use std::f64::consts::PI;

// Define an enum to represent the possible colours of a circle
enum Colour {
    Black,
    White,
    Blue,
}

// Define a struct to represent a circle with a radius, origin (x, y), and colour
struct Circle {
    radius: f64,
    origin: (f64, f64), // The (x, y) coordinates of the circle's center
    colour: Colour,     // The colour of the circle
}

impl Circle {
    // Method to move the circle by adding the given (x, y) values to its current origin
    fn move_circle(&mut self, x: f64, y: f64) {
        self.origin.0 += x; // Update the x-coordinate
        self.origin.1 += y; // Update the y-coordinate
    }

    // Method to calculate the area of the circle using the formula: π * radius^2
    fn area(&self) -> f64 {
        PI * self.radius * self.radius
    }
}

fn main() {
    // Create a new circle with a radius of 5.0, origin at (0.0, 0.0), and colour Blue
    let mut circle = Circle {
        radius: 5.0,
        origin: (0.0, 0.0),
        colour: Colour::Blue,
    };

    // Print the initial state of the circle (its origin and radius)
    println!("Initial Circle: Origin = {:?}, Radius = {}", circle.origin, circle.radius);

    // Move the circle by (3.0, 4.0) and print its new origin
    circle.move_circle(3.0, 4.0);
    println!("Moved Circle: Origin = {:?}", circle.origin);

    // Calculate and print the area of the circle, formatted to 2 decimal places
    println!("Area of Circle: {:.2}", circle.area());
}
