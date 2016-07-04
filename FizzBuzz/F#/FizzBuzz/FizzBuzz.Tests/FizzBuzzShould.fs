namespace FizzBuzz.Tests

open Xunit
open FizzBuzz
    
type FizzBuzzShould() = 
    
    [<Fact>]
    let ``Convert 1 to '1'``() =
        let convertedNumber = FizzBuzzConverter.Convert(1)
        Assert.Equal(convertedNumber, "1")
        
    [<Fact>]
    let ``Convert 2 to '2'``() =
        let convertedNumber = FizzBuzzConverter.Convert(2)
        Assert.Equal(convertedNumber, "2")

    [<Fact>]
    let ``Convert 3 to 'Fizz'``() =
        let convertedNumber = FizzBuzzConverter.Convert(3)
        Assert.Equal(convertedNumber, "Fizz")