namespace COBieCoach

[<RequireQualifiedAccess>]
module Validate =

    [<RequireQualifiedAccess>]
    module String = 

        [<RequireQualifiedAccess>]
        module Is = 

            /// Validates whether a given string
            /// represents the date/time format
            /// associated with COBie output.
            let dateTime (value: string)  =
                value
                |> Validate.String.Is.nonEmpty
                >>= Validate.String.isPlaceholder
                >>= Validate.String.Length.isLessThanOrEqualTo 19
                >>= Validate.String.matches "^\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}$"
     
            /// Validates whether a given string
            /// represents the date format
            /// associated with COBie output.
            let date (value: string) =
                value
                |> Validate.String.Is.nonEmpty
                >>= Validate.String.isPlaceholder
                >>= Validate.String.Length.isLessThanOrEqualTo 10
                >>= Validate.String.matches "^(\d{2}[-/]){3}(\d{2}|\d{4})$"
     
            /// Validates whether a given string matches
            /// the COBie organization code format.
            let organizationCode (value: string)  =
                value
                |> Validate.String.Is.nonEmpty
                >>= Validate.String.isPlaceholder
                >>= Validate.String.Length.isLessThanOrEqualTo 3
                >>= Validate.String.matches "^\w{3}$"
        
            /// Validates whether a given string
            /// represents a COBie UniClass code. 
            let uniClass (value: string) =
                value
                |> Validate.String.Is.nonEmpty
                >>= Validate.String.isPlaceholder
                >>= Validate.String.Length.isLessThanOrEqualTo 2000
                >>= Validate.String.matches "^[a-zA-Z]{2}_\d{2}(_\d{2}){0,3}\s?[:-]\s?.+$"

            /// Validates whether a given string
            /// represents one of the available 
            /// COBie linear unit options.
            let linearUnits (value: string) =
                let regexOptions =
                    "Decimal Feet" + "|" +
                    "Decimal Inches" + "|" +
                    "Feet and Fractional Inches" + "|" +
                    "Fractional Inches" + "|" +
                    "Meters" + "|" +
                    "Millimeters" + "|" +
                    "Centimeters" + "|" +
                    "Decimeters" + "|" +
                    "Meters and Centimeters"
        
                value
                |> Validate.String.Is.nonEmpty
                >>= Validate.String.isPlaceholder
                >>= Validate.String.Length.isLessThanOrEqualTo 26
                >>= Validate.String.matches $"^({regexOptions})$"
      
            /// Validates whether a given string
            /// represents one of the available 
            /// COBie area measurement options.
            let areaMeasurement (value: string) =       
                value
                |> Validate.String.Is.nonEmpty
                >>= Validate.String.isPlaceholder
                >>= Validate.String.Length.isLessThanOrEqualTo 19
                >>= Validate.String.matches $"^Revit Default Value$"
    
            /// Validates whether a given string
            /// represents one of the available 
            /// COBie area unit options.
            let areaUnits (value: string) =
                let regexOptions =
                    "Square Feet" + "|" +
                    "Square Inches" + "|" +
                    "Square Meters" + "|" +
                    "Square Centimeters" + "|" +
                    "Square Millimeters" + "|" +
                    "Acres" + "|" +
                    "Hectares"
        
                value
                |> Validate.String.Is.nonEmpty
                >>= Validate.String.isPlaceholder
                >>= Validate.String.Length.isLessThanOrEqualTo 18
                >>= Validate.String.matches $"^({regexOptions})$"
     
            /// Validates whether a given string
            /// represents one of the available 
            /// COBie volume unit options.
            let volumeUnits (value: string) =
                let regexOptions =
                    "Cubic Yards" + "|" +
                    "Cubic Feet" + "|" +
                    "Cubic Inches" + "|" +
                    "Cubic Meters" + "|" +
                    "Cubic Centimeters" + "|" +
                    "Cubic Millimeters" + "|" +
                    "Liters" + "|" +
                    "US Gallons"
        
                value
                |> Validate.String.Is.nonEmpty
                >>= Validate.String.isPlaceholder
                >>= Validate.String.Length.isLessThanOrEqualTo 17
                >>= Validate.String.matches $"^({regexOptions})$"

            /// Validates whether a given string
            /// represents one of the available 
            /// COBie zone category options.
            let zoneCategory (value: string) =
                let regexOptions =
                    "Circulation Zone" + "|" +
                    "Fire Alarm Zone" + "|" +
                    "Historical Preservation Zone" + "|" +
                    "Lighting Zone" + "|" +
                    "Occupancy Zone" + "|" +
                    "Ventilation Zone"
            
                value
                |> Validate.String.Is.nonEmpty
                >>= Validate.String.isPlaceholder
                >>= Validate.String.Length.isLessThanOrEqualTo 28
                >>= Validate.String.matches $"^({regexOptions})$"
     
            /// Validates whether a given string
            /// represents one of the available 
            /// COBie asset type options.
            let assetType (value: string) =
                value
                |> Validate.String.Is.nonEmpty
                >>= Validate.String.isPlaceholder
                >>= Validate.String.Length.isLessThanOrEqualTo 28
                >>= Validate.String.matches "^(FIXED|MOVABLE)$"
        
            /// Validates whether a given string
            /// represents one of the available 
            /// COBie duration unit options.
            let durationUnit (value: string) =
                let regexOptions =
                    "Days?" + "|" +
                    "Hours?" + "|" +
                    "Minutes?" + "|" +
                    "Weeks?" + "|" +
                    "Months?" + "|" +
                    "Years?"
            
                value
                |> Validate.String.Is.nonEmpty
                >>= Validate.String.isPlaceholder
                >>= Validate.String.Length.isLessThanOrEqualTo 7
                >>= Validate.String.matches $"^({regexOptions})$"
        
            /// Validates whether a given string
            /// represents one of the available 
            /// COBie currency options.
            let currency (value: string) =
                value
                |> Validate.String.Is.nonEmpty
                >>= Validate.String.isPlaceholder
                >>= Validate.String.Length.isEqualTo 3
                >>= Validate.String.matches "^(GBP|EUR|USD)$"