namespace COBieCoach

open COBieCoachScan
open COBieCoachError
open System.Text.RegularExpressions


[<RequireQualifiedAccess>]
module Validate = 

    [<RequireQualifiedAccess>]
    module String =
    
        /// Regex to replace all whitespace characters.
        let removeWhiteSpace (s: string): string =
            Regex.Replace(s, "\s+", "")

        /// Removes all whitespace at end of string.
        let trimEnd (s: string): string = 
            s.TrimEnd ()
        
        /// Validates whether a given string is 
        /// either null or entirely whitespace.
        let isNullOrWhiteSpace (s: string): ScanResult<_> =
            match System.String.IsNullOrWhiteSpace s with
            | true -> Error (Error.create NullOrWhitespace "Value is null or whitespace." s)
            | false -> Ok s
       
        /// Validates whether a given string is one of
        /// a predefined set of placeholder values. 
        /// Placeholders typically suggest that the 
        /// end user has entered a nonsensical value
        /// in order to proceed with their deliverables.
        let isPlaceholder (s: string): ScanResult<_> =
            match Regex.IsMatch (s, "^(?i)n/a|tbc|tba$") with
            | true -> Error (Error.create Placeholder "Placeholder value provided." s)
            | false -> Ok s
    
        /// Validates whether a string matches a regex.
        let matches (regex: string) (s: string): ScanResult<_> =
            match Regex.IsMatch (s, regex) with
            | true -> Ok s
            | false -> Error (Error.create InvalidFormat "Format is invalid." s)
                           
        [<RequireQualifiedAccess>]
        module Length = 
        
            /// Validates whether a string length is
            /// less than a given value.
            let isLessThan (n: int) (s: string): ScanResult<_> =                
                if s.Length < n
                then Ok s 
                else Error (Error.create InvalidLength $"Length greater than or equal to %d{n}." s)    

            /// Validates whether a string length is
            /// less than or equal to a given value.
            let isLessThanOrEqualTo (n: int) (s: string): ScanResult<_> =                
                if s.Length <= n
                then Ok s 
                else Error (Error.create InvalidLength $"Length greater than %d{n}." s)

            /// Validates whether a string length is
            /// equal to a given value.
            let isEqualTo (n: int) (s: string): ScanResult<_> =                
                if s.Length = n
                then Ok s 
                else Error (Error.create InvalidLength $"Length not equal to %d{n}." s)
           
            /// Validates whether a string length is
            /// greater than a given value.
            let isGreaterThan (n: int) (s: string): ScanResult<_> =
                if s.Length > n
                then Ok s
                else Error (Error.create InvalidLength $"Length less than or equal to %d{n}." s)

        [<RequireQualifiedAccess>]
        module Is = 

            /// Validates whether a given string 
            /// is null, whitespace or starts/ends
            /// with a non-word character (e.g. 
            /// whitespace or escape character).
            let nonEmpty (value: string): ScanResult<_> =
                value
                |> trimEnd
                |> isNullOrWhiteSpace
                >>= matches "^(\S|\S.*\S)$"
    
            /// Validates whether a given string 
            /// represents a typical Western 
            /// email address format.
            let emailAddress (value: string): ScanResult<_> =
                value
                |> nonEmpty
                >>= isPlaceholder
                >>= Length.isLessThanOrEqualTo 254
                >>= matches "^\w[-\.\w]*\w@\w[-\w]*\.([a-z]|[a-z]\.[a-z])+\s*$"
    
            /// Validates whether a given string
            /// represents a typical Western 
            /// phone number format. International
            /// dialing codes are acceptable.
            let phoneNumber (value: string): ScanResult<_>  =
                value
                |> removeWhiteSpace
                |> nonEmpty
                >>= isPlaceholder
                >>= Length.isLessThanOrEqualTo 16
                >>= matches "^\d{11}|\(\+\d{2}\)\d{10,11}|\+\d{2}\(0\)\d{10}|\+\d{2}\d{10}$"  

            /// Validates whether a given string 
            /// represents a standard GUID.
            let guid (value: string): ScanResult<_>  =
                value
                |> nonEmpty
                >>= isPlaceholder
                >>= Length.isLessThanOrEqualTo 38
                >>= matches "^[({]?[a-fA-F0-9]{8}[-]?([a-fA-F0-9]{4}[-]?){3}[a-fA-F0-9]{12}[})]?$"

            /// Validates whether a given string
            /// represents a typical Western PO Box.
            let POBox (value: string): ScanResult<_> = 
                value
                |> nonEmpty
                >>= isPlaceholder
                >>= Length.isLessThanOrEqualTo 12
                >>= matches "^PO\s+(?i)BOX\s+\d{2,5}$"

            /// Validates whether a given string
            /// can represent a 'real' number, 
            /// i.e. be positive/negative and 
            /// optionally contain a decimal point.
            let realNumber (value: string): ScanResult<_> =
                value
                |> nonEmpty
                >>= isPlaceholder
                >>= Length.isLessThanOrEqualTo 100
                >>= matches "^[+-]?\s?\d+(.\d+)?$"

            /// Validates whether a given string
            /// can represent a positive number.
            let positiveNumber (value: string): ScanResult<_> =
                value
                |> nonEmpty
                >>= isPlaceholder
                >>= Length.isLessThanOrEqualTo 100
                >>= matches "^\d+(.\d+)?$"