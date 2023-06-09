namespace COBieCoach.Error

/// The various error categories that can be
/// produced following the application of 
/// validator functions to data.
type ErrorClass =
    | InvalidFormat
    | InvalidLength
    | NullOrWhitespace
    | Placeholder
    | CrossReferenceFailure
    
    override self.ToString () =
        match self with
        | InvalidFormat _           ->  "Invalid Format"
        | InvalidLength _           ->  "Invalid Length"
        | NullOrWhitespace _        ->  "Null or Whitespace"
        | Placeholder _             ->  "Placeholder"
        | CrossReferenceFailure _   ->  "Cross-Reference Failure"

/// Details the specific error identified.
/// The erroneous value is stored alongside a
/// user-friendly message and error category.
type Error<'TErrorValue> =
    {
        Category    :   ErrorClass
        Message     :   string
        Value       :   'TErrorValue
    }

    /// Instantiates a fully initialized Error object.
    static member create errorClass errorMessage (errorValue: 'TErrorValue) =
        {
            Value = errorValue
            Message = errorMessage
            Category = errorClass
        }