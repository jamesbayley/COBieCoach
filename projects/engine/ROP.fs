namespace COBieCoach

[<AutoOpen>]
module ROP =
    
    /// Higher order function to be used for connecting functions 
    /// where the input and output contain Result types.
    let bind f x =
        match x with
        | Ok value -> f value
        | Error e -> Error e
        
    /// Operator overload to make the bind function more idiomatic.
    let (>>=) x f =
        bind f x 

    let (>>>) (f: 'T -> Result<'T, 'U>) (g: 'T -> Result<'T, 'U>) (x: 'T) = 
        match f x with 
        | Ok value -> g x 
        | Error e -> Error e
        